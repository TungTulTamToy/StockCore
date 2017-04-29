using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Builder;
using StockCore.Business.Repo.MongoDB;
using StockCore.DomainEntity;

namespace StockCore.Aop.Cache
{
    public class CacheBuilderDec<TInput,TResult>:BaseCacheDec<TResult>,IBuilder<TInput, TResult> where TInput:class where TResult:BaseDE
    {
        private readonly IBuilder<TInput, TResult> inner; 
        private readonly Func<string,string,TInput, string> getKey;
        public CacheBuilderDec(
            IBuilder<TInput, TResult> inner,
            Func<string,string,TInput,string> getKey,
            IGetByFuncRepo<string,CacheDE<TResult>> cacheRepo,            
            CacheModule module,
            int processErrorID,            
            int outerErrorID,
            ILogger logger
            ):base(cacheRepo,module,processErrorID,outerErrorID,logger)
        {
            this.inner = inner;  
            this.getKey = getKey;   
        }

        public async Task<TResult> BuildAsync(TInput param)
        {
            var item = await baseCacheDecOperateAsync(
                (moduleName,methodName)=>getKey(moduleName,methodName,param),
                async()=>await inner.BuildAsync(param)
            );
            return item;
        }
    }
}