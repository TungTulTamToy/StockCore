using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public class BackupStockDE:Persistant,IKeyField<string>
    {
        public string Key 
        { 
            get => Quote; 
            set => Quote=value; 
        }
        public string Quote{get;set;}
        public IEnumerable<PriceDE> Prices{get;set;}
        public IEnumerable<StatisticDE> Statistics{get;set;}
        public IEnumerable<ShareDE> Shares{get;set;}
        public IEnumerable<ConsensusDE> Consensuses{get;set;}
    }
}