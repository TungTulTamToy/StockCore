using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Aop.Mon;
using StockCore.Helper;
using StockCore.Business.Builder;
using StockCore.Business.Repo.MongoDB;
using StockCore.Aop.Cache;
using System;
using System.Collections.Generic;

namespace StockCore.Factory.Builder
{
    public class StockBuilderFactory : BaseFactory<string,IBuilder<string, Stock>>
    {
        private const string KEY = "StockBuilder";
        private const int ID = 1020100;
        private const int PROCESSERRID = 1020101;
        private const int OUTERERRID = 1020102;
        private const int MONPROCESSERRID = 1020103;
        private const int MONOUTERERRID = 1020104;
        private const int CACHEPROCESSERRID = 1020105;
        private const int CACHEOUTERERRID = 1020106;
        private readonly IConfigReader configReader;
        private readonly IFactory<string, IGetByKeyRepo<Share,string>> shareRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<Statistic,string>> statisticRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<Consensus,string>> consensusRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<Price,string>> priceRepoFactory;
        private readonly IFactory<string, IGetByFuncRepo<string,StockCoreCache<Stock>>> cacheRepoFactory;
        private readonly IFactory<string, IBuilder<IEnumerable<Price>, IEnumerable<PriceCal>>> priceCalBuilderFactory;
        public StockBuilderFactory(ILogger logger,
            IFactory<string, IGetByKeyRepo<Share,string>> shareRepoFactory,
            IFactory<string, IGetByKeyRepo<Statistic,string>> statisticRepoFactory,
            IFactory<string, IGetByKeyRepo<Consensus,string>> consensusRepoFactory,
            IFactory<string, IGetByKeyRepo<Price,string>> priceRepoFactory,
            IFactory<string, IGetByFuncRepo<string,StockCoreCache<Stock>>> cacheRepoFactory,
            IFactory<string, IBuilder<IEnumerable<Price>, IEnumerable<PriceCal>>> priceCalBuilderFactory,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.shareRepoFactory = shareRepoFactory;
            this.statisticRepoFactory = statisticRepoFactory;
            this.consensusRepoFactory = consensusRepoFactory;
            this.priceRepoFactory = priceRepoFactory;
            this.cacheRepoFactory = cacheRepoFactory;
            this.priceCalBuilderFactory = priceCalBuilderFactory;
            this.configReader = configReader;
        }
        protected override IBuilder<string, Stock> baseFactoryBuild(Tracer tracer,string t="")
        {
            IBuilder<string, Stock> inner = new StockBuilder(
                logger,
                shareRepoFactory.Build(tracer),
                statisticRepoFactory.Build(tracer),
                consensusRepoFactory.Build(tracer),
                priceRepoFactory.Build(tracer),
                priceCalBuilderFactory.Build(tracer),
                DateTime.Now);
            var module = configReader.GetByKey(getAopKey());
            inner = loadCachingDecorator(tracer, inner, module);
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IBuilder<string, Stock> loadCachingDecorator(Tracer tracer, IBuilder<string, Stock> inner, Module module)
        {
            if (module.IsCacheActive())
            {
                inner = new CacheBuilderDec<string, Stock>(
                    inner,
                    CacheHelper.GetKeyByString(),
                    cacheRepoFactory.Build(tracer),
                    module.Cache,
                    CACHEPROCESSERRID,
                    CACHEOUTERERRID,
                    logger);
            }
            return inner;
        }
        private IBuilder<string, Stock> loadMonitoringDecorator(Tracer tracer, IBuilder<string, Stock> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonBuilderDec<string, Stock>(
                    inner,
                    ValidationHelper.ValidateString(1020105, "Quote"),
                    MONPROCESSERRID,
                    MONOUTERERRID,
                    module.Monitoring,
                    logger,
                    tracer);
            }
            return inner;
        }
    }
}