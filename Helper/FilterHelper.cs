using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace StockCore.Helper
{
    public static class FilterHelper
    {
        public static Func<string,bool> FilterActiveOnly(string activeOnly)
        {
            return (value)=>(string.IsNullOrEmpty(activeOnly) || value==activeOnly);
        }
        public static Func<string,bool> FilterNotActiveOnly(string notActivateOnly)
        {
            string[] items=null;
            if(!string.IsNullOrEmpty(notActivateOnly))
            {
                items = notActivateOnly.Split(new []{","},StringSplitOptions.RemoveEmptyEntries);
            }
            return (value)=>(items==null || !items.Any() || !items.Any(value.Contains));
        }
    }
}