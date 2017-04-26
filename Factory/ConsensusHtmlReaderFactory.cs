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

namespace StockCore.Factory
{
    public class ConsensusHtmlReaderFactory : BaseFactory<string,IGetByKey<IEnumerable<ConsensusDE>,string>>
    {
        private const string KEY = "ConsensusHtmlReader";
        private const int ID = 1000100;
        private const int PROCESSERRID = 1000101;
        private const int OUTERERRID = 1000102;
        private const int MONPROCESSERRID = 1000103;
        private const int MONOUTERERRID = 1000104;
        private readonly IHttpClientWrapper client;
        private readonly IHtmlDocumentWrapper doc;
        private readonly IConfigReader configReader;
        public ConsensusHtmlReaderFactory(ILogger logger,
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.client = client;
            this.doc = doc;
            this.configReader = configReader;
        }
        protected override IGetByKey<IEnumerable<ConsensusDE>,string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByKey<IEnumerable<ConsensusDE>,string> inner = new ConsensusHtmlReader(client,doc);
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                var helper = new ValidationHelper();
                inner = new MonGetByKeyDec<ConsensusDE>(
                    inner,
                    helper.ValidateString(1000105,"Quote"),
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