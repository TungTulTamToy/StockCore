using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using StockCore.Aop;
using StockCore.Aop.Mon;
using StockCore.DomainEntity;
using StockCore.Extension;

namespace StockCore.Helper
{
    public static class ValidationHelper
    {
        public static Func<ILogger,Tracer,string,string,string,bool> ValidateString(
            int errorID,
            string paramName, 
            string activateOnly="", 
            string notActivateOnly="")
        {
            return (logger,tracer,moduleName,methodName,value)=>
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throwArgumentNullException(errorID,moduleName,methodName,paramName,logger,tracer);
                }
                return (string.IsNullOrEmpty(activateOnly) || value==activateOnly) && (string.IsNullOrEmpty(notActivateOnly) || value!=notActivateOnly);
            };
        }
        public static Func<ILogger,Tracer,string,string,IEnumerable<string>,bool> ValidateStringItems(int errorID,string paramName)
        {
            return (logger,tracer,moduleName,methodName,item)=>{
                if(item==null || !item.Any() || item.Any(i=>string.IsNullOrWhiteSpace(i)))
                {
                    throwArgumentNullException(errorID,moduleName,methodName,paramName,logger,tracer);
                }
                return true;
            };
        }
        public static Func<ILogger,Tracer,string,string,Expression<Func<T,bool>>,bool> ValidateExpression<T>(int errorID,string paramName) where T:class
        {
            return (logger,tracer,moduleName,methodName,expression)=>{
                if(expression==null)
                {
                    throwArgumentNullException(errorID,moduleName,methodName,paramName,logger,tracer);
                }
                return true;
            };
        }
        public static Func<ILogger,Tracer,string,string,IEnumerable<QuoteGroup>,bool> ValidateQuoteGroups(int errorID)
        {
            return (logger,tracer,moduleName,methodName,quoteGroup)=>{
                if(quoteGroup.Any(s=>string.IsNullOrWhiteSpace(s.Name)))
                {
                    throwArgumentNullException(errorID,moduleName,methodName,"Name",logger,tracer);
                }
                if(quoteGroup.Any(s=>s.Quotes==null || !s.Quotes.Any() || s.Quotes.Any(q=>string.IsNullOrWhiteSpace(q))))
                {
                    throwArgumentNullException(errorID,moduleName,methodName,"Quotes",logger,tracer);
                }
                return true;
            };
        }
        public static Func<ILogger,Tracer,string,string,IEnumerable<T>,bool> ValidateItemsWithStringKeyField<T>(int errorID,string paramName, string notActivateOnly="") where T:IKeyField<string>
        {
            return (logger,tracer,moduleName,methodName,items)=>{
                if(items==null || !items.Any() || items.Any(i=>i==null) || items.Any(i=>string.IsNullOrWhiteSpace(i.Key)))
                {
                    throwArgumentNullException(errorID,moduleName,methodName,paramName,logger,tracer);
                }
                return string.IsNullOrEmpty(notActivateOnly) || items.All(i=>i.Key!=notActivateOnly);
            };
        }

        public static Func<ILogger,Tracer,string,string,IEnumerable<T>,bool> ValidateItemsWithStringKeyField<T>() where T:IKeyField<string>
        {
            return (logger,tracer,moduleName,methodName,items)=>items!=null && items.Any() && items.All(i=>i!=null) || items.All(i=>!string.IsNullOrWhiteSpace(i.Key));
        }

        public static Func<ILogger,Tracer,string,string,IEnumerable<T>,bool> ValidateItems<T>(int errorID,string paramName)
        {
            return (logger,tracer,moduleName,methodName,items)=>{
                if(items==null || !items.Any() || items.Any(i=>i==null))
                {
                    throwArgumentNullException(errorID,moduleName,methodName,paramName,logger,tracer);
                }
                return true;
            };
        }

        public static Func<ILogger,Tracer,string,string,IEnumerable<T>,bool> ValidateItemsNotThrowException<T>()
        {
            return (logger,tracer,moduleName,methodName,items)=> items!=null && items.Any() && !items.Any(i=>i==null);
        }

        private static void throwArgumentNullException(int errorID,string moduleName,string methodName,string paramName,ILogger logger, Tracer tracer)
        {
            var e = new ArgumentNullException(paramName,"Input cannot be null or empty.");
            ProcessFailHelper.ComposeAndThrowException(logger,e,errorID,moduleName,methodName,tracer);
        }
    }
}