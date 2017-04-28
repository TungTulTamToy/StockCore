using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StockCore.Business.Worker;
using StockCore.Business.Worker.SyncFromWeb;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using System;
using StockCore.DomainEntity.Enum;
using StockCore.Aop.Mon.Worker;
using StockCore.Aop.Mon;
using StockCore.Helper;
using StockCore.DomainEntity;

namespace StockCore.Factory.Sync
{
    public class SyncAllFactory : BaseFactory<FactoryCondition,IOperation<IEnumerable<string>>>
    {
        private const string KEY = "SyncAll";
        private const int ID = 1013100;
        private const int PROCESSERRID = 1013101;
        private const int OUTERERRID = 1013102;
        private const int MONPROCESSERRID = 1013103;
        private const int MONOUTERERRID = 1013104;
        private readonly IConfigReader configReader;
        private readonly IServiceProvider serviceProvider;
        private readonly IFactory<string,IOperation<string>> syncQuoteFactory;
        public SyncAllFactory(
            IFactory<string,IOperation<string>> syncQuoteFactory,
            ILogger logger,
            IConfigReader configReader,
            IServiceProvider serviceProvider
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.syncQuoteFactory = syncQuoteFactory;
            this.configReader = configReader;
            this.serviceProvider = serviceProvider;
        }
        protected override IOperation<IEnumerable<string>> baseFactoryBuild(Tracer tracer,FactoryCondition condition=null)
        {
            var module = configReader.GetByKey(getAopKey());            
            IOperation<IEnumerable<string>> inner = null;
            if(condition!=null && condition.SyncType==FactoryCondition.SyncAllType.AllQuote)
            {
                inner = new SyncAllSameTime(serviceProvider);                 
            }
            else
            {
                inner = new SyncAll(syncQuoteFactory.Build(tracer));                
            }
            if(module.IsMonitoringActive())
            {
                inner = new MonOperationDec<IEnumerable<string>>(
                    inner,
                    ValidationHelper.ValidateStringItems(1013105,"Quotes"),
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