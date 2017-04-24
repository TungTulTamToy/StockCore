using System.Collections.Generic;
using System;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.Business.Repo.MongoDB;

namespace StockCore.Business.Worker.Sync
{
    public class SyncSetIndex : BaseSyncData<SetIndexDE>
    {
        public SyncSetIndex(IRepo<SetIndexDE> repo):base(repo){}
        protected override IEnumerable<SetIndexDE> calculateItemToInsert(IEnumerable<SetIndexDE> items, IEnumerable<SetIndexDE> dbItems)
        {
            return items.CalculateItemToInsert<SetIndexDE,DateTime>(dbItems);
        }

        protected override IEnumerable<SetIndexDE> calculateItemToUpdate(IEnumerable<SetIndexDE> items, IEnumerable<SetIndexDE> dbItems)
        {
            return items.CalculateItemToUpdate(dbItems);
        }

        protected override IEnumerable<SetIndexDE> calculateItemToRemove(IEnumerable<SetIndexDE> items, IEnumerable<SetIndexDE> dbItems)
        {
            return null;
        }
    }   
}   