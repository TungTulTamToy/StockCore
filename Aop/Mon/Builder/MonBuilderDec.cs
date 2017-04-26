using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Builder;
using StockCore.DomainEntity;

namespace StockCore.Aop.Mon.Builder
{
    public class MonBuilderDec<TResult> : BaseMonDec, IBuilder<string, TResult> where TResult:class
    {
        private readonly IBuilder<string, TResult> inner;
        private readonly Func<ILogger,Tracer,string,bool> validateQuote;
        public MonBuilderDec(
            IBuilder<string, TResult> inner,
            Func<ILogger,Tracer,string,bool> validateQuote,            
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer):base(processErrorID,outerErrorID,module,logger,tracer)
        {
            this.inner = inner;
            this.validateQuote = validateQuote;
        }
        public async Task<TResult> BuildAsync(string quote)
        {
            var item = await baseMonDecBuildAsync(
                quote,
                (logger,tracer)=>validateQuote(logger,tracer,quote),
                async ()=> await inner.BuildAsync(quote));
            return item;
        }
    }
}