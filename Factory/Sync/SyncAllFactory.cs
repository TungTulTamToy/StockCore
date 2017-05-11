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
    public class SyncAllFactory : BaseFactory<SyncAllFactoryCondition,IOperation<IEnumerable<string>>>, IDisposable
    {
        private const string KEY = "SyncAll";
        private const int ID = 1013100;
        private const int PROCESSERRID = 1013101;
        private const int OUTERERRID = 1013102;
        private const int MONPROCESSERRID = 1013103;
        private const int MONOUTERERRID = 1013104;
        private readonly IConfigReader<IModule> moduleReader;
        private readonly IServiceProvider serviceProvider;
        private readonly IFactory<SyncQuoteFactoryCondition,IOperation<string>> syncQuoteFactory;
        public SyncAllFactory(
            IFactory<SyncQuoteFactoryCondition,IOperation<string>> syncQuoteFactory,
            ILogger logger,
            IConfigReader<IModule> moduleReader,
            IServiceProvider serviceProvider
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.syncQuoteFactory = syncQuoteFactory;
            this.moduleReader = moduleReader;
            this.serviceProvider = serviceProvider;
        }
        protected override IOperation<IEnumerable<string>> baseFactoryBuild(Tracer tracer,SyncAllFactoryCondition condition=null)
        {
            IOperation<IEnumerable<string>> inner = null;
            if (condition != null && condition.Type == SyncAllFactoryCondition.SyncType.AllQuote)
            {
                inner = new SyncAllSameTime(serviceProvider);
            }
            else
            {
                var cond = new SyncQuoteFactoryCondition()
                {
                    Type = SyncQuoteFactoryCondition.SyncType.MethodTwo
                };
                inner = new SyncAll(syncQuoteFactory.Build(tracer, cond));
            }
            var module = moduleReader.GetByKey(getAopKey());            
            inner = loadMonitoringDecorator(tracer, module, inner);
            return inner;
        }
        private IOperation<IEnumerable<string>> loadMonitoringDecorator(Tracer tracer, IModule module, IOperation<IEnumerable<string>> inner)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonOperationDec<IEnumerable<string>>(
                    inner,
                    ValidationHelper.ValidateStringItems(1013105, "Quotes"),
                    MONPROCESSERRID,
                    MONOUTERERRID,
                    module.Monitoring,
                    logger,
                    tracer);
            }
            return inner;
        }

        private bool disposed = false;
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing && syncQuoteFactory!=null)
                {
                    syncQuoteFactory.Dispose();
                }
                disposed = true;
            }
        }
        ~SyncAllFactory()
        {
            Dispose(false);
        }
    }
}