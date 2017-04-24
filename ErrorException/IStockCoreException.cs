using System;

namespace StockCore.ErrorException
{
    public interface IStockCoreException
    {
        bool IsLogged {get;set;}
        int ID{get;}
    }
}