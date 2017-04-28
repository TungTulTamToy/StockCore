using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using System;

namespace StockCore.Aop.Mon.Repo.MongoDB
{
    public class MonGetByKeyRepoDec<T> : MonRepoDec<T>, IGetByKeyRepo<T,string> where T:BaseDE,IKeyField<string>
    {
        private readonly Func<ILogger,Tracer,string,string,bool> validateQuote;
        public MonGetByKeyRepoDec(
            IGetByKeyRepo<T,string> inner,
            Func<ILogger,Tracer,string,string,bool> validateQuote,            
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer
            ):base(inner,processErrorID,outerErrorID,module,logger,tracer)
            {
                this.validateQuote = validateQuote;
            }
        public async Task<IEnumerable<T>> GetByKeyAsync(string quote)
        {
            var returnItems = await baseMonDecBuildAsync(
                quote,
                (logger,tracer,keyName)=>validateQuote(logger,tracer,keyName,quote),
                async ()=> await ((IGetByKeyRepo<T,string>)inner).GetByKeyAsync(quote));
            return returnItems;
        }
    }
}