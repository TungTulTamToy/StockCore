using System.Linq.Expressions;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StockCore.Aop.Mon;

namespace StockCore.Extension
{
    public static class LoggerExtension
    {
        public static void TraceBegin<T>(this ILogger logger,string keyName,T inputItem=default(T),bool showParams=false)
        {
            var message = "";
            if(showParams)
            {
                message = getParamMessage(inputItem);
            }
            logger.traceDebug("--->", keyName, message);
        }
        public static void TraceEnd<T,TOut>(this ILogger logger,string keyName,T inputItem=default(T),TOut returnItem=default(TOut),bool showParams=false,bool showResult=false)
        {
            var sb = new StringBuilder();
            if(showParams)
            {
                sb.Append(getParamMessage(inputItem)); 
            }
            if(showResult)
            {
                sb.Append(getResultMessage(returnItem));
            }
            var message = sb.ToString();
            logger.traceDebug("<---", keyName, message);
        }
        public static void TraceMessage<T>(this ILogger logger,string keyName,T inputItem=default(T),string msg = "",bool showParams=false)
        {
            var sb = new StringBuilder();
            if(showParams)
            {
                sb.Append(getParamMessage(inputItem));
            }
            sb.Append(msg);
            logger.traceDebug("****",keyName, sb.ToString(),"****");
        }
        public static void TraceError(this ILogger logger,StockCoreException ex)
        {
            if(ex!=null)
            {
                var sb = new StringBuilder();
                sb.Append($"Process:[{ex.ModuleName}] ");
                sb.AppendLine();
                sb.Append($"ID:[{ex.ErrorID}] ");
                sb.AppendLine();
                sb.Append($"Info: [{ex.Info}] ");
                sb.AppendLine();
                if(ex!=null)
                {
                    sb.Append($"Exception: {ex.Message} ");
                    sb.AppendLine();
                    sb.Append($"Stack: {ex.StackTrace} ");
                    sb.AppendLine();
                    if(ex.InnerException!=null)
                    {
                        sb.Append($"Inner Exception: {ex.InnerException.Message} ");
                        sb.AppendLine();
                        sb.Append($"Inner Stack: {ex.InnerException.StackTrace} ");
                        sb.AppendLine();
                    }
                }
                logger.LogError(sb.ToString());
            }
        }
        private static void traceDebug(this ILogger logger,string prefix,string keyName, string msg,string suffix="")
        {
            logger.LogDebug($"{prefix} {keyName} {msg} {suffix}");
        }
        private static string getParamMessage<T>(T inputItem)
        {
            var paramsValue = "";
            if(inputItem!=null && !(inputItem is Expression))
            {
                paramsValue = JsonConvert.SerializeObject(inputItem);
            }
            else
            {
                paramsValue = "Not log expression type or null.";
            }
            var message = $"with parameters: {paramsValue} ";
            return message;
        }
        private static string getResultMessage<T>(T resultItem)
        {
            var paramsValue = JsonConvert.SerializeObject(resultItem);
            var message = $"with results: {paramsValue} ";
            return message;
        }
    }
}