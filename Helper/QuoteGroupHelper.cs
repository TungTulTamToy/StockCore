using System.Collections.Generic;
using System.Linq;
using System;
using StockCore.DomainEntity;

namespace StockCore.Helper
{
    public static class QuoteGroupHelper
    {
        public static Func<string,IEnumerable<Stock>,IEnumerable<Stock>> DetermineFilter()
        {
            return (groupName,stocks)=>{
                if(stocks !=null && stocks.Any())
                {
                    switch(groupName)
                    {
                        case "Sell":
                            return SellFilter(groupName,stocks);
                        case "Buy":
                            return BuyFilter(groupName,stocks);
                    }
                }
                return stocks;
            };
        }
        public static IEnumerable<Stock> SellFilter(string groupName, IEnumerable<Stock> stocks)=>stocks.Where(s=>s.MovingAverage.Hist < 0 && s.PriceCal.Any(p=>p.Name=="6M" && p.DiffAvg < -5)).ToList();
        public static IEnumerable<Stock> BuyFilter(string groupName, IEnumerable<Stock> stocks)=>stocks.Where(s=>s.MovingAverage.Hist > 0 && s.PriceCal.Any(p=>p.Name=="6M" && p.DiffAvg > 5)).ToList();
    }
}