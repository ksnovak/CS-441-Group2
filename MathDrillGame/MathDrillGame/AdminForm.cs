/* CS 441
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
        Teacher currentTeacher;// = Program.teachers[Program.currentTeacherIndex];//aurelio arango, admin logged in

        int securityStudent;//current student index //security page

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
        List<Student> valid_students;
        
        Student targetUser;         //Holds user details on the selected user
        string fileName;
        
        //Reports variables
        int reports_currentTargetID;
        List<ProblemSet> reports_usersSets = new List<ProblemSet>();    //List of all of the problem sets to a specific students
        List<Problem> reports_problemsInSet = new List<Problem>();      //List of all problems to a specific set

        Student setProblems_targetStudent;

//------------------------------------End attributes
//--------------------------------On load start
        public AdminForm()
        {
            InitializeComponent();
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            currentTeacher = new Teacher();
            currentTeacher = Program.teachers[Program.currentTeacherIndex];
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
            //Debug.WriteLine(Program.teachers[Program.currentTeacherIndex].students.Count);
            //Debug.WriteLine("students count "+currentTeacher.students.Count);
            //Debug.WriteLine("Teacher name"+currentTeacher.fullName);
            //There needs to be Lists and listBoxes for individual Student Groups
            load_ManageStudentList();
            loadvisibleStudents();
            load_dashboard();
            load_reportsPage();

            /*for (int i = 0; i < 5; i++)
            {
                List<int> problems = ProblemSet.generateProblemSet(0, 10);

                Debug.WriteLine(problems[0].ToString(), problems[1].ToString());
            }*/
        }//end function
        protected override void  OnVisibleChanged(EventArgs e)
        {
 	        base.OnVisibleChanged(e);
            currentTeacher = new Teacher();
            currentTeacher = Program.teachers[Program.currentTeacherIndex];
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
            //Debug.WriteLine(Program.teachers[Program.currentTeacherIndex].students.Count);
            //Debug.WriteLine("students count "+currentTeacher.students.Count);
            //Debug.WriteLine("Teacher name"+currentTeacher.fullName);
            //There needs to be Lists and listBoxes for individual Student Groups
            load_ManageStudentList();
            loadvisibleStudents();
            load_dashboard();
            load_reportsPage();

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
        /* 3-25-14
        * Aurelio Arango 
        * Int takes an integer that is the user_id
        * This method gets the date
        * returns a string with the last login date
        */
        //4-3-14
        //Removed Data store in objects, reading and xml reading and writing is handled by XML handler
        /*public string getUserDate(int user_id)
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
        }*/
        


//--------------------------------On load Ends


        
//------------------------------------Main Page Buttons
        /*  Aurelio Arango 4-2-14
           Functions for the buttons at the bottom of the Admin pane, these appear regardless of selected tabPage.*/
        private void buttonLogout_Click_1(object sender, EventArgs e)
        {
            goToLogin();
        }//end funtion
        //Aurelio Arango 4-2-14
        //when exit button is pressed it closes the application
        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//end function
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


        /* LOGOUT click event, when clicking the "Log out" button, starts the logout sequence
         * Kevin and Uriah
         */
        /* private void buttonLogout_Click(object sender, EventArgs e)
         {
             goToLogin();
         }*/


//---------------------------------------Main Page Buttons Ends

//
//----------------------------------------Dashboard page start
//
        protected void load_dashboard()
        {
            dashboardTeacherLabel.Text = currentTeacher.fullName + " " + currentTeacher.lastLogin;
        }

//
//------------------------------------------------Dashboard page end
//

//
// ----------------------------------------Reports Page Section Start
//
        //Removed, no longer calling a new form, using a page to display reports. Aurelio Arango
        /* REPORTS CLICK event, when clicking on the "Reports" button, show the reports window
         * Kevin and Uriah
         */
        /*private void buttonReports_Click(object sender, EventArgs e)
        {
            ReportsForm reports = new ReportsForm();
            reports.Show();
        }//end funtion*/

        protected void load_reportsPage()
        {
            comboStudentList.DataSource = null;
            load_valid_students();
            comboStudentList.DataSource = valid_students;
            comboStudentList.DisplayMember = "fullName";
            comboStudentList.ValueMember = "userID";

        }
        protected void load_valid_students()
        {
            valid_students = new List<Student>();
            for (int i = 0; i < currentTeacher.students.Count; i++)
            {
                if (currentTeacher.students[i].invisible.Equals("n"))
                {
                    valid_students.Add(currentTeacher.students[i]);
                    //Debug.WriteLine(currentTeacher.students[i].fullName);
                    //Debug.WriteLine(currentTeacher.students[i].invisible);
                }
            }
            /*for(int i=0; i < Program.teachers[Program.currentTeacherIndex].students.Count;i++)
            {
                if (currentTeacher.students[i].invisible.Equals("n"))
                {
                    //valid_students.Add(currentTeacher.students[i]);
                    Debug.WriteLine(currentTeacher.students[i].fullName);
                    Debug.WriteLine(currentTeacher.students[i].invisible);
                }
            }*/
        }
        private void comboStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reports_currentTargetID = adminStudentList[comboStudentList.SelectedIndex].userID;
        }

        //
        //----------------------------------------Reports Page Section Ends
        //
        //
        //----------------------------------------Set Problems page start
        // 
        //
        
        //When you select someone from the list, save to a variable which member it is, and personalize a message.
        /* SELECTEDINDEXCHANGED event triggered when selecting a different student for whom to create problems
         * Will update the label (Generating problems for...) and the file path.
         * Kevin and Uriah
         */

       
        private void listOfStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Program.targetUser = Convert.ToInt32(listOfStudents.SelectedIndex);
            int selectedIndex = Convert.ToInt32(listOfStudents.SelectedIndex);;
            Debug.WriteLine(listOfStudents.SelectedIndex);
            if (selectedIndex <= 0)
            {
                selectedIndex = 0;
            }
            //targetUser = Program.teachers[Program.currentTeacherIndex].students[Program.currentStudentIndex];
            setProblems_targetStudent = new Student();
            setProblems_targetStudent = Program.teachers[Program.currentTeacherIndex].students[selectedIndex];
            
            //Aurelio Arango
            //adding string for date and user
            //string admin_welcome = "Welcome " + currentUser.fullName + " "+getUserDate(currentUser.userID);
            string admin_welcome = "Welcome " + currentTeacher.fullName + " " + currentTeacher.userID;

            fileName = @"c:\users\public\MathDrills\ProblemSets\" + setProblems_targetStudent.userID + ".xml";

            labelGenProblemsFor.Text = admin_welcome + "\nGenerating problems for " + setProblems_targetStudent.fullName;
            labelGenProblemsFor.Left = (((this.ClientSize.Width - 179) - labelGenProblemsFor.Width) / 2) + 179; //Center the greeting. 179 accounts for the list of users on the side.
        }
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
                string radio="";
                if(radioA.Checked)
                {
                    radio ="A";
                }
                else if(radioB.Checked)
                {
                    radio ="B";
                }
                else
                {
                    radio ="C";
                }

                if (MessageBox.Show("Do you want to generate set for group " + radio + "?", "MathDrillGame", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                    == DialogResult.Yes)
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
                    generateProblemSet(radio,min,max, quantity);
                }
            }//end else
        }//end function
        private bool generateProblemSet(string group, int min, int max, int quantity)
        {
            string lastAccessed = Program.MINDATE.ToString("g");
            string oper = "";

            if (radioAddition.Checked)
            {
                oper = "+";
            }
            else if (radioSubtraction.Checked)
            {
                oper = "-";
            }
            else if (radioMultiplication.Checked)
            {
                oper = "*";
            }
            else
            {
                oper = "/";
            }

            Program.saveProblemSet(new ProblemSet(1, oper, false, 0, quantity, "0", lastAccessed, group, min, max));
            return true;
        }
        /* GENERATEPROBLEMSET actually creates the set of problems in XML, and also displays in a textbox.
         * Kevin and Uriah
         */
        private bool generateProblemSet()
        {
            //XmlDocument doc;
            listOfProblems.Text = "";

            //If they have no file yet, create one with the base information.
            /*if (!File.Exists(@"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml"))
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
            }*/
            /*
            XDocument xml = XDocument.Load(@"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml");
            XElement newProblemSet = new XElement("ProblemSet");
            XElement problemSetID = new XElement("ProblemSetID", Program.getNextProblemSetID());
            newProblemSet.Add(problemSetID);
            XElement operation = new XElement("Operator", (isAddition ? "+" : "-"));
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
            */
            
                
            return true;
        }//end function generate problem set

        public void generate_individualProblems()
        {

        }
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
        }//end validate input

