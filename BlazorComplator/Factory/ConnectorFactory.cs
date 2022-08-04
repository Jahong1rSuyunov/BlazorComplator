using BlazorComplator.Factory.Connector;
using BlazorComplator.Factory.Interfice;

namespace BlazorComplator.Factory
{
    public class ConnectorFactory
    {
        public static IConnector GetConnector(string connoctorType, string connectionString)
        {
            IConnector resault = null;

            switch (connoctorType)
            {
                case "MSSQL":
                    resault = new MSSQLConnector(connectionString);
                    break;
                case "MySQL":
                    resault = new MySQLConnector(connectionString);
                    break;
                case "NpgSQL":
                    resault = new NpgSqlConnector(connectionString);
                    break;

            }

            return resault;
        }
    }
}
