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
    public class SyncQuoteMovementFactory : BaseFactory<string,IOperation<IEnumerable<QuoteMovement>>>
    {
        private const string KEY = "SyncQuoteMovement";
        private const int ID = 1026100;
        private const int PROCESSERRID = 1026101;
        private const int OUTERERRID = 1026102;
        private const int MONPROCESSERRID = 1026103;
        private const int MONOUTERERRID = 1026104;
        private readonly IFactory<string, IGetByKeyRepo<QuoteMovement,string>> dbQuoteMovementFactory;
        private readonly IConfigReader<IModule> moduleReader;
        public SyncQuoteMovementFactory(
            ILogger logger,
            IFactory<string, IGetByKeyRepo<QuoteMovement,string>> dbQuoteMovementFactory,
            IConfigReader<IModule> moduleReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.dbQuoteMovementFactory = dbQuoteMovementFactory;
            this.moduleReader = moduleReader;
        }
        protected override IOperation<IEnumerable<QuoteMovement>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<QuoteMovement>> inner = new SyncDataByKey<string, QuoteMovement>(dbQuoteMovementFactory.Build(tracer));
            var module = moduleReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }

        private IOperation<IEnumerable<QuoteMovement>> loadMonitoringDecorator(Tracer tracer, IOperation<IEnumerable<QuoteMovement>> inner, IModule module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonOperationDec<IEnumerable<QuoteMovement>>(
                    inner:inner,
                    validate:ValidationHelper.ValidateItemsWithStringKeyField<QuoteMovement>(1026105, "Quote"),
                    processErrorID:MONPROCESSERRID,
                    outerErrorID:MONOUTERERRID,
                    module:module.Monitoring,
                    logger:logger,
                    tracer:tracer
                    );
            }
            return inner;
        }
    }
}