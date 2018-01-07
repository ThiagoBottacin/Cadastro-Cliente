using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DatabaseHelper
    {
        public SqlConnection DbConnection { get; set; }

        public DatabaseHelper()
        {
            DbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
        }

        public static DatabaseHelper Create()
        {
            return new DatabaseHelper();
        }

        public void OpenConnection()
        {
            if (DbConnection.State == System.Data.ConnectionState.Closed)
            {
                DbConnection.Open();
            }
        }

        public void CloseConection()
        {
            DbConnection.Close();
        }
    }
}
