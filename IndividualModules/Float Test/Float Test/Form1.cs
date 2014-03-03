using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Float_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int leftInput = Convert.ToInt32(textBox1.Text);
            int rightInput = Convert.ToInt32(textBox2.Text);
            double total = (float)leftInput / (float)rightInput;
            label1.Text = total + "";
        }
    }
}
