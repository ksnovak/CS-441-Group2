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
using System.IO;
using System.Xml;

namespace MathDrillGame
{
    public partial class StudentForm : Form
    {
        int problemIndex = 0; //Used to point to the index of the current problem in the student's problem set
        int problemSetSize;
        Problem currentProblem; //The individual problem currently being worked on
        User currentUser = Program.users[Program.currentUserIndex];
        XElement studentProblemSet;
        string fileName;

        public StudentForm()
        {
            InitializeComponent();

        }

        //When form loads, create personalized greeting and fill the side textbox with the problems 
        //Note: the textbox is really just for coding knowledge, to keep track of problems and such. Won't be there for the end product.
        private void StudentForm_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = "Welcome, " + currentUser.fullName;
            //Center the welcome message. 119 accounts for the textbox
            labelWelcome.Left = (this.ClientSize.Width - labelWelcome.Width) / 2; 
            
            //If there are no problems for them, say so, and disable any potential issues.
            fileName = @"c:\users\public\MathDrills\ProblemSets\" + currentUser.userID + ".xml";
            if (File.Exists(fileName))
                studentProblemSet = XElement.Load(fileName);
            else
            {
                buttonSubmit.Enabled = inputAnswer.Enabled = false;
                labelQuestion.Text = "You have no problems assigned.";
                labelQuestion.Top -= 40;
                labelQuestion.Font = new Font("Microsoft Sans Serif", 13);
                CancelButton = buttonLogout;
                return;
            }

            //Find out how many problems are in the active set
            //IEnumerable<XElement> problemSet = studentProblemSet.Elements();
            problemSetSize = studentProblemSet.Descendants("Problem").Count();

            currentProblem = getProblem(); //Find the first unsolved problem
            if (currentProblem != null) 
                displayProblem();
        }        

        //Find an unsolved problem.
        //the "iteration" is to avoid infinite loops. As soon as we have gone through as many problems as there are in the set, break out and disable the input.
        public Problem getProblem()
        {
            int iteration = problemSetSize;
            XElement problemInXML;
            Problem newProblem = new Problem();

            while (iteration >= 0)
            {
                problemInXML = studentProblemSet.Descendants("Problem").ElementAt(problemIndex);
                if (problemInXML.Element("IsSolved").Value == "0")
                {
                    newProblem.operand1 = Convert.ToInt32(problemInXML.Element("Operand1").Value);
                    newProblem.operand2 = Convert.ToInt32(problemInXML.Element("Operand2").Value);
                    newProblem.operation = true;
                    return newProblem;
                }
                else
                {
                    problemIndex++;
                    problemIndex = (problemIndex % problemSetSize);
                    iteration--;
                }
            }

            labelFeedback.Text = "You've solved them all!";
            buttonSubmit.Enabled = inputAnswer.Enabled = false;
            CancelButton = buttonLogout;
            return null;

        }

        //Show the problem on the screen. "n + m ="
        public void displayProblem()
        {
            labelQuestion.Text = currentProblem.printProblem() + " = ";
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
                //Program.users[Program.currentUserIndex].problemSet[problemIndex].isSolved = true;
            }
            else
            {
                inputAnswer.Text = "";
                labelFeedback.Text = "Incorrect";
            }

            //Whether they got the problem right or wrong, progress to the next one, display it, and focus on the input field.
            problemIndex++;
            problemIndex = (problemIndex % problemSetSize); //Make sure we loop through the problemset, not going out of bounds.
            currentProblem = getProblem(); //Get a new problem
            if (currentProblem != null)
                displayProblem(); //Display it
            inputAnswer.Focus(); //Focus the textbox (so they can immediately type there)
        }

        //Checks if an answer is correct. Return value is true for correct, false for incorrect.
        public bool checkAnswer()
        {
            int answer = currentProblem.operand1 + currentProblem.operand2;

            int prevAttempts = Convert.ToInt32(studentProblemSet.Descendants("Problem").ElementAt(problemIndex).Element("Attempts").Value);
            studentProblemSet.Descendants("Problem").ElementAt(problemIndex).SetElementValue("Attempts", prevAttempts + 1);

            if (answer == Convert.ToInt32(inputAnswer.Text))
            {
                studentProblemSet.Descendants("Problem").ElementAt(problemIndex).SetElementValue("IsSolved", "1");
                studentProblemSet.Save(fileName);
                return true;
            }
            else
            {
                studentProblemSet.Save(fileName);
                return false;
            }

        }

        //This will remove the feedback text (e.g. "Correct!") as soon as they start typing in an answer for the next problem
        //That way they won't be confused as to what the feedback refers to.
        private void inputAnswer_TextChanged(object sender, EventArgs e)
        {
            labelFeedback.Text = "";
        }

        //If they click the X, terminate the entire program
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //When they click the logout button, close the Student screen and show the Login screen.
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var form1 = (LoginForm)Tag;
            form1.Show();
            Close();
        }
    }//end StudentForm class
}//end namespace
