using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StockCore.Business.Worker;
using StockCore.Business.Worker.SyncFromWeb;
using StockCore.Business.Repo;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using StockCore.Aop.Retry.Worker;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Aop.Mon.Worker;
using StockCore.Aop.Mon;
using StockCore.Helper;

namespace StockCore.Factory
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
        private readonly IFactory<string, IGetByKeyRepo<PriceDE,string>> dbPriceRepoFactory;
        private readonly IFactory<string, IRepo<SetIndexDE>> dbSetIndexRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<ConsensusDE,string>> dbConsensusRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<ShareDE,string>> dbShareRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<StatisticDE,string>> dbStatisticRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<OperationStateDE,string>> operationStateRepoFactory;
        private readonly IConfigReader configReader;
        private readonly IFactory<string, IGetByKey<IEnumerable<ConsensusDE>,string>> consensusHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<PriceDE>,string>> priceHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<SetIndexDE>,string>> setIndexHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<ShareDE>,string>> shareHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<StatisticDE>,string>> statisticHtmlReaderFactory;
        public SyncQuoteFactory(ILogger logger,
            IFactory<string, IGetByKeyRepo<PriceDE,string>> dbPriceRepoFactory,
            IFactory<string, IRepo<SetIndexDE>> dbSetIndexRepoFactory,
            IFactory<string, IGetByKeyRepo<ConsensusDE,string>> dbConsensusRepoFactory,
            IFactory<string, IGetByKeyRepo<ShareDE,string>> dbShareRepoFactory,
            IFactory<string, IGetByKeyRepo<StatisticDE,string>> dbStatisticRepoFactory,
            IFactory<string, IGetByKeyRepo<OperationStateDE,string>> operationStateRepoFactory,
            IConfigReader configReader,
            IFactory<string, IGetByKey<IEnumerable<ConsensusDE>,string>> consensusHtmlReaderFactory,
            IFactory<string, IGetByKey<IEnumerable<PriceDE>,string>> priceHtmlReaderFactory,
            IFactory<string, IGetByKey<IEnumerable<SetIndexDE>,string>> setIndexHtmlReaderFactory,
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
                inner = new RetryOperationDec(
                    inner,
                    operationStateRepoFactory.Build(tracer),
                    module.Retry,
                    RETRYOUTERERRID,
                    RETRYPROCESSERRID,
                    logger);
            }
            if(module.IsMonitoringActive())
            {
                var helper = new ValidationHelper();
                inner = new MonOperationDec<string>(
                    inner,
                    helper.ValidateString(1016107,"Quote"),   
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