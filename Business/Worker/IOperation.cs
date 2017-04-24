using System.Threading.Tasks;

namespace StockCore.Business.Worker
{
    public interface IOperation<T>where T:class
    {
        Task OperateAsync(T t);
    }
}