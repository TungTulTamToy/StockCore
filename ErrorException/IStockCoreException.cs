using System;
using StockCore.DomainEntity;

namespace StockCore.ErrorException
{
    public interface IStockCoreException
    {
        bool IsLogged {get;set;}
        int ID{get;}
        Tracer Tracer{get;set;}
        string Info{get;set;}
    }
}