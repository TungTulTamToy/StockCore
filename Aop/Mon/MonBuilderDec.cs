using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Builder;
using StockCore.DomainEntity;

namespace StockCore.Aop.Mon
{
    public class MonBuilderDec<TInput,TResult> : BaseMonDec, IBuilder<TInput, TResult> where TInput:class where TResult:class
    {
        private readonly MonitoringModule module;
        private readonly IBuilder<TInput, TResult> inner;
        private readonly Func<ILogger,Tracer,string,string,TInput,bool> validateQuote;
        public MonBuilderDec(
            IBuilder<TInput, TResult> inner,
            Func<ILogger,Tracer,string,string,TInput,bool> validateQuote,            
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
        public async Task<TResult> BuildAsync(TInput param)
        {
            var item = await baseMonDecBuildAsync(
                param,
                (logger,tracer,moduleName,methodName)=>validateQuote(logger,tracer,moduleName,methodName,param),
                async ()=> await inner.BuildAsync(param));
            return item;
        }
    }
}