using System;
using System.Collections.Generic;
using System.Linq;
using StockCore.Helper;

namespace StockCore.DomainEntity
{
    public interface IQuoteGroup:IKeyField<string>
    {
        string Name { get; set; }
        IEnumerable<string> Quotes{get;set;}
        int Order{get;set;}
        bool IsDefault{get;set;}
    }
    [Serializable]
    public class BaseQuoteGroup:Persistant,IQuoteGroup
    {
        public string Name { get; set; }
        public IEnumerable<string> Quotes{get;set;}
        public int Order{get;set;}
        public bool IsDefault{get;set;}
        public string Key 
        { 
            get => Name; 
            set => Name = value; 
        }
    }
    public class QuoteGroup:BaseQuoteGroup,ILinqCriteria<QuoteGroup>
    {
        public bool Equals(QuoteGroup other)=>this.Name == other.Name;
        public override int GetHashCode()=>this.Name.GetHashCode();
        public QuoteGroup Merge(QuoteGroup other)
        {
            this.Quotes = other.Quotes;
            return this;
        }
        public bool UpdateCondition(QuoteGroup other)
        {
            return this.Quotes.Except(other.Quotes).Any() || other.Quotes.Except(this.Quotes).Any();
        }
    }
}