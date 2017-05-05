using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace StockCore.Wrapper
{
    public interface IMongoCollectionWrapper<T>
    {
        Task<List<T>> ToListAsync(Expression<Func<T, bool>> filter);
        Task<T> FirstOrDefaultAsync(FilterDefinition<T> filter);
        Task InsertManyAsync(IEnumerable<T> items);
        Task<ReplaceOneResult> ReplaceOneAsync(FilterDefinition<T> filter, T replacement);
        Task<BulkWriteResult<T>> BulkWriteAsync(IEnumerable<WriteModel<T>> requests);
        Task<DeleteResult> DeleteOneAsync(FilterDefinition<T> filter);
        Task InsertOneAsync(T item);
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
}