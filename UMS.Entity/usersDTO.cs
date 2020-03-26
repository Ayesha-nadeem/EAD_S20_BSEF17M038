using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Entity
{
    public class usersDTO
    {
        public int UserID { get; set; }
        public String Name { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String Gender { get; set; }
        public String Address { get; set; }
        public int Age { get; set; }
        public String NIC { get; set; }
        public String DOB { get; set; }
        public Boolean IsCricket { get; set; }
        public Boolean Hockey { get; set; }
        public Boolean Chess { get; set; }
        public String ImageName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public String Email { get; set; }
    }
  
}
