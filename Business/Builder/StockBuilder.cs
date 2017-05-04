using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo;
using StockCore.Business.Repo.MongoDB;
using StockCore.DomainEntity;
using StockCore.Factory;
using System;
using StockCore.Extension;

namespace StockCore.Business.Builder
{
    public class StockBuilder : IBuilder<string, Stock>
    {
        private readonly ILogger logger;
        private readonly IGetByKey<IEnumerable<Share>,string> shareRepo;
        private readonly IGetByKey<IEnumerable<Statistic>,string> statisticRepo;
        private readonly IGetByKey<IEnumerable<Consensus>,string> consensusRepo;
        private readonly IGetByKey<IEnumerable<Price>,string> priceRepo;
        public StockBuilder(
            ILogger logger,
            IGetByKey<IEnumerable<Share>,string> shareRepo,
            IGetByKey<IEnumerable<Statistic>,string> statisticRepo,
            IGetByKey<IEnumerable<Consensus>,string> consensusRepo,
            IGetByKey<IEnumerable<Price>,string> priceRepo
            )
        {
            this.logger = logger;
            this.shareRepo = shareRepo;
            this.statisticRepo = statisticRepo;
            this.consensusRepo = consensusRepo;
            this.priceRepo = priceRepo;
        }
        public async Task<Stock> BuildAsync(string quote)
        {
            var shareTask = shareRepo.GetByKeyAsync(quote);
            var statisticTask = statisticRepo.GetByKeyAsync(quote);
            var consensusTask = consensusRepo.GetByKeyAsync(quote);
            var priceTask = priceRepo.GetByKeyAsync(quote);

            var share = await shareTask;
            var statistic = await statisticTask;
            var consensus = await consensusTask;
            var price = await priceTask;

            var shareByYear = calculateShareByYear(quote,share);    
            var netProfit = calculateNetProfit(quote,statistic,consensus,shareByYear);  
            var growth = calculateGrowth(netProfit);
            var priceCal = calculatePriceCalDE(price);
            var pe = calculatePe(price,statistic,shareByYear,consensus);
            var peg = calculatePeg(pe,growth);
            var ped = calculatePeDiffPercent(pe);

            var stock = new Stock().Load(quote,price,statistic,share,consensus,netProfit,growth,priceCal,pe,peg,ped);         

            return stock;
        }
        private IEnumerable<PeDiffPercentDE> calculatePeDiffPercent(IEnumerable<PeDE> pe)
        {
            IEnumerable<PeDiffPercentDE> ped = null;
            if(pe!=null && pe.Any())
            {
                int limit = 7;
                var focusPEs = pe.Where(p=>p.Value>0).Take(limit);
                var minYear = focusPEs.Min(p => p.Year);
                var weightedPE = focusPEs.WeightedAverage(p => p.Value, p => (p.Year-minYear)+1);
                var medianPE = focusPEs.Select(p => p.Value).Median();
                var minPE = (medianPE < weightedPE) ? medianPE : weightedPE;

                ped = from p in pe
                    where p.Value > 0
                    orderby p.Year descending
                    select new PeDiffPercentDE
                    {
                        Year = p.Year,
                        Value = (minPE-p.Value)/minPE
                    };
            }
            return ped;
        }
        private IEnumerable<PegDE> calculatePeg(IEnumerable<PeDE> pe, IEnumerable<GrowthDE> growth)
        {
            IEnumerable<PegDE> peg=null;
            if(pe!=null && pe.Any() && growth!=null && growth.Any())
            {
                peg = from p in pe
                join g in growth on p.Year equals g.Year
                orderby p.Year descending
                select new PegDE
                {
                    Year = p.Year,
                    Value = p.Value/g.Value,
                    IsActual = p.IsActual
                };
            }
            return peg;
        }
        private IEnumerable<PeDE> calculatePe(
            IEnumerable<Price> price,
            IEnumerable<Statistic> statistic,
            IEnumerable<Share> shareByYear,
            IEnumerable<Consensus> consensus)
        {
            IEnumerable<PeDE> pe = null;
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
                    where stat.Year < DateTime.Now.Year
                    select new PeDE
                    {
                        Year = stat.Year,
                        Value = p.Close.Value / (stat.NetProfit.Value/((double)s.Amount.Value/1000000)),
                        IsActual = true
                    };

                var lastPrice = price.OrderByDescending(p=>p.Date).FirstOrDefault();

                //Forward PE
                pe = pe.Union(from c in consensus
                    where c.Year >= DateTime.Now.Year
                    select new PeDE
                    {
                        Year = c.Year,
                        Value = c.Average < c.Median ? lastPrice.Close.Value / c.Average.Value : lastPrice.Close.Value / c.Median.Value,
                        IsActual = false
                    }).OrderByDescending(p=>p.Year);
            }
            return pe;
        }
        private IEnumerable<PriceCal> calculatePriceCalDE(IEnumerable<Price> price)
        {
            var price1Y = price.Where(p => p.Date > DateTime.Now.AddYears(-1));
            var price6M = price.Where(p => p.Date > DateTime.Now.AddMonths(-6));
            var price3M = price.Where(p => p.Date > DateTime.Now.AddMonths(-3));
            var price1M = price.Where(p => p.Date > DateTime.Now.AddMonths(-1));

            var avg1Y = calculateAverage(price1Y);
            var avg6M = calculateAverage(price6M);
            var avg3M = calculateAverage(price3M);
            var avg1M = calculateAverage(price1M);

            var min1Y = calculateMin(price1Y);
            var min6M = calculateMin(price6M);
            var min3M = calculateMin(price3M);
            var min1M = calculateMin(price1M);

            var max1Y = calculateMax(price1Y);
            var max6M = calculateMax(price6M);
            var max3M = calculateMax(price3M);
            var max1M = calculateMax(price1M);

            var last1Y = calculateLast(price1Y);
            var last6M = calculateLast(price6M);
            var last3M = calculateLast(price3M);
            var last1M = calculateLast(price1M);

            var avgPrice1YCal = new PriceCal().Load("1Y", avg1Y, min1Y, max1Y, last1Y);
            var avgPrice6MCal = new PriceCal().Load("6M", avg6M, min6M, max6M, last6M);
            var avgPrice3MCal = new PriceCal().Load("3M", avg3M, min3M, max3M, last3M);
            var avgPrice1MCal = new PriceCal().Load("1M", avg1M, min1M, max1M, last1M);

            var avgPriceCals = new[] { avgPrice1YCal, avgPrice6MCal, avgPrice3MCal, avgPrice1MCal };
            return avgPriceCals;
        }
        private double calculateLast(IEnumerable<Price> price)
        {
            var last = (from p in price
                where p.Close.HasValue
                orderby p.Date descending
                select p.Close.Value).FirstOrDefault();
            return last;
        }
        private double calculateMax(IEnumerable<Price> price)
        {
            var max = (from p in price
                where p.Close.HasValue
                orderby p.Close descending
                select p.Close.Value).FirstOrDefault();
            return max;
        }
        private double calculateMin(IEnumerable<Price> price)
        {
            var min = (from p in price
                where p.Close.HasValue
                orderby p.Close
                select p.Close.Value).FirstOrDefault();
            return min;
        }
        private double calculateAverage(IEnumerable<Price> price)
        {
            double amountVolumnAcc = 0;
            double amountAcc = 0;
            price.ToList().ForEach(p => 
            { 
                if(p.Amount.HasValue && p.Volumn.HasValue)
                {
                    amountVolumnAcc += p.Volumn.Value;
                    amountAcc += p.Amount.Value;
                }
            });
            var avg = (amountVolumnAcc * 1000) / amountAcc;
            return avg;
        }

