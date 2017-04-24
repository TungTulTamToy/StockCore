using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using StockCore.DomainEntity;

namespace StockCore.Business.Repo.AppSetting
{
    public class ModuleConfigReader:IConfigReader
    {
        private static readonly object padlock = new object();
        private const string MAPKEY = "Aop";
        private IConfigurationRoot configRoot;
        private Dictionary<string,ModuleDE> modules;
        public ModuleConfigReader(IConfigurationRoot configRoot)
        {
            this.configRoot = configRoot;
        }
        public ModuleDE GetByKey(string key)
        {
            lock(padlock)//Cause this factory is Singleton!!!   
            {
                if(modules == null)
                {
                    var configs = configRoot.GetSection("Modules").Get<List<ModuleDE>>();
                    modules = configs.ToDictionary(c=>$"{c.Key}",c=>c);   
                }       
            }  
            return modules[key];
        }
    }
}