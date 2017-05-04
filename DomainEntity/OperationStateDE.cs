using System;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static StockCore.DomainEntity.Enum.StateOperation;

namespace StockCore.DomainEntity
{
    public interface IOperationState:IKeyField<string>
    {
        string Quote { get; set; }
        DateTime Date { get; set; }
        bool Activated{get;set;}
        OperationName OperationName{get;set;}
    }
    [Serializable]
    public class OperationState:Persistant,IOperationState
    {
        public string Key 
        { 
            get => Quote; 
            set => Quote=value; 
        }
        public string Quote { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        public bool Activated{get;set;}
        [BsonRepresentation(BsonType.String)]
        public OperationName OperationName{get;set;}
    }
}