using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StockCore.Business.Operation;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Operation.Sync;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Aop.Mon;
using StockCore.Helper;
using System;

namespace StockCore.Factory.Sync
{
    public class SyncPriceFactory : BaseFactory<string,IOperation<IEnumerable<Price>>>
    {
        private const string KEY = "SyncPrice";
        private const int ID = 1015100;
        private const int PROCESSERRID = 1015101;
        private const int OUTERERRID = 1015102;
        private const int MONPROCESSERRID = 1015103;
        private const int MONOUTERERRID = 1015104;
        private readonly IFactory<string, IGetByKeyRepo<Price,string>> dbPriceDEFactory;
        private readonly IConfigReader<IModule> moduleReader;
        public SyncPriceFactory(
            ILogger logger,
            IFactory<string, IGetByKeyRepo<Price,string>> dbPriceDEFactory,
            IConfigReader<IModule> moduleReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.dbPriceDEFactory = dbPriceDEFactory;
            this.moduleReader = moduleReader;
        }
        protected override IOperation<IEnumerable<Price>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<Price>> inner = new SyncDataByKey<string, Price>(dbPriceDEFactory.Build(tracer), false);
            var module = moduleReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IOperation<IEnumerable<Price>> loadMonitoringDecorator(Tracer tracer, IOperation<IEnumerable<Price>> inner, IModule module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonOperationDec<IEnumerable<Price>>(
                    inner,
                    ValidationHelper.ValidateItemsWithStringKeyField<Price>(1015105, "Quote"),
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