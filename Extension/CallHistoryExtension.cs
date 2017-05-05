using System;

namespace StockCore.Aop.Mon
{
    public static class CallHistoryExtension
    {
        public static CallHistory Load(this CallHistory item,string methodName,string parameters)
        {
            item.MethodName = methodName;
            item.Parameters = parameters;
            item.ActivateTime = DateTime.Now;
            return item;
        }
    }
}