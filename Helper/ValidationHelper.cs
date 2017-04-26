using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.ErrorException;
using StockCore.Extension;

namespace StockCore.Helper
{
    public class ValidationHelper
    {
        public ValidationHelper(){}
        public Func<ILogger,Tracer,string,bool> ValidateString(int errorID,string keyName)
        {
            return (logger,tracer,value)=>
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    logger.TraceError(keyName,errorID,msg:value);
                    throwArgumentNullException(keyName,errorID,tracer,true);
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,IEnumerable<string>,bool> ValidateStringItems(int errorID,string keyName)
        {
            return (logger,tracer,item)=>{
                if(item.Any(i=>string.IsNullOrWhiteSpace(i)))
                {
                    throwArgumentNullException(keyName,errorID,tracer,false);
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,Expression<Func<T,bool>>,bool> ValidateExpression<T>(int errorID,string keyName) where T:class
        {
            return (logger,tracer,expression)=>{
                if(expression==null)
                {
                    throwArgumentNullException(keyName,errorID,tracer,false);
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,IEnumerable<QuoteGroupDE>,bool> ValidateQuoteGroups(int errorID)
        {
            return (logger,tracer,quoteGroup)=>{
                if(quoteGroup.Any(s=>string.IsNullOrWhiteSpace(s.Name)))
                {
                    throwArgumentNullException("Name",errorID,tracer,false);
                }
                if(quoteGroup.Any(s=>s.Quotes==null || !s.Quotes.Any() || s.Quotes.Any(q=>string.IsNullOrWhiteSpace(q))))
                {
                    throwArgumentNullException("Quotes",errorID,tracer,false);
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,IEnumerable<T>,bool> ValidateItemsWithStringKeyField<T>(int errorID,string keyName) where T:IKeyField<string>
        {
            return (logger,tracer,items)=>{
                if(items.Any(i=>string.IsNullOrWhiteSpace(i.Key)))
                {
                    throwArgumentNullException(keyName,errorID,tracer,false);
                }
                return true;
            };
        }

        private void throwArgumentNullException(string paramName,int errorID, Tracer tracer, bool isLogged)
        {
            var e = new ArgumentNullException(paramName,"Input cannot be null or empty.");
            throw new StockCoreException(errorID,e,"",tracer)
            {
                IsLogged=isLogged
            };
        }
    }
}