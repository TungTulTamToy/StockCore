using System.Collections.Generic;
using StockCore.DomainEntity;

namespace StockCore.Business.Repo.MongoDB
{
    public interface IGetByKeyRepo<TResult,TKey>:IRepo<TResult>,IGetByKey<IEnumerable<TResult>,TKey>
        where TResult:BaseDE
        where TKey:class
    {}
}