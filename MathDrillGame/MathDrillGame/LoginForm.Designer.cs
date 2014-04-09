﻿namespace MathDrillGame
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.back_button = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.listOfUsers = new System.Windows.Forms.ListBox();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.listOfTeachers = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // back_button
            // 
            this.back_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.back_button.Location = new System.Drawing.Point(42, 423);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(96, 35);
            this.back_button.TabIndex = 4;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonLogin.Location = new System.Drawing.Point(577, 423);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(96, 35);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Log in";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // listOfUsers
            // 
            this.listOfUsers.Enabled = false;
            this.listOfUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listOfUsers.FormattingEnabled = true;
            this.listOfUsers.ItemHeight = 16;
            this.listOfUsers.Location = new System.Drawing.Point(228, 287);
            this.listOfUsers.Name = "listOfUsers";
            this.listOfUsers.Size = new System.Drawing.Size(268, 84);
            this.listOfUsers.TabIndex = 3;
            this.listOfUsers.SelectedIndexChanged += new System.EventHandler(this.listOfUsers_SelectedIndexChanged);
            // 
            // labelWelcome
            // 
            this.labelWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelWelcome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelWelcome.Location = new System.Drawing.Point(253, 33);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(208, 24);
            this.labelWelcome.TabIndex = 3;
            this.labelWelcome.Text = "Welcome, please log in";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelWelcome.Click += new System.EventHandler(this.labelWelcome_Click);
            // 
            // listOfTeachers
            // 
            this.listOfTeachers.FormattingEnabled = true;
            this.listOfTeachers.Items.AddRange(new object[] {
            "something"});
            this.listOfTeachers.Location = new System.Drawing.Point(228, 176);
            this.listOfTeachers.Name = "listOfTeachers";
            this.listOfTeachers.Size = new System.Drawing.Size(268, 69);
            this.listOfTeachers.TabIndex = 2;
            this.listOfTeachers.SelectedIndexChanged += new System.EventHandler(this.listOfTeachers_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(311, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.buttonLogin;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.back_button;
            this.ClientSize = new System.Drawing.Size(704, 512);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listOfTeachers);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.listOfUsers);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.back_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Math Drills - Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ListBox listOfUsers;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.ListBox listOfTeachers;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

