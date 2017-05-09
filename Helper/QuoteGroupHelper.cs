using System.Collections.Generic;
using System.Linq;
using System;
using StockCore.DomainEntity;

namespace StockCore.Helper
{
    public static class QuoteGroupHelper
    {
        public static List<Stock> FilterStocks(this QuoteGroup item, List<Stock> stocks)
        {
            if(stocks !=null && stocks.Any() && item!=null)
            {
                var dict = new Dictionary<string,Func<Stock,bool>>(){
                    ["Sell"]=(stock) => stock.MovingAverage.Hist < 0 && stock.PriceCal.Any(p=>p.Name=="6M" && p.DiffAvg < -5),
                    ["Buy"]=(stock) => stock.MovingAverage.Hist > 0 && stock.PriceCal.Any(p=>p.Name=="6M" && p.DiffAvg > 5)
                };
                if(dict.ContainsKey(item.Name))
                {
                    stocks = stocks.Where(s=>dict[item.Name](s)).ToList();
                }
            }
            return stocks;
        }
    }
}