using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Wrapper;
using StockCore.Provider;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Helper;
using StockCore.Aop.Mon;

namespace StockCore.Factory.DB
{
    public class DBCacheRepoFactory<T> : BaseFactory<string,IGetByFuncRepo<string,StockCoreCache<T>>>
    {
        private const string KEY = "DBCacheRepo";
        private const string COLLECTIONNAME = "Cache";
        private const int ID = 1021100;
        private const int PROCESSERRID = 1021101;
        private const int OUTERERRID = 1021102;
        private const int MONPROCESSERRID = 1021103;
        private const int MONOUTERERRID = 1021104;
        private readonly IConfigProvider config;
        private readonly IMongoDatabaseWrapper db;
        private readonly IFilterDefinitionBuilderWrapper filterBuilder;
        private readonly IReplaceOneModelBuilder replaceOneModelBuilder;
        private readonly IDeleteOneModelBuilder deleteOneModelBuilder;
        private readonly IConfigReader configReader;
        public DBCacheRepoFactory(IConfigProvider config, 
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
        protected override IGetByFuncRepo<string,StockCoreCache<T>> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByFuncRepo<string, StockCoreCache<T>> inner = new BaseFuncDBRepo<StockCoreCache<T>>(
                config,
                db,
                filterBuilder,
                replaceOneModelBuilder,
                deleteOneModelBuilder,
                COLLECTIONNAME);
            var module = configReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IGetByFuncRepo<string, StockCoreCache<T>> loadMonitoringDecorator(Tracer tracer, IGetByFuncRepo<string, StockCoreCache<T>> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonGetByFuncRepoDec<string, StockCoreCache<T>>(
                    inner,
                    ValidationHelper.ValidateExpression<StockCoreCache<T>>(1021106, "Criteria"),
                    ValidationHelper.ValidateStringWithNotActivateOnly(1021105, "Key"),
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