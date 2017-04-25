using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo;
using System;

namespace StockCore.Aop.Mon
{
    public class MonGetByKeyDec<T> : BaseMonDec,IGetByKey<IEnumerable<T>,string> where T:BaseDE
    {
        private readonly IGetByKey<IEnumerable<T>,string> inner; 
        private readonly Func<ILogger,Tracer,string,bool> validate;
        public MonGetByKeyDec(
            IGetByKey<IEnumerable<T>,string> inner,
            Func<ILogger,Tracer,string,bool> validate,
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer
            ):base(processErrorID,outerErrorID,module,logger,tracer)
        {
            this.inner = inner;
            this.validate = validate;
        }
        public async Task<IEnumerable<T>> GetByKeyAsync(string quote)
        {
            var returnItems = await operateWithResultAsync(
                quote,
                (logger,tracer)=>validate(logger,tracer,quote),
                async ()=> await inner.GetByKeyAsync(quote)
                );
            return returnItems;
        }
    }
}