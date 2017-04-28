using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Aop.Mon;
using StockCore.Helper;
using StockCore.Business.Builder;
using StockCore.Business.Repo.MongoDB;
using StockCore.Aop.Mon.Builder;
using StockCore.Aop.Cache.Builder;
using System.Collections.Generic;

namespace StockCore.Factory
{
    public class AllQuoteGroupBuilderFactory : BaseFactory<string,IBuilder<string, DECollection<QuoteGroupDE>>>
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
        private readonly IFactory<string, IGetByKeyRepo<QuoteGroupDE,string>> allQuoteGroupRepoFactory;
        private readonly IFactory<string, IGetByFuncRepo<string,CacheDE<DECollection<QuoteGroupDE>>>> cacheRepoFactory;
        public AllQuoteGroupBuilderFactory(ILogger logger,
            IFactory<string, IGetByKeyRepo<QuoteGroupDE,string>> allQuoteGroupRepoFactory,
            IFactory<string, IGetByFuncRepo<string,CacheDE<DECollection<QuoteGroupDE>>>> cacheRepoFactory,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.allQuoteGroupRepoFactory = allQuoteGroupRepoFactory;
            this.cacheRepoFactory = cacheRepoFactory;
            this.configReader = configReader;
        }
        protected override IBuilder<string, DECollection<QuoteGroupDE>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IBuilder<string, DECollection<QuoteGroupDE>> inner = new AllQuoteGroupBuilder(
                logger,
                allQuoteGroupRepoFactory.Build(tracer)
                );  
            var module = configReader.GetByKey(getAopKey());
            if(module.IsCacheActive())
            {
                inner = new CacheBuilderDec<DECollection<QuoteGroupDE>>(
                    inner,
                    cacheRepoFactory.Build(tracer),
                    module.Cache,
                    CACHEPROCESSERRID,
                    CACHEOUTERERRID,
                    logger
                );
            }
            if(module.IsMonitoringActive())
            {
                inner = new MonBuilderDec<DECollection<QuoteGroupDE>>(
                    inner,
                    (logger,fakeTracer,keyName,value)=>true,
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