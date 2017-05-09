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
using StockCore.Aop.PostFilter;

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
        private const int POSTFILTERPROCESSERRID = 1023108;
        private const int POSTFILTEROUTERERRID = 1023109;
        private readonly IConfigReader configReader;
        private readonly IFactory<string, IGetByKeyRepo<QuoteGroup,string>> quoteGroupRepoFactory;
        private readonly IFactory<string, IBuilder<string, Stock>> stockBuilderFactory;
        private readonly IFactory<string, IGetByFuncRepo<string,StockCoreCache<IEnumerable<Stock>>>> cacheRepoFactory;
        public StockByGroupBuilderFactory(ILogger logger,
            IFactory<string, IGetByKeyRepo<QuoteGroup,string>> quoteGroupRepoFactory,
            IFactory<string, IBuilder<string, Stock>> stockBuilderFactory,
            IFactory<string, IGetByFuncRepo<string,StockCoreCache<IEnumerable<Stock>>>> cacheRepoFactory,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.quoteGroupRepoFactory = quoteGroupRepoFactory;
            this.stockBuilderFactory = stockBuilderFactory;
            this.cacheRepoFactory = cacheRepoFactory;
            this.configReader = configReader;
        }
        protected override IBuilder<string, IEnumerable<Stock>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IBuilder<string, IEnumerable<Stock>> inner = new StockByGroupBuilder(
                logger,
                quoteGroupRepoFactory.Build(tracer),
                stockBuilderFactory.Build(tracer)
                );
            var module = configReader.GetByKey(getAopKey());
            inner = loadPostFilterDecorator(inner, module);
            inner = loadCachingDecorator(tracer, inner, module);
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IBuilder<string, IEnumerable<Stock>> loadPostFilterDecorator(IBuilder<string, IEnumerable<Stock>> inner, Module module)
        {
            if (module.IsPostFilterActive())
            {
                inner = new PostFilterBuilderDec<Stock>(
                    inner,
                    QuoteGroupHelper.DetermineFilter(),
                    POSTFILTERPROCESSERRID,
                    POSTFILTEROUTERERRID,
                    module.PostFilter,
                    logger);
            }
            return inner;
        }
        private IBuilder<string, IEnumerable<Stock>> loadCachingDecorator(Tracer tracer, IBuilder<string, IEnumerable<Stock>> inner, Module module)
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
        private IBuilder<string, IEnumerable<Stock>> loadMonitoringDecorator(Tracer tracer, IBuilder<string, IEnumerable<Stock>> inner, Module module)
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