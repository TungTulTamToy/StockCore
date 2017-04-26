using System;
using StockCore.DomainEntity;

namespace StockCore.ErrorException
{
    public class StockCoreException:Exception,IStockCoreException
    {
        public bool IsLogged { get; set; }
        public Tracer Tracer { get; set; }
        public string Info{get;set;}
        public int ID=>id;
        public readonly int id;
        public StockCoreException(int id,Exception ex,String info,Tracer tracer):base("StockCoreException",ex)
        {
            this.id = id;
            this.Info = info;
            this.Tracer = tracer;
        }
    }
}