//
//------------------------------------------------Set Problems page end
//
//
//----------------------------------------Manage Users page start
// 
        /*  COMPONENT: Called in AdminForm_Load(..., ...).*/
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
                }//end switch
            }//end for
            refresh_ManageStudentListBoxes();
        }
        /*  COMPONENT: Called in ManageStudentList(), Add/Remove button functions.
            PURPOSE: Refreshes the ListBoxes in the Manage Page of the Admin Form.
                     Needed to reflect changes to ListBox.DataSource...
            CONCERN: Slightly inefficient in Add/Remove buttons as it refreshes all pages regardless if those pages were altered*/
        private void refresh_ManageStudentListBoxes()
        {
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

        /*  PURPOSE: Alters the user that may be moved between groups, etc.
            NOTE: This means targetUser will refer to a student that will be unassigned. This can be adjusted.
            SUGGESTION: Right-click context menu for list items in ListBox
            BUG: Regardless of the listBoxes underneath the tabs, 
         *       the target User appears to always be the first Student in the first tab group.
         *       Oddly the program will minorly spam the messages from here on AdminForm Load*/
        private void groupRosterA_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.targetUser = Convert.ToInt32(groupRosterA.SelectedIndex);
           // Debug.WriteLine("from groupRosterA", targetUser.fullName);
        }//end function
        private void groupRosterB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.targetUser = Convert.ToInt32(groupRosterB.SelectedIndex);
            //Debug.WriteLine("from groupRosterB", targetUser.fullName);
        }//end function
        private void groupRosterC_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.targetUser = Convert.ToInt32(groupRosterC.SelectedIndex);
            //Debug.WriteLine("from groupRosterC", targetUser.fullName);
        }//end function
        /*  NOTE: Below are this way because of the GUI design.
         *  CONTEXT: A user has already been selected from the list of unassigned students.
            PURPOSE: Appends user to a group (in memory only- no XML writing)
        */
        private void addUserToGroupBtn_Click(object sender, EventArgs e)
        {
            //Add to the list of the affiliated group (given by active Tab page)
            Unassigned.Remove(targetUser);
            switch (manageGroupTabControl.SelectedTab.Name)
            {
                case "GroupPageA":
                    GroupA.Add(targetUser);
                    break;
                case "GroupPageB":
                    GroupB.Add(targetUser);
                    break;
                case "GroupPageC":
                    GroupC.Add(targetUser);
                    break;
            }
            //Update the listBox.
            refresh_ManageStudentListBoxes();
        }//end function
        /* CONTEXT: A user has already been selected from the list of assigned students. 
         * PURPOSE: Deletes a user from the group (in memory only- no XML writing).*/
        private void delUserFromGroupBtn_Click(object sender, EventArgs e)
        {
            //Remove from the list of the affiliated group (given by active Tab Page)
            switch (manageGroupTabControl.SelectedTab.Name)
            {
                case "GroupPageA":
                    GroupA.Remove(targetUser);
                    break;
                case "GroupPageB":
                    GroupB.Remove(targetUser);
                    break;
                case "GroupPageC":
                    GroupC.Remove(targetUser);
                    break;
            }
            Unassigned.Add(targetUser);
            //Update the listBox
            refresh_ManageStudentListBoxes();
        }//end function

