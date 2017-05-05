using MongoDB.Driver;

namespace StockCore.Wrapper
{
    public interface IDeleteOneModelBuilder
    {
        DeleteOneModel<T> Build<T>(string filedName, string value);
    }
    public class DeleteOneModelBuilder : IDeleteOneModelBuilder
    {
        IFilterDefinitionBuilderWrapper filterBuilder;
        public DeleteOneModelBuilder(IFilterDefinitionBuilderWrapper filterBuilder)
        {
            this.filterBuilder = filterBuilder;
        }
        public DeleteOneModel<T> Build<T>(string filedName, string value)
        {
            return new DeleteOneModel<T>(filterBuilder.Build<T>(filedName, value));
        }
    }
}