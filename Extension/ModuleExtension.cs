using System.Linq;
using StockCore.DomainEntity;

namespace StockCore.Extension
{
    public static class ModuleExtension
    {
        public static bool IsMonitoringActive(this ModuleDE module)
        {
            return module!=null && module.IsActive && module.Monitoring!=null && module.Monitoring.IsActive;
        }
        public static bool IsRetryActive(this ModuleDE module)
        {
            return module!=null && module.IsActive && module.Retry!=null && module.Retry.IsActive;
        }
        public static bool IsCacheActive(this ModuleDE module)
        {
            return module!=null && module.IsActive && module.Cache!=null && module.Cache.IsActive;
        }
        public static MonitoringModule OverrideConfigFromSubModuleIfAny(this MonitoringModule module,string methodName)
        {
            MonitoringModule newModule = null;
            if(module != null)
            {
                if(module.Actions != null)
                {
                    var item = module.Actions.FirstOrDefault(action=>action != null && action.Key == methodName);
                    if(item != null)
                    {
                        newModule=item.Copy();
                    }
                }
                newModule=module.Copy();
            }
            return newModule;
        }

        private static MonitoringModule Copy(this MonitoringModule module)
        {
            MonitoringModule newModule=null;
            if(module!=null)
            {
                newModule=new MonitoringModule()
                {
                    Key=module.Key,
                    IsActive=module.IsActive,
                    ShowParams=module.ShowParams,
                    ShowResult=module.ShowResult,
                    PerformanceMeasurement=module.PerformanceMeasurement,
                    ThrowException=module.ThrowException,
                    LogTrace=module.LogTrace
                };
            }
            return newModule;
        }
    }
}