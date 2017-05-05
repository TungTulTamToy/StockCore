using System.Runtime.Serialization;

namespace StockCore.DomainEntity
{
    public class Peg
    {
        public int Year { get; set; }
        public double Value { get; set; }
        public bool IsActual { get; set; }
    }
}