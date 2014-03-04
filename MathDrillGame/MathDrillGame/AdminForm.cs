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

/* The ADMINISTRATOR form, the main page that administrators are shown when logged in
 * Used for generating problems for students, and also has buttons to go to Reports or New User creation
 */
namespace MathDrillGame
{
    public partial class AdminForm : Form
    {
        int min; //Minimum range for RNG
        int max; //Maximum range for RNG
        int quantity; //Quantity of problems to generate
        bool isAddition; //Whether the problems are addition or subtraction for RNG
        
        static Random rng = new Random();   //Used for generating random numbers. Creates a random seed so that it is more random.
        List<User> adminStudentList = new List<User>(); //A list of students (and ONLY students) for the administrator
        User targetUser;                    //Holds user details on the selected user
        string fileName;
        public AdminForm()
        {
            InitializeComponent();
        }

        /* LOAD event is triggered when the form opens. It will read from the XML into a list in memory, which then will feed into the listbox
         * This will only display students, doesn't include administrators.
         * Kevin and Uriah
         */
        private void AdminForm_Load(object sender, EventArgs e)
        {
            XElement studentListXML = XElement.Load(Program.USERSFILE);
            adminStudentList.Clear();
            foreach (XElement user in studentListXML.Descendants("Student"))
            {
                if (user.Element("IsAdmin").Value == "0")
                {
                    adminStudentList.Add(new User
                    {
                        isAdmin = false,
                        fullName = user.Element("FullName").Value,
                        userID = Convert.ToInt32(user.Element("UserID").Value)
                    });
                }
            }
            listOfStudents.DataSource = null;   
            listOfStudents.DataSource = adminStudentList;
            listOfStudents.DisplayMember = "fullName"; //This is the value to show on-screen
            listOfStudents.ValueMember = "userID"; //This is the value to pass

            fileName = @"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml";
        }

        //When you select someone from the list, save to a variable which member it is, and personalize a message.
        /* SELECTEDINDEXCHANGED event triggered when selecting a different student for whom to create problems
         * Will update the label (Generating problems for...) and the file path.
         * Kevin and Uriah
         */
        private void listOfStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.targetUser = Convert.ToInt32(listOfStudents.SelectedIndex);
            targetUser = adminStudentList[Program.targetUser];

            fileName = @"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml";
            labelGenProblemsFor.Text = "Generating problems for " + targetUser.fullName;
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
                min = Convert.ToInt32(inputMin.Text); //Turn the string input into ints
                max = Convert.ToInt32(inputMax.Text); //Turn the string input into ints
                if (min > max) //If users mistook min for max, swap the values.
                {
                    int temp = min;
                    min = max;
                    max = temp;
                }
                quantity = Convert.ToInt32(inputQuantity.Text); //Turn the string input into ints
                isAddition = radioAddition.Checked; //Determine the type of problem
                generateProblemSet();
            }
        }

        /* GENERATEPROBLEMSET actually creates the set of problems in XML, and also displays in a textbox.
         * Kevin and Uriah
         */
        private bool generateProblemSet()
        {
            XmlDocument doc;

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
            int value; //Just a temp variable used for the TryParse function. Otherwise not used.
            if (inputMin.Text.Length == 0 || inputMax.Text.Length == 0 || !int.TryParse(inputMin.Text, out value) || !int.TryParse(inputMax.Text, out value))
            {
                listOfProblems.Text = "You must enter a number range for problems.";
                return false;
            }

            //Quantity must take a positive integer value. Blank entry unacceptable.
            else if (inputQuantity.Text.Length == 0 || Convert.ToInt32(inputQuantity.Text) <= 0 || !int.TryParse(inputQuantity.Text, out value))
            {
                listOfProblems.Text = "You must enter a positive number of problems to generate.";
                return false;
            }

            else
                return true;
        }

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

        /* REPORTS CLICK event, when clicking on the "Reports" button, show the reports window
         * Kevin and Uriah
         */
        private void buttonReports_Click(object sender, EventArgs e)
        {
            ReportsForm reports = new ReportsForm();
            reports.Show();
        }

        /* LOGOUT click event, when clicking the "Log out" button, starts the logout sequence
         * Kevin and Uriah
         */
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            goToLogin();
        }

        /* ONFORMCLOSING event, triggered when this form closes.
         * If triggered by the opening of the NEWUSER form, then this does nothing special.
         * If triggered by the LOGOUT event, then this will show the already-open-but-hidden Login form, and hide the admin form instead.
         * Kevin and Uriah
         */
        protected override void OnFormClosing(FormClosingEventArgs e)
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
        }


        /* GOTOLOGIN, called from different occasions of closing the form
         * Finds the login form object and shows that, hiding the admin form (rather than creating a new instance, which can lead to multiple instance of the program)
         * Kevin and Uriah
         */
        private void goToLogin()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(LoginForm))
                {
                    f.Show();
                    this.Hide();
                }
            }
        }
    } //end AdminForm class
} //end namespace
