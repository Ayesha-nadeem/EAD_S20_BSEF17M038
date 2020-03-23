using EmailPrac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS.Entity;

namespace assignment_2
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var id = BAL.usersBO.getUserId(txtLogin.Text.Trim(), txtLogin.Text.Trim());
            if(id==0)
            {
                MessageBox.Show("invalid user");
            }
            else
            {
                usersDTO dto = BAL.usersBO.getuserbyid(id);
                home frm = new home(id);
                frm.Show();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms["Form1"];
            if (frm != null)
            {
                frm.Show();
                this.Close();
            }
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var id = BAL.usersBO.getUserId(email);
            if(id!=0)
            {
                String code = "1234";
               // EmailHandler.SendEmail(email, "code", "1234");
                EnterResetCode frm = new EnterResetCode(code,id);
                frm.Show();
                this.Close();
            }

        }
    }
}
