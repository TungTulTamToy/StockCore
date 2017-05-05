using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public class SyncEntity<T>
    {
        public IEnumerable<T> source{get;set;}
        public IEnumerable<T> destination{get;set;}
    }
}