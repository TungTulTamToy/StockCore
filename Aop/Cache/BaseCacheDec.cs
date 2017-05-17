using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo.MongoDB;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.Helper;

namespace StockCore.Aop.Cache
{
    public class BaseCacheDec<T>:BaseDec
    {
        private readonly IGetByFuncRepo<string,StockCoreCache<T>> cacheRepo;
        private readonly CacheModule module;
        private readonly int processErrorID;
        private readonly int outerErrorID;
        private readonly ILogger logger;
        public BaseCacheDec(
            IGetByFuncRepo<string,StockCoreCache<T>> cacheRepo,        
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
            Func<string,string,string> getKey,
            Func<Task<T>> buildInnerAsync,
            [CallerMemberName]string methodName=""
            )
        {
            T item = default(T);
            string key = "";
            await baseDecOperateAsync(
                determinePathAsync:async()=> {
                    key = getKey(module.Key,methodName);
                    item = await getItemFromCacheAsync(key);
                    return item != null;},
                processAlternativePathAsync: async()=> {
                    item = await buildInnerAsync();
                    await createCacheAsync(key,item);},
                catchBlockProcess:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName,info:$"Key:[{key}]"),
                unexpectedCatchBlockProcess:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName,info:$"Key:[{key}]")
            );
            return item;
        }
        private async Task<T> getItemFromCacheAsync(string key)
        {
            var cache = await cacheRepo.GetByFuncAsync(i=>i.Key==key&&i.ExpireAt>DateTime.Now);
            T item = default(T);            
            if(cache!=null && cache.Any())
            {
                logger.TraceMessage(module.Key,$"[{key}] Cache hit.");                
                item = cache.First().CacheObject;
            }
            else
            {
                logger.TraceMessage(module.Key,$"[{key}] Cache miss.");    
            }
            return item;
        }
        private async Task<T> createCacheAsync(string key,T item)
        {
            if(item!=null)
            {
                var cacheDE = new StockCoreCache<T>(){
                    Key=key,
                    Group=module.Key,
                    CacheObject=item,
                    ExpireAt=DateTime.Now.AddMinutes(module.MinuteToExpire)
                };
                await cacheRepo.InsertAsync(cacheDE);
            }
            return item;
        }
    }
}