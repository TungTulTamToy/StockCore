using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public interface IModule:IKeyField<string>
    {
        bool IsActive {get;set;}
        MonitoringModule Monitoring {get;set;}
        RetryModule Retry {get;set;}
        CacheModule Cache{get;set;}
        PreFilterModule PreFilter{get;set;}
        PostFilterModule PostFilter{get;set;}
    }
    public class Module:IModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
        public MonitoringModule Monitoring {get;set;}
        public RetryModule Retry {get;set;}
        public CacheModule Cache{get;set;}
        public PreFilterModule PreFilter{get;set;}
        public PostFilterModule PostFilter{get;set;}
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
    public class PreFilterModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
        public string Criteria{get;set;}
    }
    public class PostFilterModule
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
    }
}