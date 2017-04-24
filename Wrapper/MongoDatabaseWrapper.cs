using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using StockCore.Provider;

namespace StockCore.Wrapper
{
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
    public class MongoCollectionWrapper<T> : IMongoCollectionWrapper<T>
    {
        private readonly IMongoCollection<T> collection;
        public MongoCollectionWrapper(IMongoCollection<T> collection)
        {
            this.collection = collection;
        }
        public async Task<BulkWriteResult<T>> BulkWriteAsync(IEnumerable<WriteModel<T>> requests)
        {
            var options = new BulkWriteOptions();
            return await collection.BulkWriteAsync(requests);
        }
        public async Task<DeleteResult> DeleteOneAsync(FilterDefinition<T> filter)
        {
            return await collection.DeleteOneAsync(filter);
        }
        public async Task<T> FirstOrDefaultAsync(FilterDefinition<T> filter)
        {
            return await collection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task InsertManyAsync(IEnumerable<T> items)
        {
            await collection.InsertManyAsync(items);
        }
        public async Task InsertOneAsync(T item)
        {
            await collection.InsertOneAsync(item);
        }
        public async Task<ReplaceOneResult> ReplaceOneAsync(FilterDefinition<T> filter, T replacement)
        {
            return await collection.ReplaceOneAsync(filter,replacement);
        }
        public async Task<List<T>> ToListAsync(Expression<Func<T, bool>> filter)
        {
            return await collection.Find(filter).ToListAsync();
        }
    }
    public class FilterDefinitionBuilderWrapper : IFilterDefinitionBuilderWrapper
    {
        public FilterDefinition<T> Build<T>(string filedName, string value)
        {
            return Builders<T>.Filter.Eq(filedName, value);
        }
    }
    public class ReplaceOneModelBuilder : IReplaceOneModelBuilder
    {
        IFilterDefinitionBuilderWrapper filterBuilder;
        public ReplaceOneModelBuilder(IFilterDefinitionBuilderWrapper filterBuilder)
        {
            this.filterBuilder = filterBuilder;
        }
        public ReplaceOneModel<T> Build<T>(string filedName, string value, T item)
        {
            return new ReplaceOneModel<T>(filterBuilder.Build<T>(filedName, value),item);
        }
    }

    public class DeleteOneModelBuilder : IDeleteOneModelBuilder
    {
        IFilterDefinitionBuilderWrapper filterBuilder;
        public DeleteOneModelBuilder(IFilterDefinitionBuilderWrapper filterBuilder)
        {
            this.filterBuilder = filterBuilder;
        }
        public DeleteOneModel<T> Build<T>(string filedName, string value)
        {
            return new DeleteOneModel<T>(filterBuilder.Build<T>(filedName, value));
        }
    }
}