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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var id = BAL.AdminBO.getAdminId(txtLogin.Text.Trim(),txtPass.Text.Trim());
            if(id==0)
            {
                MessageBox.Show("invalid admin");
            }
            else
            {
                AdminHome frm = new AdminHome();
                frm.Show();
                this.Close();
            }
        }

        private void AdminLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms["Form1"];
            if(frm!=null)
            {
                frm.Show();
                this.Close();
            }
        }
    }
}
