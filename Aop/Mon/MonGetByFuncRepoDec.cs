using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using System;
using System.Linq.Expressions;

namespace StockCore.Aop.Mon
{
    public class MonGetByFuncRepoDec<TInput,TResult> : MonGetByKeyRepoDec<TInput,TResult>, IGetByFuncRepo<TInput,TResult> where TInput:class where TResult:IBaseDE,IKeyField<string>
    {
        private readonly Func<ILogger,Tracer,string,string,Expression<Func<TResult,bool>>,bool> validateExpression;
        public MonGetByFuncRepoDec(
            IGetByFuncRepo<TInput,TResult> inner,
            Func<ILogger,Tracer,string,string,Expression<Func<TResult,bool>>,bool> validateExpression,   
            Func<ILogger,Tracer,string,string,TInput,bool> validateQuote,          
            int processErrorID,
            int outerErrorID,
            MonitoringModule module,
            ILogger logger,
            Tracer tracer
            ):base(inner,validateQuote,processErrorID,outerErrorID,module,logger,tracer)
            {
                this.validateExpression = validateExpression;
            }

        public async Task<IEnumerable<TResult>> GetByFuncAsync(Expression<Func<TResult, bool>> expression)
        {
            var returnItems = await baseMonDecBuildAsync(
                expression,
                (logger,tracer,moduleName,methodName)=>validateExpression(logger,tracer,moduleName,methodName,expression),
                async ()=> await ((IGetByFuncRepo<TInput,TResult>)inner).GetByFuncAsync(expression));
            return returnItems;
        }
    }
}