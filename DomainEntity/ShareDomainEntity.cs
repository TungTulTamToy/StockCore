using System;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class ShareDE:BaseDE,IJoinKeyField<DateTime>,IValidField,IQuoteKeyField
    {
        public string Quote { get; set; }
        [DataMember]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public long? Amount { get; set; }
        public bool IsValid { get; set; }
        public DateTime JoinKey=>Date;
    }
}