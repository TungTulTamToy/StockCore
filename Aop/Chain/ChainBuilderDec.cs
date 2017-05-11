using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using System;
using StockCore.Business.Builder;

namespace StockCore.Aop.Chain
{
    public class ChainBuilderDec<TInput,TOutput> : BaseChainDec<IEnumerable<TOutput>>,IBuilder<TInput,IEnumerable<TOutput>> where TInput:class
    {
        private readonly IBuilder<TInput,IEnumerable<TOutput>> inner; 
        private readonly Func<TInput,IEnumerable<TOutput>,IEnumerable<TOutput>> chain;
        public ChainBuilderDec(
            IBuilder<TInput,IEnumerable<TOutput>> inner,
            Func<TInput,IEnumerable<TOutput>,IEnumerable<TOutput>> chain,
            IKeyModule module,            
            int processErrorID,
            int outerErrorID,
            ILogger logger
            ):base(processErrorID:processErrorID,outerErrorID:outerErrorID,module:module,logger:logger)
        {
            this.inner = inner;
            this.chain = chain;
        }
        public IEnumerable<TOutput> Build(TInput item = default(TInput))
        {
            var returnItems = baseChainDecBuild(
                innerProcess:()=> inner.Build(item),             
                chain:(postItems)=>chain(item,postItems)
            );
            return returnItems;
        }
        public async Task<IEnumerable<TOutput>> BuildAsync(TInput item = default(TInput))
        {
            var returnItems = await baseChainDecBuildAsync(
                innerProcessAsync:async ()=> await inner.BuildAsync(item),             
                chain:(postItems)=>chain(item,postItems)
            );
            return returnItems;
        }
    }
}