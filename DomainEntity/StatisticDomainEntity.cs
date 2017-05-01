using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class StatisticDE:BaseDE,IValidField,IKeyField<string>,ILinqCriteria<int,StatisticDE>
    {
        public string Key 
        { 
            get => Quote; 
            set => Quote=value; 
        }
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
        public StatisticDE Merge(StatisticDE other)
        {
            this.Asset = other.Asset;
            this.Liability = other.Liability;
            this.Equity = other.Equity;
            this.Revenue = other.Revenue;
            this.NetProfit = other.NetProfit;
            this.Roa = other.Roa;
            this.Roe = other.Roe;
            this.Margin = other.Margin;
            return this;
        }
        public bool UpdateCondition(StatisticDE other)=>this.IsValid != other.IsValid || this.Asset != other.Asset || this.Liability != other.Liability || this.Equity != other.Equity || this.Revenue != other.Revenue || this.NetProfit != other.NetProfit || this.Roa != other.Roa || this.Roe != other.Roe || this.Margin != other.Margin;
    }
}