using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Operation;
using StockCore.DomainEntity;

namespace StockCore.Aop.Mon
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
        public async Task OperateAsync(T param)
        {     
            await baseMonDecBuildAsync(
                input:param,
                validate:(logger,tracer,moduleName,methodName) => validate(logger,tracer,moduleName,methodName,param),
                innerProcessAsync:async ()=> {
                    await inner.OperateAsync(param);
                    return true;
            });
        }
    }
}