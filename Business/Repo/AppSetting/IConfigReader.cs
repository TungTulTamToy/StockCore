using System.Collections.Generic;
using StockCore.DomainEntity;

namespace StockCore.Business.Repo.AppSetting
{
    public interface IConfigReader<T>
    {
        T GetByKey(string key);
        bool ContainsKey(string key);
        IEnumerable<string> GetAllKeys();
    }
}