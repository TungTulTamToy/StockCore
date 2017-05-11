using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo;
using StockCore.Business.Repo.AppSetting;
using StockCore.DomainEntity;
using StockCore.Helper;

namespace StockCore.Business.Builder
{
    public class StockByDynamicGroupBuilder : IBuilder<string, IEnumerable<Stock>>
    {
        private readonly ILogger logger;
        private readonly IGetByKey<IEnumerable<QuoteGroup>,string> quoteGroupProvider;
        private readonly  IBuilder<string,Stock> stockBuilder;
        private readonly IConfigReader<IDynamicGroup> dynamicGroupReader;
        public StockByDynamicGroupBuilder(
            ILogger logger,
            IConfigReader<IDynamicGroup> dynamicGroupReader,
            IGetByKey<IEnumerable<QuoteGroup>,string> quoteGroupProvider,
            IBuilder<string,Stock> stockBuilder)
        {
            this.logger = logger;
            this.quoteGroupProvider = quoteGroupProvider;
            this.dynamicGroupReader = dynamicGroupReader;
            this.stockBuilder = stockBuilder;
        }
        public IEnumerable<Stock> Build(string quoteGroupName)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Stock>> BuildAsync(string quoteGroupName)
        {
            IEnumerable<Stock> stocks = null;
            var dynamicGroup = dynamicGroupReader.GetByKey(quoteGroupName);
            var groups = await quoteGroupProvider.GetByKeyAsync(dynamicGroup.ReferenceGroup);
            if (groups != null && groups.Any())
            {
                var group = groups.First();
                stocks = await getStocksFromReferenceGroup(group);
            }
            stocks = getStockByCriteria(stocks, dynamicGroup);
            return stocks;
        }
        private IEnumerable<Stock> getStockByCriteria(IEnumerable<Stock> stocks, IDynamicGroup dynamicGroup)
        {
            if (stocks != null && stocks.Any() && !string.IsNullOrEmpty(dynamicGroup.Criteria))
            {
                var e = DynamicExpressionParser.ParseLambda(typeof(Stock), typeof(bool), dynamicGroup.Criteria);
                stocks = stocks.Where(s => (bool)e.Compile().DynamicInvoke(s));
            }
            return stocks;
        }
        private async Task<List<Stock>> getStocksFromReferenceGroup(QuoteGroup group)
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