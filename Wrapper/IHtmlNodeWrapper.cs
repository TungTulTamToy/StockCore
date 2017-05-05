using System.Collections;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace StockCore.Wrapper
{
    public interface IHtmlNodeWrapper
    {
        IHtmlNodeCollectionWrapper SelectNodes(string xpath);
        string InnerText { get; }
        IHtmlNodeCollectionWrapper ChildNodes { get; }
        IHtmlNodeWrapper NextSibling { get; }
        IHtmlNodeWrapper ParentNode { get; }
    }
    public class HtmlNodeWrapper : IHtmlNodeWrapper
    {
        private readonly HtmlNode node;
        public HtmlNodeWrapper(HtmlNode node)
        {
            this.node = node;
        }
        public string InnerText => node.InnerText;
        public IHtmlNodeCollectionWrapper ChildNodes => new HtmlNodeCollectionWrapper(node.ChildNodes);
        public IHtmlNodeWrapper NextSibling => new HtmlNodeWrapper(node.NextSibling);
        public IHtmlNodeWrapper ParentNode => new HtmlNodeWrapper(node.ParentNode);

        public IHtmlNodeCollectionWrapper SelectNodes(string xpath)
        {
            HtmlNodeCollectionWrapper wrapper = null;
            var nodes = node.SelectNodes(xpath);
            if(nodes!=null)
            {
                wrapper = new HtmlNodeCollectionWrapper(node.SelectNodes(xpath));
            }
            return wrapper;
        }
    }
}