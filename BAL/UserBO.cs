using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class UserBO
    {
        public static int Save(UserDTO dto)
        {
            return DAL.UserDAO.Save(dto);
        }
        public static UserDTO ValidateUser(String pLogin, String pPassword)
        {
            return DAL.UserDAO.ValidateUser(pLogin, pPassword);
        }
    }
}