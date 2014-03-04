using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Xml;

/* The STUDENTFORM form
 * This is the view shown to students after they log in, which currently only allows them to perform math drills.
 * 
 */

namespace MathDrillGame
{
    public partial class StudentForm : Form
    {
        int problemIndex = 0; //Keeps track of the current problem number number within a set
        int problemSetSize;   //How many problems are in the current set
        int setIndex = 0;     //Keeps track of the current set being worked on.
        Problem currentProblem; //The individual problem currently being worked on
        User currentUser = Program.users[Program.currentUserIndex]; //The user who is logged in.
        XElement StudentXMLFile; //The student's XML file, in XElement form, opened during the LOAD event
        string fileName;      //The location of the student's XML file

        public StudentForm()
        {
            InitializeComponent();
        }

        //When form loads, create personalized greeting and fill the side textbox with the problems 
        //Note: the textbox is really just for coding knowledge, to keep track of problems and such. Won't be there for the end product.
        /* When the student form loads
         * Create a personalized greeting ("Welcome, John Q. Public"), set the proper file path, and try to get a problem
         * If there are no unsolved problems assigned, say so and disable any inputs.
         * Otherwise, retrieve and display the first problem.
         */
        private void StudentForm_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = "Welcome, " + currentUser.fullName;
            labelWelcome.Left = (this.ClientSize.Width - labelWelcome.Width) / 2; 
            

            fileName = @"c:\users\public\MathDrills\ProblemSets\" + currentUser.userID + ".xml";
            if (File.Exists(fileName))
                StudentXMLFile = XElement.Load(fileName);

            //If they don't have any file, then they don't have any problems assigned. Say so, and disable inputs to avoid issues.
            else 
            {
                buttonSubmit.Enabled = inputAnswer.Enabled = false;
                labelQuestion.Text = "You have no problems assigned.";
                labelQuestion.Top -= 40;
                labelQuestion.Font = new Font("Microsoft Sans Serif", 13);
                CancelButton = buttonLogout;
                return;
            }

            //Find out how many problems in the current problem set they have.
            problemSetSize = StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").Count();

            //Get the first problem and display it.
            currentProblem = getProblem(); 
            if (currentProblem != null) 
                displayProblem();
        }        

        /* GETPROBLEM returns the next unsolved problem, or null if there are none
         * The outer while loop goes through the list of problem sets, searching for one that isn't completely solved. Upon finding one, it enters and searches that set for an individual unsovled problem
         * problemIterator and setIterator exist so that, if all of the problems or sets are solved, there is no infinite loop. When they decrement to 0 (a full loop through the list), it breaks from the loop
         * Kevin and Uriah
         */
        public Problem getProblem()
        {
            int setIterator = StudentXMLFile.Descendants("ProblemSet").Count();
            XElement problemInXML;
            XElement setInXML;
            Problem newProblem = new Problem();
            while (setIterator > 0)
            {
                setInXML = StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex);
                int problemIterator = setInXML.Descendants("Problem").Count();
                if (setInXML.Element("IsSolved").Value == "0")
                {
                    while (problemIterator > 0)
                    {
                        problemInXML = StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").ElementAt(problemIndex);
                        if (problemInXML.Element("IsSolved").Value == "0")
                        {
                            newProblem.operand1 = Convert.ToInt32(problemInXML.Element("Operand1").Value);
                            newProblem.operand2 = Convert.ToInt32(problemInXML.Element("Operand2").Value);
                            newProblem.operation = problemInXML.Parent.Element("Operator").Value;
                            return newProblem;
                        }
                        else
                        {
                            problemIndex++;
                            problemIndex = (problemIndex % problemSetSize);
                            problemIterator--;
                        }
                    }//end problem while
                    labelFeedback.Text = "You've completed a problem set!";
                    StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).SetElementValue("LastAccessed", DateTime.Now.ToString("g"));
                    StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).SetElementValue("IsSolved", "1");
                    StudentXMLFile.Save(fileName);

                    problemIndex = 0;
                }
                else
                {
                    setIndex++;
                    setIndex = (setIndex % StudentXMLFile.Descendants("ProblemSet").Count());
                    setIterator--;
                    problemIndex = 0;
                    problemSetSize = StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").Count();
                }
            }//end set while
            labelFeedback.Text = "You've completed all problem sets assigned to you!";
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
            }
            else
            {
                inputAnswer.Text = "";
                labelFeedback.Text = "Incorrect";
            }

            //Show the feedback for just a half-second by making the thread sleep
            Refresh();
            System.Threading.Thread.Sleep(500);
            labelFeedback.Text = "";

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
            int answer;

            if (StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Element("Operator").Value == "+")
                answer = currentProblem.operand1 + currentProblem.operand2;
            else
                answer = currentProblem.operand1 - currentProblem.operand2;

            int prevAttempts = Convert.ToInt32(StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").ElementAt(problemIndex).Element("Attempts").Value);
            StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").ElementAt(problemIndex).SetElementValue("Attempts", prevAttempts + 1);

            if (answer == Convert.ToInt32(inputAnswer.Text))
            {
                StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").ElementAt(problemIndex).SetElementValue("IsSolved", "1");
                StudentXMLFile.Save(fileName);
                return true;
            }
            else
            {
                StudentXMLFile.Save(fileName);
                return false;
            }

        }

        //This will remove the feedback text (e.g. "Correct!") as soon as they start typing in an answer for the next problem
        //That way they won't be confused as to what the feedback refers to.
        private void inputAnswer_TextChanged(object sender, EventArgs e)
        {
            labelFeedback.Text = "";
        }

        //When they click the logout button, close the Student screen and show the Login screen.
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure you want to log out?", "Math Drills - Alert", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                 if (File.Exists(fileName))
                    {
                        if (StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Element("IsSolved").Value == "0")
                        {
                            StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).SetElementValue("LastAccessed", DateTime.Now.ToString("g"));
                            StudentXMLFile.Save(fileName);
                        }
                    }

                 goToLogin();
                 
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
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
    }//end StudentForm class
}//end namespace
