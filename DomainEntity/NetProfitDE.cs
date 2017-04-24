using System.Runtime.Serialization;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class NetProfitDE
    {
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public double Value { get; set; }
        //[DataMember]
        public bool IsActual { get; set; }
    }
}