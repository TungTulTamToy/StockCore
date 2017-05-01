using System;
using System.Collections.Generic;
using System.Linq;
using StockCore.DomainEntity;

namespace StockCore.Extension
{
    public static class LinqExtension
    {
        public static IEnumerable<T> GetInnerJoinItem<TKey,T> (
            this IEnumerable<T> source, 
            IEnumerable<T> destination) where T:ILinqCriteria<TKey,T>
        {
            var joinItems = (from s in source
                join d in destination
                on s.JoinKey equals d.JoinKey
                select s).ToList();
            return  joinItems;
        }
        public static IEnumerable<T> GetItemToInsert<TKey,T> (
            this IEnumerable<T> source, 
            IEnumerable<T> destination) where T:ILinqCriteria<TKey,T>
        {
            var joinItems = source.GetInnerJoinItem<TKey,T>(destination);
            return  source.Except(joinItems);
        }
        public static IEnumerable<T> GetItemToDelete<TKey,T>  (
            this IEnumerable<T> source, 
            IEnumerable<T> destination) where T:ILinqCriteria<TKey,T>
        {
            var joinItems = source.GetInnerJoinItem<TKey,T>(destination);
            return  destination.Except(joinItems);
        }
        public static IEnumerable<T> GetItemToUpdate<TKey,T>(
            this IEnumerable<T> source, 
            IEnumerable<T> destination)where T:ILinqCriteria<TKey,T>
        {
            var itemToUpdate = (from s in source
                join d in destination
                on s.JoinKey equals d.JoinKey
                where s.UpdateCondition(d)
                select d.Merge(s)).ToList();
            return itemToUpdate;
        }
    }
}