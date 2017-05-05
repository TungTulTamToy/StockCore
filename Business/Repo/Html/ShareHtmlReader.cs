using System.Collections.Generic;
using System.Text.RegularExpressions;
using StockCore.DomainEntity;
using System.Linq;
using StockCore.Wrapper;
using System;

namespace StockCore.Business.Repo.Html
{
    public class ShareHtmlReader : BaseHtmlReader<Share>
    {
        public const string PATTERN = "\\d{2}/\\d{2}/\\d{4}:$";
        public ShareHtmlReader(
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc) : base(
                client, 
                doc, 
                "http://www.settrade.com/C04_03_stock_companyhighlight_p1.jsp?txtSymbol={0}&selectPage=3") { }
        protected override IEnumerable<Share> extractValues(string keyword)
        {
            var nodes = doc.DocumentNode.SelectNodes("//div").Where(node => Regex.IsMatch(node.InnerText.Trim(), PATTERN)).Take(4).Reverse();
            var shares = new List<Share>();
            if(nodes!=null)
            {
                foreach (var node in nodes)
                {
                    var selectedValue = node.NextSibling.NextSibling.InnerText.Trim();
                    var splitedValue = selectedValue.Split(' ');
                    var amount = parselong(splitedValue[0]);
                    addShares(keyword, shares, node, amount);
                }
            }
            return shares;
        }
        private void addShares(string keyword, List<Share> shares, IHtmlNodeWrapper node, long? amount)
        {
            if (amount != null)
            {
                foreach (Match match in Regex.Matches(node.InnerText.Trim(), PATTERN))
                {
                    var date = parseDateTime(match.Value.TrimEnd(':'), "dd/MM/yyyy", "th-TH");                    
                    addShare(keyword, shares, amount, date);
                }
            }
        }
        private void addShare(string keyword, List<Share> shares, long? amount, DateTime date)
        {
            if (!shares.Any(s => s.Date == date))
            {
                shares.Add(new Share
                {
                    Quote = keyword,
                    Date = date,
                    Amount = amount,
                    IsValid = true
                });
            }
        }
        private long? parselong(string value)
        {
            value = value.Replace(",", "");
            long temp;
            return long.TryParse(value.Trim(), out temp) ? temp : default(long?);
        }
    }
}