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
    public class DBConcensusRepoFactory : BaseFactory<string,IGetByKeyRepo<Consensus,string>>
    {
        private const string KEY = "DBConsensusRepo";
        private const string COLLECTIONNAME = "Consensus";
        private const int ID = 1001100;
        private const int PROCESSERRID = 1001101;
        private const int OUTERERRID = 1001102;
        private const int MONPROCESSERRID = 1001103;
        private const int MONOUTERERRID = 1001104;
        private readonly IConfigProvider config;
        private readonly IMongoDatabaseWrapper db;
        private readonly IFilterDefinitionBuilderWrapper filterBuilder;
        private readonly IReplaceOneModelBuilder replaceOneModelBuilder;
        private readonly IDeleteOneModelBuilder deleteOneModelBuilder;
        private readonly IConfigReader configReader;
        public DBConcensusRepoFactory(IConfigProvider config, 
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
        protected override IGetByKeyRepo<Consensus,string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByKeyRepo<Consensus, string> inner = new BaseKeyDBRepo<Consensus>(config, db, filterBuilder, replaceOneModelBuilder, deleteOneModelBuilder, COLLECTIONNAME);
            var module = configReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IGetByKeyRepo<Consensus, string> loadMonitoringDecorator(Tracer tracer, IGetByKeyRepo<Consensus, string> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonGetByKeyRepoDec<string, Consensus>(
                    inner,
                    ValidationHelper.ValidateString(1001105, "Quote"),
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