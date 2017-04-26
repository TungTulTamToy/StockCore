using System;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.Business.Repo.AppSetting;

namespace StockCore.Aop.Mon.Repo.AppSetting
{
    public class MonConfigReaderDec : BaseMonDec,IConfigReader
    {
        private readonly IConfigReader inner; 
        private readonly Func<ILogger,Tracer,string,bool> validateKey;
        public MonConfigReaderDec(
            IConfigReader inner,
            Func<ILogger,Tracer,string,bool> validateKey,
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
        public ModuleDE GetByKey(string key)
        {
            var m = baseMonDecBuild(
                key,
                (logger,tracer) => validateKey(logger,tracer,key),
                ()=> inner.GetByKey(key));
            return m;
        }
    }
}