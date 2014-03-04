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
            this.dataGridProblemSets = new System.Windows.Forms.DataGridView();
            this.textBoxReport = new System.Windows.Forms.TextBox();
            this.labelMinDate = new System.Windows.Forms.Label();
            this.labelMaxDate = new System.Windows.Forms.Label();
            this.labelSelectDate = new System.Windows.Forms.Label();
            this.checkBoxUnattempted = new System.Windows.Forms.CheckBox();
            this.dateTimePickerMax = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerMin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProblemSets)).BeginInit();
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
            this.labelSelectStudent.Location = new System.Drawing.Point(9, 3);
            this.labelSelectStudent.Name = "labelSelectStudent";
            this.labelSelectStudent.Size = new System.Drawing.Size(261, 17);
            this.labelSelectStudent.TabIndex = 1;
            this.labelSelectStudent.Text = "Select a student to generate reports for:";
            // 
            // buttonExit
            // 
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonExit.Location = new System.Drawing.Point(509, 414);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(178, 42);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // dataGridProblemSets
            // 
            this.dataGridProblemSets.AllowUserToAddRows = false;
            this.dataGridProblemSets.AllowUserToDeleteRows = false;
            this.dataGridProblemSets.AllowUserToOrderColumns = true;
            this.dataGridProblemSets.AllowUserToResizeRows = false;
            this.dataGridProblemSets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProblemSets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProblemSets.Location = new System.Drawing.Point(11, 219);
            this.dataGridProblemSets.Name = "dataGridProblemSets";
            this.dataGridProblemSets.ReadOnly = true;
            this.dataGridProblemSets.RowHeadersVisible = false;
            this.dataGridProblemSets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProblemSets.Size = new System.Drawing.Size(346, 189);
            this.dataGridProblemSets.TabIndex = 4;
            this.dataGridProblemSets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProblemSets_CellClick);
            // 
            // textBoxReport
            // 
            this.textBoxReport.Location = new System.Drawing.Point(394, 12);
            this.textBoxReport.Multiline = true;
            this.textBoxReport.Name = "textBoxReport";
            this.textBoxReport.ReadOnly = true;
            this.textBoxReport.Size = new System.Drawing.Size(344, 396);
            this.textBoxReport.TabIndex = 7;
            // 
            // labelMinDate
            // 
            this.labelMinDate.AutoSize = true;
            this.labelMinDate.Location = new System.Drawing.Point(9, 95);
            this.labelMinDate.Name = "labelMinDate";
            this.labelMinDate.Size = new System.Drawing.Size(70, 13);
            this.labelMinDate.TabIndex = 10;
            this.labelMinDate.Text = "Starting date:";
            // 
            // labelMaxDate
            // 
            this.labelMaxDate.AutoSize = true;
            this.labelMaxDate.Location = new System.Drawing.Point(203, 95);
            this.labelMaxDate.Name = "labelMaxDate";
            this.labelMaxDate.Size = new System.Drawing.Size(67, 13);
            this.labelMaxDate.TabIndex = 11;
            this.labelMaxDate.Text = "Ending date:";
            // 
            // labelSelectDate
            // 
            this.labelSelectDate.AutoSize = true;
            this.labelSelectDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSelectDate.Location = new System.Drawing.Point(9, 68);
            this.labelSelectDate.Name = "labelSelectDate";
            this.labelSelectDate.Size = new System.Drawing.Size(248, 17);
            this.labelSelectDate.TabIndex = 12;
            this.labelSelectDate.Text = "Select a timespan to see reports from:";
            // 
            // checkBoxUnattempted
            // 
            this.checkBoxUnattempted.AutoSize = true;
            this.checkBoxUnattempted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkBoxUnattempted.Location = new System.Drawing.Point(12, 146);
            this.checkBoxUnattempted.Name = "checkBoxUnattempted";
            this.checkBoxUnattempted.Size = new System.Drawing.Size(327, 17);
            this.checkBoxUnattempted.TabIndex = 13;
            this.checkBoxUnattempted.Text = "Check this box to include sets that have not yet been attempted";
            this.checkBoxUnattempted.UseVisualStyleBackColor = true;
            this.checkBoxUnattempted.CheckedChanged += new System.EventHandler(this.checkBoxUnattempted_CheckedChanged);
            // 
            // dateTimePickerMax
            // 
            this.dateTimePickerMax.Location = new System.Drawing.Point(206, 111);
            this.dateTimePickerMax.Name = "dateTimePickerMax";
            this.dateTimePickerMax.Size = new System.Drawing.Size(182, 20);
            this.dateTimePickerMax.TabIndex = 9;
            this.dateTimePickerMax.Value = new System.DateTime(2018, 7, 7, 4, 17, 0, 0);
            this.dateTimePickerMax.ValueChanged += new System.EventHandler(this.dateTimePickerMax_ValueChanged);
            // 
            // dateTimePickerMin
            // 
            this.dateTimePickerMin.Location = new System.Drawing.Point(12, 111);
            this.dateTimePickerMin.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerMin.Name = "dateTimePickerMin";
            this.dateTimePickerMin.Size = new System.Drawing.Size(180, 20);
            this.dateTimePickerMin.TabIndex = 8;
            this.dateTimePickerMin.ValueChanged += new System.EventHandler(this.dateTimePickerMin_ValueChanged);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(746, 529);
            this.Controls.Add(this.checkBoxUnattempted);
            this.Controls.Add(this.labelSelectDate);
            this.Controls.Add(this.labelMaxDate);
            this.Controls.Add(this.labelMinDate);
            this.Controls.Add(this.dateTimePickerMax);
            this.Controls.Add(this.dateTimePickerMin);
            this.Controls.Add(this.textBoxReport);
            this.Controls.Add(this.dataGridProblemSets);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelSelectStudent);
            this.Controls.Add(this.comboStudentList);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Math Drills - Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProblemSets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboStudentList;
        private System.Windows.Forms.Label labelSelectStudent;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.DataGridView dataGridProblemSets;
        private System.Windows.Forms.TextBox textBoxReport;
        private System.Windows.Forms.Label labelMinDate;
        private System.Windows.Forms.Label labelMaxDate;
        private System.Windows.Forms.Label labelSelectDate;
        private System.Windows.Forms.CheckBox checkBoxUnattempted;
        private System.Windows.Forms.DateTimePicker dateTimePickerMax;
        private System.Windows.Forms.DateTimePicker dateTimePickerMin;
    }
}