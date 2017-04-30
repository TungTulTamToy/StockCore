using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StockCore.Aop.Mon;
using StockCore.DomainEntity;
using StockCore.Helper;

namespace StockCore.Extension
{
    public static class LoggerExtension
    {
        public static void TraceBegin<T>(this ILogger logger,string keyName,T inputItem,bool showParams,bool showInputCount)
        {
            var sb = new StringBuilder();
            var key = getKey(inputItem);
            if(key !=null)
            {
                sb.Append($"Key: [{key}] ");
            }
            if(showParams)
            {
                sb.Append(getParamMessage(inputItem));
            }
            if(showInputCount && inputItem!=null && inputItem is IEnumerable)
            {
                int count = 0;
                var items = inputItem as IEnumerable;
                var keys = new List<string>();                
                foreach (var item in items)
                {
                    var tempKey = getKey(item);
                    if(tempKey != null && !keys.Contains(tempKey))
                    {
                        keys.Add(tempKey);
                        sb.Append($"Sub Key: [{tempKey}] ");
                    }
                    count++;
                }
                sb.Append($"with Count: {count}");
            }
            logger.traceDebug("--->", keyName, sb.ToString());
        }
        private static string getKey<T>(T inputItem)
        {
            string key = null;
            if(inputItem !=null && inputItem is IKeyField<string>)
            {
                var k = inputItem as IKeyField<string>;
                key = k.Key;
            }
            return key;
        }
        public static void TraceEnd<T,TOut>(
            this ILogger logger,
            string keyName,
            T inputItem=default(T),
            TOut returnItem=default(TOut),
            bool showParams=false,
            bool showResult=false)
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
        public static void TraceMessage(this ILogger logger,string keyName,string msg)
        {
            logger.traceDebug("****",keyName, msg,"****");
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
            var paramsValue = JsonHelper.SerializeObject(inputItem);
            var message = $"with parameters: {paramsValue} ";
            return message;
        }
        private static string getResultMessage<T>(T resultItem)
        {
            var paramsValue = JsonHelper.SerializeObject(resultItem);
            var message = $"with results: {paramsValue} ";
            return message;
        }
    }
}