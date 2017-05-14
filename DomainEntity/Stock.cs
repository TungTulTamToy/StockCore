using System;
using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public class Stock:Persistant,IKeyField<string>
    {
        public string Key
        {
            get=>Quote;
            set=>Quote=value;
        }
        public string Quote{get;set;}
        public IEnumerable<NetProfit> NetProfit{get;set;}
        public IEnumerable<GrowthDE> Growth{get;set;}
        public IEnumerable<PriceCal> PriceCal{get;set;}
        public IEnumerable<Pe> Pe{get;set;}
        public IEnumerable<Peg> Peg{get;set;}
        public IEnumerable<PeDiffPercent> PeDiffPercent{get;set;}
        public MovingAverage MovingAverage{get;set;}
        public PortCal PortCal{get;set;}
    }
}