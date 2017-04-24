using System;
using System.Collections.Generic;
using System.Linq;
using StockCore.DomainEntity;

namespace StockCore.Extension
{
    public static class DomainEntityExtension
    {
        public static QuoteGroupDE Merge(this QuoteGroupDE item, QuoteGroupDE updateItem)
        {
            item.Quotes = updateItem.Quotes;
            return item;
        }
        public static ConsensusDE Merge(this ConsensusDE item, ConsensusDE updateItem)
        {
            item.Average = updateItem.Average;
            item.High = updateItem.High;
            item.Low = updateItem.Low;
            item.Median = updateItem.Median;
            return item;
        }
        public static ShareDE Merge(this ShareDE item, ShareDE updateItem)
        {
            item.Amount = updateItem.Amount;
            return item;
        }
        public static StatisticDE Merge(this StatisticDE item, StatisticDE updateItem)
        {
            item.Asset = updateItem.Asset;
            item.Liability = updateItem.Liability;
            item.Equity = updateItem.Equity;
            item.Revenue = updateItem.Revenue;
            item.NetProfit = updateItem.NetProfit;
            item.Roa = updateItem.Roa;
            item.Roe = updateItem.Roe;
            item.Margin = updateItem.Margin;
            return item;
        }
        public static PriceDE Merge(this PriceDE item, PriceDE updateItem)
        {
            item.Amount = updateItem.Amount;
            item.Close = updateItem.Close;
            item.High = updateItem.High;
            item.Low = updateItem.Low;
            item.Volumn = updateItem.Volumn;
            return item;
        }
        public static SetIndexDE Merge(this SetIndexDE item, SetIndexDE updateItem)
        {
            item.Index = updateItem.Index;
            return item;
        }
        public static double WeightedAverage<T>(this IEnumerable<T> records, Func<T, double> value, Func<T, double> weight)
        {
            double weightedValueSum = records.Sum(x => value(x) * weight(x));
            double weightSum = records.Sum(x => weight(x));

            if (weightSum != 0)
                return weightedValueSum / weightSum;
            else
                throw new DivideByZeroException("Your message here");
        }
        public static double Median(this IEnumerable<double> records)
        {
            if (records.Count() == 0)
            {
                throw new InvalidOperationException("Cannot compute median for an empty set.");
            }

            var sortedList = from number in records
                             orderby number
                             select number;



            int itemIndex = (int)sortedList.Count() / 2;

            if (sortedList.Count() % 2 == 0)
            {
                // Even number of items. 
                return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;
            }
            else
            {
                // Odd number of items. 
                return sortedList.ElementAt(itemIndex);
            }
        }
        public static List<T> ToNonNullList<T>(this IEnumerable<T> obj)
        {
            return obj == null ? new List<T>() : obj.ToList();
        }
    }
}