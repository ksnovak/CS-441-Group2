using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public AdminForm()
        {
            InitializeComponent();
        }

        //When the form is opened, give a personalized greeting, and fill the user list with users.
        private void AdminForm_Load(object sender, EventArgs e)
        {
            listOfStudents.DataSource = Program.users;
            listOfStudents.DisplayMember = "fullName"; //This is the value to show on-screen
            listOfStudents.ValueMember = "userID"; //This is the value to pass
            fileName = @"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml";
        }

        //When they click the Logout button, close the Admin form and show the Login form (form1).
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var form1 = (LoginForm)Tag;
            form1.Show();
            Close();
        }

        //If they click the X, terminate the entire program
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //When you select someone from the list, save to a variable which member it is, and personalize a message.
        private void listOfStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Program.targetUser = Convert.ToInt32(listOfStudents.SelectedIndex);
            targetUser = Program.users[Program.targetUser];
            fileName = @"c:\users\public\MathDrills\ProblemSets\" + targetUser.userID + ".xml";
            labelGenProblemsFor.Text = "Generating problems for " + targetUser.fullName;
            labelGenProblemsFor.Left = (((this.ClientSize.Width - 179) - labelGenProblemsFor.Width) / 2) + 179; //Center the greeting. 179 accounts for the list of users on the side.

            //Do something to prevent them from generating problems for admins.
            if (!targetUser.isAdmin)
            {

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
                

                if (generateProblemSet())
                {
                    listOfProblems.Text = "Success!";
                }


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
            XElement problemSetID = new XElement("ProblemSetID", "99");
            newProblemSet.Add(problemSetID);
            XElement operation = new XElement("Operator", (isAddition? "+" : "-"));
            newProblemSet.Add(operation);
            XElement problemSetSolved = new XElement("IsSolved", "0");
            newProblemSet.Add(problemSetSolved);
            for (int i = 0; i < quantity; i++)
            {
                XElement newProblem = new XElement("Problem",
                    new XElement("Operand1", rng.Next(min, max).ToString()),
                    new XElement("Operand2", rng.Next(min, max).ToString()),
                    new XElement("IsSolved", "0"),
                    new XElement("Attempts", "0"));

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
            else if (Convert.ToInt32(inputQuantity.Text) <= 0 || inputQuantity.Text.Length == 0 || !int.TryParse(inputQuantity.Text, out value))
            {
                listOfProblems.Text = "You must enter a positive number of problems to generate.";
                return false;
            }

            else
                return true;
        }

        //Generates the problems.
        //rng is an object of class Random declared at the start of this class
/*        private Problem generateProblem()
        {
            Problem problem = new Problem();
            problem.operand1 = rng.Next(min, max); 
            problem.operand2 = rng.Next(min, max);
            problem.operation = isAddition; //True = addition selected (default), False = subtraction selected.
            if (problem.operation)
                problem.solution = problem.operand1 + problem.operand2;
            else
                problem.solution = problem.operand1 - problem.operand2;

            return problem;
        }*/
    } //end AdminForm class
} //end namespace
