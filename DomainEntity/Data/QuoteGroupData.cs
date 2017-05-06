using System.Collections.Generic;

namespace StockCore.DomainEntity.Data
{
    public static class QuoteGroupData
    {
        public static IEnumerable<QuoteGroup> Sample1
        {
            get{
                return new List<QuoteGroup>(){
                    new QuoteGroup(){
                        Name = "Test01",
                        Quotes = new[]{"ptt","bec"},
                        Order = 1,
                        IsDefault = true
                        },
                    new QuoteGroup(){
                        Name = "Test02",
                        Quotes = new[]{"work","bbl","scb"},
                        Order = 2,
                        IsDefault = false
                        }
                };
            }
        }
        public static IEnumerable<QuoteGroup> Sample2
        {
            get{
                return new List<QuoteGroup>(){
                    new QuoteGroup(){
                        Name = "Test02",
                        Quotes = new[]{"ptt","bec","work"},
                        Order = 1,
                        IsDefault = true
                        },
                    new QuoteGroup(){
                        Name = "Test03",
                        Quotes = new[]{"smit"},
                        Order = 2,
                        IsDefault = false
                        }
                };
            }
        }
        public static IEnumerable<QuoteGroup> PrepareData
        {
            get{
                return new List<QuoteGroup>(){
                    new QuoteGroup(){
                        Name = "Ready",
                        Quotes = new[]{
                            "work","ptt","earth","banpu","gunkul","ivl","ptl","aj","vnt","bcp",
                            "pttep","pttgc","scc","kce","hana","delta","advanc","dtac","jas","bland",
                            "sc","lh","siri","prin","cpn","smit","mcs","snc","bjchi","bwg",
                            "bec"},
                        Order = 1,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Check",
                        Quotes = new[]{""},
                        Order = 2,
                        IsDefault = false
                        }
                };
            }
        }
    }
}