using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using StockCore.DomainEntity;
using StockCore.Extension;
using StockCore.Business.Repo;
using StockCore.Business.Repo.MongoDB;
using StockCore.Factory;

namespace StockCore.Business.Operation.SyncFromWeb
{
    public class SyncQuote:IOperation<string>
    {
        private readonly IGetByKeyRepo<Price,string> dbPriceRepo;
        private readonly IRepo<SetIndex> dbSetIndexRepo;
        private readonly IGetByKeyRepo<Consensus,string> dbConsensusRepo;
        private readonly IGetByKeyRepo<Share,string> dbShareRepo;
        private readonly IGetByKeyRepo<Statistic,string> dbStatisticRepo;
        private readonly IGetByKey<IEnumerable<Consensus>,string> consensusHtmlReader;
        private readonly IGetByKey<IEnumerable<Price>,string> priceHtmlReader;
        private readonly IGetByKey<IEnumerable<SetIndex>,string> setIndexHtmlReader;
        private readonly IGetByKey<IEnumerable<Share>,string> shareHtmlReader;
        private readonly IGetByKey<IEnumerable<Statistic>,string> statisticHtmlReader;
        public SyncQuote(
            IGetByKeyRepo<Price,string> dbPriceRepoFactory,
            IRepo<SetIndex> dbSetIndexRepoFactory,
            IGetByKeyRepo<Consensus,string> dbConsensusRepoFactory,
            IGetByKeyRepo<Share,string> dbShareRepoFactory,
            IGetByKeyRepo<Statistic,string> dbStatisticRepoFactory,
            IGetByKey<IEnumerable<Consensus>,string> consensusHtmlReaderFactory,
            IGetByKey<IEnumerable<Price>,string> priceHtmlReaderFactory,
            IGetByKey<IEnumerable<SetIndex>,string> setIndexHtmlReaderFactory,
            IGetByKey<IEnumerable<Share>,string> shareHtmlReaderFactory,
            IGetByKey<IEnumerable<Statistic>,string> statisticHtmlReaderFactory
            )
        {
            this.dbPriceRepo = dbPriceRepoFactory;
            this.dbSetIndexRepo = dbSetIndexRepoFactory;
            this.dbConsensusRepo = dbConsensusRepoFactory;
            this.dbShareRepo = dbShareRepoFactory;
            this.dbStatisticRepo = dbStatisticRepoFactory;
            this.consensusHtmlReader = consensusHtmlReaderFactory;
            this.priceHtmlReader = priceHtmlReaderFactory;
            this.setIndexHtmlReader = setIndexHtmlReaderFactory;
            this.shareHtmlReader = shareHtmlReaderFactory;
            this.statisticHtmlReader = statisticHtmlReaderFactory;
        }
        public async Task OperateAsync(string quote)
        {
            var webTupleTask = readFromWeb(quote);
            var dbTupleTask = readFromDB(quote);
            var webTuple = await webTupleTask;
            var dbTuple = await dbTupleTask;

            var tupleToInsert = calculateTupleToInsert(webTuple,dbTuple);

            var insertTask = insertToDB(tupleToInsert);
            var updateConsensusTask = updateConcensus(webTuple.Item3,dbTuple.Item3);
            var updateShareTask = updateShare(webTuple.Item4,dbTuple.Item4);
            var updateStatisticTask = updateStatistic(webTuple.Item5,dbTuple.Item5);

            await Task.WhenAll(insertTask,updateConsensusTask,updateShareTask,updateStatisticTask);
        }
        private async Task<Tuple<IEnumerable<Price>,IEnumerable<SetIndex>,IEnumerable<Consensus>,IEnumerable<Share>,IEnumerable<Statistic>>> readFromWeb(string quote)
        {
            var priceTask = priceHtmlReader.GetByKeyAsync(quote);
            var setIndexTask = setIndexHtmlReader.GetByKeyAsync(quote);
            var consensusTask = consensusHtmlReader.GetByKeyAsync(quote);
            var shareTask = shareHtmlReader.GetByKeyAsync(quote);
            var statisticTask = statisticHtmlReader.GetByKeyAsync(quote);

            var price = await priceTask;
            var setIndex = await setIndexTask;
            var consensus = await consensusTask;
            var share = await shareTask;
            var statistic = await statisticTask;

            return new Tuple<IEnumerable<Price>,IEnumerable<SetIndex>,IEnumerable<Consensus>,IEnumerable<Share>,IEnumerable<Statistic>>(price, setIndex,consensus,share,statistic);
        }
        private async Task<Tuple<IEnumerable<Price>,IEnumerable<SetIndex>,IEnumerable<Consensus>,IEnumerable<Share>,IEnumerable<Statistic>>> readFromDB(string quote)
        {
            var priceTask = dbPriceRepo.GetByKeyAsync(quote);
            var setIndexTask = dbSetIndexRepo.GetAllAsync();
            var consensusTask = dbConsensusRepo.GetByKeyAsync(quote);
            var shareTask = dbShareRepo.GetByKeyAsync(quote);
            var statisticTask = dbStatisticRepo.GetByKeyAsync(quote);

            var price = await priceTask;
            var setIndex = await setIndexTask;
            var consensus = await consensusTask;
            var share = await shareTask;
            var statistic = await statisticTask;

            return new Tuple<IEnumerable<Price>,IEnumerable<SetIndex>,IEnumerable<Consensus>,IEnumerable<Share>,IEnumerable<Statistic>>(price, setIndex,consensus,share,statistic);
        }
        private Tuple<IEnumerable<Price>,IEnumerable<SetIndex>,IEnumerable<Consensus>,IEnumerable<Share>,IEnumerable<Statistic>> calculateTupleToInsert(
            Tuple<IEnumerable<Price>,IEnumerable<SetIndex>,IEnumerable<Consensus>,IEnumerable<Share>,IEnumerable<Statistic>> webTuple, 
            Tuple<IEnumerable<Price>,IEnumerable<SetIndex>,IEnumerable<Consensus>,IEnumerable<Share>,IEnumerable<Statistic>> dbTuple)
        {
            var priceToInsert = webTuple.Item1.GetItemToInsert(dbTuple.Item1);
            var setIndexToInsert = webTuple.Item2.GetItemToInsert(dbTuple.Item2);
            var consensusToInsert = webTuple.Item3.GetItemToInsert(dbTuple.Item3);
            var shareToInsert = webTuple.Item4.GetItemToInsert(dbTuple.Item4);
            var statisticToInsert = webTuple.Item5.GetItemToInsert(dbTuple.Item5);

            return new Tuple<IEnumerable<Price>,IEnumerable<SetIndex>,IEnumerable<Consensus>,IEnumerable<Share>,IEnumerable<Statistic>>(priceToInsert, setIndexToInsert,consensusToInsert,shareToInsert,statisticToInsert);
        }
        private async Task insertToDB(
            Tuple<IEnumerable<Price>,
            IEnumerable<SetIndex>,
            IEnumerable<Consensus>,
            IEnumerable<Share>,
            IEnumerable<Statistic>> tupleToInsert)
        {
            var priceInsertTask = operateBatchInsertAsync(tupleToInsert.Item1, dbPriceRepo);
            var setIndexInsertTask = operateBatchInsertAsync(tupleToInsert.Item2, dbSetIndexRepo);
            var consensusInsertTask = operateBatchInsertAsync(tupleToInsert.Item3, dbConsensusRepo);
            var shareInsertTask = operateBatchInsertAsync(tupleToInsert.Item4, dbShareRepo);
            var statisticInsertTask = operateBatchInsertAsync(tupleToInsert.Item5, dbStatisticRepo);

            await Task.WhenAll(priceInsertTask,setIndexInsertTask,consensusInsertTask,shareInsertTask,statisticInsertTask);
        }
        private async Task updateConcensus(IEnumerable<Consensus> webItems, IEnumerable<Consensus> dbItems)
        {
            var items = webItems.GetItemToUpdate(dbItems);
            await dbConsensusRepo.BatchUpdateAsync(items);
        }
        private async Task updateShare(IEnumerable<Share> webItems, IEnumerable<Share> dbItems)
        {
            var items = webItems.GetItemToUpdate(dbItems);
            await dbShareRepo.BatchUpdateAsync(items);
        }
        private async Task updateStatistic(IEnumerable<Statistic> webItems, IEnumerable<Statistic> dbItems)
        {
            var items = webItems.GetItemToUpdate(dbItems);
            await dbStatisticRepo.BatchUpdateAsync(items);
        }
        private async Task operateBatchInsertAsync<T>(IEnumerable<T> items, IRepo<T> repo) where T:IPersistant
        {
            await repo.BatchInsertAsync(items);
        }
    }
}