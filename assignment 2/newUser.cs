﻿using System;
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
    public partial class newUser : Form
    {
        public Boolean existing=false;
        public Boolean admin = false;
        public int id = 0;
        public newUser()
        {
            InitializeComponent();
        }
        public newUser(int id)
        {
            InitializeComponent();
            this.id = id;


        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
             if (txtName.Text.Trim() == "" || txtLogin.Text.Trim() == "" || txtpass.Text.Trim() == "" || txtAddress.Text.Trim() == "" || Int32.Parse(txtAge.Value.ToString()) <= 0 || txtNIC.Text.Trim() == "" || pictureBox1.Image == null)
            {
                MessageBox.Show("all fields required");
            }
            else
            {
                String uniqueName = "";
                usersDTO dto = new usersDTO();
                dto.Name = txtName.Text.Trim();
                dto.Login = txtLogin.Text.Trim();
                dto.Password = txtpass.Text.Trim();
                dto.Address = txtAddress.Text.Trim();
                dto.Gender = comGender.Text.Trim();
                dto.Age = (int)txtAge.Value;
                dto.NIC = txtNIC.Text.Trim();
                dto.DOB = txtDOB.Value.ToShortDateString();
                dto.IsCricket = (chCricket.Checked == true ? true : false);
                dto.Hockey = (chHockey.Checked == true ? true : false);
                dto.Chess = (chChess.Checked == true ? true : false);
               
                dto.Email = txtemail.Text.Trim();
                String imgPath = "";
                String pathToSaveImage = "";

                if (pictureBox1.Image != null)
                {
                    

                    String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                    pathToSaveImage = applicationBasePath + @"\images\";

                    uniqueName = Guid.NewGuid().ToString() + ".jpg";
                    imgPath = pathToSaveImage + uniqueName;
                    
                    pictureBox1.Image.Save(imgPath);
                    
                    dto.ImageName = uniqueName;
                }
                if (BAL.usersBO.getUserId(dto.Login) == 0)
                {
                    dto.CreatedOn = DateTime.Now;
                    dto.CreatedBy = 0;
                    dto.ModifiedOn = DateTime.Now;
                    dto.ModifiedBy = 0;
                    BAL.usersBO.save(dto);
                    dto.UserID = BAL.usersBO.getUserId(dto.Login);
                    this.id = dto.UserID;
                    home frm = new home(this.id);
                    frm.Show();
                    this.Close();
                }
                else if (BAL.usersBO.getUserId(dto.Login) != 0 && existing == false && admin == false)
                {
                    MessageBox.Show("user already exist");
                }
                else if (BAL.usersBO.getUserId(dto.Login) != 0 && existing == true && admin == false)
                {
                    dto.UserID = BAL.usersBO.getUserId( dto.Login);
                    dto.ModifiedBy = dto.UserID;
                    dto.ModifiedOn = DateTime.Now;
                    BAL.usersBO.update(dto);
                    home frm = new home(this.id);
                    frm.Show();
                    this.Close();
                }
                else if (BAL.usersBO.getUserId(dto.Login) != 0 && admin == true && existing == false)
                {
                    dto.UserID = BAL.usersBO.getUserId( dto.Login);
                    dto.ModifiedBy = dto.UserID;
                    dto.ModifiedOn = DateTime.Now;
                    BAL.usersBO.update(dto);
                    AdminHome frm2 = new AdminHome();
                    frm2.Show();
                    this.Close();
                }
            }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if(result==System.Windows.Forms.DialogResult.OK)
            {
                String file = openFileDialog1.FileName;
                pictureBox1.Image=Image.FromFile(file);
            }
        }

        private void newUser_Load(object sender, EventArgs e)
        {
            String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            System.IO.Directory.CreateDirectory(applicationBasePath + @"\images\");
            if (this.id != 0)
            {
                var dto = BAL.usersBO.getuserbyid(this.id);
                txtName.Text = dto.Name;
                txtLogin.Text = dto.Login;
                txtpass.Text = dto.Password;
                txtAddress.Text = dto.Address;
                comGender.Text = dto.Gender;
                txtAge.Value = dto.Age;
                txtNIC.Text = dto.NIC;
                txtDOB.Value = Convert.ToDateTime(dto.DOB);
                chCricket.Checked = dto.IsCricket;
                chHockey.Checked = dto.Hockey;
                chChess.Checked = dto.Chess;
                txtemail.Text = dto.Email;
                String pathToSaveImage = applicationBasePath + @"\images\";
                String imgPath = pathToSaveImage + dto.ImageName;
                pictureBox1.Image = Image.FromFile(imgPath);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms["Form1"];
            if (frm!=null && existing==false && admin==false )
            {
                frm.Show();
                this.Close();
            }
            else  if(existing==true && admin==false)
            {
                home frm2 = new home(this.id);
                frm2.Show();
                this.Close();
            }
            else
            {
                var frm2 = Application.OpenForms["AdminHome"];
                frm2.Show();
                this.Close();
            }

        }

        private void newUser_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }
    }
}
