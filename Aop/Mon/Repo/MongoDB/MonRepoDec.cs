using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;

namespace StockCore.Aop.Mon.Repo.MongoDB
{
    public class MonRepoDec<T> : BaseMonDec,IRepo<T> where T:BaseDE
    {
        protected readonly IRepo<T> inner; 
        public MonRepoDec(
            IRepo<T> inner,
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer
            ):base(processErrorID,outerErrorID,module,logger,tracer)
        {
            this.inner = inner;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var returnItems = await operateWithResultAsync(
                "",
                (logger,tracer)=>true,
                async ()=> await inner.GetAllAsync());
            return returnItems;
        }
        public async Task InsertAsync(T item)
        {
            await operateAsync<T>(item,(logger,tracer)=>validate(logger,tracer,item),async ()=> await inner.InsertAsync(item));
        }

        public async Task BatchInsertAsync(IEnumerable<T> items)
        {
            await operateAsync<IEnumerable<T>>(items,(logger,tracer)=>validate(logger,tracer,items),async ()=> await inner.BatchInsertAsync(items));
        }

        public async Task UpdateAsync(T item)
        {
            await operateAsync<T>(item,(logger,tracer)=>validate(logger,tracer,item),async ()=> await inner.UpdateAsync(item));
        }

        public async Task BatchUpdateAsync(IEnumerable<T> items)
        {
            await operateAsync<IEnumerable<T>>(items,(logger,tracer)=>validate(logger,tracer,items),async ()=>await inner.BatchUpdateAsync(items));
        }

        public async Task DeleteAsync(T item)
        {
            await operateAsync<T>(item,(logger,tracer)=> validate(logger,tracer,item),async ()=>await inner.DeleteAsync(item));
        }

        public async Task BatchDeleteAsync(IEnumerable<T> items)
        {
            await operateAsync<IEnumerable<T>>(items,(logger,tracer)=> validate(logger,tracer,items),async ()=> await inner.BatchDeleteAsync(items));
        }
        private bool validate(ILogger logger,Tracer tracer,T inputItem)
        {
            return inputItem!=null;
        }

        private bool validate(ILogger logger,Tracer tracer,IEnumerable<T> inputItems)
        {
            return inputItems!=null && inputItems.Any();
        }
    }
}