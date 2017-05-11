using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Operation;
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
            IGetByKeyRepo<OperationState,string> operationStateRepo,            
            IKeyModule module,
            int outerErrorID,
            int processErrorID,            
            ILogger logger):base(operationName:operationName,operationStateRepo:operationStateRepo,module:module,outerErrorID:outerErrorID,processErrorID:processErrorID,logger:logger)
        {
            this.inner = inner;              
            this.getKey = getKey;   
        }
        public async Task OperateAsync(T param)
        {
            await baseRetryDecOperateAsync(
                getKey:(moduleName,methodName)=>getKey(moduleName,methodName,param),
                innerProcessAsync:async()=>await inner.OperateAsync(param)
            );
        }
    }
}