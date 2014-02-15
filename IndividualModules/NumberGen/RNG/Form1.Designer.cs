namespace RNG
{
    partial class Form1
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
            this.generateButton = new System.Windows.Forms.Button();
            this.minLabel = new System.Windows.Forms.Label();
            this.inputMin = new System.Windows.Forms.TextBox();
            this.inputMax = new System.Windows.Forms.TextBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.inputQuantity = new System.Windows.Forms.TextBox();
            this.outputProblems = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.operationLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.RadioButton();
            this.subButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(403, 375);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(206, 23);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate problems";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(346, 91);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(107, 13);
            this.minLabel.TabIndex = 1;
            this.minLabel.Text = "Enter minimum value:";
            // 
            // inputMin
            // 
            this.inputMin.Location = new System.Drawing.Point(349, 107);
            this.inputMin.Name = "inputMin";
            this.inputMin.Size = new System.Drawing.Size(100, 20);
            this.inputMin.TabIndex = 2;
            // 
            // inputMax
            // 
            this.inputMax.Location = new System.Drawing.Point(525, 107);
            this.inputMax.Name = "inputMax";
            this.inputMax.Size = new System.Drawing.Size(100, 20);
            this.inputMax.TabIndex = 3;
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(400, 165);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(189, 13);
            this.quantityLabel.TabIndex = 5;
            this.quantityLabel.Text = "Enter quantity of problems to generate:";
            // 
            // inputQuantity
            // 
            this.inputQuantity.Location = new System.Drawing.Point(436, 181);
            this.inputQuantity.Name = "inputQuantity";
            this.inputQuantity.Size = new System.Drawing.Size(100, 20);
            this.inputQuantity.TabIndex = 6;
            // 
            // outputProblems
            // 
            this.outputProblems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.outputProblems.Location = new System.Drawing.Point(13, 13);
            this.outputProblems.Multiline = true;
            this.outputProblems.Name = "outputProblems";
            this.outputProblems.ReadOnly = true;
            this.outputProblems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputProblems.Size = new System.Drawing.Size(320, 568);
            this.outputProblems.TabIndex = 7;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(344, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Problem set generator 2000";
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(522, 91);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(110, 13);
            this.maxLabel.TabIndex = 10;
            this.maxLabel.Text = "Enter maximum value:";
            // 
            // operationLabel
            // 
            this.operationLabel.AutoSize = true;
            this.operationLabel.Location = new System.Drawing.Point(419, 269);
            this.operationLabel.Name = "operationLabel";
            this.operationLabel.Size = new System.Drawing.Size(159, 13);
            this.operationLabel.TabIndex = 11;
            this.operationLabel.Text = "Select the operation to be done:";
            // 
            // addButton
            // 
            this.addButton.AutoSize = true;
            this.addButton.Checked = true;
            this.addButton.Location = new System.Drawing.Point(450, 285);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(63, 17);
            this.addButton.TabIndex = 12;
            this.addButton.TabStop = true;
            this.addButton.Text = "Addition";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // subButton
            // 
            this.subButton.AutoSize = true;
            this.subButton.Location = new System.Drawing.Point(450, 309);
            this.subButton.Name = "subButton";
            this.subButton.Size = new System.Drawing.Size(79, 17);
            this.subButton.TabIndex = 13;
            this.subButton.TabStop = true;
            this.subButton.Text = "Subtraction";
            this.subButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 587);
            this.Controls.Add(this.subButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.operationLabel);
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputProblems);
            this.Controls.Add(this.inputQuantity);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.inputMax);
            this.Controls.Add(this.inputMin);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.generateButton);
            this.MinimumSize = new System.Drawing.Size(641, 287);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.TextBox inputMin;
        private System.Windows.Forms.TextBox inputMax;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.TextBox inputQuantity;
        private System.Windows.Forms.TextBox outputProblems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.Label operationLabel;
        private System.Windows.Forms.RadioButton addButton;
        private System.Windows.Forms.RadioButton subButton;
    }
}

