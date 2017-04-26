using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Worker;
using StockCore.DomainEntity;
using static StockCore.DomainEntity.Enum.StateOperation;

namespace StockCore.Aop.Retry.Worker
{
    public class RetryOperationDec : BaseRetryDec,IOperation<string>
    {
        private readonly IOperation<string> inner; 
        public RetryOperationDec(
            IOperation<string> inner,
            IGetByKeyRepo<OperationStateDE,string> operationStateRepo,            
            StockCore.DomainEntity.RetryModule module,
            int outerErrorID,
            int processErrorID,            
            ILogger logger):base(operationStateRepo,module,outerErrorID,processErrorID,logger)
        {
            this.inner = inner;                 
        }
        public async Task OperateAsync(string quote)
        {
            await baseRetryDecOperateAsync(
                quote,
                async()=>await inner.OperateAsync(quote),
                OperationName.RetrySyncQuoteDec
            );
        }
    }
}