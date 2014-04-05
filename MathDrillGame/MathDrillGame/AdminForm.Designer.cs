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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.manageSaveChangesBtn = new System.Windows.Forms.Button();
            this.addUserToGroupBtn = new System.Windows.Forms.Button();
            this.delUserFromGroupBtn = new System.Windows.Forms.Button();
            this.manageGroupTabControl = new System.Windows.Forms.TabControl();
            this.GroupPageA = new System.Windows.Forms.TabPage();
            this.groupRosterA = new System.Windows.Forms.ListBox();
            this.GroupPageB = new System.Windows.Forms.TabPage();
            this.groupRosterB = new System.Windows.Forms.ListBox();
            this.GroupPageC = new System.Windows.Forms.TabPage();
            this.groupRosterC = new System.Windows.Forms.ListBox();
            this.manageStudentList = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStudentToClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeStudentFromClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.addStudentToClassToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeStudentFromClassToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addPage = new System.Windows.Forms.TabPage();
            this.securityPage = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.studentSecurityNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.studentsSecurityListBox = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.passwordCheckBox = new System.Windows.Forms.CheckBox();
            this.aboutPage = new System.Windows.Forms.TabPage();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.checkBoxUnattempted = new System.Windows.Forms.CheckBox();
            this.labelSelectDate = new System.Windows.Forms.Label();
            this.labelMaxDate = new System.Windows.Forms.Label();
            this.labelMinDate = new System.Windows.Forms.Label();
            this.dateTimePickerMax = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerMin = new System.Windows.Forms.DateTimePicker();
            this.textBoxReport = new System.Windows.Forms.TextBox();
            this.dataGridProblemSets = new System.Windows.Forms.DataGridView();
            this.labelSelectStudent = new System.Windows.Forms.Label();
            this.comboStudentList = new System.Windows.Forms.ComboBox();
            this.inputFullName = new System.Windows.Forms.TextBox();
            this.checkAdmin = new System.Windows.Forms.CheckBox();
            this.labelAdmin = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.reportsPage.SuspendLayout();
            this.genPage.SuspendLayout();
            this.Operation.SuspendLayout();
            this.manPage.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.manageGroupTabControl.SuspendLayout();
            this.GroupPageA.SuspendLayout();
            this.GroupPageB.SuspendLayout();
            this.GroupPageC.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.addPage.SuspendLayout();
            this.securityPage.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProblemSets)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.reportsPage);
            this.tabControl1.Controls.Add(this.genPage);
            this.tabControl1.Controls.Add(this.manPage);
            this.tabControl1.Controls.Add(this.addPage);
            this.tabControl1.Controls.Add(this.securityPage);
            this.tabControl1.Controls.Add(this.aboutPage);
            this.tabControl1.Location = new System.Drawing.Point(-5, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(707, 451);
            this.tabControl1.TabIndex = 100;
            // 
            // reportsPage
            // 
            this.reportsPage.Controls.Add(this.checkBoxUnattempted);
            this.reportsPage.Controls.Add(this.labelSelectDate);
            this.reportsPage.Controls.Add(this.labelMaxDate);
            this.reportsPage.Controls.Add(this.labelMinDate);
            this.reportsPage.Controls.Add(this.dateTimePickerMax);
            this.reportsPage.Controls.Add(this.dateTimePickerMin);
            this.reportsPage.Controls.Add(this.textBoxReport);
            this.reportsPage.Controls.Add(this.dataGridProblemSets);
            this.reportsPage.Controls.Add(this.labelSelectStudent);
            this.reportsPage.Controls.Add(this.comboStudentList);
            this.reportsPage.Location = new System.Drawing.Point(4, 22);
            this.reportsPage.Name = "reportsPage";
            this.reportsPage.Padding = new System.Windows.Forms.Padding(3);
            this.reportsPage.Size = new System.Drawing.Size(699, 425);
            this.reportsPage.TabIndex = 0;
            this.reportsPage.Text = "Reports";
            this.reportsPage.UseVisualStyleBackColor = true;
            // 
            // genPage
            // 
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
            this.genPage.Size = new System.Drawing.Size(699, 425);
            this.genPage.TabIndex = 1;
            this.genPage.Text = "Set Problems";
            this.genPage.UseVisualStyleBackColor = true;
            // 
            // labelProbsGenned
            // 
            this.labelProbsGenned.AutoSize = true;
            this.labelProbsGenned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelProbsGenned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelProbsGenned.Location = new System.Drawing.Point(206, 142);
            this.labelProbsGenned.Name = "labelProbsGenned";
            this.labelProbsGenned.Size = new System.Drawing.Size(156, 20);
            this.labelProbsGenned.TabIndex = 107;
            this.labelProbsGenned.Text = "Problems generated:";
            // 
            // Operation
            // 
            this.Operation.Controls.Add(this.radioAddition);
            this.Operation.Controls.Add(this.radioSubtraction);
            this.Operation.Location = new System.Drawing.Point(456, 81);
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
            this.listOfProblems.Location = new System.Drawing.Point(210, 178);
            this.listOfProblems.Multiline = true;
            this.listOfProblems.Name = "listOfProblems";
            this.listOfProblems.ReadOnly = true;
            this.listOfProblems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listOfProblems.Size = new System.Drawing.Size(224, 198);
            this.listOfProblems.TabIndex = 106;
            this.listOfProblems.TabStop = false;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonGenerate.Location = new System.Drawing.Point(503, 323);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(116, 39);
            this.buttonGenerate.TabIndex = 105;
            this.buttonGenerate.Text = "Generate!";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // inputQuantity
            // 
            this.inputQuantity.Location = new System.Drawing.Point(598, 97);
            this.inputQuantity.Name = "inputQuantity";
            this.inputQuantity.Size = new System.Drawing.Size(86, 20);
            this.inputQuantity.TabIndex = 104;
            // 
            // inputMax
            // 
            this.inputMax.Location = new System.Drawing.Point(331, 101);
            this.inputMax.Name = "inputMax";
            this.inputMax.Size = new System.Drawing.Size(86, 20);
            this.inputMax.TabIndex = 102;
            // 
            // inputMin
            // 
            this.inputMin.Location = new System.Drawing.Point(210, 104);
            this.inputMin.Name = "inputMin";
            this.inputMin.Size = new System.Drawing.Size(86, 20);
            this.inputMin.TabIndex = 101;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(595, 81);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(49, 13);
            this.labelQuantity.TabIndex = 108;
            this.labelQuantity.Text = "Quantity:";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(328, 81);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(92, 13);
            this.labelMax.TabIndex = 109;
            this.labelMax.Text = "Maximum number:";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(207, 81);
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
            this.listOfStudents.Location = new System.Drawing.Point(3, 49);
            this.listOfStudents.Name = "listOfStudents";
            this.listOfStudents.Size = new System.Drawing.Size(178, 329);
            this.listOfStudents.TabIndex = 100;
            this.listOfStudents.SelectedIndexChanged += new System.EventHandler(this.listOfStudents_SelectedIndexChanged);
            this.listOfStudents.ValueMemberChanged += new System.EventHandler(this.listOfStudents_SelectedIndexChanged);
            // 
            // manPage
            // 
            this.manPage.Controls.Add(this.groupBox7);
            this.manPage.Controls.Add(this.manageGroupTabControl);
            this.manPage.Controls.Add(this.manageStudentList);
            this.manPage.Controls.Add(this.menuStrip1);
            this.manPage.Controls.Add(this.menuStrip2);
            this.manPage.Location = new System.Drawing.Point(4, 22);
            this.manPage.Name = "manPage";
            this.manPage.Padding = new System.Windows.Forms.Padding(3);
            this.manPage.Size = new System.Drawing.Size(699, 425);
            this.manPage.TabIndex = 2;
            this.manPage.Text = "Manage Users";
            this.manPage.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.manageSaveChangesBtn);
            this.groupBox7.Controls.Add(this.addUserToGroupBtn);
            this.groupBox7.Controls.Add(this.delUserFromGroupBtn);
            this.groupBox7.Location = new System.Drawing.Point(245, 129);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(171, 146);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Change Students";
            // 
            // manageSaveChangesBtn
            // 
            this.manageSaveChangesBtn.Location = new System.Drawing.Point(24, 101);
            this.manageSaveChangesBtn.Name = "manageSaveChangesBtn";
            this.manageSaveChangesBtn.Size = new System.Drawing.Size(124, 30);
            this.manageSaveChangesBtn.TabIndex = 4;
            this.manageSaveChangesBtn.Text = "Save Changes";
            this.manageSaveChangesBtn.UseVisualStyleBackColor = true;
            this.manageSaveChangesBtn.Click += new System.EventHandler(this.manageSaveChangesBtn_Click);
            // 
            // addUserToGroupBtn
            // 
            this.addUserToGroupBtn.Location = new System.Drawing.Point(24, 19);
            this.addUserToGroupBtn.Name = "addUserToGroupBtn";
            this.addUserToGroupBtn.Size = new System.Drawing.Size(124, 31);
            this.addUserToGroupBtn.TabIndex = 2;
            this.addUserToGroupBtn.Text = "Add To Group";
            this.addUserToGroupBtn.UseVisualStyleBackColor = true;
            this.addUserToGroupBtn.Click += new System.EventHandler(this.addUserToGroupBtn_Click);
            // 
            // delUserFromGroupBtn
            // 
            this.delUserFromGroupBtn.Location = new System.Drawing.Point(24, 64);
            this.delUserFromGroupBtn.Name = "delUserFromGroupBtn";
            this.delUserFromGroupBtn.Size = new System.Drawing.Size(124, 31);
            this.delUserFromGroupBtn.TabIndex = 3;
            this.delUserFromGroupBtn.Text = "Remove from Group";
            this.delUserFromGroupBtn.UseVisualStyleBackColor = true;
            this.delUserFromGroupBtn.Click += new System.EventHandler(this.delUserFromGroupBtn_Click);
            // 
            // manageGroupTabControl
            // 
            this.manageGroupTabControl.Controls.Add(this.GroupPageA);
            this.manageGroupTabControl.Controls.Add(this.GroupPageB);
            this.manageGroupTabControl.Controls.Add(this.GroupPageC);
            this.manageGroupTabControl.Location = new System.Drawing.Point(422, 67);
            this.manageGroupTabControl.Name = "manageGroupTabControl";
            this.manageGroupTabControl.SelectedIndex = 0;
            this.manageGroupTabControl.Size = new System.Drawing.Size(236, 329);
            this.manageGroupTabControl.TabIndex = 1;
            // 
            // GroupPageA
            // 
            this.GroupPageA.Controls.Add(this.groupRosterA);
            this.GroupPageA.Location = new System.Drawing.Point(4, 22);
            this.GroupPageA.Name = "GroupPageA";
            this.GroupPageA.Padding = new System.Windows.Forms.Padding(3);
            this.GroupPageA.Size = new System.Drawing.Size(228, 303);
            this.GroupPageA.TabIndex = 0;
            this.GroupPageA.Text = "Group A";
            this.GroupPageA.UseVisualStyleBackColor = true;
            // 
            // groupRosterA
            // 
            this.groupRosterA.FormattingEnabled = true;
            this.groupRosterA.Location = new System.Drawing.Point(0, 0);
            this.groupRosterA.Name = "groupRosterA";
            this.groupRosterA.Size = new System.Drawing.Size(226, 329);
            this.groupRosterA.TabIndex = 1;
            this.groupRosterA.SelectedIndexChanged += new System.EventHandler(this.groupRosterA_SelectedIndexChanged);
            // 
            // GroupPageB
            // 
            this.GroupPageB.Controls.Add(this.groupRosterB);
            this.GroupPageB.Location = new System.Drawing.Point(4, 22);
            this.GroupPageB.Name = "GroupPageB";
            this.GroupPageB.Padding = new System.Windows.Forms.Padding(3);
            this.GroupPageB.Size = new System.Drawing.Size(228, 303);
            this.GroupPageB.TabIndex = 1;
            this.GroupPageB.Text = "Group B";
            this.GroupPageB.UseVisualStyleBackColor = true;
            // 
            // groupRosterB
            // 
            this.groupRosterB.FormattingEnabled = true;
            this.groupRosterB.Location = new System.Drawing.Point(0, 0);
            this.groupRosterB.Name = "groupRosterB";
            this.groupRosterB.Size = new System.Drawing.Size(226, 420);
            this.groupRosterB.TabIndex = 2;
            this.groupRosterB.SelectedIndexChanged += new System.EventHandler(this.groupRosterB_SelectedIndexChanged);
            // 
            // GroupPageC
            // 
            this.GroupPageC.Controls.Add(this.groupRosterC);
            this.GroupPageC.Location = new System.Drawing.Point(4, 22);
            this.GroupPageC.Name = "GroupPageC";
            this.GroupPageC.Padding = new System.Windows.Forms.Padding(3);
            this.GroupPageC.Size = new System.Drawing.Size(228, 303);
            this.GroupPageC.TabIndex = 2;
            this.GroupPageC.Text = "Group C";
            this.GroupPageC.UseVisualStyleBackColor = true;
            // 
            // groupRosterC
            // 
            this.groupRosterC.FormattingEnabled = true;
            this.groupRosterC.Location = new System.Drawing.Point(0, 0);
            this.groupRosterC.Name = "groupRosterC";
            this.groupRosterC.Size = new System.Drawing.Size(226, 420);
            this.groupRosterC.TabIndex = 2;
            this.groupRosterC.SelectedIndexChanged += new System.EventHandler(this.groupRosterC_SelectedIndexChanged);
            // 
            // manageStudentList
            // 
            this.manageStudentList.FormattingEnabled = true;
            this.manageStudentList.Location = new System.Drawing.Point(13, 67);
            this.manageStudentList.Name = "manageStudentList";
            this.manageStudentList.Size = new System.Drawing.Size(226, 329);
            this.manageStudentList.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentToClassToolStripMenuItem,
            this.removeStudentFromClassToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.newToolStripMenuItem.Text = "New";
            // 
            // addStudentToClassToolStripMenuItem
            // 
            this.addStudentToClassToolStripMenuItem.Name = "addStudentToClassToolStripMenuItem";
            this.addStudentToClassToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.addStudentToClassToolStripMenuItem.Text = "Add Student To Class";
            // 
            // removeStudentFromClassToolStripMenuItem
            // 
            this.removeStudentFromClassToolStripMenuItem.Name = "removeStudentFromClassToolStripMenuItem";
            this.removeStudentFromClassToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.removeStudentFromClassToolStripMenuItem.Text = "Remove Student From Class";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentToClassToolStripMenuItem1,
            this.removeStudentFromClassToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(693, 24);
            this.menuStrip2.TabIndex = 6;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // addStudentToClassToolStripMenuItem1
            // 
            this.addStudentToClassToolStripMenuItem1.Name = "addStudentToClassToolStripMenuItem1";
            this.addStudentToClassToolStripMenuItem1.Size = new System.Drawing.Size(129, 20);
            this.addStudentToClassToolStripMenuItem1.Text = "Add Student to Class";
            // 
            // removeStudentFromClassToolStripMenuItem1
            // 
            this.removeStudentFromClassToolStripMenuItem1.Name = "removeStudentFromClassToolStripMenuItem1";
            this.removeStudentFromClassToolStripMenuItem1.Size = new System.Drawing.Size(165, 20);
            this.removeStudentFromClassToolStripMenuItem1.Text = "Remove Student from Class";
            // 
            // addPage
            // 
            this.addPage.Controls.Add(this.inputFullName);
            this.addPage.Controls.Add(this.checkAdmin);
            this.addPage.Controls.Add(this.labelAdmin);
            this.addPage.Controls.Add(this.labelName);
            this.addPage.Controls.Add(this.buttonClear);
            this.addPage.Controls.Add(this.buttonAddUser);
            this.addPage.Location = new System.Drawing.Point(4, 22);
            this.addPage.Name = "addPage";
            this.addPage.Size = new System.Drawing.Size(699, 425);
            this.addPage.TabIndex = 5;
            this.addPage.Text = "Add User";
            this.addPage.UseVisualStyleBackColor = true;
            // 
            // securityPage
            // 
            this.securityPage.Controls.Add(this.groupBox6);
            this.securityPage.Controls.Add(this.groupBox5);
            this.securityPage.Controls.Add(this.groupBox4);
            this.securityPage.Location = new System.Drawing.Point(4, 22);
            this.securityPage.Name = "securityPage";
            this.securityPage.Padding = new System.Windows.Forms.Padding(3);
            this.securityPage.Size = new System.Drawing.Size(699, 425);
            this.securityPage.TabIndex = 3;
            this.securityPage.Text = "Security";
            this.securityPage.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.studentSecurityNameLabel);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.comboBox1);
            this.groupBox6.Location = new System.Drawing.Point(432, 218);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 157);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Set Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Set Password";
            // 
            // studentSecurityNameLabel
            // 
            this.studentSecurityNameLabel.AutoSize = true;
            this.studentSecurityNameLabel.ForeColor = System.Drawing.Color.Red;
            this.studentSecurityNameLabel.Location = new System.Drawing.Point(106, 35);
            this.studentSecurityNameLabel.Name = "studentSecurityNameLabel";
            this.studentSecurityNameLabel.Size = new System.Drawing.Size(44, 13);
            this.studentSecurityNameLabel.TabIndex = 2;
            this.studentSecurityNameLabel.Text = "Student";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student Name:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Triangle",
            "Pentagon",
            "Circle"});
            this.comboBox1.Location = new System.Drawing.Point(101, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.studentsSecurityListBox);
            this.groupBox5.Location = new System.Drawing.Point(64, 59);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 316);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Students";
            // 
            // studentsSecurityListBox
            // 
            this.studentsSecurityListBox.FormattingEnabled = true;
            this.studentsSecurityListBox.Location = new System.Drawing.Point(29, 43);
            this.studentsSecurityListBox.Name = "studentsSecurityListBox";
            this.studentsSecurityListBox.Size = new System.Drawing.Size(134, 238);
            this.studentsSecurityListBox.TabIndex = 0;
            this.studentsSecurityListBox.SelectedIndexChanged += new System.EventHandler(this.studentsSecurityListBox_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.passwordCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(432, 59);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Class Password";
            // 
            // passwordCheckBox
            // 
            this.passwordCheckBox.AutoSize = true;
            this.passwordCheckBox.Location = new System.Drawing.Point(57, 43);
            this.passwordCheckBox.Name = "passwordCheckBox";
            this.passwordCheckBox.Size = new System.Drawing.Size(108, 17);
            this.passwordCheckBox.TabIndex = 0;
            this.passwordCheckBox.Text = "Enable Password";
            this.passwordCheckBox.UseVisualStyleBackColor = true;
            this.passwordCheckBox.CheckedChanged += new System.EventHandler(this.passwordCheckBox_CheckedChanged);
            // 
            // aboutPage
            // 
            this.aboutPage.Location = new System.Drawing.Point(4, 22);
            this.aboutPage.Name = "aboutPage";
            this.aboutPage.Size = new System.Drawing.Size(699, 425);
            this.aboutPage.TabIndex = 4;
            this.aboutPage.Text = "About";
            this.aboutPage.UseVisualStyleBackColor = true;
            // 
            // buttonLogout
            // 
            this.buttonLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLogout.Location = new System.Drawing.Point(455, 454);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(90, 43);
            this.buttonLogout.TabIndex = 112;
            this.buttonLogout.Text = "Log out";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click_1);
            // 
            // exit_button
            // 
            this.exit_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.exit_button.Location = new System.Drawing.Point(582, 454);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(90, 43);
            this.exit_button.TabIndex = 113;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // checkBoxUnattempted
            // 
            this.checkBoxUnattempted.AutoSize = true;
            this.checkBoxUnattempted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkBoxUnattempted.Location = new System.Drawing.Point(-12, 153);
            this.checkBoxUnattempted.Name = "checkBoxUnattempted";
            this.checkBoxUnattempted.Size = new System.Drawing.Size(327, 17);
            this.checkBoxUnattempted.TabIndex = 17;
            this.checkBoxUnattempted.Text = "Check this box to include sets that have not yet been attempted";
            this.checkBoxUnattempted.UseVisualStyleBackColor = true;
            // 
            // labelSelectDate
            // 
            this.labelSelectDate.AutoSize = true;
            this.labelSelectDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSelectDate.Location = new System.Drawing.Point(6, 68);
            this.labelSelectDate.Name = "labelSelectDate";
            this.labelSelectDate.Size = new System.Drawing.Size(248, 17);
            this.labelSelectDate.TabIndex = 22;
            this.labelSelectDate.Text = "Select a timespan to see reports from:";
            // 
            // labelMaxDate
            // 
            this.labelMaxDate.AutoSize = true;
            this.labelMaxDate.Location = new System.Drawing.Point(167, 102);
            this.labelMaxDate.Name = "labelMaxDate";
            this.labelMaxDate.Size = new System.Drawing.Size(67, 13);
            this.labelMaxDate.TabIndex = 21;
            this.labelMaxDate.Text = "Ending date:";
            // 
            // labelMinDate
            // 
            this.labelMinDate.AutoSize = true;
            this.labelMinDate.Location = new System.Drawing.Point(6, 102);
            this.labelMinDate.Name = "labelMinDate";
            this.labelMinDate.Size = new System.Drawing.Size(70, 13);
            this.labelMinDate.TabIndex = 20;
            this.labelMinDate.Text = "Starting date:";
            // 
            // dateTimePickerMax
            // 
            this.dateTimePickerMax.Location = new System.Drawing.Point(170, 118);
            this.dateTimePickerMax.Name = "dateTimePickerMax";
            this.dateTimePickerMax.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerMax.TabIndex = 16;
            this.dateTimePickerMax.Value = new System.DateTime(2018, 7, 7, 4, 17, 0, 0);
            // 
            // dateTimePickerMin
            // 
            this.dateTimePickerMin.Location = new System.Drawing.Point(7, 118);
            this.dateTimePickerMin.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerMin.Name = "dateTimePickerMin";
            this.dateTimePickerMin.Size = new System.Drawing.Size(138, 20);
            this.dateTimePickerMin.TabIndex = 14;
            // 
            // textBoxReport
            // 
            this.textBoxReport.Location = new System.Drawing.Point(376, 19);
            this.textBoxReport.Multiline = true;
            this.textBoxReport.Name = "textBoxReport";
            this.textBoxReport.ReadOnly = true;
            this.textBoxReport.Size = new System.Drawing.Size(315, 396);
            this.textBoxReport.TabIndex = 19;
            // 
            // dataGridProblemSets
            // 
            this.dataGridProblemSets.AllowUserToAddRows = false;
            this.dataGridProblemSets.AllowUserToDeleteRows = false;
            this.dataGridProblemSets.AllowUserToOrderColumns = true;
            this.dataGridProblemSets.AllowUserToResizeRows = false;
            this.dataGridProblemSets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProblemSets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProblemSets.Location = new System.Drawing.Point(6, 176);
            this.dataGridProblemSets.Name = "dataGridProblemSets";
            this.dataGridProblemSets.ReadOnly = true;
            this.dataGridProblemSets.RowHeadersVisible = false;
            this.dataGridProblemSets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProblemSets.Size = new System.Drawing.Size(304, 239);
            this.dataGridProblemSets.TabIndex = 18;
            // 
            // labelSelectStudent
            // 
            this.labelSelectStudent.AutoSize = true;
            this.labelSelectStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSelectStudent.Location = new System.Drawing.Point(4, 10);
            this.labelSelectStudent.Name = "labelSelectStudent";
            this.labelSelectStudent.Size = new System.Drawing.Size(261, 17);
            this.labelSelectStudent.TabIndex = 15;
            this.labelSelectStudent.Text = "Select a student to generate reports for:";
            // 
            // comboStudentList
            // 
            this.comboStudentList.FormattingEnabled = true;
            this.comboStudentList.Location = new System.Drawing.Point(7, 30);
            this.comboStudentList.Name = "comboStudentList";
            this.comboStudentList.Size = new System.Drawing.Size(220, 21);
            this.comboStudentList.TabIndex = 13;
            // 
            // inputFullName
            // 
            this.inputFullName.Location = new System.Drawing.Point(360, 154);
            this.inputFullName.Name = "inputFullName";
            this.inputFullName.Size = new System.Drawing.Size(100, 20);
            this.inputFullName.TabIndex = 5;
            // 
            // checkAdmin
            // 
            this.checkAdmin.AutoSize = true;
            this.checkAdmin.Location = new System.Drawing.Point(366, 195);
            this.checkAdmin.Name = "checkAdmin";
            this.checkAdmin.Size = new System.Drawing.Size(44, 17);
            this.checkAdmin.TabIndex = 6;
            this.checkAdmin.Text = "Yes";
            this.checkAdmin.UseVisualStyleBackColor = true;
            // 
            // labelAdmin
            // 
            this.labelAdmin.AutoSize = true;
            this.labelAdmin.Location = new System.Drawing.Point(217, 195);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(139, 13);
            this.labelAdmin.TabIndex = 9;
            this.labelAdmin.Text = "Is the user an administrator?";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(217, 161);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(126, 13);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "What is the user\'s name?";
            // 
            // buttonClear
            // 
            this.buttonClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonClear.Location = new System.Drawing.Point(220, 228);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(121, 42);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Cancel";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonAddUser.Location = new System.Drawing.Point(360, 228);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(121, 42);
            this.buttonAddUser.TabIndex = 8;
            this.buttonAddUser.Text = "Save";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 512);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Math Drills - Administrator";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.reportsPage.ResumeLayout(false);
            this.reportsPage.PerformLayout();
            this.genPage.ResumeLayout(false);
            this.genPage.PerformLayout();
            this.Operation.ResumeLayout(false);
            this.Operation.PerformLayout();
            this.manPage.ResumeLayout(false);
            this.manPage.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.manageGroupTabControl.ResumeLayout(false);
            this.GroupPageA.ResumeLayout(false);
            this.GroupPageB.ResumeLayout(false);
            this.GroupPageC.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.addPage.ResumeLayout(false);
            this.addPage.PerformLayout();
            this.securityPage.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProblemSets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage reportsPage;   //reports
        private System.Windows.Forms.TabPage genPage;       //generate
        private System.Windows.Forms.TabPage manPage;       //manage
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
        private System.Windows.Forms.TabControl manageGroupTabControl;        //sub tab control for manage
        private System.Windows.Forms.TabPage GroupPageA;              //group #
        private System.Windows.Forms.ListBox groupRosterA;              //roster for group
        private System.Windows.Forms.TabPage GroupPageB;              //group #
        private System.Windows.Forms.ListBox manageStudentList;     //roster for group 
        private System.Windows.Forms.Button delUserFromGroupBtn;    //remove button
        private System.Windows.Forms.Button addUserToGroupBtn;
        private System.Windows.Forms.Button manageSaveChangesBtn;
        private System.Windows.Forms.ListBox groupRosterB;
        private System.Windows.Forms.TabPage GroupPageC;
        private System.Windows.Forms.ListBox groupRosterC;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStudentToClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeStudentFromClassToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem addStudentToClassToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeStudentFromClassToolStripMenuItem1;
        private System.Windows.Forms.TabPage securityPage;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox studentsSecurityListBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox passwordCheckBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label studentSecurityNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.TabPage aboutPage;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TabPage addPage;
        private System.Windows.Forms.CheckBox checkBoxUnattempted;
        private System.Windows.Forms.Label labelSelectDate;
        private System.Windows.Forms.Label labelMaxDate;
        private System.Windows.Forms.Label labelMinDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerMax;
        private System.Windows.Forms.DateTimePicker dateTimePickerMin;
        private System.Windows.Forms.TextBox textBoxReport;
        private System.Windows.Forms.DataGridView dataGridProblemSets;
        private System.Windows.Forms.Label labelSelectStudent;
        private System.Windows.Forms.ComboBox comboStudentList;
        private System.Windows.Forms.TextBox inputFullName;
        private System.Windows.Forms.CheckBox checkAdmin;
        private System.Windows.Forms.Label labelAdmin;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonAddUser;
    }
}