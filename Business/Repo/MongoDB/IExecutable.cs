using System.Collections.Generic;
using System.Threading.Tasks;
using StockCore.DomainEntity;

namespace StockCore.Business.Repo.MongoDB
{
    public interface IExecutable<T> where T:IBaseDE
    {
        Task InsertAsync(T item);
        Task BatchInsertAsync(IEnumerable<T> items);
        Task UpdateAsync(T item);
        Task BatchUpdateAsync(IEnumerable<T> items);
        Task DeleteAsync(T item);
        Task BatchDeleteAsync(IEnumerable<T> items);
    }
}