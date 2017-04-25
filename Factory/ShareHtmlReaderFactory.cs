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
    public class ShareHtmlReaderFactory : BaseFactory<string,IGetByKey<IEnumerable<ShareDE>,string>>
    {
        private const string KEY = "HtmlShareGetByKey";
        private const int ID = 1011100;
        private const int PROCESSERRID = 1011101;
        private const int OUTERERRID = 1011102;
        private const int MONPROCESSERRID = 1011103;
        private const int MONOUTERERRID = 1011104;
        private readonly IConfigReader configReader;
        private readonly IHttpClientWrapper client;
        private readonly IHtmlDocumentWrapper doc;
        public ShareHtmlReaderFactory(ILogger logger,
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc,
            IConfigReader configReader
            ):base(PROCESSERRID,OUTERERRID,ID,KEY,logger)
        {
            this.client = client;
            this.doc = doc;
            this.configReader = configReader;
        }
        protected override IGetByKey<IEnumerable<ShareDE>,string> build(Tracer tracer,string t="")
        {
            IGetByKey<IEnumerable<ShareDE>,string> inner = new ShareHtmlReader(client,doc);  
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                var helper = new ValidationHelper();
                inner = new MonGetByKeyDec<ShareDE>(
                    inner,
                    helper.ValidateString(1011105,"Quote"),
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