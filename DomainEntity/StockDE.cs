using System;
using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public class StockDE:Persistant,IKeyField<string>
    {
        public string Key
        {
            get=>Quote;
            set=>Quote=value;
        }
        public string Quote{get;set;}
        public IEnumerable<Price> Price{get;set;}
        public IEnumerable<StatisticDE> Statistic{get;set;}
        public IEnumerable<Share> Share{get;set;}
        public IEnumerable<Consensus> Consensus{get;set;}
        public IEnumerable<NetProfitDE> NetProfit{get;set;}
        public IEnumerable<GrowthDE> Growth{get;set;}
        public IEnumerable<PriceCalDE> PriceCal{get;set;}
        public IEnumerable<PeDE> Pe{get;set;}
        public IEnumerable<PegDE> Peg{get;set;}
        public IEnumerable<PeDiffPercentDE> PeDiffPercent{get;set;}
        public StockDE(
            string quote,
            IEnumerable<Price> price,
            IEnumerable<StatisticDE> statistic,
            IEnumerable<Share> share,
            IEnumerable<Consensus> consensus,
            IEnumerable<NetProfitDE> netprofit,
            IEnumerable<GrowthDE> growth,
            IEnumerable<PriceCalDE> pricecal,
            IEnumerable<PeDE> pe,
            IEnumerable<PegDE> peg,
            IEnumerable<PeDiffPercentDE> pediffpercent)
        {
            this.Quote = quote;
            this.Price = price;
            this.Statistic = statistic;
            this.Share = share;
            this.Consensus = consensus;
            this.NetProfit = netprofit;
            this.Growth = growth;
            this.PriceCal = pricecal;
            this.Pe = pe;
            this.Peg = peg;
            this.PeDiffPercent = pediffpercent;
        }
    }
}