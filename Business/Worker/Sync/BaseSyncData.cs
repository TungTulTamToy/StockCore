using System.Collections.Generic;
using System.Threading.Tasks;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;

namespace StockCore.Business.Worker.Sync
{
    public abstract class BaseSyncData<T> : IOperation<IEnumerable<T>> where T:BaseDE
    {
        private readonly IRepo<T> repo;
        public BaseSyncData(IRepo<T> repo)
        {
            this.repo = repo;
        }

        protected abstract IEnumerable<T> calculateItemToInsert (IEnumerable<T> items, IEnumerable<T> dbItems);
        protected abstract IEnumerable<T> calculateItemToUpdate (IEnumerable<T> items, IEnumerable<T> dbItems);
        protected abstract IEnumerable<T> calculateItemToRemove (IEnumerable<T> items, IEnumerable<T> dbItems);
        public async Task OperateAsync(IEnumerable<T> items)
        {
            var dbItems = await repo.GetAllAsync();//Get All
            
            var insertTask = insert(items,dbItems);
            var updateTask = update(items,dbItems);
            var removeTask = remove(items,dbItems);
            
            await insertTask;
            await updateTask;
            await removeTask;
        }
        private async Task insert(IEnumerable<T> items, IEnumerable<T> dbItems)
        {
            var itemToInsert = calculateItemToInsert(items,dbItems);
            await repo.BatchInsertAsync(itemToInsert);
        }
        private async Task update(IEnumerable<T> items, IEnumerable<T> dbItems)
        {
            var itemToUpdate = calculateItemToUpdate(items,dbItems);
            await repo.BatchUpdateAsync(itemToUpdate);   
        }
        private async Task remove(IEnumerable<T> items, IEnumerable<T> dbItems)
        {
            var itemToRemove = calculateItemToRemove(items,dbItems);
            await repo.BatchDeleteAsync(itemToRemove);
        }
    }   
}   