using System;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class SetIndexDE:BaseDE,IJoinKeyField<DateTime>,IValidField
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public double? Index { get; set; }
        public bool IsValid { get; set; }
        public DateTime JoinKey=>Date;
    }
}