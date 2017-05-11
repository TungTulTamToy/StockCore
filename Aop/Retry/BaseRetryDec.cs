using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo.MongoDB;
using StockCore.DomainEntity;
using StockCore.Extension;
using static StockCore.DomainEntity.Enum.StateOperation;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StockCore.Helper;

namespace StockCore.Aop.Retry
{
    public class BaseRetryDec : BaseDec
    {
        private readonly IGetByKeyRepo<OperationState,string> operationStateRepo;
        private readonly IKeyModule module;
        private readonly int processErrorID;
        private readonly ILogger logger;
        private readonly int outerErrorID;
        private readonly OperationName operationName;
        public BaseRetryDec(
            OperationName operationName,
            IGetByKeyRepo<OperationState,string> operationStateRepo,            
            IKeyModule module,
            int outerErrorID,
            int processErrorID,            
            ILogger logger
            )
        {
            this.operationName = operationName;
            this.module = module;
            this.operationStateRepo = operationStateRepo;
            this.processErrorID = processErrorID;   
            this.outerErrorID = outerErrorID;
            this.logger = logger;
        }
        protected async Task baseRetryDecOperateAsync(
            Func<string,string,string> getKey,
            Func<Task> innerProcessAsync,
            [CallerMemberName]string methodName="")
        {
            IEnumerable<OperationState> items = null;
            string key = "";
            await baseDecOperateAsync(
                validateAsync:async()=>{
                    key = getKey(module.Key,methodName);
                    items = await operationStateRepo.GetByKeyAsync(key);
                    return shouldRetryAsync(items,key,operationName);
                },
                processAsync:async()=>{
                    await innerProcessAsync();
                    await saveStateAsync(items,key,true,operationName);
                },
                invalidProcess:()=>logger.TraceMessage(module.Key,$"[{key}] No retry."),
                processFailAsync:async(ex)=> {
                    await saveStateAsync(items,key,false,operationName);
                    ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName,info:$"Key:[{key}]");
                },
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName,info:$"Key:[{key}]")
            );
        }
        private bool shouldRetryAsync(IEnumerable<OperationState> items,string key,OperationName operationName)
        {
            var selectedItems = from i in items where 
                i.OperationName==operationName && 
                i.Activated==true &&
                i.Date == DateTime.Now.Date
                select i;
            return !selectedItems.Any();
        }

        private async Task saveStateAsync(IEnumerable<OperationState> items,string key,bool state,OperationName operationName)
        {
            await deleteIfAny(items, operationName);
            await add(key, state);
        }
        private async Task add(string key, bool state)
        {
            var newItem = new OperationState()
            {
                Quote = key,
                Date = DateTime.Now.Date,
                Activated = state,
                OperationName = OperationName.RetrySyncQuoteDec
            };
            await operationStateRepo.InsertAsync(newItem);
        }
        private async Task deleteIfAny(IEnumerable<OperationState> items, OperationName operationName)
        {
            var selectedItems = from i in items where i.OperationName == operationName select i;
            if (selectedItems.Any())
            {
                await operationStateRepo.BatchDeleteAsync(selectedItems);
            }
        }
    }
}