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
    public class SetIndexHtmlReaderFactory : BaseHtmlReaderFactory<SetIndex>
    {
        private const string KEY = "HtmlSetIndexGetByKey";
        private const int ID = 1010100;
        private const int PROCESSERRID = 1010101;
        private const int OUTERERRID = 1010102;
        private const int MONPROCESSERRID = 1010103;
        private const int MONOUTERERRID = 1010104;
        private const int FILTERPROCESSERRID = 1010106;
        private const int FILTEROUTERERRID = 1010107;
        public SetIndexHtmlReaderFactory(
            ILogger logger,
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc,
            IConfigReader<IModule> moduleReader
            ):base(client,doc,moduleReader,PROCESSERRID,OUTERERRID,ID,KEY,logger){}
        protected override IGetByKey<IEnumerable<SetIndex>,string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByKey<IEnumerable<SetIndex>, string> inner = new SetIndexHtmlReader(client, doc);
            var module = moduleReader.GetByKey(getAopKey());
            inner = loadFilterDecorator(inner, module);
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IGetByKey<IEnumerable<SetIndex>, string> loadFilterDecorator(IGetByKey<IEnumerable<SetIndex>, string> inner, IModule module)
        {
            if (module.IsPreFilterActive())
            {
                inner = new PreFilterGetByKeyDec<string,SetIndex>(
                    inner,
                    FilterHelper.FilterActiveOnly(module.PreFilter.Criteria),//ptt
                    FILTERPROCESSERRID,
                    FILTEROUTERERRID,
                    module.PreFilter,
                    logger);
            }
            return inner;
        }
        private IGetByKey<IEnumerable<SetIndex>, string> loadMonitoringDecorator(Tracer tracer, IGetByKey<IEnumerable<SetIndex>, string> inner, IModule module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonGetByKeyDec<SetIndex>(
                    inner,
                    ValidationHelper.ValidateString(1010105, "Quote"),
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