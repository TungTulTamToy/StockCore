using System;
using Microsoft.Extensions.Logging;
using StockCore.Aop;
using StockCore.Aop.Mon;
using StockCore.Helper;
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
        public TResult Build(
            Tracer caller,
            TCondition intput=default(TCondition))
        {
            TResult t = default(TResult);
            var tracer = getTracer(caller);
            baseDecOperate(
                process:()=>t=baseFactoryBuild(tracer,intput),
                processFail:(ex)=>processFail(ex,processErrID,tracer,"Build"),    
                finalProcessFail:(e)=>processFail(e,outerErrID,tracer,"Build"));
            return t;
        }
        protected string getAopKey()=>$"Aop.{keyName}";
        private Tracer getTracer(Tracer caller,string description="")
        {
            if(string.IsNullOrEmpty(description))
            {
                description = keyName;
            }
            return new Tracer().Load(ID,caller,description,TraceSourceName.Dll);
        }
        private void processFail(Exception ex,int errorID,Tracer tracer,string methodName)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,errorID,$"Factory.{keyName}",methodName,tracer:tracer);
        public void Dispose(){}
    }
}