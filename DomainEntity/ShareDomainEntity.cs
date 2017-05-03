using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class ShareDE:BaseDE,IValidField,IKeyField<string>,ILinqCriteria<ShareDE>
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
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public long? Amount { get; set; }
        public bool IsValid { get; set; }
        public bool Equals(ShareDE other)=>this.Quote == other.Quote && this.Date == other.Date;
        public override int GetHashCode()=>this.Quote.GetHashCode()^this.Date.GetHashCode();
        public ShareDE Merge(ShareDE other)
        {
            this.Amount = other.Amount;
            return this;
        }
        public bool UpdateCondition(ShareDE other)=>this.IsValid != other.IsValid || this.Amount != other.Amount;
    }
}