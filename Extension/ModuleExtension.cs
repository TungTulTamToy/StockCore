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
    }
}