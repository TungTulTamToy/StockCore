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
                        Quotes = new[]{"A","B"}
                        },
                    new QuoteGroupDE(){
                        Name = "Test02",
                        Quotes = new[]{"C","D","E"}
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
                        Quotes = new[]{"A","B","C"}
                        },
                    new QuoteGroupDE(){
                        Name = "Test03",
                        Quotes = new[]{"Z"}
                        }
                };
            }
        }
    }
}