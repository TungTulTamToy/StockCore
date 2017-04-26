using System;
using System.Collections.Generic;

namespace StockCore.Aop.Mon
{
    public class Tracer
    {
        private readonly int id;
        private readonly Tracer tracer;
        private readonly string description;
        public Tracer(int id, Tracer tracer, string description)
        {
            this.id = id;
            this.tracer = tracer;
            this.description = description;
        }
        public int ID => id;
        public Tracer Caller => tracer;
        public List<CallHistory> CallHistories=new List<CallHistory>();
        public void AddCallHistory(CallHistory callHistory)
        {
            CallHistories.Add(callHistory);
        }
    }
    public class CallHistory
    {
        public string MethodName=>methodName;
        public string Parameters=>parameters;
        public DateTime ActivateTime=>activateTime;
        private readonly string methodName;
        private readonly string parameters;
        private readonly DateTime activateTime;
        public CallHistory(string methodName,string parameters)
        {
            this.methodName = methodName;
            this.parameters = parameters;
            this.activateTime = DateTime.Now;
        }
    }
}