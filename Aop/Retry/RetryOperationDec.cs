using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Worker;
using StockCore.DomainEntity;
using static StockCore.DomainEntity.Enum.StateOperation;

namespace StockCore.Aop.Retry
{
    public class RetryOperationDec<T> : BaseRetryDec,IOperation<T> where T:class
    {
        private readonly IOperation<T> inner; 
        private readonly Func<string,string,T, string> getKey;
        public RetryOperationDec(
            IOperation<T> inner,
            Func<string,string,T,string> getKey,
            OperationName operationName,
            IGetByKeyRepo<OperationStateDE,string> operationStateRepo,            
            StockCore.DomainEntity.RetryModule module,
            int outerErrorID,
            int processErrorID,            
            ILogger logger):base(operationName,operationStateRepo,module,outerErrorID,processErrorID,logger)
        {
            this.inner = inner;              
            this.getKey = getKey;   
        }
        public async Task OperateAsync(T param)
        {
            await baseRetryDecOperateAsync(
                (moduleName,methodName)=>getKey(moduleName,methodName,param),
                async()=>await inner.OperateAsync(param)
            );
        }
    }
}