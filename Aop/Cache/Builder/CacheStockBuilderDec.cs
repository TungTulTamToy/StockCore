using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Builder;
using StockCore.Business.Repo.MongoDB;
using StockCore.DomainEntity;
using StockCore.Extension;

namespace StockCore.Aop.Cache.Builder
{
    public class CacheStockBuilderDec<T>:BaseCacheDec<T>,IBuilder<string, T> where T:BaseDE
    {
        private readonly IBuilder<string, T> inner; 
        public CacheStockBuilderDec(
            IBuilder<string, T> inner,
            IGetByFuncRepo<string,CacheDE<T>> cacheRepo,            
            CacheModule module,
            int processErrorID,            
            int outerErrorID,
            ILogger logger,
            Tracer tracer
            ):base(cacheRepo,module,processErrorID,outerErrorID,logger,tracer)
        {
            this.inner = inner;     
        }

        public async Task<T> BuildAsync(string quote)
        {
            var item = await operateCacheAsync(
                getKeyByString(quote),
                async()=>await inner.BuildAsync(quote)
            );
            return item;
        }
    }
}