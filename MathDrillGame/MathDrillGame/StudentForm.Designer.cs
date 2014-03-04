namespace MathDrillGame
{
    partial class StudentForm
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
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.inputAnswer = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelWelcome.Location = new System.Drawing.Point(7, 12);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(0, 20);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLogout.Location = new System.Drawing.Point(217, 194);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(90, 43);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.Text = "Log out";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelQuestion.Location = new System.Drawing.Point(12, 92);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(0, 29);
            this.labelQuestion.TabIndex = 4;
            // 
            // inputAnswer
            // 
            this.inputAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.inputAnswer.Location = new System.Drawing.Point(147, 86);
            this.inputAnswer.Name = "inputAnswer";
            this.inputAnswer.Size = new System.Drawing.Size(68, 35);
            this.inputAnswer.TabIndex = 1;
            this.inputAnswer.TextChanged += new System.EventHandler(this.inputAnswer_TextChanged);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonSubmit.Location = new System.Drawing.Point(221, 87);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(86, 34);
            this.buttonSubmit.TabIndex = 2;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // labelFeedback
            // 
            this.labelFeedback.AutoSize = true;
            this.labelFeedback.Enabled = false;
            this.labelFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelFeedback.Location = new System.Drawing.Point(68, 159);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(0, 20);
            this.labelFeedback.TabIndex = 7;
            // 
            // StudentForm
            // 
            this.AcceptButton = this.buttonSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonLogout;
            this.ClientSize = new System.Drawing.Size(316, 258);
            this.Controls.Add(this.labelFeedback);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.inputAnswer);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.labelWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Math Drills - Student";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.TextBox inputAnswer;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelFeedback;
    }
}