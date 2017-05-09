using System.Collections.Generic;
using System.Text.RegularExpressions;
using StockCore.DomainEntity;
using StockCore.Wrapper;

namespace StockCore.Business.Repo.Html
{
    public class PriceHtmlReader : BaseHtmlReader<Price>
    {
        public PriceHtmlReader(
            IHttpClientWrapper client,
            IHtmlDocumentWrapper doc) : base(
                client, 
                doc, 
                "http://www.settrade.com/C04_02_stock_historical_p1.jsp?txtSymbol={0}&selectPage=null&max=200&offset=0") { }
        protected override IEnumerable<Price> extractValues(string keyword)
        {
            var selectedNodes = doc.DocumentNode.SelectNodes("//div[@class='table-responsive']//table//tbody//tr");
            var prices = new List<Price>();
            if(selectedNodes!=null)
            {
                foreach (var selectedNode in selectedNodes)
                {
                    var splitedText = Regex.Split(selectedNode.InnerText.Trim(), "\r\n");
                    var date = parseDateTime(splitedText[0]);
                    var open = parseDouble(splitedText[1]);
                    var high = parseDouble(splitedText[2]);
                    var low = parseDouble(splitedText[3]);
                    var close = parseDouble(splitedText[5]);
                    var amount = parseDouble(splitedText[8]);
                    var volumn = parseDouble(splitedText[9]);

                    prices.Add(new Price
                    {
                        Quote = keyword,
                        Date = date,
                        Open = open,
                        High = high,
                        Low = low,
                        Close = close,
                        Amount = amount,
                        Volumn = volumn,
                        IsValid = true
                    });
                }
            }
            return prices;
        }
    }
}