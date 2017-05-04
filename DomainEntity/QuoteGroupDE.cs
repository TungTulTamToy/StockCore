using System;
using System.Collections.Generic;
using System.Linq;
using StockCore.Helper;

namespace StockCore.DomainEntity
{
    [Serializable]
    public class QuoteGroupDE:Persistant,IKeyField<string>,ILinqCriteria<QuoteGroupDE>
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
        public bool Equals(QuoteGroupDE other)=>this.Name == other.Name;
        public override int GetHashCode()=>this.Name.GetHashCode();
        public QuoteGroupDE Merge(QuoteGroupDE other)
        {
            this.Quotes = other.Quotes;
            return this;
        }
        public bool UpdateCondition(QuoteGroupDE other)
        {
            return this.Quotes.Except(other.Quotes).Any() || other.Quotes.Except(this.Quotes).Any();
        }
    }
}