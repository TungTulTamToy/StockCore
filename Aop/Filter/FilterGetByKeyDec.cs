using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo;
using System;
using StockCore.Extension;
using StockCore.Aop.Mon;

namespace StockCore.Aop.Filter
{
    public class FilterGetByKeyDec<T> : BaseFilterDec,IGetByKey<IEnumerable<T>,string> where T:IPersistant
    {
        private readonly IGetByKey<IEnumerable<T>,string> inner; 
        private readonly Func<string,bool> filter;
        public FilterGetByKeyDec(
            IGetByKey<IEnumerable<T>,string> inner,
            Func<string,bool> filter,
            int processErrorID,
            int outerErrorID,
            FilterModule module,
            ILogger logger
            ):base(processErrorID,outerErrorID,module,logger)
        {
            this.inner = inner;
            this.filter = filter;
        }
        public async Task<IEnumerable<T>> GetByKeyAsync(string quote)
        {
            IEnumerable<T> returnItems = null;
            await baseFilterDecBuildAsync(
                ()=>filter(quote),
                async ()=> returnItems = await inner.GetByKeyAsync(quote));
            return returnItems;
        }
    }
}