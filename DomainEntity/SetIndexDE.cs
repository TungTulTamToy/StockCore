using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class SetIndexDE:Persistant,IValidField,ILinqCriteria<SetIndexDE>
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public double? Index { get; set; }
        public bool IsValid { get; set; }
        public bool Equals(SetIndexDE other)=>this.Date == other.Date;
        public override int GetHashCode()=>this.Date.GetHashCode();
        public SetIndexDE Merge(SetIndexDE other)
        {
            this.Index = other.Index;
            return this;
        }
        public bool UpdateCondition(SetIndexDE other)=>this.IsValid != other.IsValid || this.Index != other.Index;
    }
}