        private IEnumerable<GrowthDE> calculateGrowth(IEnumerable<NetProfitDE> netProfit)
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

        private IEnumerable<NetProfitDE> calculateNetProfit(
            string quote,
            IEnumerable<Statistic> statistic,
            IEnumerable<Consensus> consensus,
            IEnumerable<Share> shareByYear)
        {
            IEnumerable<NetProfitDE> netProfit=null;
            if(shareByYear!=null && shareByYear.Any())
            {
                //actual
                netProfit = from stat in statistic
                    where stat.Year < DateTime.Now.Year
                    select new NetProfitDE
                    {
                        Year = stat.Year,
                        Value = stat.NetProfit.Value,
                        IsActual = true
                    };

                //forecast
                netProfit = netProfit.Union(from c in consensus
                    join s in shareByYear on c.Year equals s.Date.Year
                    where c.Year >= DateTime.Now.Year
                    select new NetProfitDE
                    {
                        Year = c.Year,
                        Value = c.Average < c.Median ? ((c.Average * s.Amount) / 1000000).Value : ((c.Median * s.Amount) / 1000000).Value,
                        IsActual = false
                    }).OrderByDescending(n=>n.Year);
            }
            return netProfit;
        }

        private IEnumerable<Share> calculateShareByYear(string quote,IEnumerable<Share> share)
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
    }
}