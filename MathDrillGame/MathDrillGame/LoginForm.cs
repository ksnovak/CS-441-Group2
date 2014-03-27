/* CS 441
 * Created by: Kevin
 * Date:
 * 
 * Modification: Added on show(), onShown(), OnVisibleChanged()
 * date: 3-11-14
 * Name: Aurelio Arango
 * What/Why? Debugging for purposes of updating list.
 * 
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
        //int size =0;
        XElement teachersListXML;
        public LoginForm()
        {
            InitializeComponent();
            buildTeacherList();
            //buildUserList(); //removed 3-25-14
        }

        /* BUILDUSERLIST takes users from the XML file and stores them into a List<User>, primarily for displaying on the various List Boxes.
         * Forces a .clear() on the list of users first so that there will be no out-of-date or duplicate entries in the list.
         * For the List Box, it will display "Teacher - Bill J. Admin" or "Student - Susan M. Doe" but the value member is their unique ID
         * Uriah and Kevin
         */

        //Not using this function anymore. We're not using different functions to populate Student and Teacher list.
        /*public void buildUserList()
        {
            //Debug.WriteLine("buildUserList"+(size++));
            studentListXML = XElement.Load(Program.USERSFILE);
            Program.users.Clear();
            foreach (XElement user in studentListXML.Descendants("Student"))
            {
                Program.users.Add(new User 
                { 
                    //isAdmin = (user.Element("IsAdmin").Value == "1"? true : false), 
                    fullName = user.Element("FullName").Value, 
                    userID = Convert.ToInt32(user.Element("UserID").Value)                         
                });
            }

            //Link the list of users to the listBox
            listOfUsers.DataSource = Program.users; //This will link that List<Users> to the ListBox
            listOfUsers.DisplayMember = "getRoleAndName"; //What will be shown. Note, this is a function in the User class to show both the role and the name.
            listOfUsers.ValueMember = "userID";
        }*/

        public void buildTeacherList()
        {
            teachersListXML = XElement.Load(Program.USERSFILE);
            Program.teachers.Clear();
            Debug.WriteLine("Show");
            foreach (XElement user in teachersListXML.Descendants("Teacher"))
            {
                string newName = user.Element("FullName").Value;
                string pass = user.Element("pass").Value;
                int userID = Convert.ToInt32(user.Element("UserID").Value);
                
                List<Student> studentList = getStudentList( user);
                Teacher tempTeacher = new Teacher(newName,userID,studentList,pass); 

                Program.teachers.Add(tempTeacher);
                //Debug.WriteLine(newName);
                //Debug.WriteLine(userID);

                /*Program.teachers.Add(new Teacher
                {
                    //isAdmin = (user.Element("IsAdmin").Value == "1"? true : false), 
                    fullName = user.Element("FullName").Value,
                    userID = Convert.ToInt32(user.Element("UserID").Value)
                   
                });*/
                
            }
            //listOfTeachers.DataSource = Program.users; //This will link that List<Users> to the ListBox
            listOfTeachers.DataSource = Program.teachers;
            listOfTeachers.DisplayMember = "getRoleAndName"; //What will be shown. Note, this is a function in the User class to show both the role and the name.
            listOfTeachers.ValueMember = "userID";

        }

        private List<Student> getStudentList(XElement userList)
        {
            List<Student> student_list = new List<Student>();
            foreach (XElement user in userList.Descendants("Student"))
            {
                //XElement user_student = user.Parent;
                //string userid = Parent.Name;
                
                    string user_name = user.Element("FullName").Value;
                    string user_id = user.Element("UserID").Value;
                    int user_id_int = Convert.ToInt32(user_id);
                    string user_group = user.Element("Group").Value;
                    string user_p = user.Element("pass").Value;
                    student_list.Add(new Student(user_name,user_id_int,user_group,user_p));
            }
            //Debug.WriteLine("done");

            return student_list;
        }

        /* When the LOG IN button is pressed, 
         * authenticate the user (for future cases where there is a password of some sorts), make note of the login time, and build the proper form (either Student or Admin)
         * Kevin and Uriah
         */
        private void buttonLogin_Click(object sender, EventArgs e)
        {

            Program.currentStudentIndex = Convert.ToInt32(listOfUsers.SelectedIndex);
            Program.currentUserIndex = Program.currentStudentIndex;
            //User currentUser = Program.students[Program.currentUserIndex];
            //Debug.WriteLine("Index"+Program.currentStudentIndex);
            //Debug.WriteLine("size"+Program.students.Count);

            Student currentStudent = Program.students[Program.currentStudentIndex];

            //Removed because students will authenticate in a different window
            //if (authUser(currentStudent, ""))
            //{
                //Search userlist for user, update lastLoggedIn
                //*********Rewrite************studentListXML.Descendants("Student").ElementAt(Program.currentUserIndex).SetElementValue("LastLogin", DateTime.Now.ToString("g"));
                //*********Rewrite************//studentListXML.Save(Program.USERSFILE);
               // buildUserForm(Program.users[Program.currentUserIndex]);
            //}
            buildStudentLoginForm();

        }
        //Aurelio Arango 3-25-14
        //This funtion creates a new Form in which the selected student needs to authenticate itself
        private void buildStudentLoginForm()
        {
            
            bool foundForm = false; 
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(StudentLoginForm))
                {
                    f.Show();
                    foundForm = true;
                    this.Hide();
                }
            }
            if (!foundForm)
            { 
                StudentLoginForm loginForm = new StudentLoginForm();
                loginForm.Tag = this;
                loginForm.Show(this);
                this.Hide();
                
            }
        }

        /* AUTHUSER will check the user's password against the entered password, for authentication uses later on.
         * Currently always returns true, but set up as preparation for the future
         * Kevin and Uriah
         */
        /*private bool authUser(Student user, string password)
        {
            return true;
        }*/

        //Depending on whether the user is an administrator or student, build the appropriate form and hide the login.
        /* BUILDUSERFORM is called after the user is authenticated
         * It will create either the Administrator or Student form and display that.
         * Kevin and Uriah
         */

        /*private void buildUserForm(User user)
        {
           // When trying to build the administrator form, checks if one already exists
             /If it does, just show that form, otherwise you'll create a new one
             //
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
        }*/


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
            //Debug.WriteLine(listOfTeachers.SelectedIndex);
            //Debug.WriteLine(Program.teachers.ElementAt(listOfTeachers.SelectedIndex).fullName);

            Program.currentTeacherIndex = Convert.ToInt32(listOfTeachers.SelectedIndex);//getting current user index
           // listOfUser.DataSource = Program.teachers.ElementAt(listOfTeachers.SelectedIndex).students;

            var source = new BindingSource();
            source.DataSource = Program.teachers.ElementAt(listOfTeachers.SelectedIndex).students;
            //Program.students.Clear();
            Program.students = Program.teachers.ElementAt(listOfTeachers.SelectedIndex).students;
            listOfUsers.DataSource = source;
            //listOfUsers.DataSource = Program.teachers.i;
            listOfUsers.DisplayMember = "fullName"; //What will be shown. Note, this is a function in the User class to show both the role and the name.
            listOfUsers.ValueMember = "userID";
            //getuser id from list of users
            //populate list

        }
        //Aurelio Arango
        //Method looks for previous form, displays it and hides current form
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
        //This funtion sets the current student that is selected from the list of users.
        private void listOfUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Debug.WriteLine(listOfUsers.SelectedIndex);
            Program.currentStudentIndex = Convert.ToInt32(listOfUsers.SelectedIndex);
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
