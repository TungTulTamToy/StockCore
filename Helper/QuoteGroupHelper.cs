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
                            return SellFilter(stocks);
                        case "Buy":
                            return BuyFilter(stocks);
                        case "Over Sold":
                            return OverSoldFilter(stocks);
                        case "Over Buy":
                            return OverBuyFilter(stocks);
                    }
                }
                return stocks;
            };
        }
        public static IEnumerable<Stock> SellFilter(IEnumerable<Stock> stocks)=>stocks.Where(s=>s.MovingAverage.Hist < 0 && s.PriceCal.Any(p=>p.Name=="6M" && p.DiffAvg < -5)).ToList();
        public static IEnumerable<Stock> BuyFilter(IEnumerable<Stock> stocks)=>stocks.Where(s=>s.MovingAverage.Hist > 0 && s.PriceCal.Any(p=>p.Name=="6M" && p.DiffAvg > 5)).ToList();
        public static IEnumerable<Stock> OverSoldFilter(IEnumerable<Stock> stocks)=>stocks.Where(s=>s.PriceCal.Any(p=>p.Name=="6M" && p.DiffAvg > 8)).ToList();
        public static IEnumerable<Stock> OverBuyFilter(IEnumerable<Stock> stocks)=>stocks.Where(s=>s.PriceCal.Any(p=>p.Name=="6M" && p.DiffAvg < -8)).ToList();
    }
}