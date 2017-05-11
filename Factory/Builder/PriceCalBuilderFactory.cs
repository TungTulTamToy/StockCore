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
    public class PriceCalBuilderFactory : BaseFactory<string,IBuilder<IEnumerable<Price>, IEnumerable<PriceCal>>>
    {
        private const string KEY = "PriceCalBuilder";
        private const int ID = 1025100;
        private const int PROCESSERRID = 1025101;
        private const int OUTERERRID = 1025102;
        private const int MONPROCESSERRID = 1025103;
        private const int MONOUTERERRID = 1025104;
        private readonly IConfigReader<IModule> moduleReader;
        public PriceCalBuilderFactory(ILogger logger,
            IConfigReader<IModule> moduleReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.moduleReader = moduleReader;
        }
        protected override IBuilder<IEnumerable<Price>, IEnumerable<PriceCal>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IBuilder<IEnumerable<Price>, IEnumerable<PriceCal>> inner = new PriceCalBuilder(
                logger,
                DateTime.Now);
            var module = moduleReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IBuilder<IEnumerable<Price>, IEnumerable<PriceCal>> loadMonitoringDecorator(Tracer tracer, IBuilder<IEnumerable<Price>, IEnumerable<PriceCal>> inner, IModule module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonBuilderDec<IEnumerable<Price>, IEnumerable<PriceCal>>(
                    inner,
                    ValidationHelper.ValidateItemsWithStringKeyField<Price>(),
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