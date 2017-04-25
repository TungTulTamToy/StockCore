using System;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class PriceDE:BaseDE,IJoinKeyField<DateTime>,IValidField,IKeyField<string>
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
        public DateTime JoinKey=>Date;
    }
}