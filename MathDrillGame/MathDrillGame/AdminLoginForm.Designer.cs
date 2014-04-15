namespace MathDrillGame
{
    partial class AdminLoginForm
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
            this.AdminUsersList = new System.Windows.Forms.ListBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.login_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdminUsersList
            // 
            this.AdminUsersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminUsersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AdminUsersList.FormattingEnabled = true;
            this.AdminUsersList.ItemHeight = 16;
            this.AdminUsersList.Items.AddRange(new object[] {
            "List of teachers"});
            this.AdminUsersList.Location = new System.Drawing.Point(116, 72);
            this.AdminUsersList.Name = "AdminUsersList";
            this.AdminUsersList.Size = new System.Drawing.Size(221, 148);
            this.AdminUsersList.TabIndex = 1;
            this.AdminUsersList.SelectedIndexChanged += new System.EventHandler(this.AdminUsersList_SelectedIndexChanged);
            // 
            // passwordBox
            // 
            this.passwordBox.Enabled = false;
            this.passwordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.passwordBox.Location = new System.Drawing.Point(116, 243);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(120, 29);
            this.passwordBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(14, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select User:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.login_button);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.passwordBox);
            this.panel1.Controls.Add(this.AdminUsersList);
            this.panel1.Location = new System.Drawing.Point(33, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 283);
            this.panel1.TabIndex = 3;
            // 
            // login_button
            // 
            this.login_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.login_button.Location = new System.Drawing.Point(241, 243);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(96, 29);
            this.login_button.TabIndex = 3;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(14, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 100;
            this.label2.Text = "Password:";
            // 
            // back_button
            // 
            this.back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.back_button.Location = new System.Drawing.Point(311, 314);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(96, 29);
            this.back_button.TabIndex = 4;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(14, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(330, 60);
            this.label3.TabIndex = 101;
            this.label3.Text = "Welcome, select your name and enter your password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AdminLoginForm
            // 
            this.AcceptButton = this.login_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 361);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Math Treasure - Teacher Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox AdminUsersList;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Label label3;
    }
}