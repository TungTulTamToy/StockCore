using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo;
using StockCore.DomainEntity;
using StockCore.Wrapper;
using StockCore.Business.Repo.Html;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Aop.Mon;
using StockCore.Helper;
using StockCore.Business.Builder;
using StockCore.Business.Repo.MongoDB;
using StockCore.Aop.Mon.Builder;

namespace StockCore.Factory
{
    public class StockBuilderFactory : BaseFactory<string,IBuilder<string, StockDE>>
    {
        private const string KEY = "StockBuilder";
        private const int ID = 1020100;
        private const int PROCESSERRID = 1020101;
        private const int OUTERERRID = 1020102;
        private const int MONPROCESSERRID = 1020103;
        private const int MONOUTERERRID = 1020104;
        private readonly IConfigReader configReader;
        private readonly IFactory<string, IGetByKeyRepo<ShareDE,string>> shareRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<StatisticDE,string>> statisticRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<ConsensusDE,string>> consensusRepoFactory;
        private readonly IFactory<string, IGetByKeyRepo<PriceDE,string>> priceRepoFactory;
        public StockBuilderFactory(ILogger logger,
            IFactory<string, IGetByKeyRepo<ShareDE,string>> shareRepoFactory,
            IFactory<string, IGetByKeyRepo<StatisticDE,string>> statisticRepoFactory,
            IFactory<string, IGetByKeyRepo<ConsensusDE,string>> consensusRepoFactory,
            IFactory<string, IGetByKeyRepo<PriceDE,string>> priceRepoFactory,
            IConfigReader configReader
            ):base(OUTERERRID,PROCESSERRID,ID,KEY,logger)
        {
            this.shareRepoFactory = shareRepoFactory;
            this.statisticRepoFactory = statisticRepoFactory;
            this.consensusRepoFactory = consensusRepoFactory;
            this.priceRepoFactory = priceRepoFactory;
            this.configReader = configReader;
        }
        protected override IBuilder<string, StockDE> build(Tracer tracer,string t="")
        {
            IBuilder<string, StockDE> inner = new StockBuilder(
                logger,
                shareRepoFactory.Build(tracer),
                statisticRepoFactory.Build(tracer),
                consensusRepoFactory.Build(tracer),
                priceRepoFactory.Build(tracer));  
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                var helper = new ValidationHelper();
                inner = new MonBuilderDec<StockDE>(
                    inner,
                    helper.ValidateString(1020105,"Quote"),
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