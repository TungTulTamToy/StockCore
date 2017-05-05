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
        protected readonly MonitoringModule module;
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
                processFail:(ex)=>composeAndThrowException(ex,processErrorID,methodName,input),
                postProcess:()=>postProcess(input,result,sw,methodName,subModule),
                finalProcessFail:(e)=>composeAndThrowException(e,outerErrorID,methodName,input)
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
                processFail:(ex)=>composeAndThrowException(ex,processErrorID,methodName,input),
                postProcess:()=>postProcess(input,result,sw,methodName,subModule),
                finalProcessFail:(e)=>composeAndThrowException(e,outerErrorID,methodName,input)
            );
            sw = null;
            return result;
        }
        private void composeAndThrowException<T>(Exception e,int errorID,string methodName,T item=default(T))
        {
            var info = "";
            if(item !=null && item is string)
            {
                info = item as string;
            }
            ProcessFailHelper.ComposeAndThrowException(logger,e,errorID,module.Key,methodName,tracer,module.ThrowException,info:info);
        }
        private Stopwatch preProcess<TInput>(TInput input,Stopwatch sw,string methodName,MonitoringModule module)
        {
            if(module.IsActive)
            {
                sw = startMeasurePerformance(sw, module);
                logTrace(input, methodName, module);
            }
            return sw;
        }
        private static Stopwatch startMeasurePerformance(Stopwatch sw, MonitoringModule module)
        {
            if (module.PerformanceMeasurement)
            {
                sw = new Stopwatch();
                sw.Start();
            }
            return sw;
        }
        private void logTrace<TInput>(TInput input, string methodName, MonitoringModule module)
        {
            if (module.LogTrace)
            {
                var paramsValue = JsonHelper.SerializeObject(input);
                var callHistory = new CallHistory().Load(methodName, paramsValue);
                tracer.AddCallHistory(callHistory);
            }
            logger.TraceBegin($"{module.Key}.{methodName}", input, module.ShowParams, module.ShowCount);
        }

        private void postProcess<TInput,TResult>(TInput input,TResult returnItem,Stopwatch sw,string methodName,MonitoringModule module)
        {
            if(module.IsActive)
            {
                var perfMsg = stopMeasurePerformance(sw, module);
                logger.TraceEnd($"{module.Key}.{methodName}",input,returnItem,perfMsg,module.ShowParams,module.ShowResult,module.ShowCount);
            }
        }
        private static string stopMeasurePerformance(Stopwatch sw, MonitoringModule module)
        {
            var perfMsg = "";
            if (module.PerformanceMeasurement)
            {
                sw.Stop();
                perfMsg = sw.ElapsedMilliseconds.ToString();
            }
            return perfMsg;
        }
    }
}