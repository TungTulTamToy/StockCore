using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace StockCore.Wrapper
{
    public interface IMongoDatabaseWrapper
    {
        IMongoCollectionWrapper<T> GetCollection<T>(string name);
    }
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
    public interface IFilterDefinitionBuilderWrapper
    {
        FilterDefinition<T> Build<T>(string filedName, string value);
    }
    public interface IReplaceOneModelBuilder
    {
        ReplaceOneModel<T> Build<T>(string filedName, string value, T item);
    }

    public interface IDeleteOneModelBuilder
    {
        DeleteOneModel<T> Build<T>(string filedName, string value);
    }
}