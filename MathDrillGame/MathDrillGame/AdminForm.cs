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
using System.Xml;
using System.IO;

namespace MathDrillGame
{
    public partial class AdminForm : Form
    {
        int min; //Minimum range for RNG
        int max; //Maximum range for RNG
        int quantity;
        bool isAddition; //Whether the problems are addition or subtraction for RNG
        
        static Random rng = new Random(); //Used for generating random numbers. Creates a random seed so that it is more random.
        User targetUser;
        string fileName;
        NewUserForm newuser;
        public AdminForm()
        {
            InitializeComponent();
            newuser = new NewUserForm();
            newuser.FormClosed += new FormClosedEventHandler(newuser_FormClosed);
        }

        void newuser_FormClosed(object sender, FormClosedEventArgs e)
        {


            newuser = new NewUserForm();
            newuser.FormClosed += new FormClosedEventHandler(newuser_FormClosed);

            XElement studentListXML = XElement.Load(Program.USERSFILE);
            Program.users.Clear();
            foreach (XElement user in studentListXML.Descendants("Student"))
            {

                Program.users.Add(new User
                {
                    isAdmin = (user.Element("IsAdmin").Value == "1" ? true : false),
                    fullName = user.Element("FullName").Value,
                    userID = Convert.ToInt32(user.Element("UserID").Value)
                });
            }
            listOfStudents.DataSource = null;
            listOfStudents.DataSource = Program.users;
            listOfStudents.DisplayMember = ""; //This is the value to show on-screen
            listOfStudents.DisplayMember = "getRoleAndName"; //This is the value to show on-screen
            listOfStudents.ValueMember = "userID"; //This is the value to pass
            listOfStudents.Update();


        }

        //When the form is opened, give a personalized greeting, and fill the user list with users.
        private void AdminForm_Load(object sender, EventArgs e)
        {
            listOfStudents.DataSource = null;
            listOfStudents.DataSource = Program.users;
            listOfStudents.DisplayMember = "getRoleAndName"; //This is the value to show on-screen
            listOfStudents.ValueMember = "userID"; //This is the value to pass
            fileName = @"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml";
            this.Activate();
        }

        //When you select someone from the list, save to a variable which member it is, and personalize a message.
        private void listOfStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Program.targetUser = Convert.ToInt32(listOfStudents.SelectedIndex);
            targetUser = Program.users[Program.targetUser];

            if (targetUser.isAdmin)
            {
                labelGenProblemsFor.Text = targetUser.fullName + " is not a student";
                labelGenProblemsFor.Left = (((this.ClientSize.Width - 179) - labelGenProblemsFor.Width) / 2) + 179; //Center the greeting. 179 accounts for the list of users on the side.
                inputMin.Enabled = inputMax.Enabled = inputQuantity.Enabled = Operation.Enabled = buttonGenerate.Enabled = false;
            }

            else
            {
                fileName = @"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml";
                labelGenProblemsFor.Text = "Generating problems for " + targetUser.fullName;
                labelGenProblemsFor.Left = (((this.ClientSize.Width - 179) - labelGenProblemsFor.Width) / 2) + 179; //Center the greeting. 179 accounts for the list of users on the side.
                inputMin.Enabled = inputMax.Enabled = inputQuantity.Enabled = Operation.Enabled = buttonGenerate.Enabled = true;
            }
        }

        //When they click the Generate button, start generating problems...
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (!validateInput())
            {
                return;
            }

            //Otherwise, there are values in everything. So create a problem.
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
            }
        }

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
                op1 = rng.Next(min, max);
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

        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            NewUserForm newUserForm = new NewUserForm();
            newUserForm.Show();
            Close();
            /*newUserForm.Tag = this;
            newUserForm.Show(this);
            Hide();
            //NewUserForm newuser = new NewUserForm();
            newuser.Show();*/

        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            /*ReportsForm reports = new ReportsForm();
            reports.Tag = this;
            reports.Show(this);
            Hide();*/
            ReportsForm reports = new ReportsForm();
            reports.Show();
        }

        //When they click the Logout button, close the Admin form and show the Login form (form1).
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            goToLogin();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            goToLogin();
        }


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
