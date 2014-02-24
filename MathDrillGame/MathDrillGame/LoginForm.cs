using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathDrillGame
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
            buildUserList();
        }



        //This would be replaced by reading XML. The only admin is the first user
        private void buildUserList()
        {
            Program.users.Add(new User(true, "Bill J. Admin", 101));
            Program.users.Add(new User(false, "Susan M. Doe", 102));
            Program.users.Add(new User(false, "Joe A. Doe", 103));
            Program.users.Add(new User(false, "Edgar L. Park", 104));
            Program.users.Add(new User(false, "Jane G. Kragen", 105));
            Program.users.Add(new User(false, "Matt Y. Herman", 106));
            Program.users.Add(new User(false, "Jessica Q. Booker", 107));
            Program.users.Add(new User(false, "Laura T. Gwinn", 108));
            Program.users.Add(new User(false, "Patrick D. Henry", 109));
            Program.users.Add(new User(false, "Megan P. Nelson", 110));
            Program.users.Add(new User(false, "Brian H. Noll", 111));
            listOfUsers.DataSource = Program.users; //The listbox will take elements from the users list
            listOfUsers.DisplayMember = "fullName"; //It will display the value in the fullName attribute
            listOfUsers.ValueMember = "userID";     //The return value for the selected element will be the userID value
        }


        //When a user in the list is selected, enable the login button (by default, it is disabled)
        private void listOfUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonLogin.Enabled = true;
        }

        //When the login button is clicked, open up the appropriate screen, depending on the user's class (Admin or Student).
        //This will hide the login form and display the new one.
        private void buttonLogin_Click(object sender, EventArgs e)
        {

            Program.currentUserIndex = Convert.ToInt32(listOfUsers.SelectedIndex);
            User currentUser = Program.users[Program.currentUserIndex];
            if (authUser(currentUser, ""))
                buildUserForm(Program.users[Program.currentUserIndex]);

        }

        //To be used for authentication later on. 
        private bool authUser(User user, string password)
        {
            return true;
        }

        //Depending on whether the user is an administrator or student, build the appropriate form and hide the login.
        private void buildUserForm(User user)
        {
            if (user.isAdmin)
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Tag = this; //Makes note of the current form (login form)
                adminForm.Show(this); //Pass the login form as a paramter, to access it later.
                Hide(); //Hide the login screen
            }
            else
            {
                StudentForm studentForm = new StudentForm();
                studentForm.Tag = this;
                studentForm.Show(this);
                Hide();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }//end Form1 class
}//end namespace
