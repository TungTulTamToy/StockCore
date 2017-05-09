using System.Collections.Generic;
using System.Linq;
using static StockCore.DomainEntity.Enum.GroupCategory;

namespace StockCore.DomainEntity.Data
{
    public static class DynamicQuoteGroupData
    {
        public static IEnumerable<IQuoteGroup> DataV2
        {
            get{
                return new List<IQuoteGroup>(){
                    new DynamicQuoteGroup((stock) => stock.MovingAverage.Hist > 0 && stock.PriceCal.Any(p=>p.Name=="6M" && p.DiffAvg > 5)){
                        Name = "Buy",
                        IsDefault = false,
                        Category = Category.Dynamic
                        },
                    new DynamicQuoteGroup((stock) => stock.MovingAverage.Hist < 0 && stock.PriceCal.Any(p=>p.Name=="6M" && p.DiffAvg < 5)){
                        Name = "Sell",
                        IsDefault = false,
                        Category = Category.Dynamic
                        }
                };
            }
        }
    }
}