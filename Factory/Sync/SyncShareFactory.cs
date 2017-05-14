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
    public class SyncShareFactory : BaseFactory<string,IOperation<IEnumerable<Share>>>
    {
        private const string KEY = "SyncShare";
        private const int ID = 1018100;
        private const int PROCESSERRID = 1018101;
        private const int OUTERERRID = 1018102;
        private const int MONPROCESSERRID = 1018103;
        private const int MONOUTERERRID = 1018104;
        private readonly IFactory<string, IGetByKeyRepo<Share,string>> dbShareDEFactory;
        private readonly IConfigReader<IModule> moduleReader;
        public SyncShareFactory(
            ILogger logger,
            IFactory<string, IGetByKeyRepo<Share,string>> dbShareDEFactory,
            IConfigReader<IModule> moduleReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.dbShareDEFactory = dbShareDEFactory;
            this.moduleReader = moduleReader;
        }
        protected override IOperation<IEnumerable<Share>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<Share>> inner = new SyncDataByKey<string, Share>(dbShareDEFactory.Build(tracer));
            var module = moduleReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }

        private IOperation<IEnumerable<Share>> loadMonitoringDecorator(Tracer tracer, IOperation<IEnumerable<Share>> inner, IModule module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonOperationDec<IEnumerable<Share>>(
                    inner,
                    ValidationHelper.ValidateItemsWithStringKeyField<Share>(1018105, "Quote"),
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