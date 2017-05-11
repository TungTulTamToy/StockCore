using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Wrapper;
using StockCore.Provider;
using StockCore.Business.Repo.MongoDB;
using StockCore.Business.Repo.AppSetting;
using StockCore.Extension;
using StockCore.Aop.Mon;

namespace StockCore.Factory.DB
{
    public class DBSetIndexRepoFactory : BaseFactory<string,IRepo<SetIndex>>
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
        private readonly IConfigReader<IModule> moduleReader;
        public DBSetIndexRepoFactory(IConfigProvider config, 
            ILogger logger,
            IMongoDatabaseWrapper db, 
            IFilterDefinitionBuilderWrapper filterBuilder,
            IReplaceOneModelBuilder replaceOneModelBuilder,
            IDeleteOneModelBuilder deleteOneModelBuilder,
            IConfigReader<IModule> moduleReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.config = config;
            this.db = db;   
            this.filterBuilder = filterBuilder;
            this.replaceOneModelBuilder = replaceOneModelBuilder;
            this.deleteOneModelBuilder = deleteOneModelBuilder;
            this.moduleReader = moduleReader;
        }
        protected override IRepo<SetIndex> baseFactoryBuild(Tracer trace,string t="")
        {
            IRepo<SetIndex> inner = new BaseAllDBRepo<SetIndex>(config, db, filterBuilder, replaceOneModelBuilder, deleteOneModelBuilder, COLLECTIONNAME);
            var module = moduleReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(trace, inner, module);
            return inner;
        }
        private IRepo<SetIndex> loadMonitoringDecorator(Tracer trace, IRepo<SetIndex> inner, IModule module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonRepoDec<SetIndex>(inner, MONPROCESSERRID, MONOUTERERRID, module.Monitoring, logger, trace);
            }
            return inner;
        }
    }
}