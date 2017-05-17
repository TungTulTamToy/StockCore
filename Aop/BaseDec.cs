using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.Aop.Mon;
using StockCore.Extension;

namespace StockCore.Aop
{
    public class BaseDec
    {
        protected async Task baseDecOperateAsync(
            Action preProcess=null,   
            Func<Task> preProcessAsync=null,         
            Func<bool> determinePath=null,
            Func<Task<bool>> determinePathAsync=null,
            Action processMainPath=null,
            Func<Task> processMainPathAsync=null,
            Action processAlternativePath=null,
            Func<Task> processAlternativePathAsync=null,
            Action<Exception> catchBlockProcess=null,
            Func<Exception,Task> catchBlockProcessAsync=null,
            Action finallyBlockProcess=null,
            Func<Task> finallyBlockProcessAsync=null,
            Action<Exception> unexpectedCatchBlockProcess=null,
            Func<Exception,Task> unexpectedCatchBlockProcessAsync=null
            )
        {
            try
            {
                try
                {
                    await operateAsync(preProcess,preProcessAsync);
                    if(await buildAsync(determinePath,determinePathAsync,true))
                    {
                        await operateAsync(processMainPath,processMainPathAsync);
                    }
                    else
                    {
                        await operateAsync(processAlternativePath,processAlternativePathAsync);
                    }
                }
                catch(Exception ex)
                {
                    await operateFailAsync(ex,catchBlockProcess,catchBlockProcessAsync);    
                }
                finally
                {
                    await operateAsync(finallyBlockProcess,finallyBlockProcessAsync);    
                }
            }
            catch(Exception e)
            {
                await operateFailAsync(e,unexpectedCatchBlockProcess,unexpectedCatchBlockProcessAsync);    
            }
        }
        protected void baseDecOperate(
            Action preProcess=null,   
            Func<bool> determinePath=null,
            Action processMainPath=null,
            Action processAlternativePath=null,
            Action<Exception> catchBlockProcess=null,
            Action finallyBlockProcess=null,
            Action<Exception> unexpectedCatchBlockProcess=null
            )
        {
            try
            {
                try
                {
                    operate(preProcess);
                    var isMainPath = true;
                    if(determinePath!=null)
                    {
                        isMainPath = determinePath();
                    }
                    if(isMainPath)
                    {
                        operate(processMainPath);
                    }
                    else
                    {
                        operate(processAlternativePath);
                    }
                }
                catch(Exception ex)
                {
                    if(catchBlockProcess!=null)
                    {
                        catchBlockProcess(ex);
                    }
                }
                finally
                {
                    operate(finallyBlockProcess);    
                }
            }
            catch(Exception e)
            {
                unexpectedCatchBlockProcess(e);
            }
        }
        private void operate(Action process)
        {
            if(process!=null)
            {
                process();
            }
        }
        private async Task operateFailAsync(Exception ex,Action<Exception> processFail, Func<Exception,Task> processFailAsync)
        {
            if(processFail!=null)
            {
                processFail(ex);
            }
            else if(processFailAsync!=null)
            {
                await processFailAsync(ex);
            }
        }
        private async Task operateAsync(Action process, Func<Task> processAsync)
        {
            if(process!=null)
            {
                process();
            }
            else if(processAsync!=null)
            {
                await processAsync();
            }
        }
        private async Task<bool> buildAsync(Func<bool> process, Func<Task<bool>> processAsync, bool init)
        {
            if(process!=null)
            {
                init = process();
            }
            else if(processAsync!=null)
            {
                init =  await processAsync();
            }
            return init;
        }
    }
}