using System;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.Business.Repo.AppSetting;
using StockCore.ErrorException;

namespace StockCore.Aop.Mon.Repo.AppSetting
{
    public class MonConfigReaderDec : BaseDec,IConfigReader
    {
        private readonly IConfigReader inner; 
        private readonly Monitoring module;
        private readonly int processErrorID;
        private readonly Func<ILogger,Tracer,string,bool> validate;
        private readonly Tracer tracer;
        public MonConfigReaderDec(
            IConfigReader inner,
            Monitoring module,
            Func<ILogger,Tracer,string,bool> validate,
            int processErrorID,
            int outerErrorID,
            ILogger logger,
            Tracer tracer
            ):base(outerErrorID,module.Key,logger)
        {
            this.inner = inner;
            this.module = module;
            this.validate = validate;
            this.processErrorID = processErrorID;
            this.tracer = tracer;
        }
        public ModuleDE GetByKey(string key)
        {
            ModuleDE m = null;
            operate(
                tracer,
                preProcess:()=>logger.TraceBegin(m.Key,inputItem:key,showParams:module.ShowParams),
                validate:()=>validate(logger,tracer,key),
                process:()=>m = build(key),
                processFail:(ex)=>processFail(ex,key),
                postProcess:()=>logger.TraceEnd(m.Key,inputItem:key,showParams:true,returnItem:m,showResult:module.ShowResult)
            );
            return m;
        }
        private void processFail(Exception ex,string key)
        {
            logger.TraceError(module.Key,processErrorID,msg:key,ex:ex);
            throw ex;
        }
        private ModuleDE build(string key)
        {
            return inner.GetByKey(key);
        }
    }
}