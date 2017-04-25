using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using StockCore.DomainEntity;
using StockCore.Provider;
using StockCore.Wrapper;

namespace StockCore.Business.Repo.MongoDB
{
    public class BaseFuncDBRepo<T>:BaseQuoteDBRepo<T>,IGetByFuncRepo<string,T> where T:BaseDE,IKeyField<string>
    {
        public BaseFuncDBRepo(
            IConfigProvider config, 
            IMongoDatabaseWrapper db, 
            IFilterDefinitionBuilderWrapper filterBuilder,
            IReplaceOneModelBuilder replaceOneModelBuilder,  
            IDeleteOneModelBuilder deleteOneModelBuilder,
            string collectionName):base(config,db,filterBuilder,replaceOneModelBuilder,deleteOneModelBuilder,collectionName){}

        public async Task<IEnumerable<T>> GetByFuncAsync(Expression<Func<T, bool>> func)
        {
            return await collection.ToListAsync(func);
        }
    }
}