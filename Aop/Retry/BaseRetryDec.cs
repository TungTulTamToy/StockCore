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
                determinePathAsync:async()=>{
                    key = getKey(module.Key,methodName);
                    items = await operationStateRepo.GetByKeyAsync(key);
                    return shouldRetryAsync(items,operationName);
                },
                processMainPathAsync:async()=>{
                    await innerProcessAsync();
                    await saveStateAsync(items,key,true,operationName);
                },
                processAlternativePath:()=>logger.TraceMessage(module.Key,$"[{key}] No retry."),
                catchBlockProcessAsync:async(ex)=> {
                    await saveStateAsync(items,key,false,operationName);
                    ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName,info:$"Key:[{key}]");
                },
                unexpectedCatchBlockProcess:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName,info:$"Key:[{key}]")
            );
        }
        private bool shouldRetryAsync(IEnumerable<OperationState> items,OperationName operationName)
        {
            var selectedItems = from i in items where 
                i.OperationName==operationName && 
                i.Activated==true &&
                i.ExpiredDate > DateTime.Now
                select i;
            return !selectedItems.Any();
        }

        private async Task saveStateAsync(IEnumerable<OperationState> items,string key,bool state,OperationName operationName)
        {
            await deleteIfAny(items, operationName);
            await add(key, state, operationName);
        }
        private async Task add(string key, bool state, OperationName operationName)
        {
            var newItem = new OperationState()
            {
                Quote = key,
                ExpiredDate = DateTime.Now.AddMinutes(60),
                Activated = state,
                OperationName = operationName
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