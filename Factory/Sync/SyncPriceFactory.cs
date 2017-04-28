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
    public class SyncPriceFactory : BaseFactory<string,IOperation<IEnumerable<PriceDE>>>
    {
        private const string KEY = "SyncPrice";
        private const int ID = 1015100;
        private const int PROCESSERRID = 1015101;
        private const int OUTERERRID = 1015102;
        private const int MONPROCESSERRID = 1015103;
        private const int MONOUTERERRID = 1015104;
        private readonly IFactory<string, IGetByKeyRepo<PriceDE,string>> dbPriceDEFactory;
        private readonly IConfigReader configReader;
        public SyncPriceFactory(
            ILogger logger,
            IFactory<string, IGetByKeyRepo<PriceDE,string>> dbPriceDEFactory,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.dbPriceDEFactory = dbPriceDEFactory;
            this.configReader = configReader;
        }
        protected override IOperation<IEnumerable<PriceDE>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<PriceDE>> inner = new SyncPrice(dbPriceDEFactory.Build(tracer));
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                var helper = new ValidationHelper();
                inner = new MonOperationDec<IEnumerable<PriceDE>>(
                    inner,
                    helper.ValidateItemsWithStringKeyField<PriceDE>(1015105,"Quote"),
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