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
            if (ex is StockCoreException)
            {
                e = (StockCoreException)ex;
                if (e.Tracer == null && tracer != null)
                {
                    e.Tracer = tracer;
                }
            }
            else
            {
                e = new StockCoreException(errorID, moduleName, ex, tracer, false, info);
            }
            traceError(logger, e);
            determineError(throwError, e);
        }

        private static void traceError(ILogger logger, StockCoreException e)
        {
            if (!e.IsLogged)
            {
                logger.TraceError(e);
                e.IsLogged = true;
            }
        }

        private static void determineError(bool throwError, StockCoreException e)
        {
            if (throwError)
            {
                throw e;
            }
        }
    }
}