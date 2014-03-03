namespace MathDrillGame
{
    partial class ReportsForm
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
            this.comboStudentList = new System.Windows.Forms.ComboBox();
            this.labelSelectStudent = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelDiag = new System.Windows.Forms.Label();
            this.dataGridProblemSets = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.labelProblems = new System.Windows.Forms.Label();
            this.dataGridProblems = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProblemSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProblems)).BeginInit();
            this.SuspendLayout();
            // 
            // comboStudentList
            // 
            this.comboStudentList.FormattingEnabled = true;
            this.comboStudentList.Location = new System.Drawing.Point(12, 23);
            this.comboStudentList.Name = "comboStudentList";
            this.comboStudentList.Size = new System.Drawing.Size(262, 21);
            this.comboStudentList.TabIndex = 0;
            this.comboStudentList.SelectedIndexChanged += new System.EventHandler(this.comboStudentList_SelectedIndexChanged);
            // 
            // labelSelectStudent
            // 
            this.labelSelectStudent.AutoSize = true;
            this.labelSelectStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSelectStudent.Location = new System.Drawing.Point(13, 3);
            this.labelSelectStudent.Name = "labelSelectStudent";
            this.labelSelectStudent.Size = new System.Drawing.Size(261, 17);
            this.labelSelectStudent.TabIndex = 1;
            this.labelSelectStudent.Text = "Select a student to generate reports for:";
            // 
            // buttonExit
            // 
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonExit.Location = new System.Drawing.Point(423, 422);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(178, 42);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDiag
            // 
            this.labelDiag.AutoSize = true;
            this.labelDiag.Location = new System.Drawing.Point(12, 305);
            this.labelDiag.Name = "labelDiag";
            this.labelDiag.Size = new System.Drawing.Size(36, 13);
            this.labelDiag.TabIndex = 3;
            this.labelDiag.Text = "DIAG:";
            // 
            // dataGridProblemSets
            // 
            this.dataGridProblemSets.AllowUserToAddRows = false;
            this.dataGridProblemSets.AllowUserToDeleteRows = false;
            this.dataGridProblemSets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridProblemSets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProblemSets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select});
            this.dataGridProblemSets.Location = new System.Drawing.Point(13, 51);
            this.dataGridProblemSets.Name = "dataGridProblemSets";
            this.dataGridProblemSets.ReadOnly = true;
            this.dataGridProblemSets.Size = new System.Drawing.Size(304, 170);
            this.dataGridProblemSets.TabIndex = 4;
            this.dataGridProblemSets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProblemSets_CellContentClick);
            // 
            // select
            // 
            this.select.HeaderText = "Select";
            this.select.Name = "select";
            this.select.ReadOnly = true;
            this.select.Width = 43;
            // 
            // labelProblems
            // 
            this.labelProblems.AutoSize = true;
            this.labelProblems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelProblems.Location = new System.Drawing.Point(302, 24);
            this.labelProblems.Name = "labelProblems";
            this.labelProblems.Size = new System.Drawing.Size(166, 17);
            this.labelProblems.TabIndex = 5;
            this.labelProblems.Text = "Problems in selected set:";
            // 
            // dataGridProblems
            // 
            this.dataGridProblems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridProblems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProblems.Location = new System.Drawing.Point(337, 51);
            this.dataGridProblems.Name = "dataGridProblems";
            this.dataGridProblems.Size = new System.Drawing.Size(561, 343);
            this.dataGridProblems.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 322);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 142);
            this.textBox1.TabIndex = 7;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(900, 476);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridProblems);
            this.Controls.Add(this.labelProblems);
            this.Controls.Add(this.dataGridProblemSets);
            this.Controls.Add(this.labelDiag);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelSelectStudent);
            this.Controls.Add(this.comboStudentList);
            this.Name = "ReportsForm";
            this.Text = "Math Drills - Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProblemSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProblems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboStudentList;
        private System.Windows.Forms.Label labelSelectStudent;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelDiag;
        private System.Windows.Forms.DataGridView dataGridProblemSets;
        private System.Windows.Forms.DataGridViewButtonColumn select;
        private System.Windows.Forms.Label labelProblems;
        private System.Windows.Forms.DataGridView dataGridProblems;
        private System.Windows.Forms.TextBox textBox1;
    }
}