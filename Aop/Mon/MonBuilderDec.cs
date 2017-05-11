using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Builder;
using StockCore.DomainEntity;

namespace StockCore.Aop.Mon
{
    public class MonBuilderDec<TInput,TResult> : BaseMonDec, IBuilder<TInput, TResult> where TInput:class where TResult:class
    {
        private readonly IBuilder<TInput, TResult> inner;
        private readonly Func<ILogger,Tracer,string,string,TInput,bool> validateQuote;
        public MonBuilderDec(
            IBuilder<TInput, TResult> inner,
            Func<ILogger,Tracer,string,string,TInput,bool> validateQuote,            
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer):base(processErrorID:processErrorID,outerErrorID:outerErrorID,module:module,logger:logger,tracer:tracer)
        {
            this.inner = inner;
            this.validateQuote = validateQuote;
        }
        public TResult Build(TInput param)
        {
            var item = baseMonDecBuild(
                input:param,
                validate:(logger,tracer,moduleName,methodName)=>validateQuote(logger,tracer,moduleName,methodName,param),
                innerProcess:()=> inner.Build(param));
            return item;
        }
        public async Task<TResult> BuildAsync(TInput param)
        {
            var item = await baseMonDecBuildAsync(
                input:param,
                validate:(logger,tracer,moduleName,methodName)=>validateQuote(logger,tracer,moduleName,methodName,param),
                innerProcessAsync:async ()=> await inner.BuildAsync(param));
            return item;
        }
    }
}