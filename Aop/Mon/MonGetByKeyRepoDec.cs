using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using System;

namespace StockCore.Aop.Mon
{
    public class MonGetByKeyRepoDec<TInput,TResult> : MonRepoDec<TResult>, IGetByKeyRepo<TResult,TInput> where TInput:class where TResult:IBaseDE,IKeyField<string>
    {
        private readonly Func<ILogger,Tracer,string,string,TInput,bool> validateQuote;
        public MonGetByKeyRepoDec(
            IGetByKeyRepo<TResult,TInput> inner,
            Func<ILogger,Tracer,string,string,TInput,bool> validateQuote,            
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer
            ):base(inner,processErrorID,outerErrorID,module,logger,tracer)
            {
                this.validateQuote = validateQuote;
            }
        public async Task<IEnumerable<TResult>> GetByKeyAsync(TInput quote)
        {
            var returnItems = await baseMonDecBuildAsync(
                quote,
                (logger,tracer,moduleName,methodName)=>validateQuote(logger,tracer,moduleName,methodName,quote),
                async ()=> await ((IGetByKeyRepo<TResult,TInput>)inner).GetByKeyAsync(quote));
            return returnItems;
        }
    }
}