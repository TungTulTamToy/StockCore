using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Builder;
using StockCore.Business.Repo.MongoDB;
using StockCore.DomainEntity;

namespace StockCore.Aop.Cache
{
    public class CacheBuilderDec<TInput,TResult>:BaseCacheDec<TResult>,IBuilder<TInput, TResult> where TInput:class
    {
        private readonly IBuilder<TInput, TResult> inner; 
        private readonly Func<string,string,TInput, string> getKey;
        public CacheBuilderDec(
            IBuilder<TInput, TResult> inner,
            Func<string,string,TInput,string> getKey,
            IGetByFuncRepo<string,StockCoreCache<TResult>> cacheRepo,            
            CacheModule module,
            int processErrorID,            
            int outerErrorID,
            ILogger logger
            ):base(cacheRepo:cacheRepo,module:module,processErrorID:processErrorID,outerErrorID:outerErrorID,logger:logger)
        {
            this.inner = inner;  
            this.getKey = getKey;   
        }

        public TResult Build(TInput t = null)
        {
            throw new NotImplementedException();
        }

        public async Task<TResult> BuildAsync(TInput param)
        {
            var item = await baseCacheDecOperateAsync(
                getKey:(moduleName,methodName)=>getKey(moduleName,methodName,param),
                buildInnerAsync:async()=>await inner.BuildAsync(param)
            );
            return item;
        }
    }
}