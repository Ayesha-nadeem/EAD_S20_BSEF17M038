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
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            var dt = BAL.usersBO.getallUsers();
            dataGridView1.DataSource = dt;
        }

        private void AdminHome_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==5)
            {
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                var dto = BAL.usersBO.getuserbyid(id);
                newUser frm = new newUser(id);
                frm.admin = true;
                frm.existing = false;
                frm.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms["Form1"];
            if (frm != null)
            {
                frm.Show();
                this.Close();
            }
        }
    }
}
