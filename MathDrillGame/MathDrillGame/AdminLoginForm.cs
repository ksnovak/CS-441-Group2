/* CS 441
 * Created by: Aurelio Arango
 * Date: 3-18-14
 * 
 * Modification: Added buildteacherList
 * date: 3-20-14
 * Name: Aurelio Arango
 * What/Why? This method populates the AdminUserList, with the name of all the Teachers/Administrators
 * 
 * Modification: Added exit_button_Click
 * date: 3-20-14
 * Name: Aurelio Arango
 * What/Why? closes application when exit button is click
 * 
 * Modification: Added AdminUsersList_SelectedIndexChanged
 * date: 3-20-14
 * Name: Aurelio Arango
 * What/Why? This funtion updates the current teacher and enables the textbox
 * 
 * Modification: Added login_button_Click
 * date: 3-20-14
 * Name: Aurelio Arango
 * What/Why? This method collects password info from teacher and uthenticates that it is correct and the calls the create Form method
 * 
 * Modification: Added createForm
 * date: 3-20-14
 * Name: Aurelio Arango
 * What/Why? This method creates a new form for AdminForm if it does not exist, otherwise it sets it to visible
 * 
 * Modification: added getStudentList
 * date: 3-26-14
 * Name: Aurelio Arango
 * What/Why? This method gets the list of students for a given teacher before the teacher logs in.
 * 
 * Modification: getStudentList()
 * date: 3-26-14
 * Name: Aurelio Arango
 * What/Why? Creates a list of students based on the teacher
 * 
 * Modification: check for password in login_button_click
 * date: 3-26-14
 * Name: Aurelio Arango
 * What/Why? Added the functionality to check input password vs saved password
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

namespace MathDrillGame
{
    public partial class AdminLoginForm : Form
    {
        //XElement teachersListXML;//xml that holds teacher and students info

        public AdminLoginForm()
        {
            InitializeComponent();
            buildTeacherList();
            
        }

        //Aurelio Arango
        //This function builds teacher list xml
        private void buildTeacherList()
        {
            //Aurelio Arango No longer needed 4-5-14, xml_handler takes care of reading info
            /*teachersListXML = XElement.Load(Program.USERSFILE);
            Program.teachers.Clear();
            //Debug.WriteLine("Show");
            foreach (XElement user in teachersListXML.Descendants("Teacher"))
            {
                string newName = user.Element("FullName").Value;//getting teacher name
                int userID = Convert.ToInt32(user.Element("UserID").Value);//getting user name
                string pass = user.Element("pass").Value;//teacher password
                List<Student> studentList = getStudentList(user);//setting list of students to teacher object
                Teacher tempTeacher = new Teacher(newName, userID, studentList, pass);//creates a new teacher object
                Program.teachers.Add(tempTeacher);//adds new teacher to the list of teachers
            }*/
            AdminUsersList.DataSource = null;
            AdminUsersList.DataSource = Program.teachers;
            AdminUsersList.DisplayMember = "getRoleAndName"; //What will be shown. Note, this is a function in the User class to show both the role and the name.
            AdminUsersList.ValueMember = "userID";

        }
        //Aurelio Arango
        //This funtion returns a list of all "children" (Students) of the given teacher
       /* private List<Student> getStudentList(XElement userList)
        {
            List<Student> student_list = new List<Student>();
            foreach (XElement user in userList.Descendants("Student"))
            {
                
                    string user_name = user.Element("FullName").Value;
                    string user_id = user.Element("UserID").Value;
                    int user_id_int = Convert.ToInt32(user_id);
                    string user_group = user.Element("Group").Value;
                    string user_p = user.Element("pass").Value;
                    student_list.Add(new Student(user_name,user_id_int,user_group,user_p));
            }
            return student_list;
        }*/
        //Aurelio Arango
        //This funtion closes the app when exit button is click
        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Aurelio Arango
        //This function hides the current form and shows StartForm
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
        //Aurelio Arango
        //This funtion sets textbox input to true when an admin is selected
        //It also sets the current students from the selected administrator
        private void AdminUsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            passwordBox.Enabled = true;
            Program.currentTeacherIndex = Convert.ToInt32(AdminUsersList.SelectedIndex);
            var source = new BindingSource();
            Program.students = Program.teachers.ElementAt(AdminUsersList.SelectedIndex).students;
            /*for (int i = 0; i < Program.teachers.Count; i++)
            {
                for (int j = 0; j < Program.teachers[i].students.Count; j++)
                {
                    Debug.WriteLine(Program.teachers[i].students[j].fullName);
                    Debug.WriteLine(Program.teachers[i].students[j].invisible);
                }
            }*/
        }
        //Aurelio Arango
        //This method activates when the login button is click and it allows user to display password
        private void login_button_Click(object sender, EventArgs e)
        {
            string password = passwordBox.Text;
            //Check if input password matches saved password
            if (password.Equals(Program.teachers.ElementAt(AdminUsersList.SelectedIndex).pass))
            {
                create_Form();
            }
            else
            {
                passwordBox.Text = "";//reset entry field if password is incorrect
            }
        }
        //Reuse code from Kevin and Uriah, Aurelio Arango
        //Looks for a form if it does not exist it creates the form and hides current form
        //
        private void create_Form()
        {
            bool foundForm = false;
            passwordBox.Text = "";//resetting field after login
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(AdminForm))
                {
                    f.Show();
                    foundForm = true;
                    this.Hide();
                }
            }
            if (!foundForm)
            {
                AdminForm loginform = new AdminForm();
                loginform.Tag = this;
                loginform.Show(this);
                this.Hide();
            }
        }
    }
}
