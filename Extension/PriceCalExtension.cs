using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace StockCore.DomainEntity
{
    public static class PriceCalExtension
    {
        public static PriceCal Load(this PriceCal item,string name,double avg, double min, double max, double last)
        {
            item.Name = name;
            item.Avg = avg;
            item.Min = min;
            item.Max = max;
            item.Last = last;
            item.DiffMax = calDiff(max,last);
            item.DiffMin = calDiff(min,last);
            item.DiffAvg = calDiff(avg,last);
            return item;
        }
        private static double calDiff(double price,double last)=>((price - last) / last) * 100;
    }
}