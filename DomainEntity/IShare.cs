using System;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    public interface IShare:IValidField,IKeyField<string>
    {
        string Quote { get; set; }
        DateTime Date { get; set; }
        long? Amount { get; set; }
    }
    public class BaseShare:Persistant,IShare
    {
        public string Key 
        { 
            get => Quote; 
            set => Quote=value; 
        }
        public string Quote { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        [BsonIgnoreIfNullAttribute]
        public long? Amount { get; set; }
        public bool IsValid { get; set; }
    }
    public class Share:BaseShare,ILinqCriteria<Share>
    {
        public bool Equals(Share other)=>this.Quote == other.Quote && this.Date == other.Date;
        public override int GetHashCode()=>this.Quote.GetHashCode()^this.Date.GetHashCode();
        public Share Merge(Share other)
        {
            this.Amount = other.Amount;
            return this;
        }
        public bool UpdateCondition(Share other)=>this.IsValid != other.IsValid || this.Amount != other.Amount;
    }
}