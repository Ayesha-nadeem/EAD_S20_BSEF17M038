using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Entity;

namespace BAL
{
    public static class usersBO
    {
        public static int save(usersDTO dto)
        {
            DAL.UsersDAO.save(dto);
            int id = DAL.UsersDAO.getUserId(dto.Login);
            DAL.UsersDAO.updateCreatedBy(id);
            return id;
        }
        public static int update(usersDTO dto)
        {
            return DAL.UsersDAO.update(dto);
        }
        public static usersDTO getuserbyid(int id)
        {
            return DAL.UsersDAO.getuserbyid(id);
        }
        public static int getUserId(String name, String Login)
        {
            return DAL.UsersDAO.getUserId(name, Login);
        }
        public static List<usersDTO> getallUsers()
        {
            return DAL.UsersDAO.getallUsers();
        }
        public static int getUserIdByEmail(String email)
        {
            return DAL.UsersDAO.getUserIdByEmail(email);
        }
        public static int getUserId(String email)
        {
            return DAL.UsersDAO.getUserId(email);
        }
    }
}
