using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Entity;
namespace BAL
{
    public static class AdminBO
    {
        public static int getAdminId(String login,String pass)
        {
            return DAL.adminDAO.getAdminId(login,pass);
        }
    }
}
