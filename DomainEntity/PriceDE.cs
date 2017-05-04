using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class PriceDE:Persistant,IValidField,IKeyField<string>,ILinqCriteria<PriceDE>
    {
        public string Key 
        { 
            get => Quote; 
            set => Quote=value; 
        }
        public string Quote { get; set; }
        [DataMember]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? Open { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? High { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? Low { get; set; }
        [BsonIgnoreIfNullAttribute]
        [DataMember]
        public double? Close { get; set; }
        [BsonIgnoreIfNullAttribute]
        [DataMember]
        public double? Amount { get; set; }
        [BsonIgnoreIfNullAttribute]
        [DataMember]
        public double? Volumn { get; set; }
        public bool IsValid { get; set; }
        public bool Equals(PriceDE other)=>this.Quote == other.Quote && this.Date == other.Date;
        public override int GetHashCode()=>this.Quote.GetHashCode()^this.Date.GetHashCode();
        public PriceDE Merge(PriceDE other)
        {
            this.Amount = other.Amount;
            this.Close = other.Close;
            this.High = other.High;
            this.Low = other.Low;
            this.Volumn = other.Volumn;
            return this;
        }
        public bool UpdateCondition(PriceDE other)=>this.IsValid != other.IsValid || this.Amount != other.Amount || this.Close != other.Close || this.High != other.High || this.Low != other.Low || this.Volumn != other.Volumn;
    }
}