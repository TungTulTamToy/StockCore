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
        public List<CallHistory> CallHistories{get;set;}
        public void AddCallHistory(CallHistory callHistory)
        {
            lock(CallHistories)
            {
                CallHistories.Add(callHistory);
            }
        }
    }
}