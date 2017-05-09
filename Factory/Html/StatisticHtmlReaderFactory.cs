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
    public class StatisticHtmlReaderFactory : BaseHtmlReaderFactory<Statistic>
    {
        private const string KEY = "HtmlStatisticGetByKey";
        private const int ID = 1012100;
        private const int PROCESSERRID = 1012101;
        private const int OUTERERRID = 1012102;
        private const int MONPROCESSERRID = 1012103;
        private const int MONOUTERERRID = 1012104;
        private const int FILTERPROCESSERRID = 1012106;
        private const int FILTEROUTERERRID = 1012107;
        public StatisticHtmlReaderFactory(ILogger logger,
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc,
            IConfigReader configReader
            ):base(client,doc,configReader,PROCESSERRID,OUTERERRID,ID,KEY,logger){}
        protected override IGetByKey<IEnumerable<Statistic>,string> baseFactoryBuild(Tracer tracer,string t="")
        {
            IGetByKey<IEnumerable<Statistic>, string> inner = new StatisticHtmlReader(client, doc);
            var module = configReader.GetByKey(getAopKey());
            inner = loadFilterDecorator(inner, module);
            inner = loadMonitoringDecorator(tracer, inner, module);
            return inner;
        }
        private IGetByKey<IEnumerable<Statistic>, string> loadFilterDecorator(IGetByKey<IEnumerable<Statistic>, string> inner, Module module)
        {
            if (module.IsPreFilterActive())
            {
                inner = new PreFilterGetByKeyDec<string,Statistic>(
                    inner,
                    FilterHelper.FilterNotActiveOnly(module.PreFilter.Criteria),//ait
                    FILTERPROCESSERRID,
                    FILTEROUTERERRID,
                    module.PreFilter,
                    logger);
            }
            return inner;
        }
        private IGetByKey<IEnumerable<Statistic>, string> loadMonitoringDecorator(Tracer tracer, IGetByKey<IEnumerable<Statistic>, string> inner, Module module)
        {
            if (module.IsMonitoringActive())
            {
                inner = new MonGetByKeyDec<Statistic>(
                    inner,
                    ValidationHelper.ValidateString(1012105, "Quote"),
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