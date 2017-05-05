using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace StockCore.DomainEntity
{
    public class PriceCal
    {
        public double DiffMax{get;set;}
        public double DiffMin{get;set;}
        public double DiffAvg{get;set;}
        public double Last{get;set;}
        public double Max{get;set;}
        public double Min{get;set;}
        public double Avg{get;set;}
        public string Name{get;set;}        
    }
}