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
        public IEnumerable<Price> Price{get;set;}
        public IEnumerable<Statistic> Statistic{get;set;}
        public IEnumerable<Share> Share{get;set;}
        public IEnumerable<Consensus> Consensus{get;set;}
        public IEnumerable<NetProfitDE> NetProfit{get;set;}
        public IEnumerable<GrowthDE> Growth{get;set;}
        public IEnumerable<PriceCal> PriceCal{get;set;}
        public IEnumerable<PeDE> Pe{get;set;}
        public IEnumerable<PegDE> Peg{get;set;}
        public IEnumerable<PeDiffPercentDE> PeDiffPercent{get;set;}
    }
}