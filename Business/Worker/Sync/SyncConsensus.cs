using System.Collections.Generic;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.Business.Repo.MongoDB;

namespace StockCore.Business.Worker.Sync
{
    public class SyncConsensus : BaseSyncData<ConsensusDE>
    {
        public SyncConsensus(IRepo<ConsensusDE> repo):base(repo){}
        protected override IEnumerable<ConsensusDE> calculateItemToInsert(IEnumerable<ConsensusDE> items, IEnumerable<ConsensusDE> dbItems)
        {
            return items.CalculateItemToInsert<ConsensusDE,int>(dbItems);
        }

        protected override IEnumerable<ConsensusDE> calculateItemToUpdate(IEnumerable<ConsensusDE> items, IEnumerable<ConsensusDE> dbItems)
        {
            return items.CalculateItemToUpdate(dbItems);
        }

        protected override IEnumerable<ConsensusDE> calculateItemToRemove(IEnumerable<ConsensusDE> items, IEnumerable<ConsensusDE> dbItems)
        {
            return null;
        }
    }   
}   