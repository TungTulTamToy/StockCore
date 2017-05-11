using System;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.AppSetting;

namespace StockCore.Aop.Mon
{
    public class MonConfigReaderDec<T> : BaseMonDec,IConfigReader<T>
    {
        private readonly IConfigReader<T> inner; 
        private readonly Func<ILogger,Tracer,string,string,string,bool> validateKey;
        public MonConfigReaderDec(
            IConfigReader<T> inner,
            Func<ILogger,Tracer,string,string,string,bool> validateKey,
            MonitoringModule module,            
            int processErrorID,
            int outerErrorID,
            ILogger logger,
            Tracer tracer
            ):base(processErrorID,outerErrorID,module,logger,tracer)
        {
            this.inner = inner;
            this.validateKey = validateKey;
        }
        public T GetByKey(string key)
        {
            var m = baseMonDecBuild(
                input:key,
                validate:(logger,tracer,moduleName,methodName) => validateKey(logger,tracer,moduleName,methodName,key),
                innerProcess:()=> inner.GetByKey(key));
            return m;
        }
    }
}