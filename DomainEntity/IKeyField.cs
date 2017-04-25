namespace StockCore.DomainEntity
{
    public interface IKeyField<T> where T:class
    {
        T Key { get; set;}
    }
}