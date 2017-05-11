using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Business.Builder;
using StockCore.DomainEntity;

namespace StockCore.Aop.Switch
{
    public class SwitchBuilderDec<TInput, TOutput> : BaseSwitchDec, IBuilder<TInput, TOutput> where TInput:class
    {
        private readonly Func<TInput,bool> determineSwitch;
        private readonly IBuilder<TInput, TOutput> regularInner;
        private readonly IBuilder<TInput, TOutput> switchInner;
        public SwitchBuilderDec(
            Func<TInput,bool> determineSwitch,
            IBuilder<TInput, TOutput> regularInner,
            IBuilder<TInput, TOutput> switchInner,
            IKeyModule module,
            int outerErrorID,
            int processErrorID,            
            ILogger logger
            ):base(module,outerErrorID,processErrorID,logger)
        {
            this.determineSwitch = determineSwitch;
            this.regularInner = regularInner;
            this.switchInner = switchInner;
        } 
        public TOutput Build(TInput input = default(TInput))
        {
            TOutput item = default(TOutput);
            baseSwitchDecOperate(
                determineSwitch:()=>determineSwitch(input),
                regularInner:()=> item = regularInner.Build(input),
                switchInner:()=> item = switchInner.Build(input)
            );
            return item;
        }

        public async Task<TOutput> BuildAsync(TInput input = default(TInput))
        {
            TOutput item = default(TOutput);
            await baseSwitchDecOperateAsync(
                determineSwitch:()=>determineSwitch(input),
                regularInnerAsync:async()=> item = await regularInner.BuildAsync(input),
                switchInnerAsync:async()=> item = await switchInner.BuildAsync(input)
            );
            return item;
        }
    }
}