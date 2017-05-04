using System.Collections.Generic;
using System.Threading.Tasks;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;

namespace StockCore.Business.Operation.Sync
{
    public class SyncAllData<T> : BaseSyncData<T>,IOperation<IEnumerable<T>> where T:IPersistant,ILinqCriteria<T>
    {
        public SyncAllData(IGetByKeyRepo<T,string> repo, bool inCludeRemove=false):base(repo,inCludeRemove){}
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