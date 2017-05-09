using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using StockCore.Helper;
using StockCore.DomainEntity.Enum;
using MongoDB.Bson;
using static StockCore.DomainEntity.Enum.GroupCategory;

namespace StockCore.DomainEntity
{
    public interface IQuoteGroup:IKeyField<string>,IPersistant
    {
        string Name { get; set; }
        int Order{get;set;}
        bool IsDefault{get;set;}
        Category Category{get;set;}
    }
    public interface IStaticQuoteGroup:IQuoteGroup
    {
        IEnumerable<string> Quotes{get;set;}
    }
    public interface IDynamicQuoteGroup:IQuoteGroup
    {
        IEnumerable<Stock> FilterGroupByCriteria(IEnumerable<Stock> items);
    }
    [Serializable]
    public class BaseQuoteGroup:Persistant,IStaticQuoteGroup
    {
        public string Name { get; set; }
        public int Order{get;set;}
        public bool IsDefault{get;set;}
        public IEnumerable<string> Quotes{get;set;}
        [BsonRepresentation(BsonType.String)]
        public Category Category{get;set;}
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
    public class DynamicQuoteGroup:QuoteGroup,IDynamicQuoteGroup
    {
        private readonly Func<Stock,bool> stockCriteria;
        public DynamicQuoteGroup(Func<Stock,bool> stockCriteria)
        {
            this.stockCriteria=stockCriteria;
        }
        public IEnumerable<Stock> FilterGroupByCriteria(IEnumerable<Stock> items)=> items.Where(item=>stockCriteria(item));
    }
}