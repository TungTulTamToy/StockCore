using System;
using System.Threading.Tasks;

namespace StockCore.Aop
{
    public class BaseDec
    {
        protected async Task baseDecOperateAsync(
            Action preProcess=null,   
            Func<Task> preProcessAsync=null,         
            Func<bool> validate=null,
            Func<Task<bool>> validateAsync=null,
            Action process=null,
            Func<Task> processAsync=null,
            Action invalidProcess=null,
            Func<Task> invalidProcessAsync=null,
            Action<Exception> processFail=null,
            Func<Exception,Task> processFailAsync=null,
            Action postProcess=null,
            Func<Task> postProcessAsync=null,
            Action<Exception> finalProcessFail=null,
            Func<Exception,Task> finalProcessFailAsync=null
            )
        {
            try
            {
                try
                {
                    await operateAsync(preProcess,preProcessAsync);
                    if(await buildAsync(validate,validateAsync,true))
                    {
                        await operateAsync(process,processAsync);
                    }
                    else
                    {
                        await operateAsync(invalidProcess,invalidProcessAsync);
                    }
                }
                catch(Exception ex)
                {
                    await operateFailAsync(ex,processFail,processFailAsync);    
                }
                finally
                {
                    await operateAsync(postProcess,postProcessAsync);    
                }
            }
            catch(Exception e)
            {
                await operateFailAsync(e,finalProcessFail,finalProcessFailAsync);    
            }
        }
        protected void baseDecOperate(
            Action preProcess=null,   
            Func<bool> validate=null,
            Action process=null,
            Action invalidProcess=null,
            Action<Exception> processFail=null,
            Action postProcess=null,
            Action<Exception> finalProcessFail=null
            )
        {
            try
            {
                try
                {
                    operate(preProcess);
                    var validateResult = true;
                    if(validate!=null)
                    {
                        validateResult = validate();
                    }
                    if(validateResult)
                    {
                        operate(process);
                    }
                    else
                    {
                        operate(invalidProcess);
                    }
                }
                catch(Exception ex)
                {
                    if(processFail!=null)
                    {
                        processFail(ex);
                    }
                }
                finally
                {
                    operate(postProcess);    
                }
            }
            catch(Exception e)
            {
                finalProcessFail(e);
            }
        }
        private void operate(Action process)
        {
            if(process!=null)
            {
                process();
            }
        }
        private async Task operateFailAsync(Exception ex,Action<Exception> finalProcessFail, Func<Exception,Task> finalProcessFailAsync)
        {
            if(finalProcessFail!=null)
            {
                finalProcessFail(ex);
            }
            else if(finalProcessFailAsync!=null)
            {
                await finalProcessFailAsync(ex);
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