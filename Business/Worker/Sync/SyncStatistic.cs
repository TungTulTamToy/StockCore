using System.Collections.Generic;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.Business.Repo.MongoDB;

namespace StockCore.Business.Worker.Sync
{
    public class SyncStatistic : BaseSyncData<StatisticDE>
    {
        public SyncStatistic(IRepo<StatisticDE> repo):base(repo){}
        protected override IEnumerable<StatisticDE> calculateItemToInsert(IEnumerable<StatisticDE> items, IEnumerable<StatisticDE> dbItems)
        {
            return items.CalculateItemToInsert<StatisticDE,int>(dbItems);
        }

        protected override IEnumerable<StatisticDE> calculateItemToUpdate(IEnumerable<StatisticDE> items, IEnumerable<StatisticDE> dbItems)
        {
            return items.CalculateItemToUpdate(dbItems);
        }

        protected override IEnumerable<StatisticDE> calculateItemToRemove(IEnumerable<StatisticDE> items, IEnumerable<StatisticDE> dbItems)
        {
            return null;
        }
    }   
}   