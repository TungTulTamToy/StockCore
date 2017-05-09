using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using StockCore.Aop.Mon;
using StockCore.DomainEntity;
using StockCore.Helper;

namespace StockCore.Extension
{
    public static class LoggerExtension
    {
        public static void TraceBegin<T>(this ILogger logger,string keyName,T inputItem,bool showParams,bool showCount)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            traceParam(logger, inputItem, showParams, sb, keyName);
            traceCount(inputItem, showCount, sb,"Input Count");
            logger.traceDebug("--->", keyName, sb.ToString());
        }
        public static void TraceEnd<T,TOut>(this ILogger logger,string keyName,T inputItem,TOut returnItem,string perfMsg,bool showParams,bool showResult,bool showCount)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            traceParam(logger, inputItem, showParams, sb, keyName);
            traceCount(inputItem, showCount, sb, "Input Count");
            traceResult(logger, returnItem, showResult, sb, keyName);
            traceCount(returnItem, showCount, sb, "Output Count");
            tracePerformanceMeasurement(perfMsg, sb);
            logger.traceDebug("<---", keyName, sb.ToString());
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
                traceException(ex, sb);
                logger.LogError(sb.ToString());
            }
        }
        private static void tracePerformanceMeasurement(string perfMsg, StringBuilder sb)
        {
            if (!string.IsNullOrEmpty(perfMsg))
            {
                sb.Append($"ElapsedMilliseconds: {perfMsg}");
                sb.AppendLine();
            }
        }
        private static void traceResult<TOut>(ILogger logger, TOut returnItem, bool showResult, StringBuilder sb,string keyName)
        {
            if (showResult)
            {
                sb.Append($"Result: {JsonHelper.SerializeObject(returnItem,logger,keyName)}");
                sb.AppendLine();
            }
        }
        private static void traceException(StockCoreException ex, StringBuilder sb)
        {
            if (ex != null)
            {
                sb.Append($"Exception: {ex.Message} ");
                sb.AppendLine();
                sb.Append($"Stack: {ex.StackTrace} ");
                sb.AppendLine();
                traceInnerException(ex, sb);
            }
        }
        private static void traceInnerException(StockCoreException ex, StringBuilder sb)
        {
            if (ex.InnerException != null)
            {
                sb.Append($"Inner Exception: {ex.InnerException.Message} ");
                sb.AppendLine();
                sb.Append($"Inner Stack: {ex.InnerException.StackTrace} ");
                sb.AppendLine();
            }
        }
        private static int? getCount<T>(T items)
        {
            int? count = null;
            if(items !=  null && !(items is string) && items is IEnumerable)
            {
                count = 0;
                var castItems = items as IEnumerable;
                foreach (var item in castItems)
                {
                    count++;
                }
            }
            return count;
        }
        private static void traceDebug(this ILogger logger,string prefix,string keyName, string msg,string suffix="")
        {
            logger.LogDebug($"{prefix} {keyName} {msg} {suffix}");
        }
        private static void traceParam<T>(ILogger logger, T inputItem, bool showParams, StringBuilder sb,string keyName)
        {
            if (showParams)
            {
                sb.Append($"Parameter: {JsonHelper.SerializeObject(inputItem,logger,keyName)}");
                sb.AppendLine();
            }
            else if (inputItem != null && (inputItem is IKeyField<string> || inputItem is IEnumerable))
            {
                traceParamKey(inputItem, sb);
            }
        }
        private static void traceParamKey<T>(T inputItem, StringBuilder sb)
        {
            if (inputItem is IKeyField<string>)
            {
                var key = inputItem as IKeyField<string>;
                sb.Append($"Parameter Key: {key.Key}");
            }
            else if (inputItem is IEnumerable)
            {
                var items = inputItem as IEnumerable;
                var index = 0;
                var keyList = new List<string>();
                foreach (var item in items)
                {
                    traceSubParamKey(sb, index, keyList, item);
                    index++;
                }
            }
            sb.AppendLine();
        }
        private static void traceSubParamKey(StringBuilder sb, int index, List<string> keyList, object item)
        {
            if (item is IKeyField<string>)
            {
                var key = item as IKeyField<string>;
                if (!(keyList.Contains(key.Key)))
                {
                    if (index == 0)
                    {
                        sb.Append($"Parameter Keys : ");
                    }
                    else
                    {
                        sb.Append($", ");
                    }
                    sb.Append($"[{key.Key}]");
                    keyList.Add(key.Key);
                }
            }
        }
        private static void traceCount<T>(T inputItem, bool showCount, StringBuilder sb, string prefix)
        {
            if (showCount)
            {
                var count = getCount(inputItem);
                if (count != null)
                {
                    sb.Append($"{prefix}: {count}");
                    sb.AppendLine();
                }
            }
        }
    }
}