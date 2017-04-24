using System;
using System.Collections;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;

namespace StockCore.Wrapper
{
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
            return new HtmlNodeCollectionWrapper(node.SelectNodes(xpath));
        }
    }

    public class HtmlNodeCollectionWrapper : IHtmlNodeCollectionWrapper
    {
        private readonly HtmlNodeCollection nodes;
        public HtmlNodeCollectionWrapper(HtmlNodeCollection nodes)
        {
            this.nodes = nodes;
        }

        public IHtmlNodeWrapper this[int index] 
        { 
            get => new HtmlNodeWrapper(nodes.ElementAt(index));// throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public int Count => nodes.Count();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(IHtmlNodeWrapper item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IHtmlNodeWrapper item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IHtmlNodeWrapper[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IHtmlNodeWrapper> GetEnumerator()
        {
            foreach (var n in nodes)
            {
                yield return new HtmlNodeWrapper(n);
            }
        }

        public int IndexOf(IHtmlNodeWrapper item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, IHtmlNodeWrapper item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IHtmlNodeWrapper item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}