using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS.Entity;

namespace assignment_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var dto = new UMS.Entity.usersDTO();
            //dto.Name = "b";
            //dto.Password = "b";
            //dto.Login = "b";
            //dto.Gender = "f";
            //dto.Address = "b";
            //dto.Age = 2;
            //dto.NIC = "b";
            //dto.DOB = "1/1/2011";
            //dto.IsCricket = true;
            //dto.Hockey = true;
            //dto.Chess = true;
            //dto.ImageName = "bool.jpg";
            //dto.CreatedOn = DateTime.Now;
            ////BAL.usersBO.save(dto);
            //int id = BAL.usersBO.getUserId("b", "b");
            //usersDTO dto1 = BAL.usersBO.getuserbyid(id);
            //System.Console.ReadKey();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
