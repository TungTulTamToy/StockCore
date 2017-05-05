using System.Collections.Generic;
using static StockCore.DomainEntity.Enum.TraceSource;

namespace StockCore.Aop.Mon
{
    public static class TracerExtension
    {
        public static Tracer Load(this Tracer item,int id, Tracer tracer, string description, TraceSourceName traceSourceName)
        {
            item.ID = id;
            item.Caller = tracer;
            item.Descripton = description;
            item.TraceSourceName = traceSourceName;
            item.CallHistories=new List<CallHistory>();
            return item;
        }
    }
}