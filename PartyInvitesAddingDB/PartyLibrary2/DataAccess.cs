using Dapper;
using System.Data.SqlClient;

namespace PartyLibrary2
{
    public class DataAccess
    {
        public static string GetConnectionString()
        {
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PartyDB2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                return conn.Execute(sql, data);
            }
        }
    }
}
