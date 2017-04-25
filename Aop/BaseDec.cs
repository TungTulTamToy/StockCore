using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockCore.DomainEntity;
using StockCore.ErrorException;
using StockCore.Extension;

namespace StockCore.Aop
{
    public class BaseDec
    {
        protected readonly ILogger logger;
        protected readonly string keyName;
        protected readonly int outerErrID;
        public BaseDec(int outerErrID,string keyName,ILogger logger)
        {
            this.logger = logger;
            this.keyName = keyName;
            this.outerErrID = outerErrID;
        }
        protected async Task operateAsync(
            Tracer tracer,
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
            Func<Task> postProcessAsync=null
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
                    if(processFail!=null)
                    {
                        processFail(ex);
                    }
                    else if(processFailAsync!=null)
                    {
                        await processFailAsync(ex);
                    }
                }
                finally
                {
                    await operateAsync(postProcess,postProcessAsync);    
                }
            }
            catch(Exception e)
            {
                baseProcessFail(e,outerErrID,false,tracer);
            }
        }
        protected void operate(
            Tracer tracer,
            Action preProcess=null,   
            Func<bool> validate=null,
            Action process=null,
            Action invalidProcess=null,
            Action<Exception> processFail=null,
            Action postProcess=null
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
                baseProcessFail(e,outerErrID,false,tracer);
            }
        }
        protected void baseProcessFail(Exception ex,int processErrorID,bool isThrow,Tracer tracer)
        {
            if(ex is IStockCoreException)
            {
                var e = (IStockCoreException)ex;
                if(!e.IsLogged)
                {
                    logger.TraceError(keyName,e.ID,ex:ex);
                    e.IsLogged=true;
                }
                if(isThrow)
                {
                    throw (Exception)e;
                }
            }
            else
            {
                logger.TraceError(keyName,processErrorID,ex:ex);          
                var e = new StockCoreException(processErrorID,ex,tracer);
                if(isThrow)
                {
                    throw e;
                }
            }
        }
        private void operate(Action process)
        {
            if(process!=null)
            {
                process();
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