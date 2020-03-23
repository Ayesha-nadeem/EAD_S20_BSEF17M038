namespace assignment_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_newuser = new System.Windows.Forms.Button();
            this.btn_ExistUser = new System.Windows.Forms.Button();
            this.btn_admin = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_newuser
            // 
            this.btn_newuser.Location = new System.Drawing.Point(495, 25);
            this.btn_newuser.Name = "btn_newuser";
            this.btn_newuser.Size = new System.Drawing.Size(312, 86);
            this.btn_newuser.TabIndex = 0;
            this.btn_newuser.Text = "New User";
            this.btn_newuser.UseVisualStyleBackColor = true;
            this.btn_newuser.Click += new System.EventHandler(this.btn_newuser_Click);
            // 
            // btn_ExistUser
            // 
            this.btn_ExistUser.Location = new System.Drawing.Point(495, 117);
            this.btn_ExistUser.Name = "btn_ExistUser";
            this.btn_ExistUser.Size = new System.Drawing.Size(312, 88);
            this.btn_ExistUser.TabIndex = 1;
            this.btn_ExistUser.Text = "Existing User";
            this.btn_ExistUser.UseVisualStyleBackColor = true;
            this.btn_ExistUser.Click += new System.EventHandler(this.btn_ExistUser_Click);
            // 
            // btn_admin
            // 
            this.btn_admin.Location = new System.Drawing.Point(495, 211);
            this.btn_admin.Name = "btn_admin";
            this.btn_admin.Size = new System.Drawing.Size(318, 106);
            this.btn_admin.TabIndex = 2;
            this.btn_admin.Text = "Admin";
            this.btn_admin.UseVisualStyleBackColor = true;
            this.btn_admin.Click += new System.EventHandler(this.btn_admin_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(495, 323);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(318, 86);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 450);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_admin);
            this.Controls.Add(this.btn_ExistUser);
            this.Controls.Add(this.btn_newuser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_newuser;
        private System.Windows.Forms.Button btn_ExistUser;
        private System.Windows.Forms.Button btn_admin;
        private System.Windows.Forms.Button btn_exit;
    }
}

