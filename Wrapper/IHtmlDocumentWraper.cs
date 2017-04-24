using System.Collections;
using System.Collections.Generic;

namespace StockCore.Wrapper
{
    public interface IHtmlDocumentWrapper
    {
        void LoadHtml(string html);
        IHtmlNodeWrapper DocumentNode { get; }
    }

    public interface IHtmlNodeWrapper
    {
        IHtmlNodeCollectionWrapper SelectNodes(string xpath);
        string InnerText { get; }
        IHtmlNodeCollectionWrapper ChildNodes { get; }
        IHtmlNodeWrapper NextSibling { get; }
        IHtmlNodeWrapper ParentNode { get; }
    }

    public interface IHtmlNodeCollectionWrapper : IList<IHtmlNodeWrapper>, ICollection<IHtmlNodeWrapper>, IEnumerable<IHtmlNodeWrapper>, IEnumerable
    {
    }
}