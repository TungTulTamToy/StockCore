using System.Threading.Tasks;

namespace StockCore.Business.Builder
{
    public interface IBuilder<TInput,TResult> where TInput:class where TResult:class
    {
        Task<TResult> BuildAsync(TInput t=default(TInput));
    }
}