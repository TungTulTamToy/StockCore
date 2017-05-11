using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using StockCore.Helper;
using StockCore.DomainEntity;

namespace StockCore.Aop.Switch
{
    public class BaseSwitchDec : BaseDec
    {
        private readonly IKeyModule module;
        private readonly int processErrorID;
        private readonly ILogger logger;
        private readonly int outerErrorID;
        public BaseSwitchDec(
            IKeyModule module,
            int outerErrorID,
            int processErrorID,            
            ILogger logger
            )
        {
            this.module = module;
            this.processErrorID = processErrorID;   
            this.outerErrorID = outerErrorID;
            this.logger = logger;
        }
        protected void baseSwitchDecOperate(
            Func<bool> determineSwitch,
            Action regularInner,
            Action switchInner,
            [CallerMemberName]string methodName="")
        {
            baseDecOperate(
                validate:()=>determineSwitch(),
                process:()=>regularInner(),
                invalidProcess:()=>switchInner(),
                processFail:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName),
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName)
            );
        }
        protected async Task baseSwitchDecOperateAsync(
            Func<bool> determineSwitch,
            Func<Task> regularInnerAsync,
            Func<Task> switchInnerAsync,
            [CallerMemberName]string methodName="")
        {
            await baseDecOperateAsync(
                validate:()=>determineSwitch(),
                processAsync:async()=>await regularInnerAsync(),
                invalidProcessAsync:async()=>await switchInnerAsync(),
                processFail:(ex)=>ProcessFailHelper.ComposeAndThrowException(logger,ex,processErrorID,module.Key,methodName),
                finalProcessFail:(e)=>ProcessFailHelper.ComposeAndThrowException(logger,e,outerErrorID,module.Key,methodName)
            );
        }
    }
}