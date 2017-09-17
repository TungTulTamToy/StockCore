using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using StockCore.DomainEntity;
using StockCore.Wrapper;
using System;
using System.Globalization;

namespace StockCore.Business.Repo.Html
{
    public class StatisticHtmlReader : BaseHtmlReader<Statistic>
    {
        public StatisticHtmlReader(
            IHttpClientWrapper client, 
            IHtmlDocumentWrapper doc) : base(
                client, 
                doc, 
                "http://www.settrade.com/C04_06_stock_financial_p1.jsp?txtSymbol={0}&selectPage=6") { }
        protected override IEnumerable<Statistic> extractValues(string keyword)
        {
            
            var firstPattern = "^\\d{2}/\\d{2}/\\d{4}\\s\\**$";
            var secondPattern = "^\\d{2}/\\d{2}/\\d{4}$";

            var statistics = loadStatToListV2(firstPattern);
            statistics.AddRange(loadStatToListV2(secondPattern));

            /*
            var nodes = findNodes(firstPattern);
            if (nodes.Count() == 0)
            {
                nodes = findNodes(secondPattern);
            }*/
            
            //var dateNodes = doc.DocumentNode.SelectNodes("//div[@id='fiveyear']/div/table/thead/tr/th/strong");

            var dataNodes = doc.DocumentNode.SelectNodes("//div[@id='fiveyear']/div/table/tbody").FirstOrDefault();

            //var dataNodes = dateNodes.First().ParentNode.ParentNode.NextSibling.NextSibling;
            
            var assets = parseDouble(dataNodes.ChildNodes[3].ChildNodes);
            var liabilities = parseDouble(dataNodes.ChildNodes[5].ChildNodes);
            var equities = parseDouble(dataNodes.ChildNodes[7].ChildNodes);
            var revenues = parseDouble(dataNodes.ChildNodes[11].ChildNodes);
            var netprofits = parseDouble(dataNodes.ChildNodes[13].ChildNodes);
            var roas = parseDouble(dataNodes.ChildNodes[19].ChildNodes);
            var roes = parseDouble(dataNodes.ChildNodes[21].ChildNodes);
            var margins = parseDouble(dataNodes.ChildNodes[23].ChildNodes);

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
        private List<Statistic> loadStatToListV2(string pattern)
        {
            var items = new List<Statistic>();
            var dateNodes = doc.DocumentNode.SelectNodes("//div[@id='fiveyear']/div/table/thead/tr/th/strong");
            foreach (var selectedNode in dateNodes)
            {
                foreach(var childNode in selectedNode.ChildNodes)
                {
                    foreach (Match match in Regex.Matches(childNode.InnerText.Trim(), pattern))
                    {
                        var year = parseThaiYear(match.Value.TrimEnd(new char[] { ' ', '*' }));
                        items.Add(new Statistic { Year = year });
                    }
                }
            }
            return items;
        }
        private List<Statistic> loadStatToList(string pattern)
        {
            var nodes = findNodes(pattern);
            var items = new List<Statistic>();
            if(nodes != null)
            {
                foreach (var selectedNode in nodes)
                {
                    foreach (Match match in Regex.Matches(selectedNode.InnerText.Trim(), pattern))
                    {
                        var year = parseYear(match.Value.TrimEnd(new char[] { ' ', '*' }));
                        items.Add(new Statistic { Year = year });
                    }
                }
            }
            return items;
        }
        private IEnumerable<IHtmlNodeWrapper> findNodes2(string pattern)=>doc.DocumentNode.SelectNodes("//div[@id='fiveyear']").Where(node => Regex.IsMatch(node.InnerText.Trim(), pattern));
        private IEnumerable<IHtmlNodeWrapper> findNodes(string pattern)=>doc.DocumentNode.SelectNodes("//th").Where(node => Regex.IsMatch(node.InnerText.Trim(), pattern));
        private IEnumerable<double> parseDouble(IHtmlNodeCollectionWrapper nodes)
        {
            double temp;
            var doubleValues = from n in nodes
                               where double.TryParse(n.InnerText.Replace("&nbsp;","").Trim(), out temp)
                               select double.Parse(n.InnerText.Replace("&nbsp;","").Trim());
            return doubleValues;
        }
        private int parseYear(string value)=>parseDateTime(value).Year;

        private int parseThaiYear(string value)
        {
            var thaiDate = parseDateTime(value,"dd/MM/yyyy","th-TH");
            return thaiDate.Year;
        }
    }
}