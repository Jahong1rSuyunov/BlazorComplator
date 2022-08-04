using BlazorComplator.Factory.Resault;

namespace BlazorComplator.Factory.Interfice
{
    public interface IConnector
    {
        public List<string> GetDatabases();

        public List<string> GetTables(string databaseName);

        public ResaultSet ExecuteQuery(string databaseName, string query);
    }
}
