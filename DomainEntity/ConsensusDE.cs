using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class ConsensusDE:BaseDE,IValidField,IKeyField<string>,ILinqCriteria<ConsensusDE>
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
        public bool Equals(ConsensusDE other)=>this.Quote == other.Quote && this.Year == other.Year;
        public override int GetHashCode()=>this.Quote.GetHashCode()^this.Year.GetHashCode();
        public ConsensusDE Merge(ConsensusDE other)
        {
            this.Average = other.Average;
            this.High = other.High;
            this.Low = other.Low;
            this.Median = other.Median;
            return this;
        }

        public bool UpdateCondition(ConsensusDE other)=>this.IsValid != other.IsValid || this.Average != other.Average || this.High != other.High || this.Low != other.Low || this.Median != other.Median;
    }
} 