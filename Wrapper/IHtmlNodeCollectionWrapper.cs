using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace StockCore.Wrapper
{
    public interface IHtmlNodeCollectionWrapper : IList<IHtmlNodeWrapper>, ICollection<IHtmlNodeWrapper>, IEnumerable<IHtmlNodeWrapper>, IEnumerable{}
    public class HtmlNodeCollectionWrapper : IHtmlNodeCollectionWrapper
    {
        private readonly HtmlNodeCollection nodes;
        public HtmlNodeCollectionWrapper(HtmlNodeCollection nodes)
        {
            this.nodes = nodes;
        }

        public IHtmlNodeWrapper this[int index] 
        { 
            get => new HtmlNodeWrapper(nodes.ElementAt(index));
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