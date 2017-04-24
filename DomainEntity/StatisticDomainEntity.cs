using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class StatisticDE:BaseDE,IJoinKeyField<int>,IValidField,IQuoteKeyField
    {
        public string Quote { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public double? Asset { get; set; }
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public double? Liability { get; set; }
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public double? Equity { get; set; }
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public double? Revenue { get; set; }
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public double? NetProfit { get; set; }
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public double? Roa { get; set; }
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public double? Roe { get; set; }
        [DataMember]
        [BsonIgnoreIfNullAttribute]
        public double? Margin { get; set; }
        public bool IsValid { get; set; }
        public int JoinKey=>Year;
    }
}