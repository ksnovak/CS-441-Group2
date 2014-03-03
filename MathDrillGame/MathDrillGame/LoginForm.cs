using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MathDrillGame
{
    public partial class LoginForm : Form
    {
        XElement studentListXML;
        public LoginForm()
        {
            InitializeComponent();
            buildUserList();
        }



        //Feed from the XML file into a List, the set of users.
        private void buildUserList()
        {
            studentListXML = XElement.Load(@"c:\users\public\MathDrills\users.xml");
            Program.users.Clear();
            foreach (XElement user in studentListXML.Descendants("Student"))
            {

                Program.users.Add(new User { isAdmin = (user.Element("IsAdmin").Value == "1"? true : false), 
                                            fullName = user.Element("FullName").Value, 
                                            userID = Convert.ToInt32(user.Element("UserID").Value)
                                            });
            }
            
            listOfUsers.DataSource = Program.users; //The listbox will take elements from the users list
            listOfUsers.DisplayMember = "getRoleAndName"; //It will display the value in the fullName attribute
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
            {
                //Search userlist for user, update lastLoggedIn
                DateTime now = DateTime.Now;
                studentListXML.Descendants("Student").ElementAt(Program.currentUserIndex).SetElementValue("LastLogin", now.ToString("G"));
                studentListXML.Save(@"c:\users\public\MathDrills\users.xml");
                buildUserForm(Program.users[Program.currentUserIndex]);
            }

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
            XElement doc = XElement.Load(@"c:\users\public\MathDrills\config.xml");
            doc.SetElementValue("NextValidUser", Program.nextUserID);
            doc.SetElementValue("NextValidSet", Program.nextProblemSetID);
            doc.Save(@"c:\users\public\MathDrills\config.xml");
                //studentProblemSet.Descendants("Problem").ElementAt(problemIndex).SetElementValue("Attempts", prevAttempts + 1);

            Application.Exit();
        }

    }//end Form1 class
}//end namespace
