using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Worker;
using StockCore.DomainEntity;

namespace StockCore.Aop.Mon.Worker
{
    public class MonOperationDec<T> : BaseMonDec,IOperation<T> where T:class
    {
        private readonly Func<ILogger,Tracer,T,bool> validate;
        private readonly IOperation<T> inner; 
        public MonOperationDec(
            IOperation<T> inner,    
            Func<ILogger,Tracer,T,bool> validate,
            int processErrorID,
            int outerErrorID,  
            Monitoring module,    
            ILogger logger,
            Tracer tracer
            ):base(processErrorID,outerErrorID,module,logger,tracer)
        {
            this.inner = inner;
            this.validate = validate;
        }
        public async Task OperateAsync(T t)
        {     
            await operateAsync(t,
                (logger,tracer) => validate(logger,tracer,t),
                async ()=> await innerOperateAsync(t));
        }
        private async Task innerOperateAsync(T t)
        {
            await inner.OperateAsync(t);
        }
    }
}