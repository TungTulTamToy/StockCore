using System.Collections.Generic;
using System.Threading.Tasks;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using StockCore.Extension;

namespace StockCore.Business.Operation.Sync
{
    public class BaseSyncData<T> : IOperation<SyncEntity<T>> where T:IPersistant,ILinqCriteria<T>
    {
        protected readonly IRepo<T> repo;
        private readonly bool inCludeUpdate;
        private readonly bool inCludeRemove;
        public BaseSyncData(IRepo<T> repo, bool inCludeUpdate=true, bool inCludeRemove=false)
        {
            this.repo = repo;
            this.inCludeUpdate = inCludeUpdate;
            this.inCludeRemove = inCludeRemove;
        }
        public async Task OperateAsync(SyncEntity<T> items)
        {
            var insertTask = insert(items.source, items.destination);
            var updateTask = update(items.source, items.destination);
            var removeTask = remove(items.source, items.destination);
            await Task.WhenAll(insertTask,updateTask,removeTask);
        }
        private async Task insert(IEnumerable<T> source, IEnumerable<T> destination)
        {
            var itemToInsert = source.GetItemToInsert(destination);
            await repo.BatchInsertAsync(itemToInsert);
        }
        private async Task update(IEnumerable<T> source, IEnumerable<T> destination)
        {
            if(inCludeUpdate)
            {
                var itemToUpdate = source.GetItemToUpdate(destination);
                await repo.BatchUpdateAsync(itemToUpdate);   
            }
        }
        private async Task remove(IEnumerable<T> source, IEnumerable<T> destination)
        {
            if(inCludeRemove)
            {
                var itemToRemove = source.GetItemToDelete(destination);
                await repo.BatchDeleteAsync(itemToRemove);
            }
        }
    }   
}   