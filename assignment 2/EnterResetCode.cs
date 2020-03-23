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
    public partial class EnterResetCode : Form
    {
        String code = "12345";
        int id = 0;
        public EnterResetCode()
        {
            InitializeComponent();
        }
        public EnterResetCode(String code,int id)
        {
            this.code = code;
            this.id = id;
            InitializeComponent();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            String c = txtCode.Text.Trim();
            if(c.Equals("12345")==true)
            {
                NewPassword frm = new NewPassword(this.id);
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("incorrect code");
            }
        }
    }
}
