using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public class StockDE:IQuoteKeyField
    {
        public string Quote=>quote;
        public IEnumerable<PriceDE> Price=>price;
        public IEnumerable<StatisticDE> Statistic=>statistic;
        public IEnumerable<ShareDE> Share=>share;
        public IEnumerable<ConsensusDE> Consensuse=>consensus;
        public IEnumerable<NetProfitDE> NetProfit=>netprofit;
        public IEnumerable<GrowthDE> Growth=>growth;
        public IEnumerable<PriceCalDE> PriceCal=>pricecal;
        public IEnumerable<PeDE> Pe=>pe;
        public IEnumerable<PegDE> Peg=>peg;
        public IEnumerable<PeDiffPercentDE> PeDiffPercent=>pediffpercent;
        private readonly string quote;
        private readonly IEnumerable<PriceDE> price;
        private readonly IEnumerable<StatisticDE> statistic;
        private readonly IEnumerable<ShareDE> share;
        private readonly IEnumerable<ConsensusDE> consensus;
        private readonly IEnumerable<NetProfitDE> netprofit;
        private readonly IEnumerable<GrowthDE> growth;
        private readonly IEnumerable<PriceCalDE> pricecal;
        private readonly IEnumerable<PeDE> pe;
        private readonly IEnumerable<PegDE> peg;
        private readonly IEnumerable<PeDiffPercentDE> pediffpercent;
        public StockDE(
            string quote,
            IEnumerable<PriceDE> price,
            IEnumerable<StatisticDE> statistic,
            IEnumerable<ShareDE> share,
            IEnumerable<ConsensusDE> consensus,
            IEnumerable<NetProfitDE> netprofit,
            IEnumerable<GrowthDE> growth,
            IEnumerable<PriceCalDE> pricecal,
            IEnumerable<PeDE> pe,
            IEnumerable<PegDE> peg,
            IEnumerable<PeDiffPercentDE> pediffpercent)
        {
            this.quote = quote;
            this.price = price;
            this.statistic = statistic;
            this.share = share;
            this.consensus = consensus;
            this.netprofit = netprofit;
            this.growth = growth;
            this.pricecal = pricecal;
            this.pe = pe;
            this.peg = peg;
            this.pediffpercent = pediffpercent;
        }
    }
}