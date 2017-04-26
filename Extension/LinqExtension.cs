using System.Collections.Generic;
using System.Linq;
using StockCore.DomainEntity;

namespace StockCore.Extension
{
    public static class LinqExtension
    {
        public static IEnumerable<T> CalculateItemToInsert<T,TKey> (
            this IEnumerable<T> source, 
            IEnumerable<T> destination) where T:IJoinKeyField<TKey>
        {
            var joinItems = (from s in source
                join d in destination
                on s.JoinKey equals d.JoinKey
                select s).ToList();
            return  source.Except(joinItems);
        }
        public static IEnumerable<T> CalculateItemToDelete<T,TKey>  (
            this IEnumerable<T> source, 
            IEnumerable<T> destination) where T:IJoinKeyField<TKey>
        {
            var joinItems = (from s in source
                join d in destination
                on s.JoinKey equals d.JoinKey
                select d).ToList();
            return  destination.Except(joinItems);
        }
        public static IEnumerable<ConsensusDE> CalculateItemToUpdate(
            this IEnumerable<ConsensusDE> source, 
            IEnumerable<ConsensusDE> destination)
        {
            var itemToUpdate = (from s in source
                join d in destination
                on s.JoinKey equals d.JoinKey
                where s.IsValid != d.IsValid || s.Average != d.Average || s.High != d.High || s.Low != d.Low || s.Median != d.Median
                select d.Merge(s)).ToList();
            return itemToUpdate;
        }
        public static IEnumerable<QuoteGroupDE> CalculateItemToUpdate(this IEnumerable<QuoteGroupDE> source, IEnumerable<QuoteGroupDE> destination)
        {
            var itemToUpdate = (from s in source
                join d in destination
                on s.JoinKey equals d.JoinKey
                //where s.Quotes.Any(q=>d.Quotes.Contains(q)) && d.Quotes.Any(q=>s.Quotes.Contains(q))
                where s.Quotes.Except(d.Quotes).Any() || d.Quotes.Except(s.Quotes).Any()
                select d.Merge(s)).ToList();//TODO:Must have to list here!!! Otherwise remove Except out from LINQ!!!!!!
            return itemToUpdate;
        }

        public static IEnumerable<PriceDE> CalculateItemToUpdate(this IEnumerable<PriceDE> source, IEnumerable<PriceDE> destination)
        {
            var itemToUpdate = (from s in source
                join d in destination
                on s.JoinKey equals d.JoinKey
                where s.IsValid != d.IsValid || s.Amount != d.Amount || s.Close != d.Close || s.High != d.High || s.Low != d.Low || s.Volumn != d.Volumn
                select d.Merge(s)).ToList();
            return itemToUpdate;
        }

        public static IEnumerable<ShareDE> CalculateItemToUpdate(this IEnumerable<ShareDE> source, IEnumerable<ShareDE> destination)
        {
            var itemToUpdate = (from s in source
                join d in destination
                on s.JoinKey equals d.JoinKey
                where s.IsValid != d.IsValid || s.Amount != d.Amount
                select d.Merge(s)).ToList();
            return itemToUpdate;
        }

        public static IEnumerable<StatisticDE> CalculateItemToUpdate(this IEnumerable<StatisticDE> source, IEnumerable<StatisticDE> destination)
        {
            var itemToUpdate = (from s in source
                join d in destination
                on s.JoinKey equals d.JoinKey
                where s.IsValid != d.IsValid || s.Asset != d.Asset || s.Liability != d.Liability || s.Equity != d.Equity || s.Revenue != d.Revenue || s.NetProfit != d.NetProfit || s.Roa != d.Roa || s.Roe != d.Roe || s.Margin != d.Margin
                select d.Merge(s)).ToList();
            return itemToUpdate;
        }

        public static IEnumerable<SetIndexDE> CalculateItemToUpdate(this IEnumerable<SetIndexDE> source, IEnumerable<SetIndexDE> destination)
        {
            var itemToUpdate = (from s in source
                join d in destination
                on s.JoinKey equals d.JoinKey
                where s.IsValid != d.IsValid || s.Index != d.Index
                select d.Merge(s)).ToList();
            return itemToUpdate;
        }
    }
}