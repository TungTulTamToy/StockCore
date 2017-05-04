using System;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    public class CacheDE<T>:BaseDE,IKeyField<string> where T:IBaseDE
    {
        public string Key { get; set; }
        public string Group { get; set; }
        public T CacheObject { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ExpireAt { get; set; }
    }
}