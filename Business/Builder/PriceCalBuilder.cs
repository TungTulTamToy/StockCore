using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using System;

namespace StockCore.Business.Builder
{
    public class PriceCalBuilder : IBuilder<IEnumerable<Price>, IEnumerable<PriceCal>>
    {
        private readonly ILogger logger;
        private readonly DateTime asOfDate;
        public PriceCalBuilder(
            ILogger logger,
            DateTime asOfDate)
        {
            this.logger = logger;
            this.asOfDate = asOfDate;
        }
        public IEnumerable<PriceCal> Build(IEnumerable<Price> price)
        {
            var price1Y = price.Where(p => p.Date > asOfDate.AddYears(-1));
            var price6M = price.Where(p => p.Date > asOfDate.AddMonths(-6));
            var price3M = price.Where(p => p.Date > asOfDate.AddMonths(-3));
            var price1M = price.Where(p => p.Date > asOfDate.AddMonths(-1));

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
        public Task<IEnumerable<PriceCal>> BuildAsync(IEnumerable<Price> t = null)
        {
            throw new NotImplementedException();
        }
    }
}