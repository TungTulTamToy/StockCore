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

namespace StockCore.Factory.Sync
{
    public class SyncQuoteGroupFactory : BaseFactory<string,IOperation<IEnumerable<QuoteGroup>>>
    {
        private const string KEY = "SyncQuoteGroup";
        private const int ID = 1017100;
        private const int PROCESSERRID = 1017101;
        private const int OUTERERRID = 1017102;
        private const int MONPROCESSERRID = 1017103;
        private const int MONOUTERERRID = 1017104;
        private readonly IConfigReader configReader;
        private readonly IFactory<string, IGetByKeyRepo<QuoteGroup,string>> dbQuoteGroupDEFactory;
        public SyncQuoteGroupFactory(
            ILogger logger,
            IFactory<string, IGetByKeyRepo<QuoteGroup,string>> dbQuoteGroupDEFactory,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.dbQuoteGroupDEFactory = dbQuoteGroupDEFactory;
            this.configReader = configReader;
        }
        protected override IOperation<IEnumerable<QuoteGroup>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<QuoteGroup>> inner = new SyncDataByKey<string, QuoteGroup>(dbQuoteGroupDEFactory.Build(tracer), true);
            var module = configReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IOperation<IEnumerable<QuoteGroup>> loadMonitoringDecorator(Tracer tracer, IOperation<IEnumerable<QuoteGroup>> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonOperationDec<IEnumerable<QuoteGroup>>(
                    inner,
                    ValidationHelper.ValidateQuoteGroups(1017105),
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