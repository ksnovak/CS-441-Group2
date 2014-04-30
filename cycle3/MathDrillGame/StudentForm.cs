﻿/* CS 441
 * Created by: Kevin
 * Date:
 * 
 * Modification: Added getDate()
 * date: 3-11-14
 * Name: Aurelio Arango
 * What/Why? Debugging for purposes of updating list.
 * 
 * 
 * Modification: commented-out reading last login because Student holds that information
 * date: 4-1-14
 * Name: Aurelio Arango
 * What/Why? .
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
using System.IO;
using System.Xml;


using System.Diagnostics;
/* The STUDENTFORM form is the view shown to students after they log in.
 * Currently the only function is to allow them to perform math drills.
 */

namespace MathDrillGame
{
    public partial class StudentForm : Form
    {
        int problemIndex = 0; //Keeps track of the current problem number number within a set
        int problemSetSize;   //How many problems are in the current set
        //int setIndex = 0;     //Keeps track of the current set being worked on.
        Problem currentProblem; //The individual problem currently being worked on
        List<ProblemSet> setlist;
        int solved = 0;
        int max = 0;

        //User currentUser = Program.users[Program.currentUserIndex]; //The user who is logged in.
        //4-1-14
        //
        Student currentUser; //= Program.teachers[Program.currentTeacherIndex].students[Program.currentStudentIndex];//get current student

        
        XElement StudentXMLFile; //The student's XML file, in XElement form, opened during the LOAD event
        string fileName;      //The location of the student's XML file

        DateTime loginTime;

        public StudentForm()
        {

            //Console.WriteLine(currentUser.fullName);
            loadAll();
            InitializeComponent();
            Shown += StudentShown; //When the form is created, "StudentShown" is set as an event function which triggers on the form being shown (either on creation or when being unhidden)
        }

        /* SHOWN EVENT, triggered when the form is shown (either initial creation, or when unhidden). 
         * Builds the form to be specific to that student, and tries to get the first problem.
         * If the student has no problem file, it says that they have no problems, and disables inputs.
         * Kevin and Uriah
         */
        private void StudentShown(object sender, EventArgs e)
        {
            //Aurelio Arango
            //Modified to get current date from current student
            //labelWelcome.Text = "Welcome, " + currentUser.fullName +"\n"+getDate(currentUser.userID);
            labelWelcome.Text = "Welcome, " + currentUser.fullName + "\n" + currentUser.lastLogin;
            labelWelcome.Left = (this.ClientSize.Width - labelWelcome.Width) / 2;

            loadTime();
            //Obsolete code, replaced by following function call...
            /*
             * Jorge & Aurelio & Kevin - Uncommenting code that was commented out in second cycle. Commenting this code is causing
             * for an unhandled exception to be thrown because it is trying to read a function 
             */
            fileName = @"c:\users\public\MathDrills\ProblemSets\setGroup" + currentUser.group + ".xml";
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Dialogue Box: No problem sets found for current user. CLick ok.");
                goToLogin();

            }
            else
            {
                StudentXMLFile = XElement.Load(fileName);
            

                setlist = Program.loadProblems(currentUser.group);

                //If they don't have any file, then they don't have any problems assigned. Say so, and disable inputs to avoid issues.
                //else
                if (setlist[0].group != currentUser.group )
                {
                    buttonSubmit.Enabled = inputAnswer.Enabled = false;
                    labelQuestion.Text = "You have no problems assigned.";
                    labelQuestion.Top -= 40;
                    labelQuestion.Font = new Font("Microsoft Sans Serif", 13);
                    CancelButton = buttonLogout;
                    return;
                }
                //Find out how many problems in the current problem set they have.
                //problemSetSize = StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").Count();
                problemSetSize = setlist[0].problems.Count();
                max = problemSetSize * 2;
                //Get the first problem and display it.
                currentProblem = getProblem();
                if (currentProblem != null )
                    displayProblem();
            }
        }
        //Aurelio Arango
        //4-8-14
        //This method, loads the current time and stores it in a termporary variable
        public void loadTime()
        {
            //DateTime MINDATE = new DateTime();
            //string time;//=DateTime.Now.TimeOfDay("dd/MM/yyyy");
            //time = DateTime.Now.ToString();
            //Debug.WriteLine(time);
            loginTime = DateTime.Now;
            //Program.teachers[Program.currentTeacherIndex].lastLogin = DateTime.Now;
        }
        /*Jorge Torres 4/29/2014 - Reworking the way this fucntion obtains the problem to display.
         * */
        //Aurelio Arango  & Stepahnie Yao
        /*this method gets the the current problem from the Problem Set,
        public Problem getProblem()
        {
            
            Problem newproblem = new Problem();
            // MARKER: WIP!!!
            if (solved != setlist[0].problems.Count)
            {
                //Debug.Write(setlist[0].problems[problemIndex]);
                newproblem = setlist[0].problems[problemIndex];
                //problemIndex++;
                return newproblem;
            }
            else
            {
                labelFeedback.Text = "You've completed all problem sets assigned to you!";
                buttonSubmit.Enabled = inputAnswer.Enabled = false;
                CancelButton = buttonLogout;
                return null;
            }

        }*/
        public Problem getProblem()
        {

            Problem newproblem = new Problem();
            // MARKER: WIP!!!

            //Jorge Torres - lets verify that the date is correct for the attempt on the problem set
            DateTime now = DateTime.Now;
            String dueDateForProblemSet = null;

            Console.WriteLine(currentUser.getGroup);

            switch(currentUser.getGroup)
            {
                case "A": dueDateForProblemSet = (setlist[0].dueDate);
                    break;
                case "B": dueDateForProblemSet = (setlist[1].dueDate);
                    break;
                case "C": dueDateForProblemSet = (setlist[2].dueDate);
                    break;
            }
            DateTime finalDueDate = DateTime.Parse(dueDateForProblemSet);

            if (now.Date <= finalDueDate.Date)
            {
                Console.WriteLine("we can still do this problem set!!!");
            }
            else
            {
                Console.WriteLine("you ran our of time poop:" + finalDueDate + "&&" + now);
            }

            if (solved != setlist[0].problems.Count )
            {
                //Debug.Write(setlist[0].problems[problemIndex]);
                newproblem = setlist[0].problems[problemIndex];
                //problemIndex++;
                return newproblem;
            }
            else
            {
                labelFeedback.Text = "You've completed all problem sets assigned to you!";
                buttonSubmit.Enabled = inputAnswer.Enabled = false;
                CancelButton = buttonLogout;
                return null;
            }

        }
        

