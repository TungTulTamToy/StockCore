using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public static void TraceBegin<T>(this ILogger logger,string keyName,T inputItem,bool showParams,bool showCount)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            traceParam(inputItem, showParams, sb);
            traceCount(inputItem, showCount, sb,"Input Count");
            logger.traceDebug("--->", keyName, sb.ToString());
        }
        public static void TraceEnd<T,TOut>(this ILogger logger,string keyName,T inputItem,TOut returnItem,string perfMsg,bool showParams,bool showResult,bool showCount)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            traceParam(inputItem, showParams, sb);
            traceCount(inputItem, showCount, sb,"Input Count");
            if(showResult)
            {
                sb.Append($"Result: {JsonHelper.SerializeObject(returnItem)}");
                sb.AppendLine();
            }
            traceCount(returnItem, showCount, sb,"Output Count");
            if(!string.IsNullOrEmpty(perfMsg))
            {
                sb.Append($"ElapsedMilliseconds: {perfMsg}");
                sb.AppendLine();
            }
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
        private static void traceParam<T>(T inputItem, bool showParams, StringBuilder sb)
        {
            if (showParams)
            {
                sb.Append($"Parameter: {JsonHelper.SerializeObject(inputItem)}");
                sb.AppendLine();
            }
            else if (inputItem != null && (inputItem is IKeyField<string> || inputItem is IEnumerable))
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
                        if (item is IKeyField<string>)
                        {
                            var key = item as IKeyField<string>;
                            if (!(keyList.Contains(key.Key)))
                            {
                                if(index==0)
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
                        index++;
                    }
                }
                sb.AppendLine();
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