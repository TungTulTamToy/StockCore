using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StockCore.Business.Worker;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Worker.Sync;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Aop.Mon;
using StockCore.Helper;

namespace StockCore.Factory.Sync
{
    public class SyncQuoteGroupFactory : BaseFactory<string,IOperation<IEnumerable<QuoteGroupDE>>>
    {
        private const string KEY = "SyncQuoteGroup";
        private const int ID = 1017100;
        private const int PROCESSERRID = 1017101;
        private const int OUTERERRID = 1017102;
        private const int MONPROCESSERRID = 1017103;
        private const int MONOUTERERRID = 1017104;
        private readonly IConfigReader configReader;
        private readonly IFactory<string, IGetByKeyRepo<QuoteGroupDE,string>> dbQuoteGroupDEFactory;
        public SyncQuoteGroupFactory(
            ILogger logger,
            IFactory<string, IGetByKeyRepo<QuoteGroupDE,string>> dbQuoteGroupDEFactory,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.dbQuoteGroupDEFactory = dbQuoteGroupDEFactory;
            this.configReader = configReader;
        }
        protected override IOperation<IEnumerable<QuoteGroupDE>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<QuoteGroupDE>> inner = new SyncQuoteGroup(dbQuoteGroupDEFactory.Build(tracer));
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                inner = new MonOperationDec<IEnumerable<QuoteGroupDE>>(
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