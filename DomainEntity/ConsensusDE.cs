using System;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class ConsensusDE:BaseDE,IJoinKeyField<int>,IValidField,IKeyField<string>
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
    }
}