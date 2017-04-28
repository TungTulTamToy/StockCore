using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Wrapper;
using StockCore.Provider;
using StockCore.Business.Repo.MongoDB;
using StockCore.Aop.Mon.Repo.MongoDB;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Helper;
using StockCore.Aop.Mon;

namespace StockCore.Factory.DB
{
    public class DBStatisticRepoFactory : BaseFactory<string,IGetByKeyRepo<StatisticDE,string>>
    {
        private const string KEY = "DBStatisticRepo";
        private const string COLLECTIONNAME = "Statistic";
        private const int ID = 1007100;
        private const int PROCESSERRID = 1007101;
        private const int OUTERERRID = 1007102;
        private const int MONPROCESSERRID = 1007103;
        private const int MONOUTERERRID = 1007104;
        private readonly IConfigProvider config;
        private readonly IMongoDatabaseWrapper db;
        private readonly IFilterDefinitionBuilderWrapper filterBuilder;
        private readonly IReplaceOneModelBuilder replaceOneModelBuilder;
        private readonly IDeleteOneModelBuilder deleteOneModelBuilder;
        private readonly IConfigReader configReader;
        public DBStatisticRepoFactory(IConfigProvider config, 
            ILogger logger,
            IMongoDatabaseWrapper db, 
            IFilterDefinitionBuilderWrapper filterBuilder,
            IReplaceOneModelBuilder replaceOneModelBuilder,
            IDeleteOneModelBuilder deleteOneModelBuilder,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.config = config;
            this.db = db;   
            this.filterBuilder = filterBuilder;
            this.replaceOneModelBuilder = replaceOneModelBuilder;
            this.deleteOneModelBuilder = deleteOneModelBuilder;
            this.configReader = configReader;
        }
        protected override IGetByKeyRepo<StatisticDE,string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByKeyRepo<StatisticDE,string> inner = new BaseKeyDBRepo<StatisticDE>(config,db,filterBuilder,replaceOneModelBuilder,deleteOneModelBuilder,COLLECTIONNAME);   
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                inner = new MonGetByKeyRepoDec<StatisticDE>(
                    inner,
                    ValidationHelper.ValidateString(1007105,"Quote"),
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