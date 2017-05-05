using System.Collections.Generic;
using System.Threading.Tasks;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using System.Linq;

namespace StockCore.Business.Operation.Sync
{
    public class SyncDataByKey<TKey,T> : BaseSyncData<T>,IOperation<IEnumerable<T>> where TKey: class where T:IPersistant,IKeyField<TKey>,ILinqCriteria<T>
    {
        public SyncDataByKey(IGetByKeyRepo<T,TKey> repo, bool inCludeUpdate=true, bool inCludeRemove=false):base(repo,inCludeUpdate,inCludeRemove){}
        public async Task OperateAsync(IEnumerable<T> source)
        {
            var keys = source.GroupBy(item=>item.Key).Select(i=>i.First().Key);
            var tasks = keys.Select(async key=>
            {
                var dbItems = await ((IGetByKeyRepo<T,TKey>)repo).GetByKeyAsync(key);
                var itemsPerKey = source.Where(item=>item.Key==key);
                var syncEntity = new SyncEntity<T>()
                {
                    source = itemsPerKey,
                    destination = dbItems
                };
                await base.OperateAsync(syncEntity);
            });
            await Task.WhenAll(tasks);
        }
    }   
}   