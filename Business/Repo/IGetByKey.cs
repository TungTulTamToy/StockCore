using System.Threading.Tasks;

namespace StockCore.Business.Repo
{
    public interface IGetByKey<TReturn, TKey> where TReturn:class where TKey:class
    {
        Task<TReturn> GetByKeyAsync(TKey key);
    }
}