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
    public class SyncConsensusFactory : BaseFactory<string,IOperation<IEnumerable<Consensus>>>
    {
        private const string KEY = "SyncConsensus";
        private const int ID = 1014100;
        private const int PROCESSERRID = 1014101;
        private const int OUTERERRID = 1014102;
        private const int MONPROCESSERRID = 1014103;
        private const int MONOUTERERRID = 1014104;
        private readonly IFactory<string, IGetByKeyRepo<Consensus,string>> dbConsensusFactory;
        private readonly IConfigReader<IModule> moduleReader;
        public SyncConsensusFactory(
            ILogger logger,
            IFactory<string, IGetByKeyRepo<Consensus,string>> dbConsensusFactory,
            IConfigReader<IModule> moduleReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.dbConsensusFactory = dbConsensusFactory;
            this.moduleReader = moduleReader;
        }
        protected override IOperation<IEnumerable<Consensus>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<Consensus>> inner = new SyncDataByKey<string, Consensus>(dbConsensusFactory.Build(tracer));
            var module = moduleReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IOperation<IEnumerable<Consensus>> loadMonitoringDecorator(Tracer tracer, IOperation<IEnumerable<Consensus>> inner, IModule module)
        {
            if (module.IsMonitoringActive())
            {
                Func<ILogger, Tracer, string, string, IEnumerable<Consensus>, bool> validate = null;
                if (tracer.Caller.ID == 1016100)//Call from SyncQuoteFactory
                {
                    validate = ValidationHelper.ValidateItemsWithStringKeyField<Consensus>();
                }
                else
                {
                    validate = ValidationHelper.ValidateItemsWithStringKeyField<Consensus>(1014102, "Quote");
                }
                inner = new MonOperationDec<IEnumerable<Consensus>>(
                    inner,
                    validate,
                    MONPROCESSERRID,
                    OUTERERRID,
                    module.Monitoring,
                    logger,
                    tracer);
            }
            return inner;
        }
    }
}