using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using System;
using System.Linq.Expressions;

namespace StockCore.Aop.Mon.Repo.MongoDB
{
    public class MonGetByFuncRepoDec<T> : MonGetByKeyRepoDec<T>, IGetByFuncRepo<string,T> where T:BaseDE,IKeyField<string>
    {
        private readonly Func<ILogger,Tracer,Expression<Func<T,bool>>,bool> validateExpression;
        public MonGetByFuncRepoDec(
            IGetByFuncRepo<string,T> inner,
            Func<ILogger,Tracer,Expression<Func<T,bool>>,bool> validateFunc,   
            Func<ILogger,Tracer,string,bool> validate,          
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer
            ):base(inner,validate,processErrorID,outerErrorID,module,logger,tracer)
            {
                this.validateExpression = validateFunc;
            }

        public async Task<IEnumerable<T>> GetByFuncAsync(Expression<Func<T, bool>> func)
        {
            var returnItems = await operateWithResultAsync(
                "",
                (logger,tracer)=>validateExpression(logger,tracer,func),
                async ()=> await ((IGetByFuncRepo<string,T>)inner).GetByFuncAsync(func));
            return returnItems;
        }
    }
}