using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace StockCore.DomainEntity
{
    [DataContract]
    public class PriceCalDE
    {
        [DataMember]
        public double DiffMax{get;set;}
        [DataMember]
        public double DiffMin{get;set;}
        [DataMember]
        public double DiffAvg{get;set;}
        [DataMember]
        public double Last{get;set;}
        [DataMember]
        public double Max{get;set;}
        [DataMember]
        public double Min{get;set;}
        [DataMember]
        public double Avg{get;set;}
        [DataMember]
        public string Name{get;set;}
        public PriceCalDE(string name,double avg, double min, double max, double last)
        {
            this.Name = name;
            this.Avg = avg;
            this.Min = min;
            this.Max = max;
            this.Last = last;
            this.DiffMax = calDiff(max);
            this.DiffMin = calDiff(min);
            this.DiffAvg = calDiff(avg);
        }
        private double calDiff(double price)
        {
            return ((price - Last) / Last) * 100; ;
        }
    }
}