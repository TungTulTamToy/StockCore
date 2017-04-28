using System;

namespace StockCore.Aop.Mon
{
    public class StockCoreException:Exception
    {
        public string Key{get;set;}
        public bool IsLogged{get;set;}
        public Tracer Tracer{get;set;}
        public string Info{get;set;}
        public int ID{get;set;}
        public StockCoreException(int id,string key,Exception ex,Tracer tracer=null,bool isLogged=false,String info=null):base("StockCoreException",ex)
        {
            this.ID = id;
            this.Info = info;
            this.Tracer = tracer;
            this.Key = key;
            this.IsLogged = isLogged;
        }
    }
}