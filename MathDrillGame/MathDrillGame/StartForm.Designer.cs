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
            this.SuspendLayout();
            // 
            // Student_Button
            // 
            this.Student_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Student_Button.BackgroundImage")));
            this.Student_Button.Image = ((System.Drawing.Image)(resources.GetObject("Student_Button.Image")));
            this.Student_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Student_Button.Location = new System.Drawing.Point(132, 12);
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
            this.admin_button.Location = new System.Drawing.Point(132, 223);
            this.admin_button.Name = "admin_button";
            this.admin_button.Size = new System.Drawing.Size(175, 175);
            this.admin_button.TabIndex = 1;
            this.admin_button.UseVisualStyleBackColor = true;
            this.admin_button.Click += new System.EventHandler(this.admin_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Image = ((System.Drawing.Image)(resources.GetObject("exit_button.Image")));
            this.exit_button.Location = new System.Drawing.Point(377, 348);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(50, 50);
            this.exit_button.TabIndex = 2;
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(448, 410);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.admin_button);
            this.Controls.Add(this.Student_Button);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MathDrill";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Student_Button;
        private System.Windows.Forms.Button admin_button;
        private System.Windows.Forms.Button exit_button;
    }
}