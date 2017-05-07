using System;
using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public static class StockExtention
    {
        public static Stock Load(
            this Stock item,
            string quote,
            IEnumerable<NetProfit> netprofit,
            IEnumerable<GrowthDE> growth,
            IEnumerable<PriceCal> pricecal,
            IEnumerable<Pe> pe,
            IEnumerable<Peg> peg,
            IEnumerable<PeDiffPercent> pediffpercent,
            MovingAverage movingAverage)
        {
            item.Quote = quote;
            item.NetProfit = netprofit;
            item.Growth = growth;
            item.PriceCal = pricecal;
            item.Pe = pe;
            item.Peg = peg;
            item.PeDiffPercent = pediffpercent;
            item.MovingAverage = movingAverage;
            return item;
        }
    }
}