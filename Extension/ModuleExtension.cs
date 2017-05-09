using System.Linq;
using StockCore.DomainEntity;

namespace StockCore.Extension
{
    public static class ModuleExtension
    {
        public static bool IsMonitoringActive(this Module module)=>module!=null && module.IsActive && module.Monitoring!=null && module.Monitoring.IsActive;
        public static bool IsRetryActive(this Module module)=>module!=null && module.IsActive && module.Retry!=null && module.Retry.IsActive;
        public static bool IsCacheActive(this Module module)=>module!=null && module.IsActive && module.Cache!=null && module.Cache.IsActive;
        public static bool IsPreFilterActive(this Module module)=>module!=null && module.IsActive && module.PreFilter!=null && module.PreFilter.IsActive;
        public static bool IsPostFilterActive(this Module module)=>module!=null && module.IsActive && module.PostFilter!=null && module.PostFilter.IsActive;
        public static MonitoringModule OverrideConfigFromSubModuleIfAny(this MonitoringModule module,string methodName)
        {
            if(module != null && module.Actions != null)
            {
                var item = module.Actions.FirstOrDefault(action=>action != null && action.Key == methodName);
                if(item != null)
                {
                    var newModule=item.Copy(module.Key);
                    return newModule;
                }
            }
            return module;
        }
        private static MonitoringModule Copy(this MonitoringModule module,string parentModuleKey)
        {
            MonitoringModule newModule=null;
            if(module!=null)
            {
                newModule=new MonitoringModule()
                {
                    Key=$"{parentModuleKey}.Sub",
                    IsActive=module.IsActive,
                    ShowParams=module.ShowParams,
                    ShowResult=module.ShowResult,
                    ShowCount=module.ShowCount,
                    PerformanceMeasurement=module.PerformanceMeasurement,
                    ThrowException=module.ThrowException,
                    LogTrace=module.LogTrace
                };
            }
            return newModule;
        }
    }
}