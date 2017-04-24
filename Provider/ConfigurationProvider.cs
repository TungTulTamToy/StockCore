using Microsoft.Extensions.Configuration;
using StockCore.DomainEntity;

namespace StockCore.Provider
{
    public class ConfigurationProvider:IConfigProvider
    {
        private IConfigurationRoot configurationRoot;
        public ConfigurationProvider(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }
        public string MongoDBDatabase => configurationRoot.GetSection("MongoConnection:Database").Value;

        private string mongoDBUserName;
        public string MongoDBUserName
        {
            get
            {
                if(mongoDBUserName==null)
                {
                    mongoDBUserName = configurationRoot.GetSection("MongoConnection:UserName").Value;
                }
                return mongoDBUserName;                
            }
        }
        public Monitoring MonitoringModule => configurationRoot.GetSection("ModuleRepo:Monitoring").Get<Monitoring>();
    }
}