using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Builder;
using StockCore.DomainEntity;

namespace StockCore.Aop.Mon.Builder
{
    public class CacheBuilderDec<TResult> : BaseMonDec, IBuilder<string, TResult> where TResult:class
    {
        private readonly IBuilder<string, TResult> inner;
        private readonly Func<ILogger,Tracer,string,bool> validate;
        public CacheBuilderDec(
            IBuilder<string, TResult> inner,
            Func<ILogger,Tracer,string,bool> validate,            
            int processErrorID,
            int outerErrorID,
            Monitoring module,
            ILogger logger,
            Tracer tracer):base(processErrorID,outerErrorID,module,logger,tracer)
        {
            this.inner = inner;
            this.validate = validate;
        }
        public async Task<TResult> BuildAsync(string quote)
        {
            var item = await operateWithResultAsync(
                quote,
                (logger,tracer)=>validate(logger,tracer,quote),
                async ()=> await inner.BuildAsync(quote));
            return item;
        }
    }
}