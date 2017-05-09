using System;
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
            return (value)=>(string.IsNullOrEmpty(notActivateOnly) || value!=notActivateOnly);
        }
    }
}