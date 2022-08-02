using System.Data;

namespace BlazorComplator.Services
{
    public interface IManagmentService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConString"></param>
        /// <returns></returns>
        List<string> GetDbList(string conString);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConString"></param>
        /// <returns></returns>
        List<string> GetDbTables(string conString);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConString"></param>
        /// <param name="DbName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        DataTable RunQuery(string conString, string dbName, string query);
    }
}
