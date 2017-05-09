using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Extension;
using System.Runtime.CompilerServices;
using StockCore.Helper;
using StockCore.Aop.Mon;

namespace StockCore.Aop.Filter
{
    public class BaseFilterDec:BaseDec
    {
        protected readonly FilterModule module;
        private readonly int processErrorID;
        private readonly ILogger logger;
        private readonly int outerErrorID;
        public BaseFilterDec(
            int processErrorID,
            int outerErrorID,
            FilterModule module,
            ILogger logger
            )
        {
            this.module = module;
            this.processErrorID = processErrorID;
            this.outerErrorID = outerErrorID;            
            this.logger = logger;
        }
        protected async Task baseFilterDecBuildAsync(
            Func<bool> baseFilter,
            Func<Task> innerProcessAsync,
            [CallerMemberName]string methodName="")
        {
            await baseDecOperateAsync(
                validate:()=> baseFilter(),
                processAsync: async() => await innerProcessAsync(),
                processFail:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName),
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName)
            );
        }
        protected void baseFilterDecBuild(
            Func<bool> baseFilter,
            Action innerProcess,
            [CallerMemberName]string methodName="")
        {
            baseDecOperate(
                validate:()=> baseFilter(),
                process:() => innerProcess(),
                processFail:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName),
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName)
            );
        }
    }
}