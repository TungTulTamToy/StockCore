using System;
using StockCore.DomainEntity;

namespace StockCore.ErrorException
{
    public class StockCoreException:Exception,IStockCoreException
    {
        public bool IsLogged { get; set; }
        public int ID=>id;
        public readonly int id;
        public readonly Tracer tracer;
        public StockCoreException(int id,Exception ex,Tracer tracer):base("StockCoreException",ex)
        {
            this.id = id;
            this.tracer = tracer;
        }
    }
    public class StockCoreArgumentNullException:ArgumentNullException,IStockCoreException
    {
        public bool IsLogged { get; set; }
        public int ID=>id;
        public readonly int id;
        public readonly Tracer tracer;
        public StockCoreArgumentNullException(int id,string paramName,string message,Tracer tracer):base(paramName,message)
        {
            this.id = id;
            this.tracer = tracer;
        }
    }
}