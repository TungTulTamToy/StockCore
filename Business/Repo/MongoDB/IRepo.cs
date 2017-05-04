using StockCore.DomainEntity;

namespace StockCore.Business.Repo.MongoDB
{
    public interface IRepo<T>:IGetAll<T>,IExecutable<T> where T:IPersistant
    {}
}