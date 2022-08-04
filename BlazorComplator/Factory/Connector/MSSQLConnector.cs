using System.Data.SqlClient;

namespace BlazorComplator.Factory.Connector
{
    public class MSSQLConnector : BaseConnector
    {
        public MSSQLConnector(string connectionString) : base(connectionString)
        {
            connection = new SqlConnection(connectionString);
        }
        public override List<string> GetDatabases()
        {
            var resault = new List<string>();

            var sqlQuery = "SELECT name FROM sys.databases;";

            var reqset = ExecuteQuery("", sqlQuery);

            foreach (var row in reqset.Rows)
            {
                if (row.Data.Count > 0) resault.Add(row.Data[0].ToString());
            }

            return resault;
        }

        public override List<string> GetTables(string databaseName)
        {
            var resault = new List<string>();

            var sqlQuery = $"select TABLE_NAME from {databaseName}.INFORMATION_SCHEMA.TABLES where TABLE_TYPE='BASE TABLE'";

            var reqset = ExecuteQuery(databaseName, sqlQuery);

            foreach (var row in reqset.Rows)
            {
                if (row.Data.Count() > 0) resault.Add(row.Data[0].ToString());
            }

            return resault;
        }
    }
}
