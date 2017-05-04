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

namespace StockCore.Factory.Builder
{
    public class StockByGroupBuilderFactory : BaseFactory<string,IBuilder<string, DECollection<StockDE>>>
    {
        private const string KEY = "StockByGroupBuilder";
        private const int ID = 1023100;
        private const int PROCESSERRID = 1023101;
        private const int OUTERERRID = 1023102;
        private const int MONPROCESSERRID = 1023103;
        private const int MONOUTERERRID = 1023104;
        private const int CACHEPROCESSERRID = 1023105;
        private const int CACHEOUTERERRID = 1023106;
        private readonly IConfigReader configReader;
        private readonly IFactory<string, IGetByKeyRepo<QuoteGroup,string>> quoteGroupRepoFactory;
        private readonly IFactory<string, IBuilder<string, StockDE>> stockBuilderFactory;
        private readonly IFactory<string, IGetByFuncRepo<string,CacheDE<DECollection<StockDE>>>> cacheRepoFactory;
        public StockByGroupBuilderFactory(ILogger logger,
            IFactory<string, IGetByKeyRepo<QuoteGroup,string>> quoteGroupRepoFactory,
            IFactory<string, IBuilder<string, StockDE>> stockBuilderFactory,
            IFactory<string, IGetByFuncRepo<string,CacheDE<DECollection<StockDE>>>> cacheRepoFactory,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.quoteGroupRepoFactory = quoteGroupRepoFactory;
            this.stockBuilderFactory = stockBuilderFactory;
            this.cacheRepoFactory = cacheRepoFactory;
            this.configReader = configReader;
        }
        protected override IBuilder<string, DECollection<StockDE>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IBuilder<string, DECollection<StockDE>> inner = new StockByGroupBuilder(
                logger,
                quoteGroupRepoFactory.Build(tracer),
                stockBuilderFactory.Build(tracer)
                );  
            var module = configReader.GetByKey(getAopKey());
            if(module.IsCacheActive())
            {
                inner = new CacheBuilderDec<string,DECollection<StockDE>>(
                    inner,
                    CacheHelper.GetKeyByString(),
                    cacheRepoFactory.Build(tracer),
                    module.Cache,
                    CACHEPROCESSERRID,
                    CACHEOUTERERRID,
                    logger
                );
            }
            if(module.IsMonitoringActive())
            {
                inner = new MonBuilderDec<string,DECollection<StockDE>>(
                    inner,
                    ValidationHelper.ValidateString(1023107,"GroupName"),
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