namespace StockCore.DomainEntity
{
    public interface IJoinKeyField<T>
    {
        T JoinKey { get; }
    }
}