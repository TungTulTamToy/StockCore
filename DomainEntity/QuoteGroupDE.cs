using System;
using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    [Serializable]
    public class QuoteGroupDE:BaseDE,IJoinKeyField<string>
    {
        public string Name { get; set; }
        public IEnumerable<string> Quotes{get;set;}

        public string JoinKey=>Name;
    }
}