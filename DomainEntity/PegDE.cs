using System.Runtime.Serialization;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class PegDE
    {
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public double Value { get; set; }
        public bool IsActual { get; set; }
    }
}