using System;

namespace StockCore.Aop.Mon
{
    public class StockCoreException:Exception
    {
        public Guid ID{get;set;}
        public string ModuleName{get;set;}
        public bool IsLogged{get;set;}
        public Tracer Tracer{get;set;}
        public string Info{get;set;}
        public int ErrorID{get;set;}
        public StockCoreException(int errorId,string moduleName,Exception ex,Tracer tracer=null,bool isLogged=false,String info=null):base("StockCoreException",ex)
        {
            this.ID = Guid.NewGuid();
            this.ErrorID = errorId;
            this.Info = info;
            this.Tracer = tracer;
            this.ModuleName = moduleName;
            this.IsLogged = isLogged;
        }
    }
}