using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Wrapper;
using StockCore.Provider;
using StockCore.Business.Repo.MongoDB;
using StockCore.Aop.Mon.Repo.MongoDB;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Helper;

namespace StockCore.Factory
{
    public class DBQuoteGroupRepoFactory : BaseFactory<string,IRepo<QuoteGroupDE>>
    {
        private const string KEY = "DBQuoteGroupRepo";
        private const string COLLECTIONNAME = "QuoteGroup";
        private const int ID = 1004100;
        private const int PROCESSERRID = 1004101;
        private const int OUTERERRID = 1004102;
        private const int MONPROCESSERRID = 1004103;
        private const int MONOUTERERRID = 1004104;
        private readonly IConfigProvider config;
        private readonly IMongoDatabaseWrapper db;
        private readonly IFilterDefinitionBuilderWrapper filterBuilder;
        private readonly IReplaceOneModelBuilder replaceOneModelBuilder;
        private readonly IDeleteOneModelBuilder deleteOneModelBuilder;
        private readonly IConfigReader configReader;
        public DBQuoteGroupRepoFactory(IConfigProvider config, 
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
        protected override IRepo<QuoteGroupDE> baseFactoryBuild(Tracer tracer,string t="")
        {
            IRepo<QuoteGroupDE> inner = new BaseDBRepo<QuoteGroupDE>(config,db,filterBuilder,replaceOneModelBuilder,deleteOneModelBuilder,COLLECTIONNAME); 
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                var helper = new ValidationHelper();
                inner = new MonRepoDec<QuoteGroupDE>(
                    inner,
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