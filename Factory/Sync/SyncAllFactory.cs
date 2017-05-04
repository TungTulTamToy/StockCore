using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StockCore.Business.Operation;
using StockCore.Business.Operation.SyncFromWeb;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using System;
using StockCore.DomainEntity.Enum;
using StockCore.Aop.Mon;
using StockCore.Helper;
using StockCore.DomainEntity;

namespace StockCore.Factory.Sync
{
    public class SyncAllFactory : BaseFactory<SyncAllFactoryCondition,IOperation<IEnumerable<string>>>
    {
        private const string KEY = "SyncAll";
        private const int ID = 1013100;
        private const int PROCESSERRID = 1013101;
        private const int OUTERERRID = 1013102;
        private const int MONPROCESSERRID = 1013103;
        private const int MONOUTERERRID = 1013104;
        private readonly IConfigReader configReader;
        private readonly IServiceProvider serviceProvider;
        private readonly IFactory<SyncQuoteFactoryCondition,IOperation<string>> syncQuoteFactory;
        public SyncAllFactory(
            IFactory<SyncQuoteFactoryCondition,IOperation<string>> syncQuoteFactory,
            ILogger logger,
            IConfigReader configReader,
            IServiceProvider serviceProvider
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.syncQuoteFactory = syncQuoteFactory;
            this.configReader = configReader;
            this.serviceProvider = serviceProvider;
        }
        protected override IOperation<IEnumerable<string>> baseFactoryBuild(Tracer tracer,SyncAllFactoryCondition condition=null)
        {
            var module = configReader.GetByKey(getAopKey());            
            IOperation<IEnumerable<string>> inner = null;
            if(condition!=null && condition.Type==SyncAllFactoryCondition.SyncType.AllQuote)
            {
                inner = new SyncAllSameTime(serviceProvider);                 
            }
            else
            {
                var cond = new SyncQuoteFactoryCondition()
                {
                    Type = SyncQuoteFactoryCondition.SyncType.MethodTwo
                };
                inner = new SyncAll(syncQuoteFactory.Build(tracer,cond));                
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