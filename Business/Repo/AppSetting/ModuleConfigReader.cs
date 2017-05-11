using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using StockCore.DomainEntity;

namespace StockCore.Business.Repo.AppSetting
{
    public class ModuleConfigReader:IConfigReader<IModule>
    {
        private static readonly object padlock = new object();
        private IConfigurationRoot configRoot;
        private Dictionary<string,IModule> modules;
        public ModuleConfigReader(IConfigurationRoot configRoot)
        {
            this.configRoot = configRoot;
        }
        public bool ContainsKey(string key)=>getModule().ContainsKey(key);
        public IEnumerable<string> GetAllKeys()=>getModule().Keys.ToList();
        public IModule GetByKey(string key)
        {
            return getModule()[key];
        }
        private Dictionary<string,IModule> getModule()
        {
            if(modules == null)
            {
                lock(padlock)//Cause this factory is Singleton!!!   
                {
                    var configs = configRoot.GetSection("Modules").Get<List<Module>>();
                    modules = configs.ToDictionary(c=>$"{c.Key}",c=>(IModule)c);   
                }       
            }  
            return modules;
        }
    }
}