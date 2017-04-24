using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StockCore.Business.Worker;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Worker.Sync;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Aop.Mon.Worker;
using StockCore.Aop.Mon;
using StockCore.Helper;

namespace StockCore.Factory
{
    public class SyncConcensusFactory : BaseFactory<string,IOperation<IEnumerable<ConsensusDE>>>
    {
        private const string KEY = "SyncConsensus";
        private const int ID = 1014100;
        private const int PROCESSERRID = 1014101;
        private const int OUTERERRID = 1014102;
        private const int MONPROCESSERRID = 1014103;
        private const int MONOUTERERRID = 1014104;
        private readonly IFactory<string, IGetByKeyRepo<ConsensusDE,string>> dbConsensusFactory;
        private readonly IConfigReader configReader;
        public SyncConcensusFactory(
            ILogger logger,
            IFactory<string, IGetByKeyRepo<ConsensusDE,string>> dbConsensusFactory,
            IConfigReader configReader
            ):base(OUTERERRID,PROCESSERRID,ID,KEY,logger)
        {
            this.dbConsensusFactory = dbConsensusFactory;
            this.configReader = configReader;
        }
        protected override IOperation<IEnumerable<ConsensusDE>> build(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<ConsensusDE>> inner = new SyncConsensus(dbConsensusFactory.Build(tracer));
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                var helper = new ValidationHelper();
                inner = new MonOperationDec<IEnumerable<ConsensusDE>>(
                    inner,
                    helper.ValidateQuoteKeyField<ConsensusDE>(1014102,"Quote"),
                    MONPROCESSERRID,
                    OUTERERRID,
                    module.Monitoring,
                    logger,
                    tracer
                    );     
            }
            return inner;
        }
    }
}