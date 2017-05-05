using System;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    public interface ICache<T>:IKeyField<string>
    {
        string Group { get; set; }
        T CacheObject { get; set; }
        DateTime ExpireAt { get; set; }
    }
    public class StockCoreCache<T>:Persistant,ICache<T>
    {
        public string Key { get; set; }
        public string Group { get; set; }
        public T CacheObject { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ExpireAt { get; set; }
    }
}