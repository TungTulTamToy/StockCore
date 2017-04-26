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

namespace StockCore.Factory
{
    public class DBOperationStateRepoFactory : BaseFactory<string,IGetByKeyRepo<OperationStateDE,string>>
    {
        private const string KEY = "DBOperationStateRepo";
        private const string COLLECTIONNAME = "OperationState";
        private const int ID = 1002100;
        private const int PROCESSERRID = 1002101;
        private const int OUTERERRID = 1002102;
        private const int MONPROCESSERRID = 1002103;
        private const int MONOUTERERRID = 1002104;
        private readonly IConfigProvider config;
        private readonly IMongoDatabaseWrapper db;
        private readonly IFilterDefinitionBuilderWrapper filterBuilder;
        private readonly IReplaceOneModelBuilder replaceOneModelBuilder;
        private readonly IDeleteOneModelBuilder deleteOneModelBuilder;
        private readonly IConfigReader configReader;
        public DBOperationStateRepoFactory(IConfigProvider config, 
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
        protected override IGetByKeyRepo<OperationStateDE,string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByKeyRepo<OperationStateDE,string> inner = new BaseQuoteDBRepo<OperationStateDE>(
                config,
                db,
                filterBuilder,
                replaceOneModelBuilder,
                deleteOneModelBuilder,
                COLLECTIONNAME);    
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                var helper = new ValidationHelper();
                inner = new MonGetByKeyRepoDec<OperationStateDE>(
                    inner,
                    helper.ValidateString(1002105,"Quote"),
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