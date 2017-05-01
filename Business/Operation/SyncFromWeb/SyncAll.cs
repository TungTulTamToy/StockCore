using System.Threading.Tasks;
using System.Collections.Generic;
using StockCore.Factory;

namespace StockCore.Business.Operation.SyncFromWeb
{
    public class SyncAll:IOperation<IEnumerable<string>>
    {
        private readonly IOperation<string> syncQuote;
        public SyncAll(IOperation<string> syncQuote)
        {
            this.syncQuote = syncQuote;
        }
        public async Task OperateAsync(IEnumerable<string> quotes)
        {
            foreach(var q in quotes)
            {
                await syncQuote.OperateAsync(q);
            }
        }
    }
}