//
//------------------------------------------------Manage Users page end
//

//
//----------------------------------------Add User page start
// 

        //Removed as no longer calling a new form, managed through tabs now. Aurelio Arango 4-2-14
        //
        /* NEWUSER CLICK event, when clicking on the "Add new user" button, show the form to make a new user
         * Will close this form. Done so specifically because we need the listView to update after a user has been added, and this was the best way to guarantee that.
         * Kevin and Uriah
         */
        /*private void buttonNewUser_Click(object sender, EventArgs e)
        {
            NewUserForm newUserForm = new NewUserForm();
            newUserForm.Show();
            Close();
        }*/

//
//------------------------------------------------Add User page end
//

//
//----------------------------------------Security page start
// 
        /* Below is used by buttons in the Manage Users Tab of the Admin Form. 
         * Fuck if I'm going to sort the shit above
         * Affliated members:
         *                  manageStudentList           is the class roster.
         *                  List<Student> GroupA        is the roster for group A- manipulated in memory
         *                  List<Student> GroupB        ...
         *                  List<Student> GroupC        ...
         *                  List<Student> Unassigned    ...listing for unassigned students
         *                  targetUser                  ...container for student- this is constantly reassigned
         **I wouldn't have to do this if VS2010 has a split view.
         **Comment format: Closely affiliated code are unified under one first most block comment that describes them all,
         *                 and functions will not have line breaks between them.
         *                 (Best illustrated with collapsed functions.)
         *CONCERNS: Because of the way the UI is designed, only one listBox may have a highlighted element- 
         *          Otherwise, the user may be confused about how the Add/Remove buttons work (it's one way only).
         */

        /*  REASON: Deleting Users does not remove from XML file, but marks the user as invisible. 
         */         
        private void loadvisibleStudents()
        {
            studentsSecurityListBox.DataSource = null;

            List<Student> visibleStudents = new List<Student>();

            for (int i = 0; i < currentTeacher.students.Count; i++)
            {
                if (currentTeacher.students[i].invisible.Equals("n"))
                {
                    visibleStudents.Add(currentTeacher.students[i]);
                }
            }

            studentsSecurityListBox.DataSource = visibleStudents;
            studentsSecurityListBox.DisplayMember = "fullName";
            studentsSecurityListBox.ValueMember = "userID";
        }
        //4-3-14
        //Aurelio Arango
        private void studentsSecurityListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            securityStudent = Convert.ToInt32(studentsSecurityListBox.SelectedIndex);

           // studentSecurityNameLabel.Text = currentTeacher.students[securityStudent].fullName;


        }
        //4-3-14
        //Aurelio Arango
        private void passwordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(passwordCheckBox.Checked == true)
            {
                Program.teachers[Program.currentTeacherIndex].setpass = "y";
            }
            else
            {
                Program.teachers[Program.currentTeacherIndex].setpass = "n";
                //Debug.WriteLine("False");
            }
        }
        private void comboBoxSecurityPass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Write(comboBoxSecurityPass.SelectedIndex);
        }

//
//------------------------------------------------Security page end
//

//
//----------------------------------------About page start
//
 
//
//------------------------------------------------About page end
//
        
//
//-----------------------------------------------------------------On Closing Form Start
//
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
        //Aurelio Arango 4-2-14
        //Close application
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }

//
//----------------------------------------------------------------------On Closing Form End
//        
        
        
        

        /*  PURPOSE: Saves changes to an XML- if non-existant creates it.
                     The Add/Remove button only makes changes in memory and does not finalize the changes in XML*/
        private void manageSaveChangesBtn_Click(object sender, EventArgs e)
        {

        }

       

        

        

       
       


       


//---------------------------------------------------------------------------------------

    } //end AdminForm class
} //end namespace