        //  NOTE: Made obsolete from above code.
        /* GETPROBLEM returns the next unsolved problem, or null if there are none
         * Outer loop iterates through all problem sets. Inner loop iterates through each set's individual problems.
         * Will only ever enter the inner loop if the problem as a whole has not been set to Solved
         * To avoid infinite loops, problemIterator and setIterator exist, starting with the quantity of sets in file (or problems in set) and decrementing each iteration.
         * Upon problemIterator hitting 0, it will go to the next set. Upon setIterator hitting 0, it will escape the loop entirely
         * Kevin and Uriah
         */
        /*public Problem getProblem()
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
                            problemIndex = (problemIndex % problemSetSize); //Make sure to wrap around...
                            problemIterator--;
                        }
                    }//end problem while
                    //If they get to this point, then a set has been completed. Give feedback, and save information. 
                    labelFeedback.Text = "You've completed a problem set!";
                    StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).SetElementValue("LastAccessed", DateTime.Now.ToString("g"));
                    StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).SetElementValue("IsSolved", "1");
                    StudentXMLFile.Save(fileName);
                    problemIndex = 0;
                }
                else //If they get to this point, it means that a set has been found to be completed. Go to the next one, making sure to update the various counts
                {
                    setIndex++;
                    setIndex = (setIndex % StudentXMLFile.Descendants("ProblemSet").Count());
                    setIterator--;
                    problemIndex = 0;
                    problemSetSize = StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").Count(); //Find out how many problems there are for this set
                }
            }//end set while

            //If they get to this point, then all of their sets have been completed. Give feedback, disable input, and escape the function.
            labelFeedback.Text = "You've completed all problem sets assigned to you!";
            buttonSubmit.Enabled = inputAnswer.Enabled = false;
            CancelButton = buttonLogout;
            return null;
        }
        */
        /* DISPLAYPROBLEM displays the currently selected problem on screen
         * Kevin and Uriah
         */
        public void displayProblem()
        {
            labelQuestion.Text = currentProblem.printProblem() + " = ";
        }

