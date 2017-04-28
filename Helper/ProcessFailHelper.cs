using System;
using Microsoft.Extensions.Logging;
using StockCore.Aop.Mon;
using StockCore.Extension;

namespace StockCore.Helper
{
    public static class ProcessFailHelper
    {
        public static void ComposeAndThrowException(
            ILogger logger,
            Exception ex,
            int errorID,
            string moduleName,
            string methodName,
            Tracer tracer=null,
            bool throwError=true,
            string info=null)
        {
            StockCoreException e = null;
            if(ex is StockCoreException)
            {
                e = (StockCoreException)ex;
                if(e.Tracer==null && tracer!=null)
                {
                    e.Tracer=tracer;
                }
            }
            else
            {
                e = new StockCoreException(errorID,moduleName,ex,tracer,false,info);
            }
            if(!e.IsLogged)
            {
                logger.TraceError(e);
                e.IsLogged = true;
            }
            if(throwError)
            {
                throw e;
            }
        }
    }
}