using StockCore.DomainEntity;

namespace StockCore.Business.Repo.MongoDB
{
    public interface IGetByFuncRepo<TKey,TResult>:IGetByKeyRepo<TResult,TKey>,IGetByFunc<TResult>
        where TResult:IBaseDE
        where TKey:class
    {}
}