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
    public class SyncSetIndexFactory : BaseFactory<string,IOperation<IEnumerable<SetIndex>>>
    {
        private const string KEY = "SyncSetIndex";
        private const int ID = 1024100;
        private const int PROCESSERRID = 1024101;
        private const int OUTERERRID = 1024102;
        private const int MONPROCESSERRID = 1024103;
        private const int MONOUTERERRID = 1024104;
        private readonly IFactory<string, IRepo<SetIndex>> setIndexRepoFactory;
        private readonly IConfigReader<IModule> moduleReader;
        public SyncSetIndexFactory(
            ILogger logger,
            IFactory<string, IRepo<SetIndex>> setIndexRepoFactory,
            IConfigReader<IModule> moduleReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.setIndexRepoFactory = setIndexRepoFactory;
            this.moduleReader = moduleReader;
        }
        protected override IOperation<IEnumerable<SetIndex>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<SetIndex>> inner = new SyncAllData<SetIndex>(setIndexRepoFactory.Build(tracer), false);
            var module = moduleReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IOperation<IEnumerable<SetIndex>> loadMonitoringDecorator(Tracer tracer, IOperation<IEnumerable<SetIndex>> inner, IModule module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonOperationDec<IEnumerable<SetIndex>>(
                    inner,
                    ValidationHelper.ValidateItemsNotThrowException<SetIndex>(),
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