using System.Data;
using System.Data.SqlClient;

namespace BlazorComplator.Services
{
    public class ManagmentService : IManagmentService
    {
        public List<string> GetDbList(string conString)
        {
            List<string> list = new List<string>();
            string query = "SELECT name FROM sys.databases;";
            var con = new SqlConnection(conString);

            try
            {
                con.Open();
                var cmd = new SqlCommand(query, con);
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        list.Add(dr[i].ToString());
                    }
                }

            }
            catch (SqlException)
            {

            }
            finally
            {
                if (con.State != ConnectionState.Closed) con.Close();
            }
            return list;
        }

        public List<string> GetDbTables(string conString)
        {
            List<string> dblist = GetDbList(conString);
            List<string> dbtable = new List<string>();
            foreach (var item in dblist)
            {
                string query = $"select TABLE_NAME from {item}.INFORMATION_SCHEMA.TABLES where TABLE_TYPE='BASE TABLE'";
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            string tablelist = item;
                            using (IDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        tablelist += "|" + dr[i].ToString();
                                    }
                                }
                            }
                            dbtable.Add(tablelist);
                        }
                        con.Close();
                    }
                }
                catch (Exception)
                {

                }
            }
            return dbtable;
        }

        public DataTable RunQuery(string conString, string dbName, string query)
        {
            DataTable dt = new DataTable();
            List<string> dblist = GetDbList(conString);

            //var conString = $"Data Source={Server.ServerName}; Initial Catalog={DbName}; Integrated Security=True";

            var con = new SqlConnection(conString + $"Initial Catalog={dbName};");

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception)
            {

            }
            finally
            {
                if (con.State != ConnectionState.Closed) con.Close();
            }
            return dt;
        }
    }
}
