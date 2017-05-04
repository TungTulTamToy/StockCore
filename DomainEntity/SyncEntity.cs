using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public class SyncEntity<T> //where T:IPersistant,ILinqCriteria<T>
    {
        public IEnumerable<T> source{get;set;}
        public IEnumerable<T> destination{get;set;}
    }
}