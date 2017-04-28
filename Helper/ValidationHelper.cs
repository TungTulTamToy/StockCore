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
    public class ValidationHelper
    {
        public ValidationHelper(){}
        public Func<ILogger,Tracer,string,string,bool> ValidateString(int errorID,string paramName)
        {
            return (logger,tracer,keyName,value)=>
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throwArgumentNullException(errorID,keyName,paramName,logger,tracer);
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,string,IEnumerable<string>,bool> ValidateStringItems(int errorID,string paramName)
        {
            return (logger,tracer,keyName,item)=>{
                if(item.Any(i=>string.IsNullOrWhiteSpace(i)))
                {
                    throwArgumentNullException(errorID,keyName,paramName,logger,tracer);
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,string,Expression<Func<T,bool>>,bool> ValidateExpression<T>(int errorID,string paramName) where T:class
        {
            return (logger,tracer,keyName,expression)=>{
                if(expression==null)
                {
                    throwArgumentNullException(errorID,keyName,paramName,logger,tracer);
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,string,IEnumerable<QuoteGroupDE>,bool> ValidateQuoteGroups(int errorID)
        {
            return (logger,tracer,keyName,quoteGroup)=>{
                if(quoteGroup.Any(s=>string.IsNullOrWhiteSpace(s.Name)))
                {
                    throwArgumentNullException(errorID,keyName,"Name",logger,tracer);
                }
                if(quoteGroup.Any(s=>s.Quotes==null || !s.Quotes.Any() || s.Quotes.Any(q=>string.IsNullOrWhiteSpace(q))))
                {
                    throwArgumentNullException(errorID,"","Quotes",logger,tracer);
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,string,IEnumerable<T>,bool> ValidateItemsWithStringKeyField<T>(int errorID,string paramName) where T:IKeyField<string>
        {
            return (logger,tracer,keyName,items)=>{
                if(items.Any(i=>string.IsNullOrWhiteSpace(i.Key)))
                {
                    throwArgumentNullException(errorID,keyName,paramName,logger,tracer);
                }
                return true;
            };
        }

        private void throwArgumentNullException(int errorID,string keyName,string paramName,ILogger logger, Tracer tracer)
        {
            var e = new ArgumentNullException(paramName,"Input cannot be null or empty.");
            ProcessFail.ComposeAndThrowException(logger,e,errorID,keyName,tracer);
        }
    }
}