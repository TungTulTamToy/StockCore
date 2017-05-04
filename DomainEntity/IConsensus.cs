using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    public interface IConsensus:IValidField,IKeyField<string>
    {
        string Quote { get; set; }
        int Year { get; set; }
        double? Average { get; set; }
        double? High { get; set; }
        double? Low { get; set; }
        double? Median { get; set; }
    }
    [DataContract]
    public class BaseConsensus:Persistant,IConsensus
    {
        public string Key 
        { 
            get => Quote; 
            set => Quote=value; 
        }
        public string Quote { get; set; }
        public int Year { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? Average { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? High { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? Low { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? Median { get; set; }
        public bool IsValid { get; set; }
    }
    [DataContract]
    public class Consensus:BaseConsensus,ILinqCriteria<Consensus>
    {
        public bool Equals(Consensus other)=>this.Quote == other.Quote && this.Year == other.Year;
        public override int GetHashCode()=>this.Quote.GetHashCode()^this.Year.GetHashCode();
        public Consensus Merge(Consensus other)
        {
            this.Average = other.Average;
            this.High = other.High;
            this.Low = other.Low;
            this.Median = other.Median;
            return this;
        }

        public bool UpdateCondition(Consensus other)=>this.IsValid != other.IsValid || this.Average != other.Average || this.High != other.High || this.Low != other.Low || this.Median != other.Median;
    }
} 