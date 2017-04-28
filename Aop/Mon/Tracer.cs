using System;
using System.Collections.Generic;
using static StockCore.DomainEntity.Enum.TraceSource;

namespace StockCore.Aop.Mon
{
    public class Tracer
    {
        public int ID{get;set;}
        public Tracer Caller{get;set;}
        public TraceSourceName TraceSourceName{get;set;}
        public string Descripton{get;set;}
        public List<CallHistory> CallHistories=new List<CallHistory>();
        public Tracer(int id, Tracer tracer, string description, TraceSourceName traceSourceName)
        {
            this.ID = id;
            this.Caller = tracer;
            this.Descripton = description;
            this.TraceSourceName = traceSourceName;
        }
        public void AddCallHistory(CallHistory callHistory)
        {
            CallHistories.Add(callHistory);
        }
    }
    public class CallHistory
    {
        public string MethodName{get;set;}
        public string Parameters{get;set;}
        public DateTime ActivateTime{get;set;}
        public CallHistory(string methodName,string parameters)
        {
            this.MethodName = methodName;
            this.Parameters = parameters;
            this.ActivateTime = DateTime.Now;
        }
    }
}