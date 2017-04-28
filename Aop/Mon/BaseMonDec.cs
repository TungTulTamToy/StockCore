using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using System.Diagnostics;
using StockCore.Extension;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Linq.Expressions;
using StockCore.Helper;

namespace StockCore.Aop.Mon
{
    public class BaseMonDec:BaseDec
    {
        private readonly MonitoringModule module;
        private readonly int processErrorID;
        private readonly Tracer tracer;
        private readonly ILogger logger;
        private readonly int outerErrorID;
        public BaseMonDec(
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer
            )
        {
            this.module = module;
            this.processErrorID = processErrorID;
            this.outerErrorID = outerErrorID;            
            this.tracer = tracer;
            this.logger = logger;
        }
        protected async Task<TResult> baseMonDecBuildAsync<TInput,TResult>(
            TInput input,
            Func<ILogger,Tracer,string,string,bool> validate,
            Func<Task<TResult>> innerProcessAsync,
            [CallerMemberName]string methodName="")
        {
            TResult result = default(TResult);
            Stopwatch sw = null;
            var subModule = module.OverrideConfigFromSubModuleIfAny(methodName);
            await baseDecOperateAsync(
                preProcess:()=>sw = preProcess(input,sw,methodName,subModule),
                validate:()=> validate(logger,tracer,module.Key,methodName),
                processAsync: async() => result = await innerProcessAsync(),
                processFail:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName,tracer,module.ThrowException),
                postProcess:()=>postProcess(input,result,sw,methodName,subModule),
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName,tracer,module.ThrowException)
            );
            sw = null;
            return result;
        }
        protected TResult baseMonDecBuild<TInput,TResult>(
            TInput input,
            Func<ILogger,Tracer,string,string,bool> validate,
            Func<TResult> innerProcess,
            [CallerMemberName]string methodName="")
        {
            TResult result = default(TResult);
            Stopwatch sw = null;
            var subModule = module.OverrideConfigFromSubModuleIfAny(methodName);
            baseDecOperate(
                preProcess:()=>sw = preProcess(input,sw,methodName,subModule),
                validate:()=> validate(logger,tracer,module.Key,methodName),
                process:() => result = innerProcess(),
                processFail:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName,tracer,module.ThrowException),
                postProcess:()=>postProcess(input,result,sw,methodName,subModule),
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName,tracer,module.ThrowException)
            );
            sw = null;
            return result;
        }
        private Stopwatch preProcess<TInput>(TInput input,Stopwatch sw,string methodName,MonitoringModule module)
        {
            if(module.PerformanceMeasurement)
            {
                sw = new Stopwatch();
                sw.Start();
            }
            if(module.LogTrace)
            {
                var paramsValue = "";
                if(!(input is Expression))
                {
                    paramsValue = JsonConvert.SerializeObject(input);
                }
                else
                {
                    paramsValue = "Not log expression type.";
                }
                var callHistory = new CallHistory(methodName,paramsValue);
                tracer.AddCallHistory(callHistory);
            }
            if(module.IsActive)
            {
                logger.TraceBegin($"{module.Key}.{methodName}",input,showParams:module.ShowParams);
            }
            return sw;
        }
        private void postProcess<TInput,TResult>(TInput input,TResult returnItem,Stopwatch sw,string methodName,MonitoringModule module)
        {
            if(module.IsActive)
            {
                logger.TraceEnd(
                    $"{module.Key}.{methodName}",
                    input,
                    showParams:module.ShowParams,
                    returnItem:returnItem,
                    showResult:module.ShowResult);
            }
            if(module.PerformanceMeasurement)
            {
                sw.Stop();
                logger.TraceMessage(module.Key,input,msg:$"ElapsedMilliseconds:{sw.ElapsedMilliseconds}",showParams:module.ShowParams);
            }
        }
        
    }
}