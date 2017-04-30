using System.Collections.Generic;
using System.Text.RegularExpressions;
using StockCore.DomainEntity;
using System.Linq;
using StockCore.Wrapper;

namespace StockCore.Business.Repo.Html
{
    public class ShareHtmlReader : BaseHtmlReader<ShareDE>
    {
        public ShareHtmlReader(
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc) : base(
                client, 
                doc, 
                "http://www.settrade.com/C04_03_stock_companyhighlight_p1.jsp?txtSymbol={0}&selectPage=3") { }
        protected override IEnumerable<ShareDE> extractValues(string keyword)
        {
            var pattern = "\\d{2}/\\d{2}/\\d{4}:$";
            var nodes = doc.DocumentNode.SelectNodes("//div").Where(node => Regex.IsMatch(node.InnerText.Trim(), pattern)).Take(4).Reverse();
            var shares = new List<ShareDE>();
            if(nodes!=null)
            {
                foreach (var node in nodes)
                {
                    var selectedValue = node.NextSibling.NextSibling.InnerText.Trim();
                    var splitedValue = selectedValue.Split(' ');
                    var amount = parselong(splitedValue[0]);
                    if (amount != null)
                    {
                        foreach (Match match in Regex.Matches(node.InnerText.Trim(), pattern))
                        {
                            var date = parseDateTime(match.Value.TrimEnd(':'), "dd/MM/yyyy", "th-TH");
                            if (!shares.Any(s => s.Date == date))
                            {
                                shares.Add(new ShareDE
                                {
                                    Quote = keyword,
                                    Date = date,
                                    Amount = amount,
                                    IsValid = true
                                });
                            }
                        }
                    }
                }
            }
            return shares;
        }
        private long? parselong(string value)
        {
            value = value.Replace(",", "");
            long temp;
            return long.TryParse(value.Trim(), out temp) ? temp : default(long?);
        }
    }
}