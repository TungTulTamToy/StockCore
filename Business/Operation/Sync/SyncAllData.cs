using System.Collections.Generic;
using System.Threading.Tasks;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;

namespace StockCore.Business.Operation.Sync
{
    public class SyncAllData<T> : BaseSyncData<T>,IOperation<IEnumerable<T>> where T:IPersistant,ILinqCriteria<T>
    {
        public SyncAllData(IRepo<T> repo, bool inCludeUpdate=true, bool inCludeRemove=false):base(repo,inCludeUpdate,inCludeRemove){}
        public async Task OperateAsync(IEnumerable<T> items)
        {
            var dbItems = await repo.GetAllAsync();
        
            var syncEntity = new SyncEntity<T>()
            {
                source = items,
                destination = dbItems
            };

            await base.OperateAsync(syncEntity);
        }
    }   
}   