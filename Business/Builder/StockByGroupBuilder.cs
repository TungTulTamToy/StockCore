using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo;
using StockCore.DomainEntity;

namespace StockCore.Business.Builder
{
    public class StockByGroupBuilder : IBuilder<string, DECollection<Stock>>
    {
        private readonly ILogger logger;
        private readonly IGetByKey<IEnumerable<QuoteGroup>,string> quoteGroupProvider;
        private readonly  IBuilder<string,Stock> stockBuilder;
        public StockByGroupBuilder(
            ILogger logger,
            IGetByKey<IEnumerable<QuoteGroup>,string> quoteGroupProvider,
            IBuilder<string,Stock> stockBuilder)
        {
            this.logger = logger;
            this.quoteGroupProvider = quoteGroupProvider;
            this.stockBuilder = stockBuilder;
        }
        public async Task<DECollection<Stock>> BuildAsync(string quoteGroupName)
        {
            DECollection<Stock> collection = null;
            var groups = await quoteGroupProvider.GetByKeyAsync(quoteGroupName);
            if(groups != null && groups.Any())
            {
                var group = groups.First();
                List<Stock> stocks = new List<Stock>();
                foreach (var quote in group.Quotes)
                {
                    var stock = await stockBuilder.BuildAsync(quote);
                    if(stock!=null)
                    {
                        stocks.Add(stock);  
                    }                      
                }
                if(stocks!=null)
                {
                    collection = new DECollection<Stock>(stocks);
                }
            }
            return collection;
        }
    }
}