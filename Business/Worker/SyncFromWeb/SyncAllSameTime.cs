using System.Threading.Tasks;
using System.Collections.Generic;
using StockCore.Factory;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;
using StockCore.DomainEntity;

namespace StockCore.Business.Worker.SyncFromWeb
{
    public class SyncAllSameTime:IOperation<IEnumerable<string>>
    {
        private readonly IServiceProvider serviceProvider;
        public SyncAllSameTime(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task OperateAsync(IEnumerable<string> quotes)
        {
            var tracer=new Tracer(0,null,"Start Sync All Same time.");
            var tasks = quotes.Select(async q=>{
                var factory = serviceProvider.GetService<IFactory<string,IOperation<string>>>();
                var o = factory.Build(tracer);                   
                await o.OperateAsync(q);
                });
            await Task.WhenAll(tasks);
        }
    }
}