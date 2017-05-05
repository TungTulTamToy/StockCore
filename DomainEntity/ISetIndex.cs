using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    public interface ISetIndex:IValidField
    {
        DateTime Date { get; set; }
        double? Index { get; set; }
    }
    public class BaseSetIndex:Persistant,ISetIndex
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        [BsonIgnoreIfNullAttribute]
        public double? Index { get; set; }
        public bool IsValid { get; set; }
    }
    public class SetIndex:BaseSetIndex,ILinqCriteria<SetIndex>
    {
        public bool Equals(SetIndex other)=>this.Date == other.Date;
        public override int GetHashCode()=>this.Date.GetHashCode();
        public SetIndex Merge(SetIndex other)
        {
            this.Index = other.Index;
            return this;
        }
        public bool UpdateCondition(SetIndex other)=>this.IsValid != other.IsValid || this.Index != other.Index;
    }
}