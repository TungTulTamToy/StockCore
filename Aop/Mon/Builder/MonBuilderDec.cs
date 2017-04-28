using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Builder;
using StockCore.DomainEntity;

namespace StockCore.Aop.Mon.Builder
{
    public class MonBuilderDec<TResult> : BaseMonDec, IBuilder<string, TResult> where TResult:class
    {
        private readonly MonitoringModule module;
        private readonly IBuilder<string, TResult> inner;
        private readonly Func<ILogger,Tracer,string,string,string,bool> validateQuote;
        public MonBuilderDec(
            IBuilder<string, TResult> inner,
            Func<ILogger,Tracer,string,string,string,bool> validateQuote,            
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer):base(processErrorID,outerErrorID,module,logger,tracer)
        {
            this.inner = inner;
            this.validateQuote = validateQuote;
            this.module = module;
        }
        public async Task<TResult> BuildAsync(string quote)
        {
            var item = await baseMonDecBuildAsync(
                quote,
                (logger,tracer,moduleName,methodName)=>validateQuote(logger,tracer,moduleName,methodName,quote),
                async ()=> await inner.BuildAsync(quote));
            return item;
        }
    }
}