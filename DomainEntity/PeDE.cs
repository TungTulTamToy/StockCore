using System.Runtime.Serialization;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class PeDE
    {
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public double Value { get; set; }
        public bool IsActual { get; set; }
    }
}