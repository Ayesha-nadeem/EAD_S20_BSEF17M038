using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   internal class DBHelper:IDisposable
    {
        String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        SqlConnection conn=null;
        public DBHelper()
        {
            conn = new SqlConnection(connStr);
            conn.Open();
        }
        public int executeQuery(String sqlQuery)
        {
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            var count = comm.ExecuteNonQuery();
            return count;
        }
        public object executeScalar(String sqlQuery)
        {
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            return comm.ExecuteScalar();
        }
        public SqlDataReader executeReader(String sqlQuery)
        {
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            return comm.ExecuteReader();
        }

        public void Dispose()
        {
            if (conn!=null && conn.State==System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
