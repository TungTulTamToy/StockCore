using System.Collections.Generic;
using System.Linq;
using System;
using StockCore.DomainEntity;
using StockCore.Business.Repo.AppSetting;

namespace StockCore.Helper
{
    public static class QuoteGroupHelper
    {
        public static Func<string,bool> IsDynamicGroup(IConfigReader<IDynamicGroup> dynamicGroup)=>(groupName)=>!dynamicGroup.ContainsKey(groupName);
        public static Func<string,IEnumerable<QuoteGroup>,IEnumerable<QuoteGroup>> CombineGroup(IConfigReader<IDynamicGroup> dynamicGroup)
        {
            return (input, staticGroups)=>
            {
                var dynamicGroups = getDynamicGroups(dynamicGroup);
                var allGroups = combineGroups(staticGroups, dynamicGroups);
                return allGroups;
            };
        }
        private static List<QuoteGroup> combineGroups(IEnumerable<QuoteGroup> staticGroups, List<QuoteGroup> dynamicGroups)
        {
            var allGroups = new List<QuoteGroup>();
            if (staticGroups != null && staticGroups.Any())
            {
                var count = 0;
                foreach (var staticGroup in staticGroups)
                {
                    allGroups.Add(staticGroup);
                    if (count == 0)
                    {
                        allGroups.AddRange(dynamicGroups);
                    }
                    count++;
                }
            }
            else
            {
                allGroups = dynamicGroups;
            }
            return allGroups;
        }
        private static List<QuoteGroup> getDynamicGroups(IConfigReader<IDynamicGroup> dynamicGroup)
        {
            List<QuoteGroup> dynamicGroups = new List<QuoteGroup>();
            var dynamicGroupNames = dynamicGroup.GetAllKeys();
            foreach (var dynamicGroupName in dynamicGroupNames)
            {
                dynamicGroups.Add(new QuoteGroup()
                {
                    Name = dynamicGroupName
                });
            }
            return dynamicGroups;
        }
    }
}