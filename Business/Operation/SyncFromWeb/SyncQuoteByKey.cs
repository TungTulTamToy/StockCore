using System.Threading.Tasks;
using System.Collections.Generic;
using StockCore.DomainEntity;
using StockCore.Business.Repo;

namespace StockCore.Business.Operation.SyncFromWeb
{
    public class SyncQuoteByKey:IOperation<string>
    {
        private readonly IOperation<IEnumerable<Price>> syncPrice;
        private readonly IOperation<IEnumerable<SetIndex>> syncSetIndex;
        private readonly IOperation<IEnumerable<Consensus>> syncConsensus;
        private readonly IOperation<IEnumerable<Share>> syncShare;
        private readonly IOperation<IEnumerable<Statistic>> syncStatistic;
        private readonly IGetByKey<IEnumerable<Consensus>,string> consensusHtmlReader;
        private readonly IGetByKey<IEnumerable<Price>,string> priceHtmlReader;
        private readonly IGetByKey<IEnumerable<SetIndex>,string> setIndexHtmlReader;
        private readonly IGetByKey<IEnumerable<Share>,string> shareHtmlReader;
        private readonly IGetByKey<IEnumerable<Statistic>,string> statisticHtmlReader;
        public SyncQuoteByKey(
            IOperation<IEnumerable<Price>> syncPrice,
            IOperation<IEnumerable<SetIndex>> syncSetIndex,
            IOperation<IEnumerable<Consensus>> syncConsensus,
            IOperation<IEnumerable<Share>> syncShare,
            IOperation<IEnumerable<Statistic>> syncStatistic,
            IGetByKey<IEnumerable<Consensus>,string> consensusHtmlReader,
            IGetByKey<IEnumerable<Price>,string> priceHtmlReader,
            IGetByKey<IEnumerable<SetIndex>,string> setIndexHtmlReader,
            IGetByKey<IEnumerable<Share>,string> shareHtmlReader,
            IGetByKey<IEnumerable<Statistic>,string> statisticHtmlReader
            )
        {
            this.syncPrice = syncPrice;
            this.syncSetIndex = syncSetIndex;
            this.syncConsensus = syncConsensus;
            this.syncShare = syncShare;
            this.syncStatistic = syncStatistic;
            this.consensusHtmlReader = consensusHtmlReader;
            this.priceHtmlReader = priceHtmlReader;
            this.setIndexHtmlReader = setIndexHtmlReader;
            this.shareHtmlReader = shareHtmlReader;
            this.statisticHtmlReader = statisticHtmlReader;
        }
        public async Task OperateAsync(string quote)
        {
            var priceTask = subOperateAsync(quote,priceHtmlReader,syncPrice);
            var setIndexTask = subOperateAsync(quote,setIndexHtmlReader,syncSetIndex);
            var consensusTask = subOperateAsync(quote,consensusHtmlReader,syncConsensus);
            var shareTask = subOperateAsync(quote,shareHtmlReader,syncShare);
            var statisticTask = subOperateAsync(quote,statisticHtmlReader,syncStatistic);
            await Task.WhenAll(priceTask,setIndexTask,consensusTask,shareTask,statisticTask);
        }
        private async Task subOperateAsync<T>(string quote, IGetByKey<IEnumerable<T>,string> webReader, IOperation<IEnumerable<T>> syncOperaton)
        {
            var source = await webReader.GetByKeyAsync(quote);
            await syncOperaton.OperateAsync(source);
        }
    }
}