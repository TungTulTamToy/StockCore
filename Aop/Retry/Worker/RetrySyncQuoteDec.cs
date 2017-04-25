using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Factory;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Worker;
using StockCore.DomainEntity;
using StockCore.Extension;
using static StockCore.DomainEntity.Enum.StateOperation;
using StockCore.ErrorException;

namespace StockCore.Aop.Retry.Worker
{
    public class RetryOperationDec : BaseDec,IOperation<string>
    {
        private readonly IOperation<string> inner; 
        protected readonly IGetByKeyRepo<OperationStateDE,string> operationStateRepo;
        private readonly StockCore.DomainEntity.RetryModule module;
        private readonly int processErrorID;
        private readonly Tracer tracer;
        public RetryOperationDec(
            IOperation<string> inner,
            IGetByKeyRepo<OperationStateDE,string> operationStateRepo,            
            StockCore.DomainEntity.RetryModule module,
            int outerErrorID,
            ILogger logger,
            Tracer tracer,
            int processErrorID
            ):base(outerErrorID,module.Key,logger)
        {
            this.module = module;
            this.operationStateRepo = operationStateRepo;
            this.inner = inner;     
            this.tracer = tracer;
            this.processErrorID = processErrorID;   
        }
        public async Task OperateAsync(string quote)
        {
            await operateAsync(
                tracer,
                validateAsync:async()=>await shouldRetry(quote),
                processAsync:async()=>await processAsync(quote),
                invalidProcess:()=>logger.TraceMessage(module.Key,quote,msg:$"No retry.",showParams:true),
                processFailAsync:async(ex)=> await processFailAsync(ex,quote)
            );
        }

        private async Task processAsync(string quote)
        {
            await inner.OperateAsync(quote);
            await saveState(quote,true);
        }

        private async Task processFailAsync(Exception ex,string quote)
        {
            logger.TraceError(module.Key,processErrorID,msg:quote,ex:ex);
            await saveState(quote,false);
            var e = new StockCoreException(processErrorID,ex,tracer)
            {
                IsLogged=true
            };
            throw e;
        }

        private async Task<bool> shouldRetry(string quote)
        {
            var items = await operationStateRepo.GetByKeyAsync(quote);
            var selectedItems = from i in items where 
                i.OperationName==OperationName.RetrySyncQuoteDec && 
                i.OperationState==true &&
                i.Date == DateTime.Now.Date
                select i;
            return !selectedItems.Any();
        }

        private async Task saveState(string quote,bool state)
        {
            var items = await operationStateRepo.GetByKeyAsync(quote);
            var selectedItems = from i in items where i.OperationName==OperationName.RetrySyncQuoteDec select i;
            if(selectedItems.Any())
            {
                await operationStateRepo.BatchDeleteAsync(selectedItems);
            }
            var newItem = new OperationStateDE()
            {
                Quote=quote,
                Date=DateTime.Now.Date,
                OperationState = state,
                OperationName = OperationName.RetrySyncQuoteDec
            };
            await operationStateRepo.InsertAsync(newItem);                
        }
    }
}