namespace MathDrillGame
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.Student_Button = new System.Windows.Forms.Button();
            this.admin_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Student_Button
            // 
            this.Student_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Student_Button.BackgroundImage")));
            this.Student_Button.Image = ((System.Drawing.Image)(resources.GetObject("Student_Button.Image")));
            this.Student_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Student_Button.Location = new System.Drawing.Point(12, 64);
            this.Student_Button.Name = "Student_Button";
            this.Student_Button.Size = new System.Drawing.Size(175, 175);
            this.Student_Button.TabIndex = 0;
            this.Student_Button.UseVisualStyleBackColor = true;
            this.Student_Button.Click += new System.EventHandler(this.Student_Button_Click);
            // 
            // admin_button
            // 
            this.admin_button.Image = ((System.Drawing.Image)(resources.GetObject("admin_button.Image")));
            this.admin_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.admin_button.Location = new System.Drawing.Point(231, 64);
            this.admin_button.Name = "admin_button";
            this.admin_button.Size = new System.Drawing.Size(175, 175);
            this.admin_button.TabIndex = 1;
            this.admin_button.UseVisualStyleBackColor = true;
            this.admin_button.Click += new System.EventHandler(this.admin_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Image = ((System.Drawing.Image)(resources.GetObject("exit_button.Image")));
            this.exit_button.Location = new System.Drawing.Point(356, 295);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(50, 50);
            this.exit_button.TabIndex = 2;
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Are you a student or a teacher?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(110, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Student";
            this.label2.Click += new System.EventHandler(this.student_label_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(329, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Teacher";
            this.label3.Click += new System.EventHandler(this.admin_label_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(419, 361);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.admin_button);
            this.Controls.Add(this.Student_Button);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Math Treasure - Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Student_Button;
        private System.Windows.Forms.Button admin_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}