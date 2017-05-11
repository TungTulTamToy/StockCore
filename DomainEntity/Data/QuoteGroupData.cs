using System.Collections.Generic;
using System.Linq;

namespace StockCore.DomainEntity.Data
{
    public static class QuoteGroupData
    {
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
                            "bec","cpf","bla","scb","bbl","ifs","ttw","singer","hmpro","sta",
                            "tvo","jubile","ait","m","hotpot","bdms","true","rs","ba"},
                        Order = 1,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Check",
                        Quotes = new[]{"rs"},
                        Order = 2,
                        IsDefault = false
                        }
                };
            }
        }
        public static IEnumerable<QuoteGroup> DataV2
        {
            get{
                return new List<QuoteGroup>(){
                    new QuoteGroup(){
                        Name = "All",
                        Quotes = new[]{
                            "work","ptt","earth","banpu","gunkul","ivl","ptl","aj","vnt","bcp",
                            "pttep","pttgc","scc","kce","hana","delta","advanc","dtac","jas","bland",
                            "sc","lh","siri","prin","cpn","smit","mcs","snc","bjchi","bwg",
                            "bec","cpf","bla","scb","bbl","ifs","ttw","singer","hmpro","sta",
                            "tvo","ait","jubile","m","hotpot","bdms","true","rs","intuch","cpall",
                            "makro","grammy","mcot","top","aav","nok","kbank","bay","samart","thcom",
                            "gfpt","lpn","spali","robins","egco","glow","ratch","ktc","mfec","aeonts",
                            "tkn","oishi","bh","ntv","kcar","stpi","gpsc","ba","thai","centel","aot"},
                        Order = 1,
                        IsDefault = true
                    },
                    new QuoteGroup(){
                        Name = "Home",
                        Quotes = new[]{"sc","lh","siri","prin","bland","hmpro","lpn","spali"},
                        Order = 6,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Industry",
                        Quotes = new[]{"smit","mcs","snc","bjchi","bwg","ttw","singer","stpi"},
                        Order = 7,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Finance",
                        Quotes = new[]{"bbl","scb","kbank","ifs","bla","bay","ktc","aeonts","kcar"},
                        Order = 8,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Mine",
                        Quotes = new[]{"banpu","earth"},
                        Order = 9,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Petro",
                        Quotes = new[]{"ivl","ptl","aj","pttgc","vnt"},
                        Order = 10,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Oil",
                        Quotes = new[]{"pttep","bcp","top"},
                        Order = 11,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Blueship",
                        Quotes = new[]{"ptt","scc","advanc"},
                        Order = 12,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Convenience Store",
                        Quotes = new[]{"cpn","robins"},
                        Order = 13,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Commodity",
                        Quotes = new[]{"sta","tvo"},
                        Order = 14,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Food",
                        Quotes = new[]{"m","hotpot","tkn","oishi"},
                        Order = 15,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "IT",
                        Quotes = new[]{"ait","mfec"},
                        Order = 16,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Hospital",
                        Quotes = new[]{"bdms","bh","ntv"},
                        Order = 17,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Commu",
                        Quotes = new[]{"advanc","dtac","true","jas","intuch","samart"},
                        Order = 18,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "AirLine",
                        Quotes = new[]{"aav","nok","ba","thai"},
                        Order = 18,
                        IsDefault = false
                    },
                    new QuoteGroup(){
                        Name = "Entertain",
                        Quotes = new[]{"work","bec","rs","grammy","mcot"},
                        Order = 19,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Electronic",
                        Quotes = new[]{"delta","hana","kce"},
                        Order = 20,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Feed Farm Food",
                        Quotes = new[]{"cpf","gfpt"},
                        Order = 21,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Electricity",
                        Quotes = new[]{"egco","glow","ratch","gpsc"},
                        Order = 22,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "PTT",
                        Quotes = new[]{"ptt","pttgc","pttep"},
                        Order = 23,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "CP",
                        Quotes = new[]{"cpf","makro","cpall"},
                        Order = 24,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Hotel",
                        Quotes = new[]{"centel"},
                        Order = 25,
                        IsDefault = false
                        },
                    new QuoteGroup(){
                        Name = "Other",
                        Quotes = new[]{"aot","jubile"},
                        Order = 26,
                        IsDefault = false
                        }
                };
            }
        }
        public static IEnumerable<QuoteGroup> TestSwapGroup1
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
                        Quotes = new[]{"work","bbl","scb","thcom"},
                        Order = 2,
                        IsDefault = false
                        }
                };
            }
        }
        public static IEnumerable<QuoteGroup> TestSwapGroup2
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
    }
}