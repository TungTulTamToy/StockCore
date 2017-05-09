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
using StockCore.Aop.PreFilter;

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
        private const int FILTERPROCESSERRID = 1011106;
        private const int FILTEROUTERERRID = 1011107;
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
            inner = loadFilterDecorator(inner, module);
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IGetByKey<IEnumerable<Share>, string> loadFilterDecorator(IGetByKey<IEnumerable<Share>, string> inner, Module module)
        {
            if (module.IsPreFilterActive())
            {
                inner = new PreFilterGetByKeyDec<string,Share>(
                    inner,
                    FilterHelper.FilterNotActiveOnly(module.PreFilter.Criteria),//scb
                    FILTERPROCESSERRID,
                    FILTEROUTERERRID,
                    module.PreFilter,
                    logger);
            }
            return inner;
        }
        private IGetByKey<IEnumerable<Share>, string> loadMonitoringDecorator(Tracer tracer, IGetByKey<IEnumerable<Share>, string> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonGetByKeyDec<Share>(
                    inner,
                    ValidationHelper.ValidateString(1011105, "Quote"),
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