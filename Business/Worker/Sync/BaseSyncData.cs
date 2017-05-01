using System.Collections.Generic;
using System.Threading.Tasks;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using StockCore.Extension;
using System.Linq;
using System;

namespace StockCore.Business.Worker.Sync
{
    public class BaseSyncData<TKey,T> : IOperation<IEnumerable<T>> where T:BaseDE,ILinqCriteria<TKey,T>
    {
        private readonly IRepo<T> repo;
        private readonly bool inCludeRemove;
        public BaseSyncData(IRepo<T> repo, bool inCludeRemove=false)
        {
            this.repo = repo;
            this.inCludeRemove = inCludeRemove;
        }
        public async Task OperateAsync(IEnumerable<T> items)
        {
            var dbItems = await repo.GetAllAsync();
            
            var insertTask = insert(items,dbItems);
            var updateTask = update(items,dbItems);
            if(inCludeRemove)
            {
                var removeTask = remove(items,dbItems);
                await removeTask;                
            }
            await insertTask;
            await updateTask;
        }
        private async Task insert(IEnumerable<T> items, IEnumerable<T> dbItems)
        {
            var itemToInsert = items.GetItemToInsert<TKey,T>(dbItems);
            await repo.BatchInsertAsync(itemToInsert);
        }
        private async Task update(IEnumerable<T> items, IEnumerable<T> dbItems)
        {
            var itemToUpdate = items.GetItemToUpdate<TKey,T>(dbItems);
            await repo.BatchUpdateAsync(itemToUpdate);   
        }
        private async Task remove(IEnumerable<T> items, IEnumerable<T> dbItems)
        {
            var itemToRemove = items.GetItemToDelete<TKey,T>(dbItems);
            await repo.BatchDeleteAsync(itemToRemove);
        }
    }   
}   