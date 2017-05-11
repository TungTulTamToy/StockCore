using StockCore.DomainEntity;

namespace StockCore.Business.Repo.AppSetting
{
    public interface IConfigReader<T>
    {
        T GetByKey(string key);
    }
}