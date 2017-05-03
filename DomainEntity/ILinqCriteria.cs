using System;

namespace StockCore.DomainEntity
{
    public interface ILinqCriteria<T>:IEquatable<T>
    {
        bool UpdateCondition(T other);
        T Merge(T other);
    }
}