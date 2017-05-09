using System;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StockCore.Extension;

namespace StockCore.Helper
{
    public static class JsonHelper
    {
        public static string SerializeObject<T>(T item, ILogger logger, string keyName)
        {
            var paramsValue = "";
            if(item!=null && !(item is Expression))
            {
                try
                {
                    paramsValue = JsonConvert.SerializeObject(item);
                }
                catch(Exception ex)
                {
                    var sb = new StringBuilder();
                    sb.Append($"Cannot serialize object: Type:{item.GetType()}");
                    sb.AppendLine();
                    sb.Append($"Error:{ex.Message}");
                    sb.AppendLine();
                    sb.Append($"Trace:{ex.StackTrace}");
                    sb.AppendLine();
                    logger.TraceMessage(keyName,sb.ToString());
                }
            }
            return paramsValue;
        }
    }
}