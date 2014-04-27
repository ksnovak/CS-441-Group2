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
            this.back_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // triangle_button
            // 
            this.triangle_button.BackColor = System.Drawing.SystemColors.Highlight;
            this.triangle_button.Image = ((System.Drawing.Image)(resources.GetObject("triangle_button.Image")));
            this.triangle_button.Location = new System.Drawing.Point(12, 62);
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
            this.pentagon_button.Location = new System.Drawing.Point(158, 62);
            this.pentagon_button.Name = "pentagon_button";
            this.pentagon_button.Size = new System.Drawing.Size(100, 100);
            this.pentagon_button.TabIndex = 1;
            this.pentagon_button.UseVisualStyleBackColor = false;
            this.pentagon_button.Click += new System.EventHandler(this.pentagon_button_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(306, 62);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 100);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // back_button
            // 
            this.back_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.back_button.Location = new System.Drawing.Point(306, 300);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(100, 45);
            this.back_button.TabIndex = 4;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Click on your password icon:";
            // 
            // StudentLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.back_button;
            this.ClientSize = new System.Drawing.Size(419, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pentagon_button);
            this.Controls.Add(this.triangle_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentLoginForm";
            this.Text = "Math Treasure - Student Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button triangle_button;
        private System.Windows.Forms.Button pentagon_button;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Label label1;
    }
}