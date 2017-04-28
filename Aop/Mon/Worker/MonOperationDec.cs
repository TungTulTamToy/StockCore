using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Worker;
using StockCore.DomainEntity;

namespace StockCore.Aop.Mon.Worker
{
    public class MonOperationDec<T> : BaseMonDec,IOperation<T> where T:class
    {
        private readonly Func<ILogger,Tracer,string,string,T,bool> validate;
        private readonly IOperation<T> inner; 
        public MonOperationDec(
            IOperation<T> inner,    
            Func<ILogger,Tracer,string,string,T,bool> validate,
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
        public async Task OperateAsync(T t)
        {     
            await baseMonDecBuildAsync(
                t,
                (logger,tracer,moduleName,methodName) => validate(logger,tracer,moduleName,methodName,t),
                async ()=> {
                    await inner.OperateAsync(t);
                    return true;
            });
        }
    }
}