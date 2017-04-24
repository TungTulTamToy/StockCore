using System;
using System.Threading.Tasks;

namespace StockCore.Wrapper
{
    public interface IHttpClientWrapper:IDisposable
    {
        Task<string> GetStringAsync(string requestUri);
    }
}