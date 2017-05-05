using System;
using System.Collections.Generic;

namespace StockCore.DomainEntity
{
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