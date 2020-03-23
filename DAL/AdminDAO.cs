using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class adminDAO
    {
        public static int getAdminId(String login,String pass)
        {
            string query = "Select * from dbo.Admin where AdminLogin='" + login + "' and AdminPassword='"+pass+"'";
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.executeReader(query);

                if (reader.Read())
                {
                    return (int)reader["AdminID"];
                }
            }
            return 0;
        }
    }
}
