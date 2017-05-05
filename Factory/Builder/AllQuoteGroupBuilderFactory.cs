using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Aop.Mon;
using StockCore.Helper;
using StockCore.Business.Builder;
using StockCore.Business.Repo.MongoDB;
using System.Collections.Generic;
using StockCore.Aop.Cache;

namespace StockCore.Factory.Builder
{
    public class AllQuoteGroupBuilderFactory : BaseFactory<string,IBuilder<string, IEnumerable<QuoteGroup>>>
    {
        private const string KEY = "AllQuoteGroupBuilder";
        private const int ID = 1022100;
        private const int PROCESSERRID = 1022101;
        private const int OUTERERRID = 1022102;
        private const int MONPROCESSERRID = 1022103;
        private const int MONOUTERERRID = 1022104;
        private const int CACHEPROCESSERRID = 1022105;
        private const int CACHEOUTERERRID = 1022106;
        private readonly IConfigReader configReader;
        private readonly IFactory<string, IGetByKeyRepo<QuoteGroup,string>> quoteGroupRepoFactory;
        private readonly IFactory<string, IGetByFuncRepo<string,StockCoreCache<IEnumerable<QuoteGroup>>>> cacheRepoFactory;
        public AllQuoteGroupBuilderFactory(ILogger logger,
            IFactory<string, IGetByKeyRepo<QuoteGroup,string>> quoteGroupRepoFactory,
            IFactory<string, IGetByFuncRepo<string,StockCoreCache<IEnumerable<QuoteGroup>>>> cacheRepoFactory,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.quoteGroupRepoFactory = quoteGroupRepoFactory;
            this.cacheRepoFactory = cacheRepoFactory;
            this.configReader = configReader;
        }
        protected override IBuilder<string, IEnumerable<QuoteGroup>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IBuilder<string, IEnumerable<QuoteGroup>> inner = new AllQuoteGroupBuilder(
                logger,
                quoteGroupRepoFactory.Build(tracer)
                );
            var module = configReader.GetByKey(getAopKey());
            inner = loadCachingDecorator(tracer, inner, module);
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IBuilder<string, IEnumerable<QuoteGroup>> loadCachingDecorator(Tracer tracer, IBuilder<string, IEnumerable<QuoteGroup>> inner, Module module)
        {
            if (module.IsCacheActive())
            {
                inner = new CacheBuilderDec<string, IEnumerable<QuoteGroup>>(
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
        private IBuilder<string, IEnumerable<QuoteGroup>> loadMonitoringDecorator(Tracer tracer, IBuilder<string, IEnumerable<QuoteGroup>> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonBuilderDec<string, IEnumerable<QuoteGroup>>(
                    inner,
                    (logger, fakeTracer, moduleName, methodName, value) => true,
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