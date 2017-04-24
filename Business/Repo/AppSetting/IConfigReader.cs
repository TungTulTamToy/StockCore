using StockCore.DomainEntity;

namespace StockCore.Business.Repo.AppSetting
{
    public interface IConfigReader
    {
        ModuleDE GetByKey(string key);
    }
}