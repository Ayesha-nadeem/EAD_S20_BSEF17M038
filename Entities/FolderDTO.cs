using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FolderDTO
    {
        public int FolderID { get; set; }
        public int ParentFolderID { get; set; }
        public int UserID { get; set; }
        public String FolderName { get; set; }

    }
}
