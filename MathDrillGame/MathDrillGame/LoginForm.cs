/* CS 441
 * Created by: Kevin
 * Date:
 * 
 * Modification: Added on show(), onShown(), OnVisibleChanged()
 * date: 3-11-14
 * Name: Aurelio Arango
 * What/Why? Debugging for purposes of updating list.
 */




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

using System.Diagnostics;

/* The LOGINFORM form
 * This is the first screen shown to the user, although there is some background work done in Program.cs
 * This is where they identify themselves and enter the rest of the program.
 */

namespace MathDrillGame
{
    public partial class LoginForm : Form
    {
        int size =0;
        XElement studentListXML;
        public LoginForm()
        {
            InitializeComponent();
            buildUserList(); 
        }

        /* BUILDUSERLIST takes users from the XML file and stores them into a List<User>, primarily for displaying on the various List Boxes.
         * Forces a .clear() on the list of users first so that there will be no out-of-date or duplicate entries in the list.
         * For the List Box, it will display "Teacher - Bill J. Admin" or "Student - Susan M. Doe" but the value member is their unique ID
         * Uriah and Kevin
         */

        public void buildUserList()
        {
            //Debug.WriteLine("buildUserList"+(size++));
            studentListXML = XElement.Load(Program.USERSFILE);
            Program.users.Clear();
            foreach (XElement user in studentListXML.Descendants("Student"))
            {
                Program.users.Add(new User 
                { 
                    isAdmin = (user.Element("IsAdmin").Value == "1"? true : false), 
                    fullName = user.Element("FullName").Value, 
                    userID = Convert.ToInt32(user.Element("UserID").Value)                         
                });
            }

            //Link the list of users to the listBox
            listOfUsers.DataSource = Program.users; //This will link that List<Users> to the ListBox
            listOfUsers.DisplayMember = "getRoleAndName"; //What will be shown. Note, this is a function in the User class to show both the role and the name.
            listOfUsers.ValueMember = "userID";
        }

        /* When the LOG IN button is pressed, 
         * authenticate the user (for future cases where there is a password of some sorts), make note of the login time, and build the proper form (either Student or Admin)
         * Kevin and Uriah
         */
        private void buttonLogin_Click(object sender, EventArgs e)
        {

            Program.currentUserIndex = Convert.ToInt32(listOfUsers.SelectedIndex);
            User currentUser = Program.users[Program.currentUserIndex];
            if (authUser(currentUser, ""))
            {
                //Search userlist for user, update lastLoggedIn
                studentListXML.Descendants("Student").ElementAt(Program.currentUserIndex).SetElementValue("LastLogin", DateTime.Now.ToString("g"));
                studentListXML.Save(Program.USERSFILE);
                buildUserForm(Program.users[Program.currentUserIndex]);
            }
        }

        /* AUTHUSER will check the user's password against the entered password, for authentication uses later on.
         * Currently always returns true, but set up as preparation for the future
         * Kevin and Uriah
         */
        private bool authUser(User user, string password)
        {
            return true;
        }

        //Depending on whether the user is an administrator or student, build the appropriate form and hide the login.
        /* BUILDUSERFORM is called after the user is authenticated
         * It will create either the Administrator or Student form and display that.
         * Kevin and Uriah
         */
        private void buildUserForm(User user)
        {
            /*When trying to build the administrator form, checks if one already exists
             *If it does, just show that form, otherwise you'll create a new one
             */
            bool foundForm = false; 
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(AdminForm) && user.isAdmin)
                {
                    f.Show();
                    foundForm = true;
                    this.Hide();
                }
            }
            if (!foundForm)
            {
                //Tag is used so as to be able to refer back to this instance of the form later on
                if (user.isAdmin)
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Tag = this;
                    adminForm.Show(this);
                    this.Hide();
                }
                else
                {
                    StudentForm studentForm = new StudentForm();
                    studentForm.Tag = this;
                    studentForm.Show(this);
                    this.Hide();
                }
            }
        }

        /* When the EXIT button is clicked, do some last saving of data before exiting
         * currently just tracking the unique IDs for users and problem sets
         * Uriah and Kevin
         */
        /*
        private void buttonClose_Click(object sender, EventArgs e)
        {
            //XElement doc = XElement.Load(Program.CONFIGFILE);
            //doc.SetElementValue("NextValidUser", Program.nextUserID);
            //doc.SetElementValue("NextValidSet", Program.nextProblemSetID);
            //doc.Save(Program.CONFIGFILE);
            //Application.Exit();

           

        }*/
        //Aurelio Arango 3-18-14
        //On selection of teacher, listOfStudents updates.
        //
        private void listOfTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listOfUsers.Enabled = true;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            //Aurelio Arango 3-18-14
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(StartForm))
                {
                    f.Show();
                    this.Hide();
                }
            }

        }
        //Aurelio Arango
        //Debugging for update of list
        /*
        public new void Show()
        {
            
            //Debug.WriteLine("Show");
            base.Show();
        }
        //Aurelio Arango
        //Debugging for update of list
        protected override void  OnShown(EventArgs e)
        {
            //Debug.WriteLine("OnShow");
            buildUserList();
            base.OnShown(e);
        }
        //Aurelio Arango
        //Debugging for update of list
        protected override void OnVisibleChanged(EventArgs e)
        {
            //Debug.WriteLine("onvisible");
          
            buildUserList();
            base.OnVisibleChanged(e);
        }
        */
    }//end Form1 class
}//end namespace
