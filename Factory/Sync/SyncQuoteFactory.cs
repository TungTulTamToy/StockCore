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
using System;

namespace StockCore.Factory.Sync
{
    public class SyncQuoteFactory : BaseFactory<SyncQuoteFactoryCondition,IOperation<string>>, IDisposable
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
        private readonly IFactory<string, IGetByKeyRepo<Share,string>> dbShareRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<Statistic,string>> dbStatisticRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<OperationState,string>> operationStateRepoFactory;
        private readonly IConfigReader configReader;
        private readonly IFactory<string, IGetByKey<IEnumerable<Consensus>,string>> consensusHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<Price>,string>> priceHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<SetIndex>,string>> setIndexHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<Share>,string>> shareHtmlReaderFactory;
        private readonly IFactory<string, IGetByKey<IEnumerable<Statistic>,string>> statisticHtmlReaderFactory;
        private readonly IFactory<string, IOperation<IEnumerable<Price>>> syncPriceFactory;
        private readonly IFactory<string, IOperation<IEnumerable<SetIndex>>> syncSetIndexFactory;
        private readonly IFactory<string, IOperation<IEnumerable<Consensus>>> syncConsensusFactory;
        private readonly IFactory<string, IOperation<IEnumerable<Share>>> syncShareFactory;
        private readonly IFactory<string, IOperation<IEnumerable<Statistic>>> syncStatisticFactory;
        public SyncQuoteFactory(ILogger logger,
            IFactory<string, IGetByKeyRepo<Price,string>> dbPriceRepoFactory,
            IFactory<string, IRepo<SetIndex>> dbSetIndexRepoFactory,
            IFactory<string, IGetByKeyRepo<Consensus,string>> dbConsensusRepoFactory,
            IFactory<string, IGetByKeyRepo<Share,string>> dbShareRepoFactory,
            IFactory<string, IGetByKeyRepo<Statistic,string>> dbStatisticRepoFactory,
            IFactory<string, IGetByKeyRepo<OperationState,string>> operationStateRepoFactory,
            IConfigReader configReader,
            IFactory<string, IGetByKey<IEnumerable<Consensus>,string>> consensusHtmlReaderFactory,
            IFactory<string, IGetByKey<IEnumerable<Price>,string>> priceHtmlReaderFactory,
            IFactory<string, IGetByKey<IEnumerable<SetIndex>,string>> setIndexHtmlReaderFactory,
            IFactory<string, IGetByKey<IEnumerable<Share>,string>> shareHtmlReaderFactory,
            IFactory<string, IGetByKey<IEnumerable<Statistic>,string>> statisticHtmlReaderFactory,
            IFactory<string, IOperation<IEnumerable<Price>>> syncPriceFactory,
            IFactory<string, IOperation<IEnumerable<SetIndex>>> syncSetIndexFactory,
            IFactory<string, IOperation<IEnumerable<Consensus>>> syncConsensusFactory,
            IFactory<string, IOperation<IEnumerable<Share>>> syncShareFactory,
            IFactory<string, IOperation<IEnumerable<Statistic>>> syncStatisticFactory
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
            this.syncPriceFactory = syncPriceFactory;
            this.syncSetIndexFactory = syncSetIndexFactory;
            this.syncConsensusFactory = syncConsensusFactory;
            this.syncShareFactory = syncShareFactory;
            this.syncStatisticFactory = syncStatisticFactory;
        }
        protected override IOperation<string> baseFactoryBuild(Tracer tracer,SyncQuoteFactoryCondition condition=null)
        {
            IOperation<string> inner = null;
            if (condition != null && condition.Type == SyncQuoteFactoryCondition.SyncType.MethodTwo)
            {
                inner = new SyncQuoteByKey(
                    syncPriceFactory.Build(tracer),
                    syncSetIndexFactory.Build(tracer),
                    syncConsensusFactory.Build(tracer),
                    syncShareFactory.Build(tracer),
                    syncStatisticFactory.Build(tracer),
                    consensusHtmlReaderFactory.Build(tracer),
                    priceHtmlReaderFactory.Build(tracer),
                    setIndexHtmlReaderFactory.Build(tracer),
                    shareHtmlReaderFactory.Build(tracer),
                    statisticHtmlReaderFactory.Build(tracer));
            }
            else
            {
                inner = new SyncQuote(
                    dbPriceRepoFactory.Build(tracer),
                    dbSetIndexRepoFactory.Build(tracer),
                    dbConsensusRepoFactory.Build(tracer),
                    dbShareRepoFactory.Build(tracer),
                    dbStatisticRepoFactory.Build(tracer),
                    consensusHtmlReaderFactory.Build(tracer),
                    priceHtmlReaderFactory.Build(tracer),
                    setIndexHtmlReaderFactory.Build(tracer),
                    shareHtmlReaderFactory.Build(tracer),
                    statisticHtmlReaderFactory.Build(tracer));
            }
            var module = configReader.GetByKey(getAopKey());
            inner = loadRetryDecorator(tracer, inner, module);
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IOperation<string> loadRetryDecorator(Tracer tracer, IOperation<string> inner, Module module)
        {
            if (module.IsRetryActive())
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
            return inner;
        }
        private IOperation<string> loadMonitoringDecorator(Tracer tracer, IOperation<string> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonOperationDec<string>(
                    inner,
                    ValidationHelper.ValidateStringWithNotActivateOnly(1016107, "Quote"),
                    MONPROCESSERRID,
                    MONOUTERERRID,
                    module.Monitoring,
                    logger,
                    tracer
                    );
            }
            return inner;
        }
        private bool disposed = false;
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    if(consensusHtmlReaderFactory!=null)
                    {
                        consensusHtmlReaderFactory.Dispose();
                    }
                    if(priceHtmlReaderFactory!=null)
                    {
                        priceHtmlReaderFactory.Dispose();
                    }
                    if(setIndexHtmlReaderFactory!=null)
                    {
                        setIndexHtmlReaderFactory.Dispose();
                    }
                    if(shareHtmlReaderFactory!=null)
                    {
                        shareHtmlReaderFactory.Dispose();
                    }
                    if(statisticHtmlReaderFactory!=null)
                    {
                        statisticHtmlReaderFactory.Dispose();
                    }
                }
                disposed = true;
            }
        }
        ~SyncQuoteFactory()
        {
            Dispose(false);
        }
    }
}