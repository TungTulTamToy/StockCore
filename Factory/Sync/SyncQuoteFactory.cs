using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StockCore.Business.Operation;
using StockCore.Business.Operation.SyncFromWeb;
using StockCore.Business.Repo;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Aop.Mon;
using StockCore.Helper;
using StockCore.Aop.Retry;
using StockCore.DomainEntity.Enum;
using static StockCore.DomainEntity.Enum.StateOperation;

namespace StockCore.Factory.Sync
{
    public class SyncQuoteFactory : BaseFactory<string,IOperation<string>>
    {
        private const string KEY = "SyncQuote";
        private const int ID = 1016100;
        private const int PROCESSERRID = 1016101;
        private const int OUTERERRID = 1016102;        
        private const int RETRYPROCESSERRID = 1016103;
        private const int RETRYOUTERERRID = 1016104;
        private const int MONPROCESSERRID = 1016105;
        private const int MONOUTERERRID = 1016106;
        private readonly IFactory<string, IGetByKeyRepo<Price,string>> dbPriceRepoFactory;
        private readonly IFactory<string, IRepo<SetIndex>> dbSetIndexRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<Consensus,string>> dbConsensusRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<ShareDE,string>> dbShareRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<StatisticDE,string>> dbStatisticRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<OperationState,string>> operationStateRepoFactory;
        private readonly IConfigReader configReader;
        private readonly IFactory<string, IGetByKey<IEnumerable<Consensus>,string>> consensusHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<Price>,string>> priceHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<SetIndex>,string>> setIndexHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<ShareDE>,string>> shareHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<StatisticDE>,string>> statisticHtmlReaderFactory;
        public SyncQuoteFactory(ILogger logger,
            IFactory<string, IGetByKeyRepo<Price,string>> dbPriceRepoFactory,
            IFactory<string, IRepo<SetIndex>> dbSetIndexRepoFactory,
            IFactory<string, IGetByKeyRepo<Consensus,string>> dbConsensusRepoFactory,
            IFactory<string, IGetByKeyRepo<ShareDE,string>> dbShareRepoFactory,
            IFactory<string, IGetByKeyRepo<StatisticDE,string>> dbStatisticRepoFactory,
            IFactory<string, IGetByKeyRepo<OperationState,string>> operationStateRepoFactory,
            IConfigReader configReader,
            IFactory<string, IGetByKey<IEnumerable<Consensus>,string>> consensusHtmlReaderFactory,
            IFactory<string, IGetByKey<IEnumerable<Price>,string>> priceHtmlReaderFactory,
            IFactory<string, IGetByKey<IEnumerable<SetIndex>,string>> setIndexHtmlReaderFactory,
            IFactory<string, IGetByKey<IEnumerable<ShareDE>,string>> shareHtmlReaderFactory,
            IFactory<string, IGetByKey<IEnumerable<StatisticDE>,string>> statisticHtmlReaderFactory
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.dbPriceRepoFactory = dbPriceRepoFactory;
            this.dbSetIndexRepoFactory = dbSetIndexRepoFactory;
            this.dbConsensusRepoFactory = dbConsensusRepoFactory;
            this.dbShareRepoFactory = dbShareRepoFactory;
            this.dbStatisticRepoFactory = dbStatisticRepoFactory;
            this.operationStateRepoFactory = operationStateRepoFactory;
            this.configReader = configReader;
            this.consensusHtmlReaderFactory = consensusHtmlReaderFactory;
            this.priceHtmlReaderFactory = priceHtmlReaderFactory;
            this.setIndexHtmlReaderFactory = setIndexHtmlReaderFactory;
            this.shareHtmlReaderFactory = shareHtmlReaderFactory;
            this.statisticHtmlReaderFactory = statisticHtmlReaderFactory;
        }
        protected override IOperation<string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<string> inner = new SyncQuote(
                dbPriceRepoFactory.Build(tracer),
                dbSetIndexRepoFactory.Build(tracer),
                dbConsensusRepoFactory.Build(tracer),
                dbShareRepoFactory.Build(tracer),
                dbStatisticRepoFactory.Build(tracer),
                consensusHtmlReaderFactory.Build(tracer),
                priceHtmlReaderFactory.Build(tracer),
                setIndexHtmlReaderFactory.Build(tracer),
                shareHtmlReaderFactory.Build(tracer),
                statisticHtmlReaderFactory.Build(tracer)
            ); 
            var module = configReader.GetByKey(getAopKey());
            if(module.IsRetryActive())
            {
                inner = new RetryOperationDec<string>(
                    inner,
                    CacheHelper.GetKeyByString(),
                    OperationName.RetrySyncQuoteDec,
                    operationStateRepoFactory.Build(tracer),
                    module.Retry,
                    RETRYOUTERERRID,
                    RETRYPROCESSERRID,
                    logger);
            }
            if(module.IsMonitoringActive())
            {
                inner = new MonOperationDec<string>(
                    inner,
                    ValidationHelper.ValidateString(1016107,"Quote"),   
                    MONPROCESSERRID, 
                    MONOUTERERRID,        
                    module.Monitoring,     
                    logger,
                    tracer
                    );
            }
            return inner;
        }
    }
}