using System;
namespace StockCore.Helper
{
    public static class CacheHelper
    {
        public static Func<string,string,string,string> GetKeyByString()
        {
            return (moduleName,methodName,param)=>$"{moduleName}_{methodName}_{param}_v1";
        }
    }
}