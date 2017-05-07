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
    public class ShareHtmlReaderFactory : BaseHtmlReaderFactory<Share>
    {
        private const string KEY = "HtmlShareGetByKey";
        private const int ID = 1011100;
        private const int PROCESSERRID = 1011101;
        private const int OUTERERRID = 1011102;
        private const int MONPROCESSERRID = 1011103;
        private const int MONOUTERERRID = 1011104;
        public ShareHtmlReaderFactory(
            ILogger logger,
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc,
            IConfigReader configReader
            ):base(client,doc,configReader,PROCESSERRID,OUTERERRID,ID,KEY,logger){}
        protected override IGetByKey<IEnumerable<Share>,string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByKey<IEnumerable<Share>, string> inner = new ShareHtmlReader(client, doc);
            var module = configReader.GetByKey(getAopKey());
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IGetByKey<IEnumerable<Share>, string> loadMonitoringDecorator(Tracer tracer, IGetByKey<IEnumerable<Share>, string> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonGetByKeyDec<Share>(
                    inner,
                    ValidationHelper.ValidateString(1011105, "Quote",notActivateOnly:"scb"),
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