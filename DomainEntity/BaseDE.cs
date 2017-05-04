using System;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace StockCore.DomainEntity
{
    public interface IBaseDE
    {
        string Id { get; set; }
        DateTime? UpdatedOn { get; set; }
        DateTime? CreatedOn { get; set; }
        string CreateBy { get; set; }
        string UpdateBy { get; set; }
    }
    [Serializable]
    public class BaseDE:IBaseDE
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