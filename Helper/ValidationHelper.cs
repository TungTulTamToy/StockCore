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
        public ValidationHelper()
        {
        }
        public Func<ILogger,Tracer,string,bool> ValidateString(int errorID,string keyName)
        {
            return (logger,tracer,value)=>
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    logger.TraceError(keyName,errorID,msg:value);
                    throw new StockCoreArgumentNullException(errorID,$"{keyName}","Input cannot be null or empty.");
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,IEnumerable<string>,bool> ValidateStringItems(int errorID,string keyName)
        {
            return (logger,tracer,item)=>{
                if(item.Any(i=>string.IsNullOrWhiteSpace(i)))
                {
                    throw new StockCoreArgumentNullException(errorID,$"{keyName}","Input cannot be null or empty");
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,Expression<Func<T,bool>>,bool> ValidateExpression<T>(int errorID,string keyName) where T:class
        {
            return (logger,tracer,expression)=>{
                if(expression==null)
                {
                    throw new StockCoreArgumentNullException(errorID,$"{keyName}","Input cannot be null or empty");
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,IEnumerable<QuoteGroupDE>,bool> ValidateQuoteGroups(int errorID)
        {
            return (logger,tracer,quoteGroup)=>{
                if(quoteGroup.Any(s=>string.IsNullOrWhiteSpace(s.Name)))
                {
                    throw new StockCoreArgumentNullException(errorID,"Name","Input cannot be null or empty");
                }
                if(quoteGroup.Any(s=>s.Quotes==null || !s.Quotes.Any() || s.Quotes.Any(q=>string.IsNullOrWhiteSpace(q))))
                {
                    throw new StockCoreArgumentNullException(errorID,"Quotes","Input cannot be null or empty");
                }
                return true;
            };
        }
        public Func<ILogger,Tracer,IEnumerable<T>,bool> ValidateItemsWithStringKeyField<T>(int errorID,string keyName) where T:IKeyField<string>
        {
            return (logger,tracer,items)=>{
                if(items.Any(i=>string.IsNullOrWhiteSpace(i.Key)))
                {
                    throw new StockCoreArgumentNullException(errorID,$"{keyName}","Input cannot be null or empty");
                }
                return true;
            };
        }
    }
}