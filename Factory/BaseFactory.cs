using System;
using Microsoft.Extensions.Logging;
using StockCore.Aop;
using StockCore.DomainEntity;
using StockCore.Extension;

namespace StockCore.Factory
{
    public abstract class BaseFactory<TCondition,TResult>:BaseDec,IFactory<TCondition,TResult> where TCondition:class where TResult:class
    {
        private readonly int ID;
        private readonly int processErrID;
        protected abstract TResult build(Tracer tracer,TCondition intput=default(TCondition)); 
        public BaseFactory(int processErrID,int outerErrID,int ID,string keyName,ILogger logger):base(outerErrID,keyName,logger)
        {
            this.ID = ID;
            this.processErrID = processErrID;
        }
        public TResult Build(Tracer caller,TCondition intput=default(TCondition))
        {
            TResult t = default(TResult);
            var tracer = getTracer(caller);
            operate(
                tracer,
                process:()=>t=build(tracer,intput),
                processFail:(ex)=>processFail(ex,caller)//Not throw exception since this method can be called from constructor     
                );
            return t;
        }
        protected string getAopKey()
        {
            return $"Aop.{keyName}";
        }
        
        protected Tracer getTracer(Tracer caller,string description="")
        {
            if(string.IsNullOrEmpty(description))
            {
                description = keyName;
            }
            return new Tracer(ID,caller,description);
        }
        private void processFail(Exception ex,Tracer caller)
        {
            var tracer = getTracer(caller);
            logger.TraceError($"Factory.{keyName}",processErrID,ex:ex);
        }
    }
}