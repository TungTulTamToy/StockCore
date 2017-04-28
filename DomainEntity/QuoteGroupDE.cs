using System;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StockCore.DomainEntity
{
    [Serializable]
    public class QuoteGroupDE:BaseDE,IJoinKeyField<string>,IKeyField<string>
    {
        public string Name { get; set; }
        public IEnumerable<string> Quotes{get;set;}
        public int Order{get;set;}
        public bool IsDefault{get;set;}
        public string JoinKey=>Name;
        public string Key 
        { 
            get => Name; 
            set => Name = value; 
        }
    }
}