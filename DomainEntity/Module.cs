using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public class Module:IKeyField<string>
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
        public MonitoringModule Monitoring {get;set;}
        public RetryModule Retry {get;set;}
        public CacheModule Cache{get;set;}
        public FilterModule Filter{get;set;}
    }
    public class MonitoringModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
        public bool ShowParams {get;set;}
        public bool ShowResult {get;set;}
        public bool ShowCount {get;set;}
        public bool PerformanceMeasurement{get;set;}
        public bool ThrowException{get;set;}
        public bool LogTrace{get;set;}
        public List<MonitoringModule> Actions{get;set;}
    }
    public class RetryModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
    }
    public class CacheModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
        public int MinuteToExpire{get;set;}
    }
    public class FilterModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
        public string Criteria{get;set;}
    }
}