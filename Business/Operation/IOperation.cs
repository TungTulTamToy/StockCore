using System.Threading.Tasks;

namespace StockCore.Business.Operation
{
    public interface IOperation<T>where T:class
    {
        Task OperateAsync(T t);
    }
}