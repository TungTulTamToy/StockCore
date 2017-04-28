using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using StockCore.Aop;
using StockCore.Aop.Mon;
using StockCore.DomainEntity;
using StockCore.Extension;

namespace StockCore.Helper
{
    public static class CacheHelper
    {
        public static Func<string,string,string,string> GetKeyByString()
        {
            return (moduleName,methodName,param)=>
            {
                return $"{moduleName}_{methodName}_{param}_v1";
            };
        }
    }
}