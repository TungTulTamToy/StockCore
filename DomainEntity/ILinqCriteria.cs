namespace StockCore.DomainEntity
{
    public interface ILinqCriteria<TKey,T>
    {
        bool UpdateCondition(T other);
        T Merge(T other);
        TKey JoinKey { get; }
    }
}