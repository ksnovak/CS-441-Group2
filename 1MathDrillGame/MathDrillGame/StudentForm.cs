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
    public partial class StudentForm : Form
    {
        int problemNum = 0; //Used to point to the index of the current problem in the student's problem set
        Problem currentProblem; //The individual problem currently being worked on

        public StudentForm()
        {
            InitializeComponent();
        }

        //When form loads, create personalized greeting and fill the side textbox with the problems 
        //Note: the textbox is really just for coding knowledge, to keep track of problems and such. Won't be there for the end product.
        private void StudentForm_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = "Welcome, " + Program.users[Program.currentUser].fullName;

            if (Program.users[Program.currentUser].problemSet.Count == 0)
            {
                textBox1.Text = "You have no assignments.";
                return;
            }

            foreach (Problem problem in Program.users[Program.currentUser].problemSet)
            {
                textBox1.AppendText(problem.printProblem() + "\r\n");
            }


            currentProblem = getProblem(); //Find the first unsolved problem
            displayProblem(); //And display it
        }

        //When they click the logout button, close the Student screen and show the Login screen.
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        //Find an unsolved problem.
        public Problem getProblem()
        {
            int lastProblem = problemNum -1; //Keep track of where we last were.

            //Loop through the list of problems, until an unsolved one is found.
            while (Program.users[Program.currentUser].problemSet[problemNum].isSolved) 
            {
                //If we have cycled all the way through the list of problems, and have failed to find an unsolved one, then we are done
                //WARNING: THIS IS MY INFINITE LOOP PROBLEM
                if (problemNum == lastProblem /*&& Program.users[Program.currentUser].problemSet[lastProblem].isSolved*/)
                {
                    labelFeedback.Text = "You've solved them all!";
                    break;
                }

                //If we are not back at the starting point, then iterate to the next problem.
                else
                {
                    problemNum++;
                    problemNum = (problemNum % Program.users[Program.currentUser].problemSet.Count);
                }
            }

            //Once we have found a problem, then increment attemptNumber (for future use, when we limit students to just 2 attempts), and return the problem.
            Program.users[Program.currentUser].problemSet[problemNum].attemptNumber++;
            return Program.users[Program.currentUser].problemSet[problemNum];
        }

        //Show the problem on the screen. "n + m ="
        public void displayProblem()
        {
            labelQuestion.Text = currentProblem.printProblem();
        }

        //When clicking the submit button, check if the answer is right.
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            submitAnswer(); 
        }

        //Checks if the answer is right. Called either by clicking Submit, or by pressing Enter. 
        public void submitAnswer()
        {
            int value; //Temporary, just used for int.TryParse, otherwise unneeded.

            //If they put in a non-number, or they put nothing in, this will (1) say so, (2) clear the value, and (3) re-select the input box.
            if ((inputAnswer.Text.Length == 0) || (!int.TryParse(inputAnswer.Text, out value)))
            {
                inputAnswer.Focus();
                inputAnswer.Text = "";
                labelFeedback.Text = "That was not a number";
                return;
            }

            //checkAnswer() returns a boolean, true if they got the answer right, false if not.
            //If it was right, mark that problem as solved (so it will not reappear later)
            //Give the appropriate feedback either way.
            if (checkAnswer())
            {
                inputAnswer.Text = "";
                labelFeedback.Text = "Correct!";
                Program.users[Program.currentUser].problemSet[problemNum].isSolved = true;
            }
            else
            {
                inputAnswer.Text = "";
                labelFeedback.Text = "Incorrect";
            }

            //Whether they got the problem right or wrong, progress to the next one, display it, and focus on the input field.
            problemNum++;
            problemNum = (problemNum % Program.users[Program.currentUser].problemSet.Count); //Make sure we loop through the problemset, not going out of bounds.
            currentProblem = getProblem(); //Get a new problem
            displayProblem(); //Display it
            inputAnswer.Focus(); //Focus the textbox (so they can immediately type there)
        }

        //Checks if an answer is correct. Return value is true for correct, false for incorrect.
        public bool checkAnswer()
        {
            return (currentProblem.solution == Convert.ToInt32(inputAnswer.Text));
        }

        //This will remove the feedback text (e.g. "Correct!") as soon as they start typing in an answer for the next problem
        //That way they won't be confused as to what the feedback refers to.
        private void inputAnswer_TextChanged(object sender, EventArgs e)
        {
            labelFeedback.Text = "";
        }

        //Checks for keyboard shortcuts
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter) //If they pressed enter, check the answer input.
            {
                submitAnswer();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }//end StudentForm class
}//end namespace
