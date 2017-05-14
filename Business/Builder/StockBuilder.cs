using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo;
using StockCore.DomainEntity;
using System;
using StockCore.Extension;
using StockCore.Helper;

namespace StockCore.Business.Builder
{
    public class StockBuilder : IBuilder<string, Stock>
    {
        private readonly ILogger logger;
        private readonly IGetByKey<IEnumerable<Share>,string> shareRepo;
        private readonly IGetByKey<IEnumerable<Statistic>,string> statisticRepo;
        private readonly IGetByKey<IEnumerable<Consensus>,string> consensusRepo;
        private readonly IGetByKey<IEnumerable<Price>,string> priceRepo;
        private readonly IBuilder<IEnumerable<Price>, IEnumerable<PriceCal>> priceCalBuilder;
        private readonly IGetByKey<IEnumerable<QuoteMovement>,string> quoteMovementRepo;
        private readonly DateTime asOfDate;
        public StockBuilder(
            ILogger logger,
            IGetByKey<IEnumerable<Share>,string> shareRepo,
            IGetByKey<IEnumerable<Statistic>,string> statisticRepo,
            IGetByKey<IEnumerable<Consensus>,string> consensusRepo,
            IGetByKey<IEnumerable<Price>,string> priceRepo,
            IBuilder<IEnumerable<Price>, IEnumerable<PriceCal>> priceCalBuilder,
            IGetByKey<IEnumerable<QuoteMovement>,string> quoteMovementRepo,
            DateTime asOfDate)
        {
            this.logger = logger;
            this.shareRepo = shareRepo;
            this.statisticRepo = statisticRepo;
            this.consensusRepo = consensusRepo;
            this.priceRepo = priceRepo;
            this.priceCalBuilder = priceCalBuilder;
            this.quoteMovementRepo = quoteMovementRepo;
            this.asOfDate = asOfDate;
        }
        public async Task<Stock> BuildAsync(string quote)
        {
            var shareTask = shareRepo.GetByKeyAsync(quote);
            var statisticTask = statisticRepo.GetByKeyAsync(quote);
            var consensusTask = consensusRepo.GetByKeyAsync(quote);
            var priceTask = priceRepo.GetByKeyAsync(quote);
            var quoteMovementTask = quoteMovementRepo.GetByKeyAsync(quote);

            var share = await shareTask;
            var statistic = await statisticTask;
            var consensus = await consensusTask;
            var price = await priceTask;
            var quoteMovement = await quoteMovementTask;

            var priceCal = priceCalBuilder.Build(price);
            var movingAverage = calculateMACD(price);     

            var shareByYear = calculateShareByYear(share);   

            var netProfit = calculateNetProfit(statistic,consensus,shareByYear);  
            var growth = calculateGrowth(netProfit);

            var pe = calculatePe(price,statistic,shareByYear,consensus);
            var peg = calculatePeg(pe,growth);
            var ped = calculatePeDiffPercent(pe);
            
            var portCal = calculateMinPriceDiffPercent(price,quoteMovement);

            var stock = new Stock().Load(quote,netProfit,growth,priceCal,pe,peg,ped,movingAverage,portCal);         

            return stock;
        }
        private PortCal calculateMinPriceDiffPercent(IEnumerable<Price> price, IEnumerable<QuoteMovement> quoteMovement)
        {
            PortCal portCal = null;
            if(price!=null && price.Any() && quoteMovement!=null && quoteMovement.Any())
            {
                var lastPrice = price.OrderByDescending(p=>p.Date).FirstOrDefault().Close;
                var buyPrice = quoteMovement
                    .Where(q=>q.Transaction!=null&&q.Transaction.Any())
                    .SelectMany(q=>q.Transaction)
                    .Where(t=>t.BuyOrder!=null && t.SellOrder==null)
                    .Select(t=>t.BuyOrder.Price);
                if(buyPrice!=null && buyPrice.Any())
                {
                    var minPrice = buyPrice.OrderBy(p=>p).FirstOrDefault();
                    var maxPrice = buyPrice.OrderByDescending(p=>p).FirstOrDefault();
                    portCal = new PortCal()
                    {
                        MinPriceDiffPercent = ((lastPrice-minPrice)/minPrice)*100,
                        MaxPriceDiffPercent = ((lastPrice-maxPrice)/maxPrice)*100
                    };
                }
            }
            return portCal;
        }
        private IEnumerable<PeDiffPercent> calculatePeDiffPercent(IEnumerable<Pe> pe)
        {
            IEnumerable<PeDiffPercent> ped = null;
            if(pe!=null && pe.Any())
            {
                int limit = 7;
                var focusPEs = pe.Where(p=>p.Value>0).Take(limit);
                if(focusPEs!=null && focusPEs.Any())
                {
                    var minYear = focusPEs.Min(p => p.Year);
                    var weightedPE = focusPEs.WeightedAverage(p => p.Value, p => (p.Year-minYear)+1);
                    var medianPE = focusPEs.Select(p => p.Value).Median();
                    var minPE = (medianPE < weightedPE) ? medianPE : weightedPE;

                    ped = from p in pe
                        where p.Value > 0
                        orderby p.Year descending
                        select new PeDiffPercent
                        {
                            Year = p.Year,
                            Value = (minPE-p.Value)/minPE
                        };
                }
            }
            return ped;
        }
        private IEnumerable<Peg> calculatePeg(IEnumerable<Pe> pe, IEnumerable<GrowthDE> growth)
        {
            IEnumerable<Peg> peg=null;
            if(pe!=null && pe.Any() && growth!=null && growth.Any())
            {
                peg = from p in pe
                join g in growth on p.Year equals g.Year
                orderby p.Year descending
                select new Peg
                {
                    Year = p.Year,
                    Value = p.Value/g.Value,
                    IsActual = p.IsActual
                };
            }
            return peg;
        }
        private IEnumerable<Pe> calculatePe(
            IEnumerable<Price> price,
            IEnumerable<Statistic> statistic,
            IEnumerable<Share> shareByYear,
            IEnumerable<Consensus> consensus)
        {
            IEnumerable<Pe> pe = null;
            if(shareByYear != null && shareByYear.Any())
            {
                var avgPriceOfEachJan = from p in price
                    where p.Date.Month == 1
                    group p by p.Date.Year into g
                    select new Price
                    {
                        Close = g.WeightedAverage(p => p.Close.Value, p => p.Date.Day),
                        Date = new DateTime(g.Key, 1, 1)
                    };

                pe = from p in avgPriceOfEachJan
                    join stat in statistic on (p.Date.Year-1) equals stat.Year
                    join s in shareByYear on stat.Year equals s.Date.Year
                    where stat.Year < asOfDate.Year
                    select new Pe
                    {
                        Year = stat.Year,
                        Value = p.Close.Value / (stat.NetProfit.Value/((double)s.Amount.Value/1000000)),
                        IsActual = true
                    };

                var lastPrice = price.OrderByDescending(p=>p.Date).FirstOrDefault();

                //Forward PE
                pe = pe.Union(from c in consensus
                    where c.Year >= asOfDate.Year && c.Average!=null && c.Median!=null
                    select new Pe
                    {
                        Year = c.Year,
                        Value = c.Average < c.Median ? lastPrice.Close.Value / c.Average.Value : lastPrice.Close.Value / c.Median.Value,
                        IsActual = false
                    }).OrderByDescending(p=>p.Year);
            }
            return pe;
        }
        private IEnumerable<GrowthDE> calculateGrowth(IEnumerable<NetProfit> netProfit)
        {
            IEnumerable<GrowthDE> growth = null;
            if(netProfit != null && netProfit.Any())
            {
                growth = from n in netProfit
                join nn in netProfit on n.Year equals nn.Year+1
                orderby n.Year descending
                select new GrowthDE
                {
                    Year = n.Year,
                    Value = ((n.Value - nn.Value)/nn.Value)*100,
                    IsActual = n.IsActual
                };
            }
            return growth;
        }
        private IEnumerable<NetProfit> calculateNetProfit(
            IEnumerable<Statistic> statistic,
            IEnumerable<Consensus> consensus,
            IEnumerable<Share> shareByYear)
        {
            IEnumerable<NetProfit> netProfit=null;
            if(shareByYear!=null && shareByYear.Any())
            {
                //actual
                netProfit = from stat in statistic
                    where stat.Year < asOfDate.Year
                    select new NetProfit
                    {
                        Year = stat.Year,
                        Value = stat.NetProfit.Value,
                        IsActual = true
                    };
                //forecast
                netProfit = netProfit.Union(from c in consensus
                    join s in shareByYear on c.Year equals s.Date.Year
                    where c.Year >= asOfDate.Year && c.Average!=null && c.Median!=null
                    select new NetProfit
                    {
                        Year = c.Year,
                        Value = c.Average < c.Median ? ((c.Average * s.Amount) / 1000000).Value : ((c.Median * s.Amount) / 1000000).Value,
                        IsActual = false
                    }).OrderByDescending(n=>n.Year);
            }
            return netProfit;
        }
        private IEnumerable<Share> calculateShareByYear(IEnumerable<Share> share)
        {
            IEnumerable<Share> shareByYear = null;
            if(share != null && share.Any())
            {
                shareByYear = from s in share
                                group s by s.Date.Year into g
                                select (g.OrderByDescending(s => s.Date).First());
                var oldestYear = shareByYear.OrderBy(g => g.Date).FirstOrDefault();
                var newestYear = shareByYear.OrderByDescending(g => g.Date).FirstOrDefault();
                shareByYear = shareByYear.Concat(new Share[] 
                { 
                    new Share { Date = oldestYear.Date.AddYears(-5), Amount = oldestYear.Amount },
                    new Share { Date = oldestYear.Date.AddYears(-4), Amount = oldestYear.Amount },
                    new Share { Date = oldestYear.Date.AddYears(-3), Amount = oldestYear.Amount },
                    new Share { Date = oldestYear.Date.AddYears(-2), Amount = oldestYear.Amount },
                    new Share { Date = oldestYear.Date.AddYears(-1), Amount = oldestYear.Amount },
                    new Share { Date = newestYear.Date.AddYears(1), Amount = newestYear.Amount },
                    new Share { Date = newestYear.Date.AddYears(2), Amount = newestYear.Amount } 
                }).OrderByDescending(s=>s.Date);
            }
            return shareByYear;
        }
        private MovingAverage calculateMACD(IEnumerable<Price> prices)
        {
            MovingAverage item = null;
            if(prices != null && prices.Any())
            {
                var sortedPrices = prices.Where(p => p.Close.HasValue && p .Date > asOfDate.AddMonths(-3)).OrderByDescending(p => p.Date).Take(60).OrderBy(p => p.Date).ToList();
                var macd = new MovingAverageHelper(12, 26, 9);
                foreach (var price in sortedPrices) 
                { 
                    macd.ReceiveTick(price.Close.Value); 
                } 
                item = macd.Value();
            };
            return item;
        }
        public Stock Build(string t = null)
        {
            throw new NotImplementedException();
        }
    }
}