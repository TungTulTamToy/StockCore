using System;

namespace StockCore.ErrorException
{
    public class StockCoreException:Exception,IStockCoreException
    {
        public bool IsLogged { get; set; }
        public int ID=>id;
        public readonly int id;
        public StockCoreException(int id,Exception ex):base("StockCoreException",ex)
        {
            this.id = id;
        }
    }
    public class StockCoreArgumentNullException:ArgumentNullException,IStockCoreException
    {
        public bool IsLogged { get; set; }
        public int ID=>id;
        public readonly int id;
        public StockCoreArgumentNullException(int id,string paramName,string message):base(paramName,message)
        {
            this.id = id;
        }
    }
}