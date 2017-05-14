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
    public class DBQuoteMovementRepoFactory : BaseFactory<string,IGetByKeyRepo<QuoteMovement,string>>
    {
        private const string KEY = "DBQuoteMovementRepo";
        private const string COLLECTIONNAME = "QuoteMovement";
        private const int ID = 1027100;
        private const int PROCESSERRID = 1027101;
        private const int OUTERERRID = 1027102;
        private const int MONPROCESSERRID = 1027103;
        private const int MONOUTERERRID = 1027104;
        private readonly IConfigProvider config;
        private readonly IMongoDatabaseWrapper db;
        private readonly IFilterDefinitionBuilderWrapper filterBuilder;
        private readonly IReplaceOneModelBuilder replaceOneModelBuilder;
        private readonly IDeleteOneModelBuilder deleteOneModelBuilder;
        private readonly IConfigReader<IModule> moduleReader;
        public DBQuoteMovementRepoFactory(IConfigProvider config, 
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
        protected override IGetByKeyRepo<QuoteMovement,string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByKeyRepo<QuoteMovement, string> inner = new BaseKeyDBRepo<QuoteMovement>(
                config:config, 
                db:db, 
                filterBuilder:filterBuilder, 
                replaceOneModelBuilder:replaceOneModelBuilder, 
                deleteOneModelBuilder:deleteOneModelBuilder, 
                collectionName:COLLECTIONNAME);
            var module = moduleReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }

        private IGetByKeyRepo<QuoteMovement, string> loadMonitoringDecorator(Tracer tracer, IGetByKeyRepo<QuoteMovement,string> inner, IModule module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonGetByKeyRepoDec<string, QuoteMovement>(
                    inner:inner,
                    validateQuote:ValidationHelper.ValidateString(1027105, "Quote"),
                    processErrorID:MONPROCESSERRID,
                    outerErrorID:MONOUTERERRID,
                    module:module.Monitoring,
                    logger:logger,
                    tracer:tracer);
            }
            return inner;
        }
    }
}