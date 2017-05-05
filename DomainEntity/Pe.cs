using System.Runtime.Serialization;

namespace StockCore.DomainEntity
{
    public class Pe
    {
        public int Year { get; set; }
        public double Value { get; set; }
        public bool IsActual { get; set; }
    }
}