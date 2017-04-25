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
    public class CacheStockBuilderDec<T>:BaseDec,IBuilder<string, T> where T:BaseDE
    {
        private readonly IBuilder<string, T> inner; 
        protected readonly IGetByFuncRepo<string,CacheDE<T>> cacheRepo;
        private readonly CacheModule module;
        private readonly int processErrorID;
        private readonly Tracer tracer;
        public CacheStockBuilderDec(
            IBuilder<string, T> inner,
            IGetByFuncRepo<string,CacheDE<T>> cacheRepo,            
            CacheModule module,
            int processErrorID,            
            int outerErrorID,
            ILogger logger,
            Tracer tracer
            ):base(outerErrorID,module.Key,logger)
        {
            this.module = module;
            this.cacheRepo = cacheRepo;
            this.inner = inner;     
            this.tracer = tracer;
            this.processErrorID = processErrorID;   
        }

        public async Task<T> BuildAsync(string quote)
        {
            var key = getKey(quote,"BuildAsync");                        
            T stock = null;
            await operateAsync(
                tracer,
                validateAsync:async()=> {
                    stock = await getFromCache(quote,key);
                    return stock != null;
                    },
                invalidProcessAsync: async()=> stock = await createCache(quote,key),
                processFail:(ex)=> processFail(ex,quote)
            );
            return stock;
        }

        private async Task<T> getFromCache(string quote,string key)
        {
            var cache = await cacheRepo.GetByFuncAsync(i=>i.Key==key&&i.ExpireAt>DateTime.Now);
            T item = null;            
            if(cache!=null && cache.Any())
            {
                logger.TraceMessage(module.Key,key,msg:$"Cache hit.",showParams:true);                
                item = cache.First().CacheObject;
            }
            else
            {
                logger.TraceMessage(module.Key,key,msg:$"Cache miss.",showParams:true);    
            }
            return item;
        }
        private async Task<T> createCache(string quote,string key)
        {
            var item = await inner.BuildAsync(quote);

            var cacheDE = new CacheDE<T>(){
                Key=key,
                Group=module.Key,
                CacheObject=item,
                ExpireAt=DateTime.Now.AddMinutes(module.MinuteToExpire)
            };
            await cacheRepo.InsertAsync(cacheDE);
            return item;
        }
        private string getKey(string quote,string methodName)
        {
            return $"{module.Key}_{methodName}_{quote}_v1";
        }
        private void processFail(Exception ex,string quote)
        {
            logger.TraceError(module.Key,processErrorID,msg:quote,ex:ex);
            throw ex;
        }
    }
}