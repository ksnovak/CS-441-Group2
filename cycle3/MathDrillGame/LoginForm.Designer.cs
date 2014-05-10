namespace MathDrillGame
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
            this.back_button = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.listOfUsers = new System.Windows.Forms.ListBox();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.listOfTeachers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // back_button
            // 
            this.back_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.back_button.Location = new System.Drawing.Point(208, 330);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(96, 29);
            this.back_button.TabIndex = 4;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLogin.Location = new System.Drawing.Point(321, 330);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(96, 29);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Log in";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // listOfUsers
            // 
            this.listOfUsers.Enabled = false;
            this.listOfUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listOfUsers.ForeColor = System.Drawing.Color.Black;
            this.listOfUsers.FormattingEnabled = true;
            this.listOfUsers.ItemHeight = 16;
            this.listOfUsers.Items.AddRange(new object[] {
            "List of students"});
            this.listOfUsers.Location = new System.Drawing.Point(237, 140);
            this.listOfUsers.Name = "listOfUsers";
            this.listOfUsers.Size = new System.Drawing.Size(180, 164);
            this.listOfUsers.TabIndex = 3;
            this.listOfUsers.SelectedIndexChanged += new System.EventHandler(this.listOfUsers_SelectedIndexChanged);
            // 
            // labelWelcome
            // 
            this.labelWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelWelcome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelWelcome.Location = new System.Drawing.Point(113, 12);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(208, 24);
            this.labelWelcome.TabIndex = 3;
            this.labelWelcome.Text = "Welcome, please log in";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelWelcome.Click += new System.EventHandler(this.labelWelcome_Click);
            // 
            // listOfTeachers
            // 
            this.listOfTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listOfTeachers.ForeColor = System.Drawing.Color.Black;
            this.listOfTeachers.FormattingEnabled = true;
            this.listOfTeachers.ItemHeight = 16;
            this.listOfTeachers.Items.AddRange(new object[] {
            "List of teachers"});
            this.listOfTeachers.Location = new System.Drawing.Point(12, 140);
            this.listOfTeachers.Name = "listOfTeachers";
            this.listOfTeachers.Size = new System.Drawing.Size(180, 164);
            this.listOfTeachers.TabIndex = 2;
            this.listOfTeachers.SelectedIndexChanged += new System.EventHandler(this.listOfTeachers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pick your Teacher";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(269, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Find your Name";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.buttonLogin;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MathDrillGame.Properties.Resources._11;
            this.CancelButton = this.back_button;
            this.ClientSize = new System.Drawing.Size(429, 371);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.Text = "Math Treasure - Student Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ListBox listOfUsers;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.ListBox listOfTeachers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

