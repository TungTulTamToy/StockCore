using System;
using Microsoft.Extensions.Logging;
using StockCore.Aop.Mon;
using StockCore.Extension;

namespace StockCore.Aop
{
    public static class ProcessFail
    {
        public static void ComposeAndThrowException(ILogger logger,Exception ex,int errorID,string moduleKey,Tracer tracer=null,bool throwError=true,string info=null)
        {
            StockCoreException e = null;
            if(ex is StockCoreException)
            {
                e = (StockCoreException)ex;
                if(!e.IsLogged)
                {
                    logger.TraceError(e);
                    e.IsLogged = true;
                }
                if(e.Tracer==null && tracer!=null)
                {
                    e.Tracer=tracer;
                }
            }
            else
            {
                e = new StockCoreException(errorID,moduleKey,ex,tracer,true,info);
                logger.TraceError(e);
            }
            if(throwError)
            {
                throw e;
            }
        }
    }
}