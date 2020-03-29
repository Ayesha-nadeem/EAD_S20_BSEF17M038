using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS.Entity;

namespace assignment_2
{
    public partial class home : Form
    {
        public int id = 0;
        public home(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        public home()
        {
            InitializeComponent();
            
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms["Form1"];
            if (frm != null)
            {
                frm.Show();
                this.Close();
               
            }
        }

        private void btnEditprofile_Click(object sender, EventArgs e)
        {
            usersDTO dto = new usersDTO();
            dto = BAL.usersBO.getuserbyid(id);
            newUser frm = new newUser(this.id);
            frm.existing = true;
            frm.admin = false;
            frm.Show();
            this.Close();

        }

        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        private void home_Load(object sender, EventArgs e)
        {
            var dto = BAL.usersBO.getuserbyid(this.id);
            lblWelcome.Text = "Welcome" + dto.Name;
            String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            String pathToSaveImage = applicationBasePath + @"\images\";

            String imgPath = pathToSaveImage + dto.ImageName;
            pictureBox1.Image = Image.FromFile(imgPath);
        }

        //private void home_Load(object sender, EventArgs e)
        //{
        //    lblWelcome.Text=newUser.
        //}
    }
}
