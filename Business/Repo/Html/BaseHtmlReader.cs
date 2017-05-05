using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using StockCore.DomainEntity;
using StockCore.Wrapper;

namespace StockCore.Business.Repo.Html
{
    public abstract class BaseHtmlReader<T> : IGetByKey<IEnumerable<T>,string> where T:IPersistant
    {
        protected readonly IHtmlDocumentWrapper doc;
        private readonly string url;
        private readonly IHttpClientWrapper client;
        protected abstract IEnumerable<T> extractValues(string keyword);        
        public BaseHtmlReader(IHttpClientWrapper client, IHtmlDocumentWrapper doc, string url)
        {
            this.doc = doc;
            this.url = url;
            this.client = client;
        }
        public async Task<IEnumerable<T>> GetByKeyAsync(string id)
        {
            var response = await client.GetStringAsync(string.Format(url,id));
            doc.LoadHtml(response);
            var items = extractValues(id);
            return items;
        }
        protected double? parseDouble(string value)
        {
            double temp;
            return double.TryParse(value.Trim(), out temp) ? temp : default(double?);
        }
        protected DateTime parseDateTime(string value, string format = "dd/MM/yy", string culture = "en-US")
        {
            return DateTime.ParseExact(value.Trim(), format, new CultureInfo(culture));
        }
    }
}