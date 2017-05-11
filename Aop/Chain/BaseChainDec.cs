using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Extension;
using System.Runtime.CompilerServices;
using StockCore.Helper;
using StockCore.Aop.Mon;

namespace StockCore.Aop.Chain
{
    public class BaseChainDec<T>:BaseDec
    {
        protected readonly PostFilterModule module;
        private readonly int processErrorID;
        private readonly ILogger logger;
        private readonly int outerErrorID;
        public BaseChainDec(
            int processErrorID,
            int outerErrorID,
            PostFilterModule module,
            ILogger logger
            )
        {
            this.module = module;
            this.processErrorID = processErrorID;
            this.outerErrorID = outerErrorID;            
            this.logger = logger;
        }
        protected async Task<T> baseChainDecBuildAsync(
            Func<Task<T>> innerProcessAsync,            
            Func<T,T> chain,
            [CallerMemberName]string methodName="")
        {
            var t = default(T);
            await baseDecOperateAsync(
                processAsync: async() => {
                    t = await innerProcessAsync();
                    t = chain(t);
                    },
                processFail:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName),
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName)
            );
            return t;
        }
        protected T baseChainDecBuild(
            Func<T,T> chain,
            Func<T> innerProcess,
            [CallerMemberName]string methodName="")
        {
            var t = default(T);
            baseDecOperate(
                process:() => {
                    t = innerProcess();
                    t = chain(t);
                    },
                processFail:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName),
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName)
            );
            return t;
        }
    }
}