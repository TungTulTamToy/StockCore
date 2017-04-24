using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public class ModuleDE
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
        public Monitoring Monitoring {get;set;}
        public Retry Retry {get;set;}
    }
    public class Monitoring
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
        public bool ShowParams {get;set;}
        public bool ShowResult {get;set;}
        public bool PerformanceMeasurement{get;set;}
        public bool ThrowException{get;set;}
        public bool LogTrace{get;set;}
        public List<Monitoring> Actions{get;set;}
    }
    public class Retry
    {
        public string Key{get;set;}
        public bool IsActive {get;set;}
    }
}