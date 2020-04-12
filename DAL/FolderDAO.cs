using Entities;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
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
            
            sqlQuery = String.Format("INSERT INTO folder(foldername, parentfolder,userid) VALUES('{0}','{1}','{2}')",
                dto.FolderName, dto.ParentFolderID, dto.UserID);
        

            using (DBHelper helper = new DBHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
        }
    
      
        public static List<FolderDTO> GetChildFolders(int pid, int userid)
        {
            using (DBHelper helper = new DBHelper())
            {
                var query = String.Format("Select * from folder Where userid={0} and parentfolder={1}", userid, pid);
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
        private static FolderDTO FillDTO(MySqlDataReader reader)
        {
            var dto = new FolderDTO();
           dto.FolderID = reader.GetInt32(0);
            dto.FolderName = reader.GetString(1);
            dto.ParentFolderID = reader.GetInt32(2);
            dto.UserID = reader.GetInt32(3);
           

            return dto;
        }
    }

}
