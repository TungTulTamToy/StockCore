using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Builder;
using StockCore.Business.Repo.MongoDB;
using StockCore.DomainEntity;
using StockCore.ErrorException;
using StockCore.Extension;

namespace StockCore.Aop.Cache.Builder
{
    public class BaseCacheDec<T>:BaseDec where T:BaseDE
    {
        protected readonly IGetByFuncRepo<string,CacheDE<T>> cacheRepo;
        private readonly CacheModule module;
        private readonly int processErrorID;
        protected readonly Tracer tracer;
        public BaseCacheDec(
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
            this.tracer = tracer;
            this.processErrorID = processErrorID;   
        }
        protected async Task<T> operateCacheAsync(
            string key,
            Func<Task<T>> buildAsync
            )
        {
            T t = null;
            await operateAsync(
                tracer,
                validateAsync:async()=> {
                    t = await getFromCacheAsync(key);
                    return t != null;
                    },
                invalidProcessAsync: async()=> {
                    t = await buildAsync();
                    await createCacheAsync(t,key);
                    },
                processFail:(ex)=> processFail(ex)
            );
            return t;
        }
        protected async Task<T> getFromCacheAsync(string key)
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
        private async Task<T> createCacheAsync(T item,string key)
        {
            var cacheDE = new CacheDE<T>(){
                Key=key,
                Group=module.Key,
                CacheObject=item,
                ExpireAt=DateTime.Now.AddMinutes(module.MinuteToExpire)
            };
            await cacheRepo.InsertAsync(cacheDE);
            return item;
        }
        protected string getKeyByString(string quote,[CallerMemberName]string methodName="")
        {
            return $"{module.Key}_{methodName}_{quote}_v1";
        }
        private void processFail(Exception ex)
        {
            logger.TraceError(module.Key,processErrorID,ex:ex);
            var e = new StockCoreException(processErrorID,ex,tracer)
            {
                IsLogged=true
            };
            throw e;
        }
    }
}