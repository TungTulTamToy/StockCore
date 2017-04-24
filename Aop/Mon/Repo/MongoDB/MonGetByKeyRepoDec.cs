using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using System;

namespace StockCore.Aop.Mon.Repo.MongoDB
{
    public class MonGetByKeyRepoDec<T> : MonRepoDec<T>, IGetByKeyRepo<T,string> where T:BaseDE,IQuoteKeyField
    {
        private readonly Func<ILogger,Tracer,string,bool> validate;
        public MonGetByKeyRepoDec(
            IGetByKeyRepo<T,string> inner,
            Func<ILogger,Tracer,string,bool> validate,            
            int processErrorID,
            int outerErrorID,
            Monitoring module,
            ILogger logger,
            Tracer tracer
            ):base(inner,processErrorID,outerErrorID,module,logger,tracer)
            {
                this.validate = validate;
            }
        public async Task<IEnumerable<T>> GetByKeyAsync(string quote)
        {
            var returnItems = await operateWithResultAsync(
                quote,
                (logger,tracer)=>validate(logger,tracer,quote),
                async ()=> await ((IGetByKeyRepo<T,string>)inner).GetByKeyAsync(quote));
            return returnItems;
        }
    }
}