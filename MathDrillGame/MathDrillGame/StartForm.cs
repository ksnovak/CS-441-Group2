/* Created: 3-17-14
 * Aurelio Arango
 * CS 441
 * 
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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }
        //Aurelio Arango
        //Exit application when exit button is pressed
        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Aurelio Arango
        //Calls start_form when student button is clicked, sets admin to false
        private void Student_Button_Click(object sender, EventArgs e)
        {
            bool admin = false;
            start_form(admin);
        }
        //Aurelio Arango
        //calls start_form when admin button is click, sets admin to true
        private void admin_button_Click(object sender, EventArgs e)
        {
            bool admin = true;
            start_form(admin);
        }
        //Aurelio Arango
        //This method takes a boolean if user is admin or not
        //Depending on user, it creates a form for the user if it does not exist otherwise it shows the form for the user
        private void start_form(bool user)
        {
            bool foundForm = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(AdminForm) && user)
                {
                    f.Show();
                    foundForm = true;
                    this.Hide();
                }
            }
            if (!foundForm)
            {
                //Tag is used so as to be able to refer back to this instance of the form later on
                if (user)
                {
                    AdminLoginForm adminForm = new AdminLoginForm();
                    adminForm.Tag = this;
                    adminForm.Show(this);
                    this.Hide();
                }
                else
                {
                    LoginForm loginform = new LoginForm();
                    loginform.Tag = this;
                    loginform.Show(this);
                    this.Hide();
                }
            }
        }
    }
}
