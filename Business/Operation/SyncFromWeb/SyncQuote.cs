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
        private readonly IGetByKeyRepo<PriceDE,string> dbPriceRepo;
        private readonly IRepo<SetIndexDE> dbSetIndexRepo;
        private readonly IGetByKeyRepo<ConsensusDE,string> dbConsensusRepo;
        private readonly IGetByKeyRepo<ShareDE,string> dbShareRepo;
        private readonly IGetByKeyRepo<StatisticDE,string> dbStatisticRepo;
        private readonly IGetByKey<IEnumerable<ConsensusDE>,string> consensusHtmlReader;
        private readonly IGetByKey<IEnumerable<PriceDE>,string> priceHtmlReader;
        private readonly IGetByKey<IEnumerable<SetIndexDE>,string> setIndexHtmlReader;
        private readonly IGetByKey<IEnumerable<ShareDE>,string> shareHtmlReader;
        private readonly IGetByKey<IEnumerable<StatisticDE>,string> statisticHtmlReader;
        public SyncQuote(
            IGetByKeyRepo<PriceDE,string> dbPriceRepoFactory,
            IRepo<SetIndexDE> dbSetIndexRepoFactory,
            IGetByKeyRepo<ConsensusDE,string> dbConsensusRepoFactory,
            IGetByKeyRepo<ShareDE,string> dbShareRepoFactory,
            IGetByKeyRepo<StatisticDE,string> dbStatisticRepoFactory,
            IGetByKey<IEnumerable<ConsensusDE>,string> consensusHtmlReaderFactory,
            IGetByKey<IEnumerable<PriceDE>,string> priceHtmlReaderFactory,
            IGetByKey<IEnumerable<SetIndexDE>,string> setIndexHtmlReaderFactory,
            IGetByKey<IEnumerable<ShareDE>,string> shareHtmlReaderFactory,
            IGetByKey<IEnumerable<StatisticDE>,string> statisticHtmlReaderFactory
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

            var tupleToInsert = calculateTupleToInsert(quote,webTuple,dbTuple);

            var insertTask = insertToDB(quote,tupleToInsert);
            var updateConsensusTask = updateConcensus(quote,webTuple.Item3,dbTuple.Item3);
            var updateShareTask = updateShare(quote,webTuple.Item4,dbTuple.Item4);
            var updateStatisticTask = updateStatistic(quote,webTuple.Item5,dbTuple.Item5);

            await Task.WhenAll(insertTask,updateConsensusTask,updateShareTask,updateStatisticTask);
        }
        private async Task<Tuple<IEnumerable<PriceDE>,IEnumerable<SetIndexDE>,IEnumerable<ConsensusDE>,IEnumerable<ShareDE>,IEnumerable<StatisticDE>>> readFromWeb(string quote)
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

            return new Tuple<IEnumerable<PriceDE>,IEnumerable<SetIndexDE>,IEnumerable<ConsensusDE>,IEnumerable<ShareDE>,IEnumerable<StatisticDE>>(price, setIndex,consensus,share,statistic);
        }
        private async Task<Tuple<IEnumerable<PriceDE>,IEnumerable<SetIndexDE>,IEnumerable<ConsensusDE>,IEnumerable<ShareDE>,IEnumerable<StatisticDE>>> readFromDB(string quote)
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

            return new Tuple<IEnumerable<PriceDE>,IEnumerable<SetIndexDE>,IEnumerable<ConsensusDE>,IEnumerable<ShareDE>,IEnumerable<StatisticDE>>(price, setIndex,consensus,share,statistic);
        }
        private Tuple<IEnumerable<PriceDE>,IEnumerable<SetIndexDE>,IEnumerable<ConsensusDE>,IEnumerable<ShareDE>,IEnumerable<StatisticDE>> calculateTupleToInsert(
            string quote,
            Tuple<IEnumerable<PriceDE>,IEnumerable<SetIndexDE>,IEnumerable<ConsensusDE>,IEnumerable<ShareDE>,IEnumerable<StatisticDE>> webTuple, 
            Tuple<IEnumerable<PriceDE>,IEnumerable<SetIndexDE>,IEnumerable<ConsensusDE>,IEnumerable<ShareDE>,IEnumerable<StatisticDE>> dbTuple)
        {
            var priceToInsert = webTuple.Item1.GetItemToInsert<DateTime,PriceDE>(dbTuple.Item1);
            var setIndexToInsert = webTuple.Item2.GetItemToInsert<DateTime,SetIndexDE>(dbTuple.Item2);
            var consensusToInsert = webTuple.Item3.GetItemToInsert<int,ConsensusDE>(dbTuple.Item3);
            var shareToInsert = webTuple.Item4.GetItemToInsert<DateTime,ShareDE>(dbTuple.Item4);
            var statisticToInsert = webTuple.Item5.GetItemToInsert<int,StatisticDE>(dbTuple.Item5);

            return new Tuple<IEnumerable<PriceDE>,IEnumerable<SetIndexDE>,IEnumerable<ConsensusDE>,IEnumerable<ShareDE>,IEnumerable<StatisticDE>>(priceToInsert, setIndexToInsert,consensusToInsert,shareToInsert,statisticToInsert);
        }
        private async Task insertToDB(string quote,
            Tuple<IEnumerable<PriceDE>,IEnumerable<SetIndexDE>,IEnumerable<ConsensusDE>,IEnumerable<ShareDE>,IEnumerable<StatisticDE>> tupleToInsert)
        {
            var priceInsertTask = operateBatchInsertAsync(quote,tupleToInsert.Item1, dbPriceRepo);
            var setIndexInsertTask = operateBatchInsertAsync(quote,tupleToInsert.Item2, dbSetIndexRepo);
            var consensusInsertTask = operateBatchInsertAsync(quote,tupleToInsert.Item3, dbConsensusRepo);
            var shareInsertTask = operateBatchInsertAsync(quote,tupleToInsert.Item4, dbShareRepo);
            var statisticInsertTask = operateBatchInsertAsync(quote,tupleToInsert.Item5, dbStatisticRepo);

            await Task.WhenAll(priceInsertTask,setIndexInsertTask,consensusInsertTask,shareInsertTask,statisticInsertTask);
        }
        private async Task updateConcensus(string quote,IEnumerable<ConsensusDE> webItems, IEnumerable<ConsensusDE> dbItems)
        {
            var items = webItems.GetItemToUpdate<int,ConsensusDE>(dbItems);
            await dbConsensusRepo.BatchUpdateAsync(items);
        }
        private async Task updateShare(string quote,IEnumerable<ShareDE> webItems, IEnumerable<ShareDE> dbItems)
        {
            var items = webItems.GetItemToUpdate<DateTime,ShareDE>(dbItems);
            await dbShareRepo.BatchUpdateAsync(items);
        }
        private async Task updateStatistic(string quote,IEnumerable<StatisticDE> webItems, IEnumerable<StatisticDE> dbItems)
        {
            var items = webItems.GetItemToUpdate<int,StatisticDE>(dbItems);
            await dbStatisticRepo.BatchUpdateAsync(items);
        }
        private async Task operateBatchInsertAsync<T>(string quote,IEnumerable<T> items, IRepo<T> repo) where T:BaseDE
        {
            await repo.BatchInsertAsync(items);
        }
    }
}