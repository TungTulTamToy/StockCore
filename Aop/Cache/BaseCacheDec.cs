using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Aop.Mon;
using StockCore.Business.Repo.MongoDB;
using StockCore.DomainEntity;
using StockCore.Extension;

namespace StockCore.Aop.Cache.Builder
{
    public class BaseCacheDec<T>:BaseDec where T:BaseDE
    {
        private readonly IGetByFuncRepo<string,CacheDE<T>> cacheRepo;
        private readonly CacheModule module;
        private readonly int processErrorID;
        private readonly int outerErrorID;
        private readonly ILogger logger;
        public BaseCacheDec(
            IGetByFuncRepo<string,CacheDE<T>> cacheRepo,        
            CacheModule module,
            int processErrorID,            
            int outerErrorID,
            ILogger logger
            )
        {
            this.module = module;
            this.cacheRepo = cacheRepo;
            this.processErrorID = processErrorID; 
            this.outerErrorID = outerErrorID;
            this.logger=logger; 
        }
        protected async Task<T> baseCacheDecOperateAsync(
            string key,
            Func<Task<T>> buildAsync
            )
        {
            T t = null;
            await baseDecOperateAsync(
                validateAsync:async()=> {
                    t = await getFromCacheAsync(key);
                    return t != null;},
                invalidProcessAsync: async()=> {
                    t = await buildAsync();
                    await createCacheAsync(t,key);},
                processFail:(ex)=>ProcessFail.ComposeAndThrowException(logger,ex,processErrorID,module.Key,info:$"Key:[{key}]"),
                finalProcessFail:(e)=>ProcessFail.ComposeAndThrowException(logger,e,outerErrorID,module.Key,info:$"Key:[{key}]")
            );
            return t;
        }
        //TODO:should be helper class
        protected string getKeyByString(string quote,[CallerMemberName]string methodName="")
        {
            return $"{module.Key}_{methodName}_{quote}_v1";
        }
        private async Task<T> getFromCacheAsync(string key)
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
    }
}