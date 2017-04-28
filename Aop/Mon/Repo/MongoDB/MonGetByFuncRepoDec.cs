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
        private readonly Func<ILogger,Tracer,string,string,Expression<Func<T,bool>>,bool> validateExpression;
        public MonGetByFuncRepoDec(
            IGetByFuncRepo<string,T> inner,
            Func<ILogger,Tracer,string,string,Expression<Func<T,bool>>,bool> validateExpression,   
            Func<ILogger,Tracer,string,string,string,bool> validateQuote,          
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer
            ):base(inner,validateQuote,processErrorID,outerErrorID,module,logger,tracer)
            {
                this.validateExpression = validateExpression;
            }

        public async Task<IEnumerable<T>> GetByFuncAsync(Expression<Func<T, bool>> expression)
        {
            var returnItems = await baseMonDecBuildAsync(
                expression,
                (logger,tracer,moduleName,methodName)=>validateExpression(logger,tracer,moduleName,methodName,expression),
                async ()=> await ((IGetByFuncRepo<string,T>)inner).GetByFuncAsync(expression));
            return returnItems;
        }
    }
}