using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Business.Repo.MongoDB;
using System;
using System.Linq.Expressions;

namespace StockCore.Aop.Mon
{
    public class MonGetByFuncRepoDec<TInput,TResult> : MonGetByKeyRepoDec<TInput,TResult>, IGetByFuncRepo<TInput,TResult> where TInput:class where TResult:IPersistant,IKeyField<string>
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
            ):base(inner:inner,validateQuote:validateQuote,processErrorID:processErrorID,outerErrorID:outerErrorID,module:module,logger:logger,tracer:tracer)
            {
                this.validateExpression = validateExpression;
            }

        public async Task<IEnumerable<TResult>> GetByFuncAsync(Expression<Func<TResult, bool>> expression)
        {
            var returnItems = await baseMonDecBuildAsync(
                input:expression,
                validate:(logger,tracer,moduleName,methodName)=>validateExpression(logger,tracer,moduleName,methodName,expression),
                innerProcessAsync:async ()=> await ((IGetByFuncRepo<TInput,TResult>)inner).GetByFuncAsync(expression));
            return returnItems;
        }
    }
}