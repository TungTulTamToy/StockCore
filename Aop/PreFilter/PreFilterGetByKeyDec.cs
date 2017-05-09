using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo;
using System;
using StockCore.Extension;
using StockCore.Aop.Mon;

namespace StockCore.Aop.PreFilter
{
    public class PreFilterGetByKeyDec<TKey,T> : BasePreFilterDec,IGetByKey<IEnumerable<T>,TKey> where TKey:class where T:IPersistant
    {
        private readonly IGetByKey<IEnumerable<T>,TKey> inner; 
        private readonly Func<TKey,bool> filter;
        public PreFilterGetByKeyDec(
            IGetByKey<IEnumerable<T>,TKey> inner,
            Func<TKey,bool> filter,
            int processErrorID,
            int outerErrorID,
            PreFilterModule module,
            ILogger logger
            ):base(processErrorID,outerErrorID,module,logger)
        {
            this.inner = inner;
            this.filter = filter;
        }
        public async Task<IEnumerable<T>> GetByKeyAsync(TKey quote)
        {
            IEnumerable<T> returnItems = null;
            await basePreFilterDecBuildAsync(
                preFilter:()=>filter(quote),
                innerProcessAsync:async ()=> returnItems = await inner.GetByKeyAsync(quote)
            );
            return returnItems;
        }
    }
}