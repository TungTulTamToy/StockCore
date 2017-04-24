using System.Collections.Generic;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.Business.Repo.MongoDB;

namespace StockCore.Business.Worker.Sync
{
    public class SyncQuoteGroup : BaseSyncData<QuoteGroupDE>
    {
        public SyncQuoteGroup(IRepo<QuoteGroupDE> repo):base(repo){}
        protected override IEnumerable<QuoteGroupDE> calculateItemToInsert(IEnumerable<QuoteGroupDE> items, IEnumerable<QuoteGroupDE> dbItems)
        {
            return items.CalculateItemToInsert<QuoteGroupDE,string>(dbItems);
        }

        protected override IEnumerable<QuoteGroupDE> calculateItemToUpdate(IEnumerable<QuoteGroupDE> items, IEnumerable<QuoteGroupDE> dbItems)
        {
            return items.CalculateItemToUpdate(dbItems);
        }

        protected override IEnumerable<QuoteGroupDE> calculateItemToRemove(IEnumerable<QuoteGroupDE> items, IEnumerable<QuoteGroupDE> dbItems)
        {
            return items.CalculateItemToDelete<QuoteGroupDE,string>(dbItems);
        }
    }   
}   