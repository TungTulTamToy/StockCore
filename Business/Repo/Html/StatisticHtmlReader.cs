using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using StockCore.DomainEntity;
using StockCore.Wrapper;

namespace StockCore.Business.Repo.Html
{
    public class StatisticHtmlReader : BaseHtmlReader<StatisticDE>
    {
        public StatisticHtmlReader(
            IHttpClientWrapper client, 
            IHtmlDocumentWrapper doc) : base(
                client, 
                doc, 
                "http://www.settrade.com/C04_03_stock_companyhighlight_p1.jsp?txtSymbol={0}&selectPage=3") { }
        protected override IEnumerable<StatisticDE> extractValues(string keyword)
        {
            var firstPattern = "^\\d{2}/\\d{2}/\\d{2}\\s\\**$";
            var secondPattern = "^\\d{2}/\\d{2}/\\d{2}$";

            var statistics = loadStatToList(firstPattern);
            statistics.AddRange(loadStatToList(secondPattern));

            var nodes = findNodes(firstPattern);
            if (nodes.Count() == 0)
            {
                nodes = findNodes(secondPattern);
            }

            var dataNodes = nodes.First().ParentNode.ParentNode.NextSibling.NextSibling;
            var assets = parseDouble(dataNodes.ChildNodes[1].ChildNodes);
            var liabilities = parseDouble(dataNodes.ChildNodes[3].ChildNodes);
            var equities = parseDouble(dataNodes.ChildNodes[5].ChildNodes);
            var revenues = parseDouble(dataNodes.ChildNodes[9].ChildNodes);
            var netprofits = parseDouble(dataNodes.ChildNodes[11].ChildNodes);
            var roas = parseDouble(dataNodes.ChildNodes[13].ChildNodes);
            var roes = parseDouble(dataNodes.ChildNodes[15].ChildNodes);
            var margins = parseDouble(dataNodes.ChildNodes[17].ChildNodes);

            for (int i = 0; i < statistics.Count(); i++)
            {
                statistics[i].Quote = keyword;
                statistics[i].Asset = assets.ElementAt(i);
                statistics[i].Liability = liabilities.ElementAt(i);
                statistics[i].Equity = equities.ElementAt(i);
                statistics[i].Revenue = revenues.ElementAt(i);
                statistics[i].NetProfit = netprofits.ElementAt(i);
                statistics[i].Roa = roas.ElementAt(i);
                statistics[i].Roe = roes.ElementAt(i);
                statistics[i].Margin = margins.ElementAt(i);
                statistics[i].IsValid = true;
            }
            return statistics;
        }
        private List<StatisticDE> loadStatToList(string pattern)
        {
            var nodes = findNodes(pattern);
            var items = new List<StatisticDE>();
            if(nodes != null)
            {
                foreach (var selectedNode in nodes)
                {
                    foreach (Match match in Regex.Matches(selectedNode.InnerText.Trim(), pattern))
                    {
                        var year = parseYear(match.Value.TrimEnd(new char[] { ' ', '*' }));
                        items.Add(new StatisticDE { Year = year });
                    }
                }
            }
            return items;
        }
        private IEnumerable<IHtmlNodeWrapper> findNodes(string pattern)
        {
            return doc.DocumentNode.SelectNodes("//th").Where(node => Regex.IsMatch(node.InnerText.Trim(), pattern));
        }
        private IEnumerable<double> parseDouble(IHtmlNodeCollectionWrapper nodes)
        {
            double temp;
            var doubleValues = from n in nodes
                               where double.TryParse(n.InnerText.Trim(), out temp)
                               select double.Parse(n.InnerText.Trim());
            return doubleValues;
        }
        private int parseYear(string value)
        {
            return parseDateTime(value).Year;
        }
    }
}