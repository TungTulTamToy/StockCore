using System.Linq.Expressions;
using Newtonsoft.Json;

namespace StockCore.Helper
{
    public static class JsonHelper
    {
        public static string SerializeObject<T>(T item)
        {
            var paramsValue = "";
            if(item!=null && !(item is Expression))
            {
                paramsValue = JsonConvert.SerializeObject(item);
            }
            return paramsValue;
        }
    }
}