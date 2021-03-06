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
    public class StatisticHtmlReaderFactory : BaseFactory<string,IGetByKey<IEnumerable<StatisticDE>,string>>
    {
        private const string KEY = "HtmlStatisticGetByKey";
        private const int ID = 1012100;
        private const int PROCESSERRID = 1012101;
        private const int OUTERERRID = 1012102;
        private const int MONPROCESSERRID = 1012103;
        private const int MONOUTERERRID = 1012104;
        private readonly IConfigReader configReader;
        private readonly IHttpClientWrapper client;
        private readonly IHtmlDocumentWrapper doc;
        public StatisticHtmlReaderFactory(ILogger logger,
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc,
            IConfigReader configReader
            ):base(OUTERERRID,PROCESSERRID,ID,KEY,logger)
        {
            this.client = client;
            this.doc = doc;
            this.configReader = configReader;
        }
        protected override IGetByKey<IEnumerable<StatisticDE>,string> build(Tracer tracer,string t="")
        {
            IGetByKey<IEnumerable<StatisticDE>,string> inner = new StatisticHtmlReader(client,doc);
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                var helper = new ValidationHelper();
                inner = new MonGetByKeyDec<StatisticDE>(
                    inner,
                    helper.ValidateString(1012105,"Quote"),
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