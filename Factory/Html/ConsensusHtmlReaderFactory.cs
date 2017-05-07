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
using System;

namespace StockCore.Factory.Html
{
    public class ConsensusHtmlReaderFactory : BaseHtmlReaderFactory<Consensus>
    {
        private const string KEY = "ConsensusHtmlReader";
        private const int ID = 1000100;
        private const int PROCESSERRID = 1000101;
        private const int OUTERERRID = 1000102;
        private const int MONPROCESSERRID = 1000103;
        private const int MONOUTERERRID = 1000104;
        public ConsensusHtmlReaderFactory(
            ILogger logger,
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc,
            IConfigReader configReader
            ):base(client,doc,configReader,PROCESSERRID,OUTERERRID,ID,KEY,logger){}
        protected override IGetByKey<IEnumerable<Consensus>,string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByKey<IEnumerable<Consensus>, string> inner = new ConsensusHtmlReader(client, doc);
            var module = configReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IGetByKey<IEnumerable<Consensus>, string> loadMonitoringDecorator(Tracer tracer, IGetByKey<IEnumerable<Consensus>, string> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonGetByKeyDec<Consensus>(
                    inner,
                    ValidationHelper.ValidateString(1000105, "Quote"),
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