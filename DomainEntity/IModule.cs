using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public interface IKeyModule:IKeyField<string>
    {
        bool IsActive {get;set;} 
    }
    public interface IModule:IKeyModule
    {
        MonitoringModule Monitoring {get;set;}
        RetryModule Retry {get;set;}
        CacheModule Cache{get;set;}
        PreFilterModule PreFilter{get;set;}
        ChainModule Chain{get;set;}
        SwitchModule Switch{get;set;}
    }
    public class Module:IModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
        public MonitoringModule Monitoring {get;set;}
        public RetryModule Retry {get;set;}
        public CacheModule Cache{get;set;}
        public PreFilterModule PreFilter{get;set;}
        public ChainModule Chain{get;set;}
        public SwitchModule Switch{get;set;}
    }
    public class MonitoringModule:IKeyModule
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
    public class RetryModule:IKeyModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
    }
    public class CacheModule:IKeyModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
        public int MinuteToExpire{get;set;}
    }
    public class PreFilterModule:IKeyModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
        public string Criteria{get;set;}
    }
    public class ChainModule:IKeyModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
    }
    public class SwitchModule:IKeyModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
    }
}