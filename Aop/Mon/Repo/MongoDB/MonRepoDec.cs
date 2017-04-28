using System.Collections.Generic;
using System.Linq;
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
            var returnItems = await baseMonDecBuildAsync(
                "",
                (logger,tracer,moduleName,methodName)=>true,
                async ()=> await inner.GetAllAsync());
            return returnItems;
        }
        public async Task InsertAsync(T item)
        {
            await baseMonDecBuildAsync(
                item,
                (logger,tracer,moduleName,methodName)=>validateEntity(item),
                async ()=> {
                    await inner.InsertAsync(item);
                    return true;
            });
        }

        public async Task BatchInsertAsync(IEnumerable<T> items)
        {
            await baseMonDecBuildAsync(
                items,
                (logger,tracer,moduleName,methodName)=>validateEntities(items),
                async ()=> {
                    await inner.BatchInsertAsync(items);
                    return true;
            });
        }

        public async Task UpdateAsync(T item)
        {
            await baseMonDecBuildAsync(
                item,
                (logger,tracer,moduleName,methodName)=>validateEntity(item),
                async ()=> {
                    await inner.UpdateAsync(item);
                    return true;
            });
        }

        public async Task BatchUpdateAsync(IEnumerable<T> items)
        {
            await baseMonDecBuildAsync(
                items,
                (logger,tracer,moduleName,methodName)=>validateEntities(items),
                async ()=>{
                    await inner.BatchUpdateAsync(items);
                    return true;
            });
        }

        public async Task DeleteAsync(T item)
        {
            await baseMonDecBuildAsync(
                item,
                (logger,tracer,moduleName,methodName)=> validateEntity(item),
                async ()=>{
                    await inner.DeleteAsync(item);
                    return true;
            });
        }

        public async Task BatchDeleteAsync(IEnumerable<T> items)
        {
            await baseMonDecBuildAsync(
                items,
                (logger,tracer,moduleName,methodName)=> validateEntities(items),
                async ()=> {
                    await inner.BatchDeleteAsync(items);
                    return true;
            });
        }
        private bool validateEntity(T inputItem)
        {
            return inputItem!=null;
        }

        private bool validateEntities(IEnumerable<T> inputItems)
        {
            return inputItems!=null && inputItems.Any();
        }
    }
}