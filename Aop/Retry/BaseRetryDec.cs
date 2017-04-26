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
            await baseDecOperateAsync(
                validateAsync:async()=>await shouldRetryAsync(key,operationName),
                processAsync:async()=>{
                    await processAsync();
                    await saveStateAsync(key,true,operationName);
                },
                invalidProcess:()=>logger.TraceMessage(module.Key,key,msg:$"No retry.",showParams:true),
                processFailAsync:async(ex)=> {
                    await saveStateAsync(key,false,operationName);
                    processFail(ex,processErrorID,key);
                },
                finalProcessFail:(e)=>processFail(e,outerErrorID,key)
            );
        }
        private void processFail(Exception ex,int errorID,string key)
        {
            var e = new StockCoreException(errorID,ex,$"[{key}]",null);
            throw e;//It will be manage by monitoring decorator
        }
        private async Task<bool> shouldRetryAsync(string key,OperationName operationName)
        {
            var items = await operationStateRepo.GetByKeyAsync(key);
            var selectedItems = from i in items where 
                i.OperationName==operationName && 
                i.OperationState==true &&
                i.Date == DateTime.Now.Date
                select i;
            return !selectedItems.Any();
        }

        private async Task saveStateAsync(string key,bool state,OperationName operationName)
        {
            var items = await operationStateRepo.GetByKeyAsync(key);
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