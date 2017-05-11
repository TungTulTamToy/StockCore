using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Aop.Mon;
using StockCore.Helper;
using StockCore.Business.Builder;
using StockCore.Business.Repo.MongoDB;
using StockCore.Aop.Cache;
using System.Collections.Generic;
using StockCore.Aop.Chain;
using StockCore.Aop.Switch;

namespace StockCore.Factory.Builder
{
    public class StockByGroupBuilderFactory : BaseFactory<string,IBuilder<string, IEnumerable<Stock>>>
    {
        private const string KEY = "StockByGroupBuilder";
        private const int ID = 1023100;
        private const int PROCESSERRID = 1023101;
        private const int OUTERERRID = 1023102;
        private const int MONPROCESSERRID = 1023103;
        private const int MONOUTERERRID = 1023104;
        private const int CACHEPROCESSERRID = 1023105;
        private const int CACHEOUTERERRID = 1023106;
        private const int SWITCHPROCESSERRID = 1023108;
        private const int SWITCHOUTERERRID = 10231109;
        private readonly IConfigReader<IModule> moduleReader;
        private readonly IConfigReader<IDynamicGroup> dynamicGroupReader;
        private readonly IFactory<string, IGetByKeyRepo<QuoteGroup,string>> quoteGroupRepoFactory;
        private readonly IFactory<string, IBuilder<string, Stock>> stockBuilderFactory;
        private readonly IFactory<string, IGetByFuncRepo<string,StockCoreCache<IEnumerable<Stock>>>> cacheRepoFactory;
        public StockByGroupBuilderFactory(ILogger logger,
            IFactory<string, IGetByKeyRepo<QuoteGroup,string>> quoteGroupRepoFactory,
            IFactory<string, IBuilder<string, Stock>> stockBuilderFactory,
            IFactory<string, IGetByFuncRepo<string,StockCoreCache<IEnumerable<Stock>>>> cacheRepoFactory,
            IConfigReader<IModule> moduleReader,
            IConfigReader<IDynamicGroup> dynamicGroupReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.quoteGroupRepoFactory = quoteGroupRepoFactory;
            this.stockBuilderFactory = stockBuilderFactory;
            this.cacheRepoFactory = cacheRepoFactory;
            this.moduleReader = moduleReader;
            this.dynamicGroupReader = dynamicGroupReader;
        }
        protected override IBuilder<string, IEnumerable<Stock>> baseFactoryBuild(Tracer tracer,string t="")
        {
            var quoteGroupProvider = quoteGroupRepoFactory.Build(tracer);
            var stockBuilder = stockBuilderFactory.Build(tracer);
            IBuilder<string, IEnumerable<Stock>> inner = new StockByStaticGroupBuilder(
                logger,
                quoteGroupProvider,
                stockBuilder
                );
            var module = moduleReader.GetByKey(getAopKey());
            inner = loadSwitchDecorator(inner, module, quoteGroupProvider, stockBuilder);
            inner = loadCachingDecorator(tracer, inner, module);
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IBuilder<string, IEnumerable<Stock>> loadSwitchDecorator(
            IBuilder<string, IEnumerable<Stock>> inner, 
            IModule module, 
            IGetByKeyRepo<QuoteGroup,string> quoteGroupProvider,
            IBuilder<string, Stock> stockBuilder)
        {
            if (module.IsSwitchActive())
            {
                var switchInner = new StockByDynamicGroupBuilder(
                    logger,
                    dynamicGroupReader,
                    quoteGroupProvider,
                    stockBuilder
                );
                inner = new SwitchBuilderDec<string,IEnumerable<Stock>>(
                    QuoteGroupHelper.IsDynamicGroup(dynamicGroupReader),
                    inner,
                    switchInner,
                    module.Switch,
                    SWITCHOUTERERRID,
                    SWITCHPROCESSERRID,
                    logger);
            }
            return inner;
        }
        private IBuilder<string, IEnumerable<Stock>> loadCachingDecorator(Tracer tracer, IBuilder<string, IEnumerable<Stock>> inner, IModule module)
        {
            if (module.IsCacheActive())
            {
                inner = new CacheBuilderDec<string, IEnumerable<Stock>>(
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
        private IBuilder<string, IEnumerable<Stock>> loadMonitoringDecorator(Tracer tracer, IBuilder<string, IEnumerable<Stock>> inner, IModule module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonBuilderDec<string, IEnumerable<Stock>>(
                    inner,
                    ValidationHelper.ValidateString(1023107, "GroupName"),
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