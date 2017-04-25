using StockCore.DomainEntity;

namespace StockCore.Provider
{
    public interface IConfigProvider
    {
        string MongoDBDatabase{get;}
        string MongoDBUserName{get;}
        MonitoringModule MonitoringModule{get;}
    }
}