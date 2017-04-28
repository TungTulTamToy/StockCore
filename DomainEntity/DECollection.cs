using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StockCore.DomainEntity
{
    public class DECollection<T> : BaseDE, IEnumerable<T> where T:class
    {
        List<T> stockList = new List<T>();

        public T this[int index]  
        {  
            get { return stockList[index]; }  
            set { stockList.Insert(index, value); }  
        } 
        public DECollection(IEnumerable<T> items)
        {
            if(items!=null)
            {
                stockList = items.ToList();
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return stockList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.ToList().GetEnumerator();
        }
    }
}