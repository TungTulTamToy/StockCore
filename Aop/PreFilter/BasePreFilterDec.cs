using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.Extension;
using System.Runtime.CompilerServices;
using StockCore.Helper;
using StockCore.Aop.Mon;

namespace StockCore.Aop.PreFilter
{
    public class BasePreFilterDec:BaseDec
    {
        protected readonly PreFilterModule module;
        private readonly int processErrorID;
        private readonly ILogger logger;
        private readonly int outerErrorID;
        public BasePreFilterDec(
            int processErrorID,
            int outerErrorID,
            PreFilterModule module,
            ILogger logger
            )
        {
            this.module = module;
            this.processErrorID = processErrorID;
            this.outerErrorID = outerErrorID;            
            this.logger = logger;
        }
        protected async Task basePreFilterDecBuildAsync(
            Func<bool> preFilter,
            Func<Task> innerProcessAsync,
            [CallerMemberName]string methodName="")
        {
            await baseDecOperateAsync(
                validate:()=> preFilter(),
                processAsync: async() => await innerProcessAsync(),
                processFail:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName),
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName)
            );
        }
        protected void basePreFilterDecBuild(
            Func<bool> preFilter,
            Action innerProcess,
            [CallerMemberName]string methodName="")
        {
            baseDecOperate(
                validate:()=> preFilter(),
                process:() => innerProcess(),
                processFail:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName),
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName)
            );
        }
    }
}