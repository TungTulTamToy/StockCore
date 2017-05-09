using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using System;
using StockCore.Business.Builder;

namespace StockCore.Aop.PostFilter
{
    public class PostFilterBuilderDec<T> : BasePostFilterDec<IEnumerable<T>>,IBuilder<string,IEnumerable<T>>
    {
        private readonly IBuilder<string,IEnumerable<T>> inner; 
        private readonly Func<string,IEnumerable<T>,IEnumerable<T>> filter;
        public PostFilterBuilderDec(
            IBuilder<string,IEnumerable<T>> inner,
            Func<string,IEnumerable<T>,IEnumerable<T>> filter,
            int processErrorID,
            int outerErrorID,
            PostFilterModule module,
            ILogger logger
            ):base(processErrorID,outerErrorID,module,logger)
        {
            this.inner = inner;
            this.filter = filter;
        }

        public async Task<IEnumerable<T>> BuildAsync(string item = null)
        {
            var returnItems = await basePostFilterDecBuildAsync(
                async ()=> await inner.BuildAsync(item),             
                (postItem)=>filter(item,postItem));
            return returnItems;
        }
    }
}