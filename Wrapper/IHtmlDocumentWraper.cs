using System.Collections;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace StockCore.Wrapper
{
    public interface IHtmlDocumentWrapper
    {
        void LoadHtml(string html);
        IHtmlNodeWrapper DocumentNode { get; }
    }
    public class HtmlDocumentWrapper : IHtmlDocumentWrapper
    {
        private readonly HtmlDocument doc;
        public HtmlDocumentWrapper()
        {
            this.doc = new HtmlDocument();
        }
        public IHtmlNodeWrapper DocumentNode => new HtmlNodeWrapper(doc.DocumentNode);

        public void LoadHtml(string html)
        {
            doc.LoadHtml(html);
        }
    }
}