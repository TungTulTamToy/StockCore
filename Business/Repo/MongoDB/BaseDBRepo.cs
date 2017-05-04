using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockCore.DomainEntity;
using StockCore.Provider;
using StockCore.Wrapper;

namespace StockCore.Business.Repo.MongoDB
{
    public class BaseAllDBRepo<T> : IRepo<T> where T:IPersistant
    {
        private const string ID = "Id";
        private readonly string collectionName;
        private readonly IConfigProvider config;
        private readonly IMongoDatabaseWrapper db;
        private readonly IFilterDefinitionBuilderWrapper filterBuilder;
        private readonly IReplaceOneModelBuilder replaceOneModelBuilder;
        private readonly IDeleteOneModelBuilder deleteOneModelBuilder;
        protected IMongoCollectionWrapper<T> collection => db.GetCollection<T>(collectionName);
        public BaseAllDBRepo(
            IConfigProvider config, 
            IMongoDatabaseWrapper db, 
            IFilterDefinitionBuilderWrapper filterBuilder,
            IReplaceOneModelBuilder replaceOneModelBuilder,  
            IDeleteOneModelBuilder deleteOneModelBuilder,
            string collectionName)
        {
            this.collectionName = collectionName;
            this.config = config;
            this.db =db;
            this.filterBuilder = filterBuilder;
            this.replaceOneModelBuilder = replaceOneModelBuilder;
            this.deleteOneModelBuilder = deleteOneModelBuilder;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await collection.ToListAsync(_=>true);
        }
        public async Task InsertAsync(T item)
        {
            await collection.InsertOneAsync(stampInsertItem(item));
        }
        public async Task BatchInsertAsync(IEnumerable<T> items)
        {
            var stampItems = items.Select(i=>stampInsertItem(i));
            await collection.InsertManyAsync(stampItems);
        }
        public async Task UpdateAsync(T item)
        {
            var filter = filterBuilder.Build<T>(ID, item.Id);
            item = stampUpdateItem(item);
            await collection.ReplaceOneAsync(filter,item);
        }
        public async Task BatchUpdateAsync(IEnumerable<T> items)
        {
            var updates = items.Select(d => replaceOneModelBuilder.Build(ID,d.Id,stampUpdateItem(d)));
            await collection.BulkWriteAsync(updates);
        }
        public async Task DeleteAsync(T item)
        {
            var filter = filterBuilder.Build<T>(ID, item.Id);
            await collection.DeleteOneAsync(filter);
        }
        public async Task BatchDeleteAsync(IEnumerable<T> items)
        {
            var deletes = items.Select(d => deleteOneModelBuilder.Build<T>(ID,d.Id));
            await collection.BulkWriteAsync(deletes);
        }
        private T stampInsertItem(T item)
        {
            item.CreatedOn = DateTime.Now;
            item.CreateBy = config.MongoDBUserName;
            return item;
        }
        private T stampUpdateItem(T item)
        {
            item.UpdatedOn = DateTime.Now;
            item.UpdateBy = config.MongoDBUserName;
            return item;
        }
    }
}