        /* SUBMIT CLICK event, when the Submit button is clicked, submit the answer
         * Kevin and Uriah
         */
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            submitAnswer(); 
        }

        /* SUBMITANSWER, called after clicking the Submit button, checks if the input is valid, checks if it is correct, gives feedback, and finds the next problem
         * Kevin and Uriah
         */
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
                setlist[0].problems[problemIndex].isSolved = true;
                solved++;
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
            {
                displayProblem(); //Display it
                inputAnswer.Focus(); //Focus the textbox (so they can immediately type there)
            }
            else
            {

            }
        }

        //Checks if an answer is correct. Return value is true for correct, false for incorrect.
        /* CHECKANSWER, checks if the answer is correct or not and returns a bool as such
         * 
         * Kevin and Uriah
         */
        public bool checkAnswer()
        {
            int answer = 0;

            //Update the XML to specify how many times the problem has been attempted.
            //int prevAttempts = Convert.ToInt32(StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").ElementAt(problemIndex).Element("Attempts").Value);
            //StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").ElementAt(problemIndex).SetElementValue("Attempts", prevAttempts + 1);

            //Figure out what the answer should be
            //if (StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Element("Operator").Value == "+")
            if (currentProblem.operation == "+")    
                answer = currentProblem.operand1 + currentProblem.operand2;
            else if (currentProblem.operation == "-")
                answer = currentProblem.operand1 - currentProblem.operand2;
            else if (currentProblem.operation == "*")
                answer = currentProblem.operand1 * currentProblem.operand2;
            else if (currentProblem.operation == "/")
                answer = currentProblem.operand1 / currentProblem.operand2;
            else
            { 
            
            }
            
            //Check if the answer is what it should be, and return a relevant boolean.
            //If it is correct, update the XML to say that the problem is solved.
            if (answer == Convert.ToInt32(inputAnswer.Text))
            {
                //StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").ElementAt(problemIndex).SetElementValue("IsSolved", "1");
                //StudentXMLFile.Save(fileName);
                return true;
            }
            else
            {
                //StudentXMLFile.Save(fileName);
                return false;
            }

        }

        /* INPUT CHANGE event, when the user starts to type things in the input box, clear the feedback text
         * This makes sure that any feedback for the last problem (or the last problem set) won't be misunderstood to be relevant to the current one
         * Kevin and Uriah
         */
        private void inputAnswer_TextChanged(object sender, EventArgs e)
        {
            labelFeedback.Text = "";
        }

        //When they click the logout button, close the Student screen and show the Login screen.
        /* LOGOUT CLICK event, triggered upon clicking the "Log out" button, makes sure that they wish to log out. 
         * If they do, then saves the XML and returns to the login screen
         * Kevin and Uriah
         */
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure you want to log out?", "Math Drills - Alert", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                 if (File.Exists(fileName))
                    {
                        /*if (StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Element("IsSolved").Value == "0")
                        {
                            StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).SetElementValue("LastAccessed", DateTime.Now.ToString("g"));
                            StudentXMLFile.Save(fileName);
                        }*/
                    }
                 Program.teachers[Program.currentTeacherIndex].students[Program.currentStudentIndex].lastLogin = loginTime;
                 Program.saveData();
                 goToLogin();
            }
        }

        /* FORM CLOSING event, triggered when the student form closes for any reason. Goes to the login screen
         * Kevin and Uriah
         */
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Program.teachers[Program.currentTeacherIndex].students[Program.currentStudentIndex].lastLogin = loginTime;
                 
            Program.saveData();
            goToLogin();
        }

        /* GOTOLOGIN, triggered by attempts to close the screen. Opens up the Login screen and hides the student screen
         * Finds the login screen by cycling through the list of currently open Forms.
         * Kevin and Uriah
         */
        private void goToLogin()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(LoginForm))
                {
                    //f.Refresh();
                    f.Show();
                    this.Hide();
                }
            }
        }
        /*Aurelio Arango
         * This method retrieves the last login date for a given user based user id.
         * Returns a string of the last date a student was logged. 
         */
        //Aurelio Arango
        //Not in use because student object holds last loggin
       /* public string getDate(int user_id)
        {
            string string_date="";
            XElement studentListXML;
            studentListXML = XElement.Load(Program.USERSFILE);

            foreach (XElement user in studentListXML.Descendants("Student"))
            {
                if (Convert.ToInt32(user.Element("UserID").Value) == user_id)
                {
                    string_date = user.Element("LastLogin").Value;
                }
            }

            return string_date;
        }*/
        
        /*
         *Jorge Torres & Aurelio Arango & Kevin Novak 24/29/2014 - Reload all the data when the form is reloaded
         */
        private void loadAll()
        {
            currentUser = new Student();
            //currentUser = Program.Student[Program.currentStudentIndex];
            
            currentUser = Program.students[Program.currentStudentIndex]; //Program.teachers[Program.currentTeacherIndex].students[Program.currentStudentIndex];

            Console.WriteLine(currentUser.fullName);
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            loadAll();
        }
    }//end StudentForm class
}//end namespace
