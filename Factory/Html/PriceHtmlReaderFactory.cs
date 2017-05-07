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
    public class PriceHtmlReaderFactory : BaseHtmlReaderFactory<Price>
    {
        private const string KEY = "HtmlPriceGetByKey";
        private const int ID = 1009100;
        private const int PROCESSERRID = 1009101;
        private const int OUTERERRID = 1009102;
        private const int MONPROCESSERRID = 1009103;
        private const int MONOUTERERRID = 1009104;
        public PriceHtmlReaderFactory(
            ILogger logger,
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc,
            IConfigReader configReader
            ):base(client,doc,configReader,PROCESSERRID,OUTERERRID,ID,KEY,logger){}
        protected override IGetByKey<IEnumerable<Price>,string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByKey<IEnumerable<Price>, string> inner = new PriceHtmlReader(client, doc);
            var module = configReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IGetByKey<IEnumerable<Price>, string> loadMonitoringDecorator(Tracer tracer, IGetByKey<IEnumerable<Price>, string> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonGetByKeyDec<Price>(
                    inner,
                    ValidationHelper.ValidateStringWithNotActivateOnly(1009105, "Quote"),
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