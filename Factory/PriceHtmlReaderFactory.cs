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
    public class PriceHtmlReaderFactory : BaseFactory<string,IGetByKey<IEnumerable<PriceDE>,string>>
    {
        private const string KEY = "HtmlPriceGetByKey";
        private const int ID = 1009100;
        private const int PROCESSERRID = 1009101;
        private const int OUTERERRID = 1009102;
        private const int MONPROCESSERRID = 1009103;
        private const int MONOUTERERRID = 1009104;
        private readonly IConfigReader configReader;
        private readonly IHttpClientWrapper client;
        private readonly IHtmlDocumentWrapper doc;
        public PriceHtmlReaderFactory(ILogger logger,
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.client = client;
            this.doc = doc;
            this.configReader = configReader;
        }
        protected override IGetByKey<IEnumerable<PriceDE>,string> build(Tracer tracer,string t="")
        {
            IGetByKey<IEnumerable<PriceDE>,string> inner = new PriceHtmlReader(client,doc);  
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                var helper = new ValidationHelper();
                inner = new MonGetByKeyDec<PriceDE>(
                    inner,
                    helper.ValidateString(1009105,"Quote"),
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