using System.Collections.Generic;

namespace StockCore.DomainEntity
{
    public interface IDynamicGroup
    {
        string Name{get;set;}
        bool IsActive {get;set;}
        string ReferenceGroup {get;set;}
        string Criteria {get;set;}
    }
    public class DynamicGroup:IDynamicGroup
    {
        public string Name{get;set;}
        public bool IsActive {get;set;}
        public string ReferenceGroup {get;set;}
        public string Criteria {get;set;}
    }
}