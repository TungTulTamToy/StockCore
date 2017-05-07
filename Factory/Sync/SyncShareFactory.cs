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
    public class SyncShareFactory : BaseFactory<string,IOperation<IEnumerable<Share>>>
    {
        private const string KEY = "SyncShare";
        private const int ID = 1018100;
        private const int PROCESSERRID = 1018101;
        private const int OUTERERRID = 1018102;
        private const int MONPROCESSERRID = 1018103;
        private const int MONOUTERERRID = 1018104;
        private readonly IFactory<string, IGetByKeyRepo<Share,string>> dbShareDEFactory;
        private readonly IConfigReader configReader;
        public SyncShareFactory(
            ILogger logger,
            IFactory<string, IGetByKeyRepo<Share,string>> dbShareDEFactory,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.dbShareDEFactory = dbShareDEFactory;
            this.configReader = configReader;
        }
        protected override IOperation<IEnumerable<Share>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IOperation<IEnumerable<Share>> inner = new SyncDataByKey<string,Share>(dbShareDEFactory.Build(tracer));
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                Func<ILogger,Tracer,string,string,IEnumerable<Share>,bool> validation = null;
                //if(tracer.Caller.ID==1016100)
                //{
                //    validation = ValidationHelper.ValidateItemsWithStringKeyField<Share>(1018105,"Quote","scb");
                //}
                //else
                //{
                    validation = ValidationHelper.ValidateItemsWithStringKeyField<Share>(1018105,"Quote");
                //}
                inner = new MonOperationDec<IEnumerable<Share>>(
                    inner,
                    validation,  
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