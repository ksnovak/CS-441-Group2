﻿/* CS 441
 * Created by: Kevin
 * Date:
 * 
 * Modification: Added getUserDate() and display content
 * date: 3-11-14
 * Name: Aurelio Arango
 * What/Why? Displaying date and name for current administrator.
 * 
 * Modifiction: change AdminForm_Load()
 * date: 3-26-14
 * Name: Aurelio Arango
 * What/Why?: load list of students assigned to teacher object, not openning xml
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
using System.Xml;
using System.IO;

using System.Diagnostics;

/* The ADMINISTRATOR form, the main page that administrators are shown when logged in
 * Used for generating problems for students, and also has buttons to go to Reports or New User creation
 */
namespace MathDrillGame
{//this shit makes me miss function prototypes Q_Q
    public partial class AdminForm : Form
    {
        int min;            //Minimum range for RNG
        int max;            //Maximum range for RNG
        int quantity;       //Quantity of problems to generate
        bool isAddition;    //Whether the problems are addition or subtraction for RNG
        //Aurelio Arango

        //crash site here. complaints about this being a NULL value.
        //User currentUser = Program.users[Program.currentUserIndex]; //The user who is logged in.
        Teacher currentTeacher = Program.teachers[Program.currentTeacherIndex];//aurelio arango, admin logged in

        static Random rng = new Random();               //Used for generating random numbers. Creates a random seed so that it is more random.
        
        //Below obsolete? All sections it appears in is commented out.
        //[currentTeacher.students] appears to be used instead.
        List<User> adminStudentList = new List<User>(); //A list of students (and ONLY students) for the administrator

        //Initialized in AdminLoad()
        List<Student> GroupA;       //Added in for Grouping functionality
        List<Student> GroupB;
        List<Student> GroupC;
        List<Student> Unassigned;   //a "Group" for students with no groups
                                    //Assumed default value when a student is added with no specifications
                                    //Also did the same thing this list as with A,B,C..
                                    //However this one gets no Warnings
        
        Student targetUser;         //Holds user details on the selected user
        string fileName;
//------------------------------------End attributes
        public AdminForm()
        {
            InitializeComponent();
        }

        /* LOAD event is triggered when the form opens. It will read from the XML into a list in memory, which then will feed into the listbox
         * This will only display students, doesn't include administrators.
         * Kevin and Uriah
         */
        /*private void AdminForm_Load(object sender, EventArgs e)
        {
            XElement studentListXML = XElement.Load(Program.USERSFILE);
            adminStudentList.Clear();
            foreach (XElement user in studentListXML.Descendants("Student"))
            {
                if (user.Element("IsAdmin").Value == "0")
                {
                    adminStudentList.Add(new User
                    {
                        //isAdmin = false,
                        fullName = user.Element("FullName").Value,
                        userID = Convert.ToInt32(user.Element("UserID").Value)
                    });//new user init
                }//end if
            }//end foreach
            
            //Following below both are to show the roster for the class
            listOfStudents.DataSource = null;   
            listOfStudents.DataSource = adminStudentList;
            listOfStudents.DisplayMember = "fullName";  //This is the value to show on-screen
            listOfStudents.ValueMember = "userID";      //This is the value to pass
            
            manageStudentList.DataSource = adminStudentList;
            manageStudentList.DisplayMember = "fullName";
            manageStudentList.ValueMember = "userID";

            fileName = @"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml";
        }*/
        /* 
         * Aurelio Arango & SY
         * Populates List boxes in the Generate (entire class) and Manage tabs (by group or lack of).
         * Returns nothing
         */
        private void AdminForm_Load(object sender, EventArgs e)    
        {
            Teacher currentTeacher =Program.teachers[Program.currentTeacherIndex];
            //Used in Generate Tab
            listOfStudents.DataSource = null;//data biding 
            listOfStudents.DataSource = currentTeacher.students;//set data source
            listOfStudents.DisplayMember = "fullName";
            listOfStudents.ValueMember = "userID";

            //Debug.WriteLine(targetUser); debug line
            //fileName = @"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml";

            //Used in Manage Tab

            /*ISSUE: 
             * List boxes on the right do not properly display the names
             * Oddly for loop iterates once only*/
           // Debug.WriteLine(Program.teachers[Program.currentTeacherIndex].students.Count);
            Debug.WriteLine("students count "+currentTeacher.students.Count);
            Debug.WriteLine("Teacher name"+currentTeacher.fullName);
            //There needs to be Lists and listBoxes for individual Student Groups


            load_ManageStudentList();

            loadvisibleStudents();

            groupRosterA.DataSource = GroupA;
                groupRosterA.DisplayMember = "fullName";
                groupRosterA.ValueMember = "userID";
            groupRosterB.DataSource = GroupB;
                groupRosterB.DisplayMember = "fullName";
                groupRosterB.ValueMember = "userID";
            groupRosterC.DataSource = GroupC;
                groupRosterC.DisplayMember = "fullName";
                groupRosterC.ValueMember = "userID";
            
        }//end function
       
