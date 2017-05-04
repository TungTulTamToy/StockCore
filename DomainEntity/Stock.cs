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
    public static class StockExtention
    {
        public static Stock Load(
            this Stock item,
            string quote,
            IEnumerable<Price> price,
            IEnumerable<Statistic> statistic,
            IEnumerable<Share> share,
            IEnumerable<Consensus> consensus,
            IEnumerable<NetProfitDE> netprofit,
            IEnumerable<GrowthDE> growth,
            IEnumerable<PriceCal> pricecal,
            IEnumerable<PeDE> pe,
            IEnumerable<PegDE> peg,
            IEnumerable<PeDiffPercentDE> pediffpercent)
        {
            item.Quote = quote;
            item.Price = price;
            item.Statistic = statistic;
            item.Share = share;
            item.Consensus = consensus;
            item.NetProfit = netprofit;
            item.Growth = growth;
            item.PriceCal = pricecal;
            item.Pe = pe;
            item.Peg = peg;
            item.PeDiffPercent = pediffpercent;
            return item;
        }
    }
}