using StockCore.DomainEntity;

namespace StockCore.Factory
{
    public interface IFactory<TIn,TOut> where TIn:class where TOut:class
    {
        TOut Build(Tracer tracer,TIn t=default(TIn));
    }
}