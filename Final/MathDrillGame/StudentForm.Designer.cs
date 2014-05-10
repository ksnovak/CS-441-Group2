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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.inputAnswer = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.map2 = new System.Windows.Forms.PictureBox();
            this.map1 = new System.Windows.Forms.PictureBox();
            this.map4 = new System.Windows.Forms.PictureBox();
            this.map3 = new System.Windows.Forms.PictureBox();
            this.map8 = new System.Windows.Forms.PictureBox();
            this.map7 = new System.Windows.Forms.PictureBox();
            this.map6 = new System.Windows.Forms.PictureBox();
            this.map5 = new System.Windows.Forms.PictureBox();
            this.map10 = new System.Windows.Forms.PictureBox();
            this.map9 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map9)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelWelcome.Location = new System.Drawing.Point(206, 9);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(19, 29);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = " ";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonLogout
            // 
            this.buttonLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLogout.Location = new System.Drawing.Point(596, 471);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(96, 29);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.Text = "Log out";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelQuestion.Location = new System.Drawing.Point(209, 115);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(112, 29);
            this.labelQuestion.TabIndex = 4;
            this.labelQuestion.Text = "[X + Y = ]";
            // 
            // inputAnswer
            // 
            this.inputAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputAnswer.Location = new System.Drawing.Point(337, 116);
            this.inputAnswer.Name = "inputAnswer";
            this.inputAnswer.Size = new System.Drawing.Size(68, 29);
            this.inputAnswer.TabIndex = 1;
            this.inputAnswer.TextChanged += new System.EventHandler(this.inputAnswer_TextChanged);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonSubmit.Location = new System.Drawing.Point(428, 115);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(96, 29);
            this.buttonSubmit.TabIndex = 2;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // labelFeedback
            // 
            this.labelFeedback.AutoSize = true;
            this.labelFeedback.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelFeedback.Enabled = false;
            this.labelFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelFeedback.ForeColor = System.Drawing.Color.White;
            this.labelFeedback.Location = new System.Drawing.Point(210, 198);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(88, 20);
            this.labelFeedback.TabIndex = 7;
            this.labelFeedback.Text = "[Feedback]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 335);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(648, 126);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(382, 233);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(100, 98);
            this.pictureBox10.TabIndex = 17;
            this.pictureBox10.TabStop = false;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(363, 9);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(277, 62);
            this.welcomeLabel.TabIndex = 18;
            this.welcomeLabel.Text = "test message display";
            // 
            // map2
            // 
            this.map2.Image = global::MathDrillGame.Properties.Resources.straight_line2;
            this.map2.Location = new System.Drawing.Point(149, 380);
            this.map2.Name = "map2";
            this.map2.Size = new System.Drawing.Size(50, 50);
            this.map2.TabIndex = 28;
            this.map2.TabStop = false;
            this.map2.Visible = false;
            // 
            // map1
            // 
            this.map1.Image = ((System.Drawing.Image)(resources.GetObject("map1.Image")));
            this.map1.InitialImage = null;
            this.map1.Location = new System.Drawing.Point(97, 380);
            this.map1.Name = "map1";
            this.map1.Size = new System.Drawing.Size(50, 50);
            this.map1.TabIndex = 27;
            this.map1.TabStop = false;
            // 
            // map4
            // 
            this.map4.Image = ((System.Drawing.Image)(resources.GetObject("map4.Image")));
            this.map4.Location = new System.Drawing.Point(254, 380);
            this.map4.Name = "map4";
            this.map4.Size = new System.Drawing.Size(50, 50);
            this.map4.TabIndex = 30;
            this.map4.TabStop = false;
            this.map4.Visible = false;
            // 
            // map3
            // 
            this.map3.Image = ((System.Drawing.Image)(resources.GetObject("map3.Image")));
            this.map3.Location = new System.Drawing.Point(202, 380);
            this.map3.Name = "map3";
            this.map3.Size = new System.Drawing.Size(50, 50);
            this.map3.TabIndex = 29;
            this.map3.TabStop = false;
            this.map3.Visible = false;
            // 
            // map8
            // 
            this.map8.Image = ((System.Drawing.Image)(resources.GetObject("map8.Image")));
            this.map8.Location = new System.Drawing.Point(464, 380);
            this.map8.Name = "map8";
            this.map8.Size = new System.Drawing.Size(50, 50);
            this.map8.TabIndex = 34;
            this.map8.TabStop = false;
            this.map8.Visible = false;
            // 
            // map7
            // 
            this.map7.Image = ((System.Drawing.Image)(resources.GetObject("map7.Image")));
            this.map7.Location = new System.Drawing.Point(412, 380);
            this.map7.Name = "map7";
            this.map7.Size = new System.Drawing.Size(50, 50);
            this.map7.TabIndex = 33;
            this.map7.TabStop = false;
            this.map7.Visible = false;
            // 
            // map6
            // 
            this.map6.Image = ((System.Drawing.Image)(resources.GetObject("map6.Image")));
            this.map6.Location = new System.Drawing.Point(359, 380);
            this.map6.Name = "map6";
            this.map6.Size = new System.Drawing.Size(50, 50);
            this.map6.TabIndex = 32;
            this.map6.TabStop = false;
            this.map6.Visible = false;
            // 
            // map5
            // 
            this.map5.Image = ((System.Drawing.Image)(resources.GetObject("map5.Image")));
            this.map5.Location = new System.Drawing.Point(307, 380);
            this.map5.Name = "map5";
            this.map5.Size = new System.Drawing.Size(50, 50);
            this.map5.TabIndex = 31;
            this.map5.TabStop = false;
            this.map5.Visible = false;
            // 
            // map10
            // 
            this.map10.Image = global::MathDrillGame.Properties.Resources.endX;
            this.map10.Location = new System.Drawing.Point(569, 380);
            this.map10.Name = "map10";
            this.map10.Size = new System.Drawing.Size(50, 50);
            this.map10.TabIndex = 36;
            this.map10.TabStop = false;
            this.map10.Visible = false;
            // 
            // map9
            // 
            this.map9.Image = ((System.Drawing.Image)(resources.GetObject("map9.Image")));
            this.map9.Location = new System.Drawing.Point(517, 380);
            this.map9.Name = "map9";
            this.map9.Size = new System.Drawing.Size(50, 50);
            this.map9.TabIndex = 35;
            this.map9.TabStop = false;
            this.map9.Visible = false;
            // 
            // StudentForm
            // 
            this.AcceptButton = this.buttonSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MathDrillGame.Properties.Resources._12;
            this.CancelButton = this.buttonLogout;
            this.ClientSize = new System.Drawing.Size(704, 512);
            this.Controls.Add(this.map10);
            this.Controls.Add(this.map9);
            this.Controls.Add(this.map8);
            this.Controls.Add(this.map7);
            this.Controls.Add(this.map6);
            this.Controls.Add(this.map5);
            this.Controls.Add(this.map4);
            this.Controls.Add(this.map3);
            this.Controls.Add(this.map2);
            this.Controls.Add(this.map1);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox1);
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
            this.Text = "Math Treasure - Student";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map9)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.PictureBox map2;
        private System.Windows.Forms.PictureBox map1;
        private System.Windows.Forms.PictureBox map4;
        private System.Windows.Forms.PictureBox map3;
        private System.Windows.Forms.PictureBox map8;
        private System.Windows.Forms.PictureBox map7;
        private System.Windows.Forms.PictureBox map6;
        private System.Windows.Forms.PictureBox map5;
        private System.Windows.Forms.PictureBox map10;
        private System.Windows.Forms.PictureBox map9;
    }
}