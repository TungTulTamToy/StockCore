using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace StockCore.DomainEntity
{
    public interface IStatistic:IValidField,IKeyField<string>
    {
        string Quote { get; set; }
        int Year { get; set; }
        double? Asset { get; set; }
        double? Liability { get; set; }
        double? Equity { get; set; }
        double? Revenue { get; set; }
        double? NetProfit { get; set; }
        double? Roa { get; set; }
        double? Roe { get; set; }
        double? Margin { get; set; }
    }
    [DataContract]
    public class BaseStatistic:Persistant,IStatistic
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
    }
    public class Statistic:BaseStatistic,ILinqCriteria<Statistic>
    {
        public bool Equals(Statistic other)
        {
            return this.Quote == other.Quote && this.Year == other.Year;
        }
        public override int GetHashCode()=>this.Quote.GetHashCode() ^ this.Year.GetHashCode();
        public Statistic Merge(Statistic other)
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
        public bool UpdateCondition(Statistic other)=>this.IsValid != other.IsValid || this.Asset != other.Asset || this.Liability != other.Liability || this.Equity != other.Equity || this.Revenue != other.Revenue || this.NetProfit != other.NetProfit || this.Roa != other.Roa || this.Roe != other.Roe || this.Margin != other.Margin;
    }
}