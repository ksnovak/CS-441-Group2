/* Aurelio Arango
 * 3-25-14
 * This form is to authenticate the current student and allows him/her to move to take the drills
 * 
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathDrillGame
{
    public partial class StudentLoginForm : Form
    {
        public StudentLoginForm()
        {
            InitializeComponent();
        }

        private void triangle_button_Click(object sender, EventArgs e)
        {

        }

        private void pentagon_button_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private bool authenticateUser(int itemclicked)
        {
            return false;
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
