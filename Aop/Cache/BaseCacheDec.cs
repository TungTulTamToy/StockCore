using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo.MongoDB;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.Helper;

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
            Func<Task<T>> buildInnerAsync,
            [CallerMemberName]string methodName=""
            )
        {
            T item = null;
            await baseDecOperateAsync(
                validateAsync:async()=> {
                    item = await getItemFromCacheAsync(key);
                    return item != null;},
                invalidProcessAsync: async()=> {
                    item = await buildInnerAsync();
                    await createCacheAsync(key,item);},
                processFail:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName,info:$"Key:[{key}]"),
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName,info:$"Key:[{key}]")
            );
            return item;
        }
        //TODO:should be helper class
        protected string getKeyByString(string quote,[CallerMemberName]string methodName="")
        {
            return $"{module.Key}_{methodName}_{quote}_v1";
        }
        private async Task<T> getItemFromCacheAsync(string key)
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
        private async Task<T> createCacheAsync(string key,T item)
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