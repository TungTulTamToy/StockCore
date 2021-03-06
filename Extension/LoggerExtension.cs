using System;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StockCore.DomainEntity;

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
        public static void TraceError(this ILogger logger,string keyName,int registrationID,string msg="")
        {
            logger.LogError($"XXXXX Exception at [{keyName}] with message: [{msg}] XXXXX");
        }
        public static void TraceError(this ILogger logger,string keyName,int registrationID,string msg="",Exception ex=null)
        {
            if(ex!=null)
            {
                logger.LogError($"!!!!! [{keyName}] with message: [{msg}] with exception: {ex.Message} with stack: {ex.StackTrace} !!!!!");
            }
        }
        private static void traceDebug(this ILogger logger,string prefix,string keyName, string msg,string suffix="")
        {
            logger.LogDebug($"{prefix} {keyName} {msg} {suffix}");
        }
        private static string getParamMessage<T>(T inputItem)
        {
            var paramsValue = JsonConvert.SerializeObject(inputItem);
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