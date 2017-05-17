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
        protected readonly IKeyModule module;
        private readonly int processErrorID;
        private readonly ILogger logger;
        private readonly int outerErrorID;
        public BaseChainDec(
            int processErrorID,
            int outerErrorID,
            IKeyModule module,
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
            var item = default(T);
            await baseDecOperateAsync(
                processMainPathAsync: async() => {
                    item = await innerProcessAsync();
                    item = chain(item);
                    },
                catchBlockProcess:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName),
                unexpectedCatchBlockProcess:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName)
            );
            return item;
        }
        protected T baseChainDecBuild(
            Func<T> innerProcess,
            Func<T,T> chain,            
            [CallerMemberName]string methodName="")
        {
            var item = default(T);
            baseDecOperate(
                processMainPath:() => {
                    item = innerProcess();
                    item = chain(item);
                    },
                catchBlockProcess:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName),
                unexpectedCatchBlockProcess:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName)
            );
            return item;
        }
    }
}