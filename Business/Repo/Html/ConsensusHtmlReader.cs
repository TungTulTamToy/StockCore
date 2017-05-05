using System.Collections.Generic;
using System.Linq;
using StockCore.DomainEntity;
using StockCore.Wrapper;

namespace StockCore.Business.Repo.Html
{
    public class ConsensusHtmlReader : BaseHtmlReader<Consensus>
    {
        public ConsensusHtmlReader(
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc) : base(
                client, 
                doc, 
                "http://www.settrade.com/AnalystConsensus/C04_10_stock_saa_p1.jsp?txtSymbol={0}&selectPage=10") { }
        protected override IEnumerable<Consensus> extractValues(string keyword)
        {
            var consensuses = new List<Consensus>();
            var matchedNode = doc.DocumentNode.SelectNodes("//th").SingleOrDefault(node => node.InnerText == "EPS (Baht)");
            if (matchedNode != null)
            {
                    var dataNodes = doc.DocumentNode.SelectNodes("//div[@class='table-responsive']//table//tfoot//tr");
                    consensuses.Add(
                        new Consensus 
                        { 
                            Quote = keyword, 
                            Year = extractYear(1),
                            Average = extractDouble(dataNodes,0,3),
                            High = extractDouble(dataNodes,1,3),
                            Low = extractDouble(dataNodes,2,3),
                            Median = extractDouble(dataNodes,3,3),
                            IsValid = true
                        });

                    consensuses.Add(
                        new Consensus 
                        { 
                            Quote = keyword, 
                            Year = extractYear(5),
                            Average = extractDouble(dataNodes,0,7),
                            High = extractDouble(dataNodes,1,7),
                            Low = extractDouble(dataNodes,2,7),
                            Median = extractDouble(dataNodes,3,7),
                            IsValid = true
                        });
            }
            return consensuses;
        }
        private int extractYear(int elementAt)
        {
            var y = doc.DocumentNode.SelectNodes("//div[@class='table-responsive']//table//thead//tr").ElementAt(1).ChildNodes.ElementAt(elementAt).InnerText.Trim();
            if (y.EndsWith("F"))
            {
                return int.Parse(y.TrimEnd('F'));
            }
            else
            {
                return int.Parse(y);
            }
        }

        private double? extractDouble(IHtmlNodeCollectionWrapper nodes, int nodeElementAt, int childElementAt)
        {
            var d = parseDouble(nodes.ElementAt(nodeElementAt).ChildNodes.ElementAt(childElementAt).InnerText);
            return d;
        }
    }
}