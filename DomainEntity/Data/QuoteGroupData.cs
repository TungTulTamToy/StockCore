using System.Collections.Generic;

namespace StockCore.DomainEntity.Data
{
    public static class QuoteGroupData
    {
        public static IEnumerable<QuoteGroupDE> Sample1
        {
            get{
                return new List<QuoteGroupDE>(){
                    new QuoteGroupDE(){
                        Name = "Test01",
                        Quotes = new[]{"ptt","bec"},
                        Order = 1,
                        IsDefault = true
                        },
                    new QuoteGroupDE(){
                        Name = "Test02",
                        Quotes = new[]{"work","bbl","scb"},
                        Order = 2,
                        IsDefault = false
                        }
                };
            }
        }
        public static IEnumerable<QuoteGroupDE> Sample2
        {
            get{
                return new List<QuoteGroupDE>(){
                    new QuoteGroupDE(){
                        Name = "Test02",
                        Quotes = new[]{"ptt","bec","work"},
                        Order = 1,
                        IsDefault = true
                        },
                    new QuoteGroupDE(){
                        Name = "Test03",
                        Quotes = new[]{"smit"},
                        Order = 2,
                        IsDefault = false
                        }
                };
            }
        }
        public static IEnumerable<QuoteGroupDE> PrepareData
        {
            get{
                return new List<QuoteGroupDE>(){
                    new QuoteGroupDE(){
                        Name = "Ready",
                        Quotes = new[]{"work","ptt","earth","banpu","gunkul"},
                        Order = 1,
                        IsDefault = false
                        },
                    new QuoteGroupDE(){
                        Name = "Check",
                        Quotes = new[]{"ptt"},
                        Order = 2,
                        IsDefault = false
                        }
                };
            }
        }
    }
}