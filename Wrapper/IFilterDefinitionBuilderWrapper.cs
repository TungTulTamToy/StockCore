using MongoDB.Driver;

namespace StockCore.Wrapper
{
    public interface IFilterDefinitionBuilderWrapper
    {
        FilterDefinition<T> Build<T>(string filedName, string value);
    }
    public class FilterDefinitionBuilderWrapper : IFilterDefinitionBuilderWrapper
    {
        public FilterDefinition<T> Build<T>(string filedName, string value)
        {
            return Builders<T>.Filter.Eq(filedName, value);
        }
    }
}