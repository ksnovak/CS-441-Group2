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
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(StartForm))
                {
                    f.Show();
                    this.Hide();
                }
            }
        }

        private void AdminUsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            passwordBox.Enabled = true;
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string password = passwordBox.Text;
            
            if(password.Equals("admin"))
            {
                AdminForm adminForm = new AdminForm();

            }
        }
    }
}
