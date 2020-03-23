using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Entity;

namespace DAL
{
    public static class UsersDAO
    {
        public static int save(usersDTO dto)
        {
            String sqlQuery = "";
            int c = 0,h=0,ch=0;
            if(dto.IsCricket==true)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
            if (dto.Hockey == true)
            {
                h = 1;
            }
            else
            {
                h = 0;
            }
            if (dto.Chess == true)
            {
                ch = 1;
            }
            else
            {
                ch = 0;
            }
            sqlQuery = "insert into dbo.Users(Name,Login,Password,Gender,Address,Age,NIC,DOB,IsCricket,Hockey,Chess,ImageName,CreatedOn,Email) values('"+dto.Name+"','"+dto.Login+ "','" +dto.Password+ "','" +dto.Gender+"','" +dto.Address+ "'," +dto.Age+ ",'" +dto.NIC+ "','" +dto.DOB+ "'," +c+ "," +h+ "," +ch+ ",'" +dto.ImageName+ "','" + dto.CreatedOn+"','"+dto.Email+"')";
           using(DBHelper helper=new DBHelper())
            {
                return helper.executeQuery(sqlQuery);
            }
          
        }
        public static int update(usersDTO dto)
        {
            String sqlQuery = "";
            int c = 0, h = 0, ch = 0;
            if (dto.IsCricket == true)
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
            if (dto.Hockey == true)
            {
                h = 1;
            }
            else
            {
                h = 0;
            }
            if (dto.Chess == true)
            {
                ch = 1;
            }
            else
            {
                ch = 0;
            }
            sqlQuery = "update dbo.Users set Name='"+dto.Name+"',Login='"+dto.Login+"',Password='"+dto.Password+"',Gender='"+dto.Gender+"',Address='"+dto.Address+"',Age="+dto.Age+",NIC='"+dto.NIC+"',DOB='"+dto.DOB+"',IsCricket="+c+",Hockey="+h+",Chess="+ch+",ImageName='"+dto.ImageName+"',CreatedOn='"+dto.CreatedOn+"',Email='"+dto.Email+"' where UserID="+dto.UserID;
            using (DBHelper helper = new DBHelper())
            {
                return helper.executeQuery(sqlQuery);
            }

        }
        public static usersDTO getuserbyid(int id)
        {
            string query = "Select * from dbo.Users where UserID= " + id;
            using(DBHelper helper=new DBHelper())
            {
                var reader = helper.executeReader(query);
                usersDTO dto = null;
                if(reader.Read())
                {
                    dto = fillDTO(reader);
                }
                return dto;
            }
           
        }
        public static usersDTO getuserbyEmail(String email)
        {
            string query = "Select * from dbo.Users where Email= " + email;
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.executeReader(query);
                usersDTO dto = null;
                if (reader.Read())
                {
                    dto = fillDTO(reader);
                }
                return dto;
            }

        }
        public static int  getUserId(String name,String login)
        {
            string query = "Select * from dbo.Users where Name='"+name+"' and Login='"+login+"'";
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.executeReader(query);

                if (reader.Read())
                {
                    return (int)reader["UserID"];
                }

              
            }
            return 0;
        }
        public static int getUserId(String email)
        {
            string query = "Select * from dbo.Users where Name='" + email + "'";
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.executeReader(query);

                if (reader.Read())
                {
                    return (int)reader["UserID"];
                }


            }
            return 0;
        }
        public static List<usersDTO> getallUsers()
        {
            var query = "select * from dbo.Users";
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.executeReader(query);
                List<usersDTO> list = new List<usersDTO>();
                while(reader.Read())
                {
                    var dto = fillDTO(reader);
                    if(dto!=null)
                    {
                        list.Add(dto);
                    }
                }
                return list;
            }
                
        }
        public static int deleteUser(int id)
        {
            return 0;
        }
        private static usersDTO fillDTO(SqlDataReader reader)
        {
            var dto = new usersDTO();
            dto.UserID = (int)reader["UserID"];
            dto.Name = (String)reader["Name"];
            dto.Login = (String)reader["Login"];
            dto.Password = (String)reader["Password"];
            dto.Gender = (String)reader["Gender"];
            dto.Address = (String)reader["Address"];
            dto.Age = (int)reader["Age"];
            dto.NIC = (String)reader["NIC"];
            dto.DOB = reader["DOB"].ToString();
            dto.IsCricket = reader.GetBoolean(9);
            dto.Hockey = reader.GetBoolean(10);
            dto.Chess = reader.GetBoolean(11);
            dto.ImageName = (String)reader["ImageName"];
            dto.CreatedOn = (DateTime)reader["CreatedOn"];
            return dto;
        }
    }
   
}
