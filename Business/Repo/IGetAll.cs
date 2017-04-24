using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockCore.Business.Repo
{
    public interface IGetAll<TReturn> where TReturn:class
    {
        Task<IEnumerable<TReturn>> GetAllAsync();
    }
}