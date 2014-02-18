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
    public partial class AdminForm : Form
    {
        int min; //Minimum range for RNG
        int max; //Maximum range for RNG
        bool isAddition; //Whether the problems are addition or subtraction for RNG
        bool isAppending; //Whether the problem set is appended or replaces the student's current 
        static Random rng = new Random(); //Used for generating random numbers. Creates a random seed so that it is more random.
        public AdminForm()
        {
            InitializeComponent();
        }

        //When the form is opened, give a personalized greeting, and fill the user list with users.
        private void AdminForm_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = "Welcome, " + Program.users[Program.currentUser].fullName;
            listOfStudents.DataSource = Program.users;
            listOfStudents.DisplayMember = "fullName"; //This is the value to show on-screen
            listOfStudents.ValueMember = "userID"; //This is the value to pass
        }

        //When they click the Logout button, close the Admin form and show the Login form (form1).
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        //When you select someone from the list, save to a variable which member it is, and personalize a message.
        private void listOfStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.targetUser = Convert.ToInt32(listOfStudents.SelectedIndex); 
            labelGenProblemsFor.Text = "Generating problems for " + Program.users[Program.targetUser].fullName;

            //Do something to prevent them from generating problems for admins.
            if (!Program.users[Program.targetUser].isAdmin)
            {

            }
        }

        //When they click the Generate button, start generating problems...
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            //Make sure every input field has a value. If not, don't bother.
            if (inputMin.Text.Length == 0 || inputMax.Text.Length == 0 || inputQuantity.Text.Length == 0)
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
                int quantity = Convert.ToInt32(inputQuantity.Text); //Turn the string input into ints
                isAddition = radioAddition.Checked; //Determine the type of problem
                isAppending = radioAppend.Checked; //Determine whether the sets are added to replacing any prior sets.

                if (!isAppending) //If they are replacing, just empty out any current problems assigned to the student.
                {
                    Program.users[Program.targetUser].problemSet.Clear();
                }

                //For as many problems as is necessary, generate a problem and add to the specific student's problem set.
                for (int i = 0; i < quantity; i++)
                {
                    Program.users[Program.targetUser].problemSet.Add(generateProblem());
                }

                //Once finished generating, display just for the teacher's knowledge.
                textBox1.Text = "Problem set: \r\n"; 
                foreach (Problem problem in Program.users[Program.targetUser].problemSet)
                {
                    textBox1.AppendText(problem.printProblem() + "\r\n");
                }
            }
        }

        //Generates the problems.
        //rng is an object of class Random declared at the start of this class
        private Problem generateProblem()
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
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    } //end AdminForm class
} //end namespace
