using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Repo;
using StockCore.DomainEntity;

namespace StockCore.Business.Builder
{
    public class AllQuoteGroupBuilder : IBuilder<string, DECollection<QuoteGroup>>
    {
        private readonly ILogger logger;
        private readonly IGetAll<QuoteGroup> allGroupProvider;
        public AllQuoteGroupBuilder(
            ILogger logger,
            IGetAll<QuoteGroup> allGroupProvider)
        {
            this.logger = logger;
            this.allGroupProvider = allGroupProvider;
        }
        public async Task<DECollection<QuoteGroup>> BuildAsync(string t="")
        {
            var items = await allGroupProvider.GetAllAsync();
            var sortedItems = items.OrderBy(g=>g.Order);
            var collection = new DECollection<QuoteGroup>(sortedItems);
            return collection;
        }
    }
}