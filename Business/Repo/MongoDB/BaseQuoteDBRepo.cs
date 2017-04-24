using System.Collections.Generic;
using System.Threading.Tasks;
using StockCore.DomainEntity;
using StockCore.Provider;
using StockCore.Wrapper;

namespace StockCore.Business.Repo.MongoDB
{
    public class BaseQuoteDBRepo<T> : BaseDBRepo<T>, IGetByKeyRepo<T,string> where T:BaseDE,IQuoteKeyField
    {
        public BaseQuoteDBRepo(
            IConfigProvider config, 
            IMongoDatabaseWrapper db, 
            IFilterDefinitionBuilderWrapper filterBuilder,
            IReplaceOneModelBuilder replaceOneModelBuilder,  
            IDeleteOneModelBuilder deleteOneModelBuilder,
            string collectionName):base(config,db,filterBuilder,replaceOneModelBuilder,deleteOneModelBuilder,collectionName){}
        public async Task<IEnumerable<T>> GetByKeyAsync(string quote)
        {
            return await collection.ToListAsync(i=>i.Quote == quote);
        }
    }
}