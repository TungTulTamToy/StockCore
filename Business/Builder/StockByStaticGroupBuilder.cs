using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo;
using StockCore.DomainEntity;
using StockCore.Helper;

namespace StockCore.Business.Builder
{
    public class StockByStaticGroupBuilder : IBuilder<string, IEnumerable<Stock>>
    {
        private readonly ILogger logger;
        private readonly IGetByKey<IEnumerable<QuoteGroup>,string> quoteGroupProvider;
        private readonly  IBuilder<string,Stock> stockBuilder;
        public StockByStaticGroupBuilder(
            ILogger logger,
            IGetByKey<IEnumerable<QuoteGroup>,string> quoteGroupProvider,
            IBuilder<string,Stock> stockBuilder)
        {
            this.logger = logger;
            this.quoteGroupProvider = quoteGroupProvider;
            this.stockBuilder = stockBuilder;
        }
        public IEnumerable<Stock> Build(string t = null)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<IEnumerable<Stock>> BuildAsync(string quoteGroupName)
        {
            IEnumerable<Stock> stocks = null;
            var groups = await quoteGroupProvider.GetByKeyAsync(quoteGroupName);
            if(groups != null && groups.Any())
            {
                var group = groups.First();
                stocks = await getStocks(group);
            }
            return stocks;
        }
        private async Task<List<Stock>> getStocks(QuoteGroup group)
        {
            List<Stock> stocks = new List<Stock>();
            foreach (var quote in group.Quotes)
            {
                var stock = await stockBuilder.BuildAsync(quote);
                if (stock != null)
                {
                    stocks.Add(stock);
                }
            }
            return stocks;
        }
    }
}