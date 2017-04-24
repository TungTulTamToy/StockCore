using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Wrapper;
using StockCore.Provider;
using StockCore.Business.Repo.MongoDB;
using StockCore.Aop.Mon.Repo.MongoDB;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;

namespace StockCore.Factory
{
    public class DBSetIndexRepoFactory : BaseFactory<string,IRepo<SetIndexDE>>
    {
        private const string KEY = "DBSetIndexRepo";
        private const string COLLECTIONNAME = "SetIndex";
        private const int ID = 1005100;
        private const int PROCESSERRID = 1005101;
        private const int OUTERERRID = 1005102;
        private const int MONPROCESSERRID = 1005103;
        private const int MONOUTERERRID = 1005104;
        private readonly IConfigProvider config;
        private readonly IMongoDatabaseWrapper db;
        private readonly IFilterDefinitionBuilderWrapper filterBuilder;
        private readonly IReplaceOneModelBuilder replaceOneModelBuilder;
        private readonly IDeleteOneModelBuilder deleteOneModelBuilder;
        private readonly IConfigReader configReader;
        public DBSetIndexRepoFactory(IConfigProvider config, 
            ILogger logger,
            IMongoDatabaseWrapper db, 
            IFilterDefinitionBuilderWrapper filterBuilder,
            IReplaceOneModelBuilder replaceOneModelBuilder,
            IDeleteOneModelBuilder deleteOneModelBuilder,
            IConfigReader configReader
            ):base(OUTERERRID,PROCESSERRID,ID,KEY,logger)
        {
            this.config = config;
            this.db = db;   
            this.filterBuilder = filterBuilder;
            this.replaceOneModelBuilder = replaceOneModelBuilder;
            this.deleteOneModelBuilder = deleteOneModelBuilder;
            this.configReader = configReader;
        }
        protected override IRepo<SetIndexDE> build(Tracer trace,string t="")
        {
            IRepo<SetIndexDE> inner = new BaseDBRepo<SetIndexDE>(config,db,filterBuilder,replaceOneModelBuilder,deleteOneModelBuilder,COLLECTIONNAME);   
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                inner = new MonRepoDec<SetIndexDE>(inner,MONPROCESSERRID,MONOUTERERRID,module.Monitoring,logger,trace);
            }
            return inner;
        }
    }
}