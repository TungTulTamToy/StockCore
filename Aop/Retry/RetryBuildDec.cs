using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Operation;
using StockCore.DomainEntity;
using StockCore.Business.Builder;
using static StockCore.DomainEntity.Enum.StateOperation;

namespace StockCore.Aop.Retry
{
    public class RetryBuildDec<TInput,TResult> : BaseRetryDec,IBuilder<TInput,TResult> where TInput:class where TResult:class
    {
        private readonly IBuilder<TInput,TResult> inner; 
        private readonly Func<string,string,TInput, string> getKey;
        public RetryBuildDec(
            IBuilder<TInput,TResult>inner,
            Func<string,string,TInput,string> getKey,
            OperationName operationName,
            IGetByKeyRepo<OperationState,string> operationStateRepo,            
            StockCore.DomainEntity.RetryModule module,
            int outerErrorID,
            int processErrorID,            
            ILogger logger):base(operationName,operationStateRepo,module,outerErrorID,processErrorID,logger)
        {
            this.inner = inner;              
            this.getKey = getKey;   
        }

        public async Task<TResult> BuildAsync(TInput param)
        {
            TResult item = default(TResult);
            await baseRetryDecOperateAsync(
                (moduleName,methodName)=>getKey(moduleName,methodName,param),
                async()=>await inner.BuildAsync(param)
            );
            return item;
        }
    }
}