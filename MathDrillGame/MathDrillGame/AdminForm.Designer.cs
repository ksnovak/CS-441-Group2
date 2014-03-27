//holy fucking shit this thing is a mess kill me
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.reportsPage = new System.Windows.Forms.TabPage();
            this.genPage = new System.Windows.Forms.TabPage();
            this.buttonReports = new System.Windows.Forms.Button();
            this.buttonNewUser = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelProbsGenned = new System.Windows.Forms.Label();
            this.Operation = new System.Windows.Forms.GroupBox();
            this.radioAddition = new System.Windows.Forms.RadioButton();
            this.radioSubtraction = new System.Windows.Forms.RadioButton();
            this.listOfProblems = new System.Windows.Forms.TextBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.inputQuantity = new System.Windows.Forms.TextBox();
            this.inputMax = new System.Windows.Forms.TextBox();
            this.inputMin = new System.Windows.Forms.TextBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelGenProblemsFor = new System.Windows.Forms.Label();
            this.listOfStudents = new System.Windows.Forms.ListBox();
            this.manPage = new System.Windows.Forms.TabPage();
            this.manageSaveChangesBtn = new System.Windows.Forms.Button();
            this.delUserFromGroupBtn = new System.Windows.Forms.Button();
            this.addUserToGroupBtn = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.Group1 = new System.Windows.Forms.TabPage();
            this.groupRoster1 = new System.Windows.Forms.ListBox();
            this.Group2 = new System.Windows.Forms.TabPage();
            this.manageStudentList = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabControl1.SuspendLayout();
            this.genPage.SuspendLayout();
            this.Operation.SuspendLayout();
            this.manPage.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.Group1.SuspendLayout();
            this.Group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.reportsPage);
            this.tabControl1.Controls.Add(this.genPage);
            this.tabControl1.Controls.Add(this.manPage);
            this.tabControl1.Location = new System.Drawing.Point(-5, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(707, 508);
            this.tabControl1.TabIndex = 100;
            // 
            // reportsPage
            // 
            this.reportsPage.Location = new System.Drawing.Point(4, 22);
            this.reportsPage.Name = "reportsPage";
            this.reportsPage.Padding = new System.Windows.Forms.Padding(3);
            this.reportsPage.Size = new System.Drawing.Size(699, 482);
            this.reportsPage.TabIndex = 0;
            this.reportsPage.Text = "Reports";
            this.reportsPage.UseVisualStyleBackColor = true;
            // 
            // genPage
            // 
            this.genPage.Controls.Add(this.buttonReports);
            this.genPage.Controls.Add(this.buttonNewUser);
            this.genPage.Controls.Add(this.buttonLogout);
            this.genPage.Controls.Add(this.labelProbsGenned);
            this.genPage.Controls.Add(this.Operation);
            this.genPage.Controls.Add(this.listOfProblems);
            this.genPage.Controls.Add(this.buttonGenerate);
            this.genPage.Controls.Add(this.inputQuantity);
            this.genPage.Controls.Add(this.inputMax);
            this.genPage.Controls.Add(this.inputMin);
            this.genPage.Controls.Add(this.labelQuantity);
            this.genPage.Controls.Add(this.labelMax);
            this.genPage.Controls.Add(this.labelMin);
            this.genPage.Controls.Add(this.labelGenProblemsFor);
            this.genPage.Controls.Add(this.listOfStudents);
            this.genPage.Location = new System.Drawing.Point(4, 22);
            this.genPage.Name = "genPage";
            this.genPage.Padding = new System.Windows.Forms.Padding(3);
            this.genPage.Size = new System.Drawing.Size(699, 482);
            this.genPage.TabIndex = 1;
            this.genPage.Text = "Generate";
            this.genPage.UseVisualStyleBackColor = true;
            // 
            // buttonReports
            // 
            this.buttonReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonReports.Location = new System.Drawing.Point(6, 368);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(178, 42);
            this.buttonReports.TabIndex = 113;
            this.buttonReports.Text = "Reports";
            this.buttonReports.UseVisualStyleBackColor = true;
            // 
            // buttonNewUser
            // 
            this.buttonNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNewUser.Location = new System.Drawing.Point(6, 416);
            this.buttonNewUser.Name = "buttonNewUser";
            this.buttonNewUser.Size = new System.Drawing.Size(178, 42);
            this.buttonNewUser.TabIndex = 114;
            this.buttonNewUser.Text = "Add new user";
            this.buttonNewUser.UseVisualStyleBackColor = true;
            // 
            // buttonLogout
            // 
            this.buttonLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLogout.Location = new System.Drawing.Point(603, 426);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(90, 43);
            this.buttonLogout.TabIndex = 112;
            this.buttonLogout.Text = "Log out";
            this.buttonLogout.UseVisualStyleBackColor = true;
            // 
            // labelProbsGenned
            // 
            this.labelProbsGenned.AutoSize = true;
            this.labelProbsGenned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelProbsGenned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelProbsGenned.Location = new System.Drawing.Point(206, 127);
            this.labelProbsGenned.Name = "labelProbsGenned";
            this.labelProbsGenned.Size = new System.Drawing.Size(156, 20);
            this.labelProbsGenned.TabIndex = 107;
            this.labelProbsGenned.Text = "Problems generated:";
            // 
            // Operation
            // 
            this.Operation.Controls.Add(this.radioAddition);
            this.Operation.Controls.Add(this.radioSubtraction);
            this.Operation.Location = new System.Drawing.Point(451, 62);
            this.Operation.Name = "Operation";
            this.Operation.Size = new System.Drawing.Size(110, 100);
            this.Operation.TabIndex = 103;
            this.Operation.TabStop = false;
            this.Operation.Text = "Operation:";
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
            this.listOfProblems.Location = new System.Drawing.Point(210, 150);
            this.listOfProblems.Multiline = true;
            this.listOfProblems.Name = "listOfProblems";
            this.listOfProblems.ReadOnly = true;
            this.listOfProblems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listOfProblems.Size = new System.Drawing.Size(224, 284);
            this.listOfProblems.TabIndex = 106;
            this.listOfProblems.TabStop = false;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonGenerate.Location = new System.Drawing.Point(503, 191);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(116, 39);
            this.buttonGenerate.TabIndex = 105;
            this.buttonGenerate.Text = "Generate!";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            // 
            // inputQuantity
            // 
            this.inputQuantity.Location = new System.Drawing.Point(598, 88);
            this.inputQuantity.Name = "inputQuantity";
            this.inputQuantity.Size = new System.Drawing.Size(86, 20);
            this.inputQuantity.TabIndex = 104;
            // 
            // inputMax
            // 
            this.inputMax.Location = new System.Drawing.Point(331, 88);
            this.inputMax.Name = "inputMax";
            this.inputMax.Size = new System.Drawing.Size(86, 20);
            this.inputMax.TabIndex = 102;
            // 
            // inputMin
            // 
            this.inputMin.Location = new System.Drawing.Point(210, 88);
            this.inputMin.Name = "inputMin";
            this.inputMin.Size = new System.Drawing.Size(86, 20);
            this.inputMin.TabIndex = 101;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(595, 62);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(46, 13);
            this.labelQuantity.TabIndex = 108;
            this.labelQuantity.Text = "Quantity";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(328, 62);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(92, 13);
            this.labelMax.TabIndex = 109;
            this.labelMax.Text = "Maximum number:";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(207, 62);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(89, 13);
            this.labelMin.TabIndex = 110;
            this.labelMin.Text = "Minimum number:";
            // 
            // labelGenProblemsFor
            // 
            this.labelGenProblemsFor.AutoSize = true;
            this.labelGenProblemsFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelGenProblemsFor.Location = new System.Drawing.Point(259, 20);
            this.labelGenProblemsFor.Name = "labelGenProblemsFor";
            this.labelGenProblemsFor.Size = new System.Drawing.Size(360, 25);
            this.labelGenProblemsFor.TabIndex = 111;
            this.labelGenProblemsFor.Text = "Generating problems for Aaaa B. Ccccc.";
            // 
            // listOfStudents
            // 
            this.listOfStudents.FormattingEnabled = true;
            this.listOfStudents.Location = new System.Drawing.Point(6, 20);
            this.listOfStudents.Name = "listOfStudents";
            this.listOfStudents.Size = new System.Drawing.Size(178, 342);
            this.listOfStudents.TabIndex = 100;
            // 
            // manPage
            // 
            this.manPage.Controls.Add(this.manageSaveChangesBtn);
            this.manPage.Controls.Add(this.delUserFromGroupBtn);
            this.manPage.Controls.Add(this.addUserToGroupBtn);
            this.manPage.Controls.Add(this.tabControl2);
            this.manPage.Controls.Add(this.manageStudentList);
            this.manPage.Location = new System.Drawing.Point(4, 22);
            this.manPage.Name = "manPage";
            this.manPage.Padding = new System.Windows.Forms.Padding(3);
            this.manPage.Size = new System.Drawing.Size(699, 482);
            this.manPage.TabIndex = 2;
            this.manPage.Text = "Manage Users";
            this.manPage.UseVisualStyleBackColor = true;
            // 
            // manageSaveChangesBtn
            // 
            this.manageSaveChangesBtn.Location = new System.Drawing.Point(269, 176);
            this.manageSaveChangesBtn.Name = "manageSaveChangesBtn";
            this.manageSaveChangesBtn.Size = new System.Drawing.Size(124, 30);
            this.manageSaveChangesBtn.TabIndex = 4;
            this.manageSaveChangesBtn.Text = "Save Changes";
            this.manageSaveChangesBtn.UseVisualStyleBackColor = true;
            this.manageSaveChangesBtn.Click += new System.EventHandler(this.manageSaveChangesBtn_Click);
            // 
            // delUserFromGroupBtn
            // 
            this.delUserFromGroupBtn.Location = new System.Drawing.Point(269, 123);
            this.delUserFromGroupBtn.Name = "delUserFromGroupBtn";
            this.delUserFromGroupBtn.Size = new System.Drawing.Size(124, 31);
            this.delUserFromGroupBtn.TabIndex = 3;
            this.delUserFromGroupBtn.Text = "Remove from Group";
            this.delUserFromGroupBtn.UseVisualStyleBackColor = true;
            this.delUserFromGroupBtn.Click += new System.EventHandler(this.delUserFromGroupBtn_Click);
            // 
            // addUserToGroupBtn
            // 
            this.addUserToGroupBtn.Location = new System.Drawing.Point(269, 86);
            this.addUserToGroupBtn.Name = "addUserToGroupBtn";
            this.addUserToGroupBtn.Size = new System.Drawing.Size(124, 31);
            this.addUserToGroupBtn.TabIndex = 2;
            this.addUserToGroupBtn.Text = "Add To Group";
            this.addUserToGroupBtn.UseVisualStyleBackColor = true;
            this.addUserToGroupBtn.Click += new System.EventHandler(this.addUserToGroupBtn_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.Group1);
            this.tabControl2.Controls.Add(this.Group2);
            this.tabControl2.Location = new System.Drawing.Point(422, 19);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(236, 442);
            this.tabControl2.TabIndex = 1;
            // 
            // Group1
            // 
            this.Group1.Controls.Add(this.groupRoster1);
            this.Group1.Location = new System.Drawing.Point(4, 22);
            this.Group1.Name = "Group1";
            this.Group1.Padding = new System.Windows.Forms.Padding(3);
            this.Group1.Size = new System.Drawing.Size(228, 416);
            this.Group1.TabIndex = 0;
            this.Group1.Text = "Group1";
            this.Group1.UseVisualStyleBackColor = true;
            // 
            // groupRoster1
            // 
            this.groupRoster1.FormattingEnabled = true;
            this.groupRoster1.Location = new System.Drawing.Point(0, 0);
            this.groupRoster1.Name = "groupRoster1";
            this.groupRoster1.Size = new System.Drawing.Size(226, 420);
            this.groupRoster1.TabIndex = 1;
            // 
            // Group2
            // 
            this.Group2.Controls.Add(this.listView1);
            this.Group2.Location = new System.Drawing.Point(4, 22);
            this.Group2.Name = "Group2";
            this.Group2.Padding = new System.Windows.Forms.Padding(3);
            this.Group2.Size = new System.Drawing.Size(228, 416);
            this.Group2.TabIndex = 1;
            this.Group2.Text = "Group2";
            this.Group2.UseVisualStyleBackColor = true;
            // 
            // manageStudentList
            // 
            this.manageStudentList.FormattingEnabled = true;
            this.manageStudentList.Location = new System.Drawing.Point(13, 41);
            this.manageStudentList.Name = "manageStudentList";
            this.manageStudentList.Size = new System.Drawing.Size(226, 420);
            this.manageStudentList.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(226, 416);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 504);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Math Drills - Administrator";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.genPage.ResumeLayout(false);
            this.genPage.PerformLayout();
            this.Operation.ResumeLayout(false);
            this.Operation.PerformLayout();
            this.manPage.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.Group1.ResumeLayout(false);
            this.Group2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage reportsPage;   //reports
        private System.Windows.Forms.TabPage genPage;       //generate
        private System.Windows.Forms.TabPage manPage;       //manage
        private System.Windows.Forms.Button buttonReports;
        private System.Windows.Forms.Button buttonNewUser;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label labelProbsGenned;
        private System.Windows.Forms.GroupBox Operation;
        private System.Windows.Forms.RadioButton radioAddition;
        private System.Windows.Forms.RadioButton radioSubtraction;
        private System.Windows.Forms.TextBox listOfProblems;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TextBox inputQuantity;
        private System.Windows.Forms.TextBox inputMax;
        private System.Windows.Forms.TextBox inputMin;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelGenProblemsFor;
        private System.Windows.Forms.ListBox listOfStudents;
        private System.Windows.Forms.TabControl tabControl2;        //sub tab control for manage
        private System.Windows.Forms.TabPage Group1;              //group #
        private System.Windows.Forms.ListBox groupRoster1;              //roster for group
        private System.Windows.Forms.TabPage Group2;              //group #
        private System.Windows.Forms.ListBox manageStudentList;     //roster for group 
        private System.Windows.Forms.Button delUserFromGroupBtn;    //remove button
        private System.Windows.Forms.Button addUserToGroupBtn;
        private System.Windows.Forms.Button manageSaveChangesBtn;
        private System.Windows.Forms.ListView listView1;
    }
}