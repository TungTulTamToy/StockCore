using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class ConsensusDE:BaseDE,IValidField,IKeyField<string>,ILinqCriteria<int,ConsensusDE>
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
        public int JoinKey=>Year;

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