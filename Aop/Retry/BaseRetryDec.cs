using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Factory;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Worker;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.DomainEntity.Enum;
using StockCore.Aop.Mon;
using static StockCore.DomainEntity.Enum.StateOperation;
using System.Collections.Generic;

namespace StockCore.Aop.Retry.Worker
{
    public class BaseRetryDec : BaseDec
    {
        private readonly IGetByKeyRepo<OperationStateDE,string> operationStateRepo;
        private readonly StockCore.DomainEntity.RetryModule module;
        private readonly int processErrorID;
        private readonly ILogger logger;
        private readonly int outerErrorID;
        public BaseRetryDec(
            IGetByKeyRepo<OperationStateDE,string> operationStateRepo,            
            StockCore.DomainEntity.RetryModule module,
            int outerErrorID,
            int processErrorID,            
            ILogger logger
            )
        {
            this.module = module;
            this.operationStateRepo = operationStateRepo;
            this.processErrorID = processErrorID;   
            this.outerErrorID = outerErrorID;
            this.logger = logger;
        }
        protected async Task baseRetryDecOperateAsync(
            string key,
            Func<Task> processAsync,
            OperationName operationName)
        {
            IEnumerable<OperationStateDE> items = null;
            await baseDecOperateAsync(
                validateAsync:async()=>{
                    items = await operationStateRepo.GetByKeyAsync(key);
                    return shouldRetryAsync(items,key,operationName);
                },
                processAsync:async()=>{
                    await processAsync();
                    await saveStateAsync(items,key,true,operationName);
                },
                invalidProcess:()=>logger.TraceMessage(module.Key,key,msg:$"No retry.",showParams:true),
                processFailAsync:async(ex)=> {
                    await saveStateAsync(items,key,false,operationName);
                    baseDecProcessFail(logger,ex,processErrorID,module.Key,$"Key:[{key}]");
                },
                finalProcessFail:(e)=>baseDecProcessFail(logger,e,outerErrorID,module.Key,$"Key:[{key}]")
            );
        }
        private bool shouldRetryAsync(IEnumerable<OperationStateDE> items,string key,OperationName operationName)
        {
            var selectedItems = from i in items where 
                i.OperationName==operationName && 
                i.OperationState==true &&
                i.Date == DateTime.Now.Date
                select i;
            return !selectedItems.Any();
        }

        private async Task saveStateAsync(IEnumerable<OperationStateDE> items,string key,bool state,OperationName operationName)
        {
            var selectedItems = from i in items where i.OperationName==operationName select i;
            if(selectedItems.Any())
            {
                await operationStateRepo.BatchDeleteAsync(selectedItems);
            }
            var newItem = new OperationStateDE()
            {
                Quote=key,
                Date=DateTime.Now.Date,
                OperationState = state,
                OperationName = OperationName.RetrySyncQuoteDec
            };
            await operationStateRepo.InsertAsync(newItem);                
        }
    }
}