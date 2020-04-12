using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class FolderBO
    {
        public static int Save(FolderDTO dto)
        {
            return DAL.FolderDAO.Save(dto);
        }
        public static List<FolderDTO> GetChildFolders(int pid, int userid)
        {
            return DAL.FolderDAO.GetChildFolders(pid, userid);
        }

        }
}