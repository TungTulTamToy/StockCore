using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using StockCore.DomainEntity;

namespace StockCore.Business.Repo.AppSetting
{
    public class DynamicGroupReader:IConfigReader<IDynamicGroup>
    {
        private static readonly object padlock = new object();
        private IConfigurationRoot configRoot;
        private Dictionary<string,IDynamicGroup> dynamicGroup;
        public DynamicGroupReader(IConfigurationRoot configRoot)
        {
            this.configRoot = configRoot;
        }
        public bool ContainsKey(string key)=>getDynamicGroup().ContainsKey(key);
        public IEnumerable<string> GetAllKeys()=>getDynamicGroup().Keys.ToList();
        public IDynamicGroup GetByKey(string key)
        {
            return getDynamicGroup()[key];
        }
        private Dictionary<string,IDynamicGroup> getDynamicGroup()
        {
            if(dynamicGroup == null)
            {
                lock(padlock)//Cause this factory is Singleton!!!   
                {
                    var configs = configRoot.GetSection("DynamicGroups").Get<List<DynamicGroup>>();
                    dynamicGroup = configs.ToDictionary(c=>$"{c.Name}",c=>(IDynamicGroup)c);   
                }  
            }
            return dynamicGroup;
        }
    }
}