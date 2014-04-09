namespace MathDrillGame
{
    partial class StudentLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentLoginForm));
            this.triangle_button = new System.Windows.Forms.Button();
            this.pentagon_button = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // triangle_button
            // 
            this.triangle_button.BackColor = System.Drawing.SystemColors.Highlight;
            this.triangle_button.Image = ((System.Drawing.Image)(resources.GetObject("triangle_button.Image")));
            this.triangle_button.Location = new System.Drawing.Point(55, 82);
            this.triangle_button.Name = "triangle_button";
            this.triangle_button.Size = new System.Drawing.Size(100, 100);
            this.triangle_button.TabIndex = 0;
            this.triangle_button.UseVisualStyleBackColor = false;
            this.triangle_button.Click += new System.EventHandler(this.triangle_button_Click);
            // 
            // pentagon_button
            // 
            this.pentagon_button.BackColor = System.Drawing.Color.Firebrick;
            this.pentagon_button.Image = ((System.Drawing.Image)(resources.GetObject("pentagon_button.Image")));
            this.pentagon_button.Location = new System.Drawing.Point(231, 82);
            this.pentagon_button.Name = "pentagon_button";
            this.pentagon_button.Size = new System.Drawing.Size(100, 100);
            this.pentagon_button.TabIndex = 1;
            this.pentagon_button.UseVisualStyleBackColor = false;
            this.pentagon_button.Click += new System.EventHandler(this.pentagon_button_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(403, 82);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 100);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // exit_button
            // 
            this.exit_button.Image = ((System.Drawing.Image)(resources.GetObject("exit_button.Image")));
            this.exit_button.Location = new System.Drawing.Point(428, 260);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(50, 50);
            this.exit_button.TabIndex = 5;
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(95, 260);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(74, 50);
            this.back_button.TabIndex = 4;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // StudentLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 502);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pentagon_button);
            this.Controls.Add(this.triangle_button);
            this.Name = "StudentLoginForm";
            this.Text = "Log in";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button triangle_button;
        private System.Windows.Forms.Button pentagon_button;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button back_button;
    }
}