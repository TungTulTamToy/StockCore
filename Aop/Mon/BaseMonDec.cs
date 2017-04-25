using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using System.Diagnostics;
using StockCore.Extension;
using StockCore.ErrorException;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace StockCore.Aop.Mon
{
    public class BaseMonDec:BaseDec
    {
        protected readonly MonitoringModule module;
        private readonly int processErrorID;
        private readonly Tracer tracer;
        public BaseMonDec(
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer
            ):base(outerErrorID,module.Key,logger)
        {
            this.module = module;
            this.processErrorID = processErrorID;
            this.tracer = tracer;
        }
        protected async Task operateAsync<TInput>(
            TInput input,
            Func<ILogger,Tracer,bool> validate,
            Func<Task> processAsync,
            [CallerMemberName]string methodName="")
        {
            Stopwatch sw = null;
            await operateAsync(
                tracer,
                preProcess:()=>sw = preProcess(input,sw,methodName),
                validate:()=> validate(logger,tracer),
                processAsync: async() => await processAsync(),
                processFail:(ex)=>baseProcessFail(ex,processErrorID,module.ThrowException,tracer),
                postProcess:()=>postProcess<TInput,string>(input,null,sw,methodName)
            );
            sw = null;
        }

        protected async Task<TResult> operateWithResultAsync<TInput,TResult>(
            TInput input,
            Func<ILogger,Tracer,bool> validate,
            Func<Task<TResult>> processAsync,
            [CallerMemberName]string methodName="")
        {
            TResult result = default(TResult);
            Stopwatch sw = null;
            await operateAsync(
                tracer,
                preProcess:()=>sw = preProcess(input,sw,methodName),
                validate:()=> validate(logger,tracer),
                processAsync: async() => result = await processAsync(),
                processFail:(ex)=>baseProcessFail(ex,processErrorID,module.ThrowException,tracer),
                postProcess:()=>postProcess(input,result,sw,methodName)
            );
            sw = null;
            return result;
        }
        private Stopwatch preProcess<TInput>(TInput input,Stopwatch sw,string methodName)
        {
            if(module.LogTrace)
            {
                var paramsValue = JsonConvert.SerializeObject(input);
                var callHistory = new CallHistory(methodName,paramsValue);
                tracer.AddCallHistory(callHistory);
            }
            if(module.PerformanceMeasurement)
            {
                sw = new Stopwatch();
                sw.Start();
            }
            if(module.IsActive)
            {
                logger.TraceBegin($"{module.Key}.{methodName}",input,showParams:module.ShowParams);
            }
            return sw;
        }
        private void postProcess<TInput,TResult>(TInput input,TResult returnItem,Stopwatch sw,string methodName)
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