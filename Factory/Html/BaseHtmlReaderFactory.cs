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
    public abstract class BaseHtmlReaderFactory<T> : BaseFactory<string,IGetByKey<IEnumerable<T>,string>>, IDisposable
    {
        protected readonly IHttpClientWrapper client;
        protected readonly IHtmlDocumentWrapper doc;
        protected readonly IConfigReader configReader;
        public BaseHtmlReaderFactory(
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc,
            IConfigReader configReader,
            int processErrId,
            int outerErrId,
            int id,
            string key,
            ILogger logger            
            ):base(processErrId,outerErrId,id,key,logger)
        {
            this.client = client;
            this.doc = doc;
            this.configReader = configReader;
        }
        private bool disposed = false;
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    if(client!=null)
                    {
                        client.Dispose();
                    }
                }
                disposed = true;
            }
        }
        ~BaseHtmlReaderFactory()
        {
            Dispose(false);
        }
    }
}