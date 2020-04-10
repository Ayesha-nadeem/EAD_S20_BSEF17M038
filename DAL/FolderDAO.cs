using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FolderDAO
    {
        public static int Save(FolderDTO dto)
        {
            String sqlQuery = "";
            //if (dto.UserID > 0)
            //{
            //    sqlQuery = String.Format("Update dbo.Users Set Name='{0}', Password='{1}',Login='{2}' Where UserID={2}",
            //        dto.Name, dto.Password,dto.Login, dto.UserID);
            //}
            //else
            //{
            sqlQuery = String.Format("INSERT INTO dbo.Folder(FolderName, ParentFolderID,UserID) VALUES('{0}','{1}','{2}')",
                dto.FolderName, dto.ParentFolderID, dto.UserID);
            //}

            using (DBHelper helper = new DBHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
        }
        //public static UserDTO GetUserById(int pid)
        //{

        //    var query = String.Format("Select * from dbo.Users Where UserId={0}", pid);

        //    using (DBHelper helper = new DBHelper())
        //    {
        //        var reader = helper.ExecuteReader(query);

        //        UserDTO dto = null;

        //        if (reader.Read())
        //        {
        //            dto = FillDTO(reader);
        //        }

        //        return dto;
        //    }
        //}
        private static UserDTO FillDTO(SqlDataReader reader)
        {
            var dto = new UserDTO();
            dto.UserID = reader.GetInt32(0);
            dto.Name = reader.GetString(1);
            dto.Login = reader.GetString(2);
            dto.Password = reader.GetString(3);
            //dto.PictureName = reader.GetString(4);
            //dto.IsAdmin = reader.GetBoolean(5);
            //dto.IsActive = reader.GetBoolean(6);

            return dto;
        }
    }

}
