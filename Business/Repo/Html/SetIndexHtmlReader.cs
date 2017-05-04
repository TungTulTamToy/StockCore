using System.Collections.Generic;
using System.Text.RegularExpressions;
using StockCore.DomainEntity;
using StockCore.Wrapper;

namespace StockCore.Business.Repo.Html
{
    public class SetIndexHtmlReader : BaseHtmlReader<SetIndex>
    {
        public SetIndexHtmlReader(
            IHttpClientWrapper client, 
            IHtmlDocumentWrapper doc) : base(
                client, 
                doc, 
                "http://www.settrade.com/C04_02_stock_historical_p1.jsp?txtSymbol={0}&selectPage=2&ssoPageId=9") { }
        protected override IEnumerable<SetIndex> extractValues(string keyword)
        {
            var selectedNodes = doc.DocumentNode.SelectNodes("//div[@class='table-responsive']//table//tbody//tr");
            var setIndex = new List<SetIndex>();
            if(selectedNodes!=null)
            {
                foreach (var selectedNode in selectedNodes)
                {
                    var splitedText = Regex.Split(selectedNode.InnerText.Trim(), "\r\n");
                    var date = parseDateTime(splitedText[0]);
                    var index = parseDouble(splitedText[10]);

                    setIndex.Add(new SetIndex
                    { 
                        Date = date,
                        Index = index,
                        IsValid = true
                    });
                }
            }
            return setIndex;
        }
    }
}