using System.Runtime.Serialization;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class PeDiffPercentDE
    {
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public double Value { get; set; }
    }
}