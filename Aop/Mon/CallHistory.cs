using System;

namespace StockCore.Aop.Mon
{
    public class CallHistory
    {
        public string MethodName{get;set;}
        public string Parameters{get;set;}
        public DateTime ActivateTime{get;set;}
    }
}