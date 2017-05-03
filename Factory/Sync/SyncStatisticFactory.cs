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
    public class SyncStatisticFactory : BaseFactory<string,IOperation<IEnumerable<StatisticDE>>>
    {
        private const string KEY = "SyncStatistic";
        private const int ID = 1019100;
        private const int PROCESSERRID = 1019101;
        private const int OUTERERRID = 1019102;
        private const int MONPROCESSERRID = 1019103;
        private const int MONOUTERERRID = 1019104;
        private readonly IFactory<string, IGetByKeyRepo<StatisticDE,string>> dbStatisticDEFactory;
        private readonly IConfigReader configReader;
        public SyncStatisticFactory(
            ILogger logger,
            IFactory<string, IGetByKeyRepo<StatisticDE,string>> dbStatisticDEFactory,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.dbStatisticDEFactory = dbStatisticDEFactory;
            this.configReader = configReader;
        }
        protected override IOperation<IEnumerable<StatisticDE>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<StatisticDE>> inner = new BaseSyncData<StatisticDE>(dbStatisticDEFactory.Build(tracer));  
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                inner = new MonOperationDec<IEnumerable<StatisticDE>>(
                    inner,
                    ValidationHelper.ValidateItemsWithStringKeyField<StatisticDE>(1019102,"Quote"),    
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