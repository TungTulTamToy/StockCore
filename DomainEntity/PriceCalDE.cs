using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class PriceCalDE
    {
        [DataMember]
        public double DiffMax=>calDiff(max);
        [DataMember]
        public double DiffMin=>calDiff(min);
        [DataMember]
        public double DiffAvg=>calDiff(avg);
        [DataMember]
        public double Last=>last;
        [DataMember]
        public double Max=>max;
        [DataMember]
        public double Min=>min;
        [DataMember]
        public double Avg=>avg;

        [DataMember]
        public string Name=>name;
        private readonly double last;
        private readonly double max;
        private readonly double min;
        private readonly double avg;
        private readonly string name;

        public PriceCalDE(string name,double avg, double min, double max, double last)
        {
            this.name = name;
            this.avg = avg;
            this.min = min;
            this.max = max;
            this.last = last;
        }
        private double calDiff(double price)
        {
            return ((price - Last) / Last) * 100; ;
        }
    }
}