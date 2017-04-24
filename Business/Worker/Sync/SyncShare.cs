using System.Collections.Generic;
using System;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.Business.Repo.MongoDB;

namespace StockCore.Business.Worker.Sync
{
    public class SyncShare : BaseSyncData<ShareDE>
    {
        public SyncShare(IRepo<ShareDE> repo):base(repo){}
        protected override IEnumerable<ShareDE> calculateItemToInsert(IEnumerable<ShareDE> items, IEnumerable<ShareDE> dbItems)
        {
            return items.CalculateItemToInsert<ShareDE,DateTime>(dbItems);
        }

        protected override IEnumerable<ShareDE> calculateItemToUpdate(IEnumerable<ShareDE> items, IEnumerable<ShareDE> dbItems)
        {
            return items.CalculateItemToUpdate(dbItems);
        }

        protected override IEnumerable<ShareDE> calculateItemToRemove(IEnumerable<ShareDE> items, IEnumerable<ShareDE> dbItems)
        {
            return null;
        }
    }   
}   