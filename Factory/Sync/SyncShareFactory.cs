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

namespace StockCore.Factory.Sync
{
    public class SyncShareFactory : BaseFactory<string,IOperation<IEnumerable<ShareDE>>>
    {
        private const string KEY = "SyncShare";
        private const int ID = 1018100;
        private const int PROCESSERRID = 1018101;
        private const int OUTERERRID = 1018102;
        private const int MONPROCESSERRID = 1018103;
        private const int MONOUTERERRID = 1018104;
        private readonly IRepo<ShareDE> dbShareDE;
        private readonly IConfigReader configReader;
        public SyncShareFactory(
            ILogger logger,
            IGetByKeyRepo<ShareDE,string> dbShareDE,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.dbShareDE = dbShareDE;
            this.configReader = configReader;
        }
        protected override IOperation<IEnumerable<ShareDE>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<ShareDE>> inner = new SyncShare(dbShareDE);
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                inner = new MonOperationDec<IEnumerable<ShareDE>>(
                    inner,
                    ValidationHelper.ValidateItemsWithStringKeyField<ShareDE>(1018105,"Quote"),  
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