using System;
using System.Collections.Generic;
using System.Linq;
using StockCore.DomainEntity;
using StockCore.Helper;

namespace StockCore.Extension
{
    public static class LinqExtension
    {
        public static IEnumerable<T> GetInnerJoinItem<T> (this IEnumerable<T> mainItems, IEnumerable<T> otherItems) where T:ILinqCriteria<T>
        {
            var joinItems = (from main in mainItems
                join other in otherItems
                on main equals other
                select main).ToList();
            return  joinItems;
        }
        public static IEnumerable<T> GetItemToInsert<T> (this IEnumerable<T> source, IEnumerable<T> destination) where T:ILinqCriteria<T>
        {
            var joinItems = source.GetInnerJoinItem(destination);
            var xxx = source.Except(joinItems);
            return  xxx;
        }
        public static IEnumerable<T> GetItemToDelete<T>  (this IEnumerable<T> source, IEnumerable<T> destination) where T:ILinqCriteria<T>
        {
            var joinItems = source.GetInnerJoinItem(destination);
            return  destination.Except(joinItems);
        }
        public static IEnumerable<T> GetItemToUpdate<T>(this IEnumerable<T> source, IEnumerable<T> destination)where T:ILinqCriteria<T>
        {
            var itemToUpdate = (from s in source
                join d in destination
                on s equals d
                where s.UpdateCondition(d)
                select d.Merge(s)).ToList();
            return itemToUpdate;
        }
    }
}