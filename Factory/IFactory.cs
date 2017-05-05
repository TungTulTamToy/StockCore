using System;
using StockCore.Aop.Mon;

namespace StockCore.Factory
{
    public interface IFactory<TIn,TOut>:IDisposable where TIn:class where TOut:class
    {
        TOut Build(Tracer tracer,TIn t=default(TIn));
    }
}