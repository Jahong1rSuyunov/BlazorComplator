using BlazorComplator.Models;

namespace BlazorComplator.Services
{
    public interface IQueryService
    {
        public List<Query> GetQueries(string ConnectorType);
        public Query GetQuery(int id);
        public void Delete(Query query);
        public void UpdateQuery(Query query);
        public Query Create(Query query);
        public bool CheckName(string name, string ConnectorType);


    }
}
