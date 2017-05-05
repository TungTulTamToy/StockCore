using MongoDB.Driver;

namespace StockCore.Wrapper
{
    public interface IReplaceOneModelBuilder
    {
        ReplaceOneModel<T> Build<T>(string filedName, string value, T item);
    }
    public class ReplaceOneModelBuilder : IReplaceOneModelBuilder
    {
        IFilterDefinitionBuilderWrapper filterBuilder;
        public ReplaceOneModelBuilder(IFilterDefinitionBuilderWrapper filterBuilder)
        {
            this.filterBuilder = filterBuilder;
        }
        public ReplaceOneModel<T> Build<T>(string filedName, string value, T item)
        {
            return new ReplaceOneModel<T>(filterBuilder.Build<T>(filedName, value),item);
        }
    }
}