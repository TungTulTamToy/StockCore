using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo;
using StockCore.DomainEntity;

namespace StockCore.Business.Builder
{
    public class StockByGroupBuilder : IBuilder<string, DECollection<StockDE>>
    {
        private readonly ILogger logger;
        private readonly IGetByKey<IEnumerable<QuoteGroup>,string> quoteGroupProvider;
        private readonly  IBuilder<string,StockDE> stockBuilder;
        public StockByGroupBuilder(
            ILogger logger,
            IGetByKey<IEnumerable<QuoteGroup>,string> quoteGroupProvider,
            IBuilder<string,StockDE> stockBuilder)
        {
            this.logger = logger;
            this.quoteGroupProvider = quoteGroupProvider;
            this.stockBuilder = stockBuilder;
        }
        public async Task<DECollection<StockDE>> BuildAsync(string quoteGroupName)
        {
            DECollection<StockDE> collection = null;
            var groups = await quoteGroupProvider.GetByKeyAsync(quoteGroupName);
            if(groups != null && groups.Any())
            {
                var group = groups.First();
                List<StockDE> stocks = new List<StockDE>();
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
                    collection = new DECollection<StockDE>(stocks);
                }
            }
            return collection;
        }
    }
}