using System.Collections.Generic;
using System.Threading.Tasks;
using StockCore.DomainEntity;
using StockCore.Provider;
using StockCore.Wrapper;

namespace StockCore.Business.Repo.MongoDB
{
    public class BaseKeyDBRepo<T> : BaseAllDBRepo<T>, IGetByKeyRepo<T,string> where T:IPersistant,IKeyField<string>
    {
        public BaseKeyDBRepo(
            IConfigProvider config, 
            IMongoDatabaseWrapper db, 
            IFilterDefinitionBuilderWrapper filterBuilder,
            IReplaceOneModelBuilder replaceOneModelBuilder,  
            IDeleteOneModelBuilder deleteOneModelBuilder,
            string collectionName):base(config,db,filterBuilder,replaceOneModelBuilder,deleteOneModelBuilder,collectionName){}
        public async Task<IEnumerable<T>> GetByKeyAsync(string keyName)=>await collection.ToListAsync(i=>i.Key == keyName);
    }
}