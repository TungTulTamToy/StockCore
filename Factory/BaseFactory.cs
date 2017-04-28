using System;
using Microsoft.Extensions.Logging;
using StockCore.Aop;
using StockCore.Aop.Mon;
using StockCore.Extension;
using static StockCore.DomainEntity.Enum.TraceSource;

namespace StockCore.Factory
{
    public abstract class BaseFactory<TCondition,TResult>:BaseDec,IFactory<TCondition,TResult> where TCondition:class where TResult:class
    {
        private readonly int ID;
        private readonly string keyName;
        private readonly int processErrID;
        private readonly int outerErrID;
        protected readonly ILogger logger;
        protected abstract TResult baseFactoryBuild(Tracer tracer,TCondition intput=default(TCondition)); 
        public BaseFactory(int processErrID,int outerErrID,int ID,string keyName,ILogger logger)
        {
            this.ID = ID;
            this.keyName = keyName;
            this.processErrID = processErrID;
            this.outerErrID = outerErrID;
            this.logger = logger;
        }
        public TResult Build(Tracer caller,TCondition intput=default(TCondition))
        {
            TResult t = default(TResult);
            var tracer = getTracer(caller);
            baseDecOperate(
                process:()=>t=baseFactoryBuild(tracer,intput),
                processFail:(ex)=>processFail(ex,processErrID,tracer),    
                finalProcessFail:(e)=>processFail(e,outerErrID,tracer)
                );
            return t;
        }
        protected string getAopKey()
        {
            return $"Aop.{keyName}";
        }
        
        private Tracer getTracer(Tracer caller,string description="")
        {
            if(string.IsNullOrEmpty(description))
            {
                description = keyName;
            }
            return new Tracer(ID,caller,description,TraceSourceName.Dll);
        }
        private void processFail(Exception ex,int errorID,Tracer tracer) 
        { 
            var e = new StockCoreException(errorID,$"Factory.{keyName}",ex,tracer,true);
            logger.TraceError(e);//Not throw exception since this method can be called from constructor 
        } 
    }
}