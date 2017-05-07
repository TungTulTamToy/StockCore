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
    public class DBPriceRepoFactory : BaseFactory<string,IGetByKeyRepo<Price,string>>
    {
        private const string KEY = "DBPriceRepo";
        private const string COLLECTIONNAME = "Price";
        private const int ID = 1003100;
        private const int PROCESSERRID = 1003101;
        private const int OUTERERRID = 1003102;
        private const int MONPROCESSERRID = 1003103;
        private const int MONOUTERERRID = 1003104;
        private readonly IConfigProvider config;
        private readonly IMongoDatabaseWrapper db;
        private readonly IFilterDefinitionBuilderWrapper filterBuilder;
        private readonly IReplaceOneModelBuilder replaceOneModelBuilder;
        private readonly IDeleteOneModelBuilder deleteOneModelBuilder;
        private readonly IConfigReader configReader;
        public DBPriceRepoFactory(IConfigProvider config, 
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
        protected override IGetByKeyRepo<Price,string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByKeyRepo<Price, string> inner = new BaseKeyDBRepo<Price>(config, db, filterBuilder, replaceOneModelBuilder, deleteOneModelBuilder, COLLECTIONNAME);
            var module = configReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IGetByKeyRepo<Price, string> loadMonitoringDecorator(Tracer tracer, IGetByKeyRepo<Price, string> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonGetByKeyRepoDec<string, Price>(
                    inner,
                    ValidationHelper.ValidateString(1003105, "Quote"),
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