        //When you select someone from the list, save to a variable which member it is, and personalize a message.
        /* SELECTEDINDEXCHANGED event triggered when selecting a different student for whom to create problems
         * Will update the label (Generating problems for...) and the file path.
         * Kevin and Uriah
         */
        private void listOfStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.targetUser = Convert.ToInt32(listOfStudents.SelectedIndex);
            Debug.WriteLine(listOfStudents.SelectedIndex);
            targetUser = Program.teachers[Program.currentTeacherIndex].students[Program.currentStudentIndex];
            //Aurelio Arango
            //adding string for date and user
            //string admin_welcome = "Welcome " + currentUser.fullName + " "+getUserDate(currentUser.userID);
            string admin_welcome = "Welcome " + currentTeacher.fullName + " " + currentTeacher.userID;

            fileName = @"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml";
            labelGenProblemsFor.Text = admin_welcome+"\nGenerating problems for " + targetUser.fullName;
            labelGenProblemsFor.Left = (((this.ClientSize.Width - 179) - labelGenProblemsFor.Width) / 2) + 179; //Center the greeting. 179 accounts for the list of users on the side.
        }

//---------------------------------------------------------------------------------------
        /* GENERATION CLICK event, when the administrator clicks the "Generate!" button to make problems for a student
         * Makes sure the input is valid, and if so, calls the function to generate problems
         * Kevin and Uriah
         */
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (!validateInput())
            {
                return;
            }

            //If the inputs are valid, then start generating problems in those constraints.
            else
            {
                min = Convert.ToInt32(inputMin.Text);   //Turn the string input into ints
                max = Convert.ToInt32(inputMax.Text);   //Turn the string input into ints
                if (min > max)                          //If users mistook min for max, swap the values.
                {
                    int temp = min;
                    min = max;
                    max = temp;
                }
                quantity = Convert.ToInt32(inputQuantity.Text); //Turn the string input into ints
                isAddition = radioAddition.Checked;             //Determine the type of problem
                generateProblemSet();
            }//end else
        }//end function

//---------------------------------------------------------------------------------------
        /* GENERATEPROBLEMSET actually creates the set of problems in XML, and also displays in a textbox.
         * Kevin and Uriah
         */
        private bool generateProblemSet()
        {
            XmlDocument doc;
            listOfProblems.Text = "";

            //If they have no file yet, create one with the base information.
            if (!File.Exists(@"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml"))
            {
                doc = new XmlDocument();
                XmlElement allProblemSets = doc.CreateElement("AllProblemSets");
                XmlElement studentID = doc.CreateElement("StudentID");
                studentID.InnerText = targetUser.userID.ToString();
                allProblemSets.AppendChild(studentID);

                XmlElement studentName = doc.CreateElement("StudentName");
                studentName.InnerText = targetUser.fullName;
                allProblemSets.AppendChild(studentName);

                doc.AppendChild(allProblemSets);
                doc.Save(@"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml");
            }

            XDocument xml = XDocument.Load(@"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml");
            XElement newProblemSet = new XElement("ProblemSet");
            XElement problemSetID = new XElement("ProblemSetID", Program.getNextProblemSetID());
            newProblemSet.Add(problemSetID);
            XElement operation = new XElement("Operator", (isAddition? "+" : "-"));
            newProblemSet.Add(operation);
            XElement problemSetSolved = new XElement("IsSolved", "0");
            newProblemSet.Add(problemSetSolved);
            XElement lastAccessed = new XElement("LastAccessed", Program.MINDATE.ToString("g"));
            newProblemSet.Add(lastAccessed);
            int op1;
            int op2;
            for (int i = 0; i < quantity; i++)
            {
                op1 = rng.Next(min, max);   //rng.Next will randomly generate an integer between min and max
                op2 = rng.Next(min, max);
                XElement newProblem = new XElement("Problem",
                    new XElement("Operand1", op1.ToString()),
                    new XElement("Operand2", op2.ToString()),
                    new XElement("IsSolved", "0"),
                    new XElement("Attempts", "0"));
                listOfProblems.AppendText(op1 + (isAddition ? " + " : " - ") + op2 + "\r\n");
                newProblemSet.Add(newProblem);
            }

            xml.Root.Add(newProblemSet);
            xml.Save(@"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml");
            return true;
        }

