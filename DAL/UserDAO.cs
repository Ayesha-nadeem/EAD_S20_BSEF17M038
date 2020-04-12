using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class UserDAO
    {
        public static int Save(UserDTO dto)
        {
            String sqlQuery = "";
  
            sqlQuery = String.Format("INSERT INTO user(name, login,password) VALUES('{0}','{1}','{2}')",
                dto.Name, dto.Login, dto.Password);
            using (DBHelper helper = new DBHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
        }

        public static UserDTO ValidateUser(String pLogin, String pPassword)
        {
            var query = String.Format("Select * from user Where login='{0}' and password='{1}'", pLogin, pPassword);

            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);

                UserDTO dto = null;

                if (reader.Read())
                {
                    dto = FillDTO(reader);
                }

                return dto;
            }
        }

        private static UserDTO FillDTO(MySqlDataReader reader)
        {
            var dto = new UserDTO();
            dto.UserID = reader.GetInt32(0);
            dto.Name = reader.GetString(1);
            dto.Login = reader.GetString(2);
            dto.Password = reader.GetString(3);
            return dto;
        }
    }
}