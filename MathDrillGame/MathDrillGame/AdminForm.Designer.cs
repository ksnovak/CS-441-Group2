namespace MathDrillGame
{
    partial class AdminForm
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
            this.buttonLogout = new System.Windows.Forms.Button();
            this.listOfStudents = new System.Windows.Forms.ListBox();
            this.labelGenProblemsFor = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.inputMin = new System.Windows.Forms.TextBox();
            this.inputMax = new System.Windows.Forms.TextBox();
            this.inputQuantity = new System.Windows.Forms.TextBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.radioAddition = new System.Windows.Forms.RadioButton();
            this.radioSubtraction = new System.Windows.Forms.RadioButton();
            this.listOfProblems = new System.Windows.Forms.TextBox();
            this.Operation = new System.Windows.Forms.GroupBox();
            this.labelProbsGenned = new System.Windows.Forms.Label();
            this.buttonNewUser = new System.Windows.Forms.Button();
            this.buttonReports = new System.Windows.Forms.Button();
            this.Operation.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLogout.Location = new System.Drawing.Point(602, 440);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(90, 43);
            this.buttonLogout.TabIndex = 9;
            this.buttonLogout.Text = "Log out";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // listOfStudents
            // 
            this.listOfStudents.FormattingEnabled = true;
            this.listOfStudents.Location = new System.Drawing.Point(12, 12);
            this.listOfStudents.Name = "listOfStudents";
            this.listOfStudents.Size = new System.Drawing.Size(179, 368);
            this.listOfStudents.TabIndex = 0;
            this.listOfStudents.SelectedIndexChanged += new System.EventHandler(this.listOfStudents_SelectedIndexChanged);
            // 
            // labelGenProblemsFor
            // 
            this.labelGenProblemsFor.AutoSize = true;
            this.labelGenProblemsFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelGenProblemsFor.Location = new System.Drawing.Point(279, 28);
            this.labelGenProblemsFor.Name = "labelGenProblemsFor";
            this.labelGenProblemsFor.Size = new System.Drawing.Size(360, 25);
            this.labelGenProblemsFor.TabIndex = 99;
            this.labelGenProblemsFor.Text = "Generating problems for Aaaa B. Ccccc.";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(215, 94);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(89, 13);
            this.labelMin.TabIndex = 98;
            this.labelMin.Text = "Minimum number:";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(336, 94);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(92, 13);
            this.labelMax.TabIndex = 97;
            this.labelMax.Text = "Maximum number:";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(603, 94);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(46, 13);
            this.labelQuantity.TabIndex = 96;
            this.labelQuantity.Text = "Quantity";
            // 
            // inputMin
            // 
            this.inputMin.Location = new System.Drawing.Point(218, 120);
            this.inputMin.Name = "inputMin";
            this.inputMin.Size = new System.Drawing.Size(86, 20);
            this.inputMin.TabIndex = 1;
            // 
            // inputMax
            // 
            this.inputMax.Location = new System.Drawing.Point(339, 120);
            this.inputMax.Name = "inputMax";
            this.inputMax.Size = new System.Drawing.Size(86, 20);
            this.inputMax.TabIndex = 2;
            // 
            // inputQuantity
            // 
            this.inputQuantity.Location = new System.Drawing.Point(606, 120);
            this.inputQuantity.Name = "inputQuantity";
            this.inputQuantity.Size = new System.Drawing.Size(86, 20);
            this.inputQuantity.TabIndex = 4;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonGenerate.Location = new System.Drawing.Point(576, 233);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(116, 39);
            this.buttonGenerate.TabIndex = 6;
            this.buttonGenerate.Text = "Generate!";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // radioAddition
            // 
            this.radioAddition.AutoSize = true;
            this.radioAddition.Checked = true;
            this.radioAddition.Location = new System.Drawing.Point(6, 19);
            this.radioAddition.Name = "radioAddition";
            this.radioAddition.Size = new System.Drawing.Size(63, 17);
            this.radioAddition.TabIndex = 12;
            this.radioAddition.TabStop = true;
            this.radioAddition.Text = "Addition";
            this.radioAddition.UseVisualStyleBackColor = true;
            // 
            // radioSubtraction
            // 
            this.radioSubtraction.AutoSize = true;
            this.radioSubtraction.Location = new System.Drawing.Point(6, 42);
            this.radioSubtraction.Name = "radioSubtraction";
            this.radioSubtraction.Size = new System.Drawing.Size(79, 17);
            this.radioSubtraction.TabIndex = 13;
            this.radioSubtraction.Text = "Subtraction";
            this.radioSubtraction.UseVisualStyleBackColor = true;
            // 
            // listOfProblems
            // 
            this.listOfProblems.Location = new System.Drawing.Point(218, 211);
            this.listOfProblems.Multiline = true;
            this.listOfProblems.Name = "listOfProblems";
            this.listOfProblems.ReadOnly = true;
            this.listOfProblems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listOfProblems.Size = new System.Drawing.Size(224, 284);
            this.listOfProblems.TabIndex = 14;
            this.listOfProblems.TabStop = false;
            // 
            // Operation
            // 
            this.Operation.Controls.Add(this.radioAddition);
            this.Operation.Controls.Add(this.radioSubtraction);
            this.Operation.Location = new System.Drawing.Point(459, 94);
            this.Operation.Name = "Operation";
            this.Operation.Size = new System.Drawing.Size(110, 100);
            this.Operation.TabIndex = 3;
            this.Operation.TabStop = false;
            this.Operation.Text = "Operation:";
            // 
            // labelProbsGenned
            // 
            this.labelProbsGenned.AutoSize = true;
            this.labelProbsGenned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelProbsGenned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelProbsGenned.Location = new System.Drawing.Point(214, 188);
            this.labelProbsGenned.Name = "labelProbsGenned";
            this.labelProbsGenned.Size = new System.Drawing.Size(156, 20);
            this.labelProbsGenned.TabIndex = 95;
            this.labelProbsGenned.Text = "Problems generated:";
            // 
            // buttonNewUser
            // 
            this.buttonNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNewUser.Location = new System.Drawing.Point(13, 440);
            this.buttonNewUser.Name = "buttonNewUser";
            this.buttonNewUser.Size = new System.Drawing.Size(178, 42);
            this.buttonNewUser.TabIndex = 8;
            this.buttonNewUser.Text = "Add new user";
            this.buttonNewUser.UseVisualStyleBackColor = true;
            this.buttonNewUser.Click += new System.EventHandler(this.buttonNewUser_Click);
            // 
            // buttonReports
            // 
            this.buttonReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonReports.Location = new System.Drawing.Point(12, 392);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(178, 42);
            this.buttonReports.TabIndex = 7;
            this.buttonReports.Text = "Reports";
            this.buttonReports.UseVisualStyleBackColor = true;
            this.buttonReports.Click += new System.EventHandler(this.buttonReports_Click);
            // 
            // AdminForm
            // 
            this.AcceptButton = this.buttonGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonLogout;
            this.ClientSize = new System.Drawing.Size(702, 504);
            this.Controls.Add(this.buttonReports);
            this.Controls.Add(this.buttonNewUser);
            this.Controls.Add(this.labelProbsGenned);
            this.Controls.Add(this.Operation);
            this.Controls.Add(this.listOfProblems);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.inputQuantity);
            this.Controls.Add(this.inputMax);
            this.Controls.Add(this.inputMin);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.labelGenProblemsFor);
            this.Controls.Add(this.listOfStudents);
            this.Controls.Add(this.buttonLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Math Drills - Administrator";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.Operation.ResumeLayout(false);
            this.Operation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.ListBox listOfStudents;
        private System.Windows.Forms.Label labelGenProblemsFor;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.TextBox inputMin;
        private System.Windows.Forms.TextBox inputMax;
        private System.Windows.Forms.TextBox inputQuantity;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.RadioButton radioAddition;
        private System.Windows.Forms.RadioButton radioSubtraction;
        private System.Windows.Forms.TextBox listOfProblems;
        private System.Windows.Forms.GroupBox Operation;
        private System.Windows.Forms.Label labelProbsGenned;
        private System.Windows.Forms.Button buttonNewUser;
        private System.Windows.Forms.Button buttonReports;
    }
}