using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StockCore.DomainEntity
{
    public class DECollection<T> : Persistant, IEnumerable<T> where T:class
    {
        private List<T> list;
        //TODO:Cannot move logic to Load method. Mongo cannot deserialize it back!!!
        public DECollection(IEnumerable<T> items)
        {
            if(items!=null && items.Any())
            {
                list = new List<T>();
                list = items.ToList();
            }
        }
        /*
        public void Load(IEnumerable<T> items)
        {
            if(items!=null && items.Any())
            {
                list = new List<T>();
                list = items.ToList();
            }
        }*/
        public IEnumerator<T> GetEnumerator()=>list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()=>this.ToList().GetEnumerator();
    }
}