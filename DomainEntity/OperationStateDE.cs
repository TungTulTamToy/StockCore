using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static StockCore.DomainEntity.Enum.StateOperation;

namespace StockCore.DomainEntity
{
    [Serializable]
    public class OperationStateDE:BaseDE,IQuoteKeyField
    {
        public string Quote { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        public bool OperationState{get;set;}
        [BsonRepresentation(BsonType.String)]
        public OperationName OperationName{get;set;}
    }
}