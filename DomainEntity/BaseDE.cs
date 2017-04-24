using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace StockCore.DomainEntity
{
    [Serializable]
    public class BaseDE
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        [BsonIgnoreIfNullAttribute]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedOn { get; set; }
        [BsonIgnoreIfNullAttribute]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? CreatedOn { get; set; }
        [BsonIgnoreIfNullAttribute]
        public string CreateBy { get; set; }
        [BsonIgnoreIfNullAttribute]
        public string UpdateBy { get; set; }
    }
}