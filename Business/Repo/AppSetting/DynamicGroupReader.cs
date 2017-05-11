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
        public IDynamicGroup GetByKey(string key)
        {
            lock(padlock)//Cause this factory is Singleton!!!   
            {
                if(dynamicGroup == null)
                {
                    var configs = configRoot.GetSection("DynamicGroups").Get<List<DynamicGroup>>();
                    dynamicGroup = configs.ToDictionary(c=>$"{c.Name}",c=>(IDynamicGroup)c);   
                }       
            }  
            return dynamicGroup[key];
        }
    }
}