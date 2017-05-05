using MongoDB.Driver;
using StockCore.Provider;

namespace StockCore.Wrapper
{
    public interface IMongoDatabaseWrapper
    {
        IMongoCollectionWrapper<T> GetCollection<T>(string name);
    }
    public class MongoDatabaseWrapper : IMongoDatabaseWrapper
    {
        private readonly IMongoClient client;
        private readonly IConfigProvider config;
        public MongoDatabaseWrapper(IMongoClient client, IConfigProvider config)
        {
            this.client = client;
            this.config = config;
        }
        public IMongoCollectionWrapper<T> GetCollection<T>(string name)
        {
            var db = client.GetDatabase(config.MongoDBDatabase);
            return new MongoCollectionWrapper<T>(db.GetCollection<T>(name));
        }
    }
}