//---------------------------------------------------------------------------------------
        //Ensures that the admin entered valid arguments for problem generation.
        /* VALIDATEINPUT makes sure that the attributes the teacher input for problem sets is valid.
         * Min, Max, and Quantity all have to have some value in them.
         * Min, Max, and Quantity all have to have integer values
         * Quantity has to have a non-negative value
         * If any are invalid, show in the textbox to explain the problem.
         * 
         * Kevin and Uriah
         */
        private bool validateInput()
        {
            //Min and Max must take an integer value. Blank entry unacceptable.

            //Just a temp variable used for the TryParse function. Otherwise not used.
            int value;

            if (inputMin.Text.Length == 0 || inputMax.Text.Length == 0 || !int.TryParse(inputMin.Text, out value) 
                || !int.TryParse(inputMax.Text, out value) && !int.TryParse(inputQuantity.Text, out value))
            {
                listOfProblems.Text = "You must enter a number range for problems.";
                return false;
            }

            //Quantity must take a positive integer value. Blank entry unacceptable.
            else if (inputQuantity.Text.Length > 0 && int.TryParse(inputQuantity.Text, out value))
            {
                if (Convert.ToInt32(inputQuantity.Text) <= 0)
                {
                    listOfProblems.Text = "You must enter a positive number of problems to generate.";
                    return false;
                }
                else
                {
                    return true;
                }//end else
            }//end else if

            else
                listOfProblems.Text = "You must enter a valid numbers of problems.";
                return false;
        }//end if

//---------------------------------------------------------------------------------------
        /* NEWUSER CLICK event, when clicking on the "Add new user" button, show the form to make a new user
         * Will close this form. Done so specifically because we need the listView to update after a user has been added, and this was the best way to guarantee that.
         * Kevin and Uriah
         */
        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            NewUserForm newUserForm = new NewUserForm();
            newUserForm.Show();
            Close();
        }

//---------------------------------------------------------------------------------------
        /* REPORTS CLICK event, when clicking on the "Reports" button, show the reports window
         * Kevin and Uriah
         */
        private void buttonReports_Click(object sender, EventArgs e)
        {
            ReportsForm reports = new ReportsForm();
            reports.Show();
        }

//---------------------------------------------------------------------------------------
        /* LOGOUT click event, when clicking the "Log out" button, starts the logout sequence
         * Kevin and Uriah
         */
       /* private void buttonLogout_Click(object sender, EventArgs e)
        {
            goToLogin();
        }*/
//---------------------------------------------------------------------------------------
        /* ONFORMCLOSING event, triggered when this form closes.
         * If triggered by the opening of the NEWUSER form, then this does nothing special.
         * If triggered by the LOGOUT event, then this will show the already-open-but-hidden Login form, and hide the admin form instead.
         * Kevin and Uriah
         */
        /*protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            bool makingnewuser = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(NewUserForm))
                    makingnewuser = true;
            }

            if (!makingnewuser)
                goToLogin();
        }*/
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }

//---------------------------------------------------------------------------------------
        /* GOTOLOGIN, called from different occasions of closing the form
         * Finds the login form object and shows that, hiding the admin form (rather than creating a new instance, which can lead to multiple instance of the program)
         * Kevin and Uriah
         */
        private void goToLogin()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(StartForm))
                {
                    f.Show();
                    this.Hide();
                }//end if
            }//end foreach
        }//end function

//---------------------------------------------------------------------------------------
        /* Aurelio Arango 
         * Int takes an integer that is the user_id
         * This method gets the date
         * returns a string with the last login date
         */
        public string getUserDate(int user_id)
        {
            string string_date = "";
            XElement studentListXML;
            studentListXML = XElement.Load(Program.USERSFILE);
            
            foreach (XElement user in studentListXML.Descendants("Student"))
            {
                if (Convert.ToInt32(user.Element("UserID").Value) == user_id)
                {
                    //Debug.WriteLine("Last Date"+ user.Element("LastLogin").Value);
                    string_date = user.Element("LastLogin").Value + " ";//+user.Element("LastLogin").Value;
                }//end if
            }//end foreach
            return string_date;
        }
