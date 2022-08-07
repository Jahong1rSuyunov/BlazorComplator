using BlazorComplator.AppDbContext;
using BlazorComplator.Models;

namespace BlazorComplator.Services
{
    public class QueryService : IQueryService
    {
        private readonly QueryDbContext context;

        public QueryService(QueryDbContext context)
        {
            this.context = context;
        }

        public bool CheckName(string name, string ConnectorType)
        {
            int resault = context.Queries.Where(x => x.QueryName.Equals(name) && x.ConnectorType.Equals(ConnectorType)).Count();
            if(resault == 0) return true;
            return false;
        }

        public Query Create(Query query)
        {
            var obj = context.Queries.Add(query);
            context.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Query query)
        {
            context.Queries.Remove(query);
            context.SaveChanges();
        }

        public List<Query> GetQueries(string ConnectorType)
        {
            return context.Queries.Where(x => x.ConnectorType == ConnectorType).ToList();
        }

        public Query GetQuery(int id)
        {
            var obj = context.Queries.FirstOrDefault(x => x.QueryId == id);
            return obj;
        }

        public void UpdateQuery(Query query)
        {
            context.Queries.Update(query);
            context.SaveChanges();
        }
    }
}
