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
    
        //public static FolderDTO GetChildFolders(int pid,int userid)
        //{

        //    var query = String.Format("Select * from dbo.Folder Where UserId={0} and ParentFolderID={0}",userid, pid);

        //    using (DBHelper helper = new DBHelper())
        //    {
        //        var reader = helper.ExecuteReader(query);

        //        FolderDTO dto = null;

        //        if (reader.Read())
        //        {
        //            dto = FillDTO(reader);
        //        }

        //        return dto;
        //    }
        //}
        public static List<FolderDTO> GetChildFolders(int pid, int userid)
        {
            using (DBHelper helper = new DBHelper())
            {
                var query = String.Format("Select * from dbo.Folder Where UserID={0} and ParentFolderID={1}", userid, pid);
                var reader = helper.ExecuteReader(query);
                List<FolderDTO> list = new List<FolderDTO>();

                while (reader.Read())
                {
                    var dto = FillDTO(reader);
                    if (dto != null)
                    {
                        list.Add(dto);
                    }
                }

                return list;
            }
        }
        private static FolderDTO FillDTO(SqlDataReader reader)
        {
            var dto = new FolderDTO();
           dto.FolderID = reader.GetInt32(0);
            dto.FolderName = reader.GetString(1);
            dto.ParentFolderID = reader.GetInt32(2);
            dto.UserID = reader.GetInt32(3);
            //dto.PictureName = reader.GetString(4);
            //dto.IsAdmin = reader.GetBoolean(5);
            //dto.IsActive = reader.GetBoolean(6);

            return dto;
        }
    }

}
