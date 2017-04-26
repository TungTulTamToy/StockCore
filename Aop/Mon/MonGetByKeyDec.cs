using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo;
using System;
using StockCore.Extension;

namespace StockCore.Aop.Mon
{
    public class MonGetByKeyDec<T> : BaseMonDec,IGetByKey<IEnumerable<T>,string> where T:BaseDE
    {
        private readonly IGetByKey<IEnumerable<T>,string> inner; 
        private readonly Func<ILogger,Tracer,string,bool> validateQuote;
        public MonGetByKeyDec(
            IGetByKey<IEnumerable<T>,string> inner,
            Func<ILogger,Tracer,string,bool> validateString,
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer
            ):base(processErrorID,outerErrorID,module,logger,tracer)
        {
            this.inner = inner;
            this.validateQuote = validateString;
        }
        public async Task<IEnumerable<T>> GetByKeyAsync(string quote)
        {
            var returnItems = await baseMonDecBuildAsync(
                quote,
                (logger,tracer)=>validateQuote(logger,tracer,quote),
                async ()=> await inner.GetByKeyAsync(quote));
            return returnItems;
        }
    }
}