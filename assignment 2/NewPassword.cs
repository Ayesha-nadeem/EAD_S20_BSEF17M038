using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment_2
{
    public partial class NewPassword : Form
    {
        public int id = 0;
        public NewPassword()
        {
            InitializeComponent();
        }
        public NewPassword(int id)
        {
            this.id = id;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var dto = BAL.usersBO.getuserbyid(this.id);
            home frm = new home(this.id);
            frm.Show();
            this.Close();
        }
    }
}
