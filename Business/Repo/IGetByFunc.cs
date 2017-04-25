using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StockCore.Business.Repo
{
    public interface IGetByFunc<T> where T:class
    {
        Task<IEnumerable<T>> GetByFuncAsync(Expression<Func<T, bool>> func);
    }
}