//---------------------------------------------------------------------------------------
        /*Below is used by buttons in the Manager Users Tab of the Admin Form. 
         * Fuck if I'm going to sort the shit above*/
        /*
         * //Need to dynamically create tab pages somehow. Each tab page comes with it's own listBox to
         * hold it's roster of students- the add/remove button should target the right list- which it isn't doing now.
         * 
         * //manageStudentList = class roster. Named this way because it's a student list under the manage tab.
         * //these are out of place compared to where they really need to be.
         * List<User> addUs;    //this the data source for an individual group roster
         *                      //there is one per tab page
         * List<User> removeUs; //likewise for this thing
         
         * //First need to load the Group's XML into addUs
         */
        private void targetListBox()
        {
 
        }

        private void addUserToGroupBtn_Click(object sender, EventArgs e)
        {
            /*
             * ***
             * //Pick the sucker to manipulate
             * Program.TargetUser = ConvertToInt32(manageStudentList.SelectedIndex);
             * targetUser = adminStudentList[Program.targetUser];
             * addUs.Add(targetUser);
             * //Update the list on the right to reflect changes (left list = class roster; right = group roster)
             * ***
             */
        }

        /*Deletes a user from the group (temporary storage)*/
        private void delUserFromGroupBtn_Click(object sender, EventArgs e)
        {
            //Select User
            //Add to a list of "to remove from Group XML"
            /*
             * //Pick the sucker to manipulate
             * Program.TargetUser = ConvertToInt32(manageStudentList.SelectedIndex);
             * targetUser = adminStudentList[Program.targetUser];
             *
             */
        }//end function

        /*Saves changes to an XML- if non-existant creates it.*/
        private void manageSaveChangesBtn_Click(object sender, EventArgs e)
        {
            //Actually changes the XML- if there is none, make it
            /*
             * 
             */
        }

        private void load_ManageStudentList()
        {
            Unassigned = new List<Student>();
            GroupA = new List<Student>();
            GroupB = new List<Student>();
            GroupC = new List<Student>();
            for (int i = 0; i < currentTeacher.students.Count; i++)
            {
                switch (currentTeacher.students[i].group)
                {
                    case "U": Unassigned.Add(currentTeacher.students[i]); break;
                    case "A": GroupA.Add(currentTeacher.students[i]); break;
                    case "B": GroupB.Add(currentTeacher.students[i]); break;
                    case "C": GroupC.Add(currentTeacher.students[i]); break;
                }
            }
            manageStudentList.DataSource = null;
            manageStudentList.DataSource = Unassigned;
            manageStudentList.DisplayMember = "fullName";
            manageStudentList.ValueMember = "userID";


            groupRosterA.DataSource = null;
            groupRosterA.DataSource = GroupA;
            groupRosterA.DisplayMember = "fullName";
            groupRosterA.ValueMember = "userID";
            groupRosterB.DataSource = null;
            groupRosterB.DataSource = GroupB;
            groupRosterB.DisplayMember = "fullName";
            groupRosterB.ValueMember = "userID";
            groupRosterC.DataSource = null;
            groupRosterC.DataSource = GroupC;
            groupRosterC.DisplayMember = "fullName";
            groupRosterC.ValueMember = "userID";
        }

        private void loadvisibleStudents()
        {
            studentsSecurityListBox.DataSource = null;

            List<Student> visibleStudents = new List<Student>();
            
            for (int i = 0; i < currentTeacher.students.Count; i++)
            { 
                if(currentTeacher.students[i].invisible.Equals("n"))
                {
                    visibleStudents.Add(currentTeacher.students[i]);
                }
            }

            studentsSecurityListBox.DataSource = visibleStudents;
            studentsSecurityListBox.DisplayMember="fullName";
            studentsSecurityListBox.ValueMember="userID";

        }


        private void groupRosterA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupRosterB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupRosterC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void studentsSecurityListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Aurelio Arango 4-2-14
        private void buttonLogout_Click_1(object sender, EventArgs e)
        {
            goToLogin();
        }
        //Aurelio Arango 4-2-14
        //
        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


//---------------------------------------------------------------------------------------

    } //end AdminForm class
} //end namespace
