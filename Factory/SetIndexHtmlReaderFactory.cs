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
    public class SetIndexHtmlReaderFactory : BaseFactory<string,IGetByKey<IEnumerable<SetIndexDE>,string>>
    {
        private const string KEY = "HtmlSetIndexGetByKey";
        private const int ID = 1010100;
        private const int PROCESSERRID = 1010101;
        private const int OUTERERRID = 1010102;
        private const int MONPROCESSERRID = 1010103;
        private const int MONOUTERERRID = 1010104;
        private readonly IConfigReader configReader;
        private readonly IHttpClientWrapper client;
        private readonly IHtmlDocumentWrapper doc;
        public SetIndexHtmlReaderFactory(ILogger logger,
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc,
            IConfigReader configReader
            ):base(OUTERERRID,PROCESSERRID,ID,KEY,logger)
        {
            this.client = client;
            this.doc = doc;
            this.configReader = configReader;
        }
        protected override IGetByKey<IEnumerable<SetIndexDE>,string> build(Tracer tracer,string t="")
        {
            IGetByKey<IEnumerable<SetIndexDE>,string> inner = new SetIndexHtmlReader(client,doc);   
            var module = configReader.GetByKey(getAopKey());
            if(module.IsMonitoringActive())
            {
                var helper = new ValidationHelper();
                inner = new MonGetByKeyDec<SetIndexDE>(
                    inner,
                    helper.ValidateString(1010105,"Quote"),
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