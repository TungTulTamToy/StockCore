using Microsoft.Extensions.Logging;
using StockCore.Aop.Mon.Repo.AppSetting;
using Microsoft.Extensions.Configuration;
using StockCore.Provider;
using StockCore.Business.Repo.AppSetting;
using StockCore.DomainEntity;
using StockCore.Helper;

namespace StockCore.Factory
{
    public class ModuleConfigFactory : BaseFactory<string,IConfigReader>
    {
        private const string KEY = "ModuleGetByKey";
        private const int ID = 1008100;
        private const int PROCESSERRID = 1008101;
        private const int OUTERERRID = 1008102;
        private const int MONPROCESSERRID = 1008103;
        private const int MONOUTERERRID = 1008104;
        private readonly IConfigProvider config;
        private IConfigurationRoot configRoot;
        private IConfigReader inner;
        private static readonly object padlock = new object();
        public ModuleConfigFactory(ILogger logger,
            IConfigurationRoot configRoot,
            IConfigProvider config
            ):base(OUTERERRID,PROCESSERRID,ID,KEY,logger)
        {
            this.configRoot = configRoot;
            this.config = config;
        }
        protected override IConfigReader build(Tracer tracer,string t="")
        {
            lock(padlock)//Cause this factory is Singleton!!!   
            {
                if(inner==null)
                {
                    var module = config.MonitoringModule;
                    inner = new ModuleConfigReader(configRoot);
                    var helper = new ValidationHelper();
                    inner = new MonConfigReaderDec(
                        inner,
                        module,
                        helper.ValidateString(1008105,"Quote"),
                        MONPROCESSERRID,
                        MONOUTERERRID,
                        logger,
                        tracer
                        );  
                }
            }
            return inner;
        }
    }
}