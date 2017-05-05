using System;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    public interface IPrice:IValidField,IKeyField<string>
    {
        string Quote { get; set; }
        DateTime Date { get; set; }
        double? Open { get; set; }
        double? High { get; set; }
        double? Low { get; set; }
        double? Close { get; set; }
        double? Amount { get; set; }
        double? Volumn { get; set; }
    }
    public class BasePrice:Persistant,IPrice
    {
        public string Key 
        { 
            get => Quote; 
            set => Quote=value; 
        }
        public string Quote { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? Open { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? High { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? Low { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? Close { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? Amount { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? Volumn { get; set; }
        public bool IsValid { get; set; }
    }
    public class Price:BasePrice,ILinqCriteria<Price>
    {
        public bool Equals(Price other)=>this.Quote == other.Quote && this.Date == other.Date;
        public override int GetHashCode()=>this.Quote.GetHashCode()^this.Date.GetHashCode();
        public Price Merge(Price other)
        {
            this.Amount = other.Amount;
            this.Close = other.Close;
            this.High = other.High;
            this.Low = other.Low;
            this.Volumn = other.Volumn;
            return this;
        }
        public bool UpdateCondition(Price other)=>this.IsValid != other.IsValid || this.Amount != other.Amount || this.Close != other.Close || this.High != other.High || this.Low != other.Low || this.Volumn != other.Volumn;
    }
}