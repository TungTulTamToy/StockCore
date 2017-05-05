using StockCore.DomainEntity;

namespace StockCore.Business.Repo.AppSetting
{
    public interface IConfigReader
    {
        Module GetByKey(string key);
    }
}