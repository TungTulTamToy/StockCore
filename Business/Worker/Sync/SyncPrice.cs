using System.Collections.Generic;
using System;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.Business.Repo.MongoDB;

namespace StockCore.Business.Worker.Sync
{
    public class SyncPrice : BaseSyncData<PriceDE>
    {
        public SyncPrice(IRepo<PriceDE> repo):base(repo){}
        protected override IEnumerable<PriceDE> calculateItemToInsert(IEnumerable<PriceDE> items, IEnumerable<PriceDE> dbItems)
        {
            return items.CalculateItemToInsert<PriceDE,DateTime>(dbItems);
        }

        protected override IEnumerable<PriceDE> calculateItemToUpdate(IEnumerable<PriceDE> items, IEnumerable<PriceDE> dbItems)
        {
            return items.CalculateItemToUpdate(dbItems);
        }

        protected override IEnumerable<PriceDE> calculateItemToRemove(IEnumerable<PriceDE> items, IEnumerable<PriceDE> dbItems)
        {
            return null;
        }
    }   
}   