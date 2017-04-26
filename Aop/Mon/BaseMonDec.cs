using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using System.Diagnostics;
using StockCore.Extension;
using StockCore.ErrorException;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Linq.Expressions;

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
            Func<ILogger,Tracer,bool> validate,
            Func<Task<TResult>> processAsync,
            [CallerMemberName]string methodName="")
        {
            TResult result = default(TResult);
            Stopwatch sw = null;
            await baseDecOperateAsync(
                preProcess:()=>sw = preProcess(input,sw,methodName),
                validate:()=> validate(logger,tracer),
                processAsync: async() => result = await processAsync(),
                processFail:(ex)=>processFail(ex,processErrorID),
                postProcess:()=>postProcess(input,result,sw,methodName),
                finalProcessFail:(e)=>processFail(e,outerErrorID)
            );
            sw = null;
            return result;
        }
        protected TResult baseMonDecBuild<TInput,TResult>(
            TInput input,
            Func<ILogger,Tracer,bool> validate,
            Func<TResult> process,
            [CallerMemberName]string methodName="")
        {
            TResult result = default(TResult);
            Stopwatch sw = null;
            baseDecOperate(
                preProcess:()=>sw = preProcess(input,sw,methodName),
                validate:()=> validate(logger,tracer),
                process:() => result = process(),
                processFail:(ex)=>processFail(ex,processErrorID),
                postProcess:()=>postProcess(input,result,sw,methodName),
                finalProcessFail:(e)=>processFail(e,outerErrorID)
            );
            sw = null;
            return result;
        }
        private void processFail(Exception ex,int processErrorID)
        {
            if(ex is IStockCoreException)
            {
                var e = (IStockCoreException)ex;
                if(!e.IsLogged)
                {
                    logger.TraceError(module.Key,e.ID,ex:ex);
                    e.IsLogged=true;
                }
                if(e.Tracer==null)
                {
                    e.Tracer=tracer;
                }
                if(module.ThrowException)
                {
                    throw (Exception)e;
                }
            }
            else
            {
                logger.TraceError(module.Key,processErrorID,ex:ex);          
                var e = new StockCoreException(processErrorID,ex,"",tracer)
                {
                    IsLogged=true
                };
                if(module.ThrowException)
                {
                    throw e;
                }
            }
        }
        private Stopwatch preProcess<TInput>(TInput input,Stopwatch sw,string methodName)
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
                var callHistory = new CallHistory(methodName,paramsValue);
                tracer.AddCallHistory(callHistory);
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