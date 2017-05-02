using System;
using System.Collections.Generic;
using System.Linq;

namespace StockCore.DomainEntity
{
    [Serializable]
    public class QuoteGroupDE:BaseDE,IKeyField<string>,ILinqCriteria<string,QuoteGroupDE>
    {
        public string Name { get; set; }
        public IEnumerable<string> Quotes{get;set;}
        public int Order{get;set;}
        public bool IsDefault{get;set;}
        public string JoinKey=>Name;
        public string Key 
        { 
            get => Name; 
            set => Name = value; 
        }
        public QuoteGroupDE Merge(QuoteGroupDE other)
        {
            this.Quotes = other.Quotes;
            return this;
        }

        public bool UpdateCondition(QuoteGroupDE other)=>this.Quotes.Except(other.Quotes).Any() || other.Quotes.Except(this.Quotes).Any();
    }
}