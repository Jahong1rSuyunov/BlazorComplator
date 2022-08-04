using BlazorComplator.Factory.Interfice;
using BlazorComplator.Factory.Resault;
using System.Data;

namespace BlazorComplator.Factory.Connector
{
    public abstract class BaseConnector : IConnector
    {
        protected IDbConnection connection = null;
        protected string? connectionString;

        public BaseConnector(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public virtual ResaultSet ExecuteQuery(string databaseName, string query)
        {
            connection.ConnectionString = connectionString + $"database={databaseName}";
            var resault = new ResaultSet();

            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                connection.Open();

                var reader = cmd.ExecuteReader();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var colName = reader.GetName(i);
                    resault.Columns.Add(colName);
                }

                while (reader.Read())
                {
                    var row = new Row();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var data = reader[i];
                        row.Data.Add(data);
                    }

                    resault.Rows.Add(row);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (connection.State != ConnectionState.Closed) connection.Close();
            }
            return resault;
        }

        public abstract List<string> GetDatabases();

        public abstract List<string> GetTables(string databaseName);
    }
}
