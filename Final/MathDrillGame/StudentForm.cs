/* CS 441
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
        string incorrect_problems="";
        //int current_problem_index;
        DateTime finalDueDate; //Jorge Torres - variable that will look for the due date for the problem set
        
        //vairbale of the mapdisplay
        PictureBox[] mapArray = new PictureBox[9];
        //variable to traverse teh array
        int mapIndex;

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
<<<<<<< HEAD
=======
            loadAll();
>>>>>>> c70fcc07f9152a63dce728e6262ddb4a96ec1d13
            InitializeComponent();

            //Jorge Torres - calling the load data one too many times
            //loadAll();
            /*
             * Jorge Torres - Commenting the below line out because it has absolutely no functionality to this program
             */
            //Shown += StudentShown; //When the form is created, "StudentShown" is set as an event function which triggers on the form being shown (either on creation or when being unhidden)
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
            //welcomeLabel.Text = "Welcome, " + currentUser.fullName +"\n"+getDate(currentUser.userID);
            welcomeLabel.Text = "Welcome, " + currentUser.fullName + "\n" + currentUser.lastLogin;
            welcomeLabel.BackColor = Color.Transparent;
            welcomeLabel.Left = (this.ClientSize.Width - welcomeLabel.Width) / 2;

            loadTime();
            //Obsolete code, replaced by following function call...
<<<<<<< HEAD
            
=======
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
>>>>>>> c70fcc07f9152a63dce728e6262ddb4a96ec1d13
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
<<<<<<< HEAD
            
                Problem newproblem = new Problem();
                // MARKER: WIP!!!

                //try to read last problem
                //problemIndex = Program.student_xml_last_problem_attempted(currentUser.userID, setlist[checkProblemSetInDateRange()].problemSetID);

                //Jorge Torres - lets verify that the date is correct for the attempt on the problem set
                // DateTime now = DateTime.Now;
                String dueDateForProblemSet = null;

                //Console.WriteLine(currentUser.getGroup);
                //load the correct problem set based on the date and the group
                switch (currentUser.getGroup)
                {
                    case "A": dueDateForProblemSet = (setlist[checkProblemSetInDateRange()].dueDate);
                        break;
                    case "B": dueDateForProblemSet = (setlist[checkProblemSetInDateRange()].dueDate);
                        break;
                    case "C": dueDateForProblemSet = (setlist[checkProblemSetInDateRange()].dueDate);
                        break;
                }

                //problemIndex++;
                if (problemIndex == 10)
                { 

                    //do stuff
                
                }

                if (problemIndex != setlist[checkProblemSetInDateRange()].problems.Count)
                {

                    //Debug.Write(setlist[0].problems[problemIndex]);

                    //get the last problem

                    newproblem = setlist[checkProblemSetInDateRange()].problems[problemIndex];
                    //problemIndex++;
                    Console.Write("Current problem in the set :: " + newproblem.printProblem());
                    return newproblem;
                }
                else
                {
                    //get all the incorrect problems
                    incorrect_problems = Program.student_xml_incorrect_problems(currentUser.userID, setlist[checkProblemSetInDateRange()].problemSetID);

                    //In this area, the current data will be updated
                    //write data directly into xml
                    labelFeedback.Text = "You've completed all problem sets assigned to you!";


                    //disable input

                    //save the data and change set as solved (1)
                    Program.save_student_xml_problem(currentUser.userID,
                                                    setlist[checkProblemSetInDateRange()].problemSetID
                                                    , 1
                                                    , DateTime.Now
                                                    , incorrect_problems
                                                    , problemIndex);

                    buttonSubmit.Enabled = inputAnswer.Enabled = false;
                    CancelButton = buttonLogout;
                    //problemIndex = 0;
                    return null;
                }
=======

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

>>>>>>> c70fcc07f9152a63dce728e6262ddb4a96ec1d13
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
        //method to load the array of picturboxes
        void load_picture_box_array()
        {
            mapArray[0] = map2;
            mapArray[1] = map3;
            mapArray[2] = map4;
            mapArray[3] = map5;
            mapArray[4] = map6;
            mapArray[5] = map7;
            mapArray[6] = map8;
            mapArray[7] = map9;
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
                //saving the problem

                problemIndex++;
                Program.save_student_xml_problem(currentUser.userID,
                                                setlist[checkProblemSetInDateRange()].problemSetID
                                                ,0
                                                ,DateTime.Now
                                                ,incorrect_problems
                                                , problemIndex);
            }
            else
            {
                inputAnswer.Text = "";
                labelFeedback.Text = "Incorrect";
                //adding tp the list of incorrect problems
                incorrect_problems += problemIndex + ",";
                //save the data to xml
                problemIndex++;
                Program.save_student_xml_problem(currentUser.userID,
                                                setlist[checkProblemSetInDateRange()].problemSetID
                                                , 0
                                                , DateTime.Now
                                                , incorrect_problems
                                                , problemIndex);

            }
            //increase problem set
            //current_problem_index++;
            //Show the feedback for just a half-second by making the thread sleep
            Refresh();
            System.Threading.Thread.Sleep(500);
            labelFeedback.Text = "";

            //Whether they got the problem right or wrong, progress to the next one, display it, and focus on the input field.
            //problemIndex++;
            //problemIndex = (problemIndex % problemSetSize); //Make sure we loop through the problemset, not going out of bounds.
          
            currentProblem = getProblem(); //Get a new problem
            if (currentProblem != null)
            {
                displayProblem(); //Display it
                inputAnswer.Focus(); //Focus the textbox (so they can immediately type there)
            }
            else
            {
                Debug.WriteLine("You've completed all problem sets assigned to you!");
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

            //create a counter for the map display
            

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

                //if the answer is correct set the appropriate box to visible
                mapArray[mapIndex].Visible = true;
                mapArray[mapIndex].Image = Properties.Resources.straight_line2;
                mapIndex++;
                return true;
            }
            else if(answer != Convert.ToInt32(inputAnswer.Text))
            {
                mapArray[mapIndex].Visible = true;
                mapArray[mapIndex].Image = Properties.Resources.curve2;
                mapIndex++;
                //StudentXMLFile.Save(fileName);
                return false;
            }

            return false;

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
<<<<<<< HEAD
            
            //load the picturebox
            load_picture_box_array();

            loadCurrentStudent();
            //Jorge Torres - **********************IMPORTANT**********
            //Check if XML Exist, do not duplicate content
            if (!File.Exists(fileName))
            {
                Program.loadDesiredStudent(currentUser.userID, problemSetSize, currentUser.fullName); 
            }
            
            loadTheWelcomeMessage();
            loadTheProblemSetForStudent();
            //checkProblemSetInDateRange();
            
            //test
            //Program.read_student_xml(currentUser.userID,9);
            
            //Program.test();
            
        }

        //load the student
        private void loadCurrentStudent()
        {
            currentUser = new Student();
            //currentUser = Program.Student[Program.currentStudentIndex];
            currentUser = Program.students[Program.currentStudentIndex]; //Program.teachers[Program.currentTeacherIndex].students[Program.currentStudentIndex];
        }
        //loading the message
        private void loadTheWelcomeMessage()
        {
            //Console.WriteLine(currentUser.fullName);
            welcomeLabel.Text = "Welcome, " + currentUser.fullName + "\n" + currentUser.lastLogin;
        }
        //check to see if the prblem set is in the range
        private int checkProblemSetInDateRange()
        {
            int index = -1;
            
            for(int i=0; i < setlist.Count(); i++)
            {
                String dueDateForProblemSet = setlist[i].dueDate;
                
                //Jorge - set the due date
                finalDueDate = DateTime.Parse(dueDateForProblemSet);

                //Debug.WriteLine("this string should print  :: " + (loginTime.Date <= finalDueDate.Date));

                //calculate the time we logged in
                loadTime();

                if (loginTime.Date <= finalDueDate.Date)
                {
                    int solved = Program.student_xml_problem_is_solved(currentUser.userID, setlist[i].problemSetID);

                    //Debug.WriteLine("The current problem is solved (1 solved / 0 not solved) " + solved);

                    if(solved ==-1)
                    {
                        Debug.WriteLine("Problem is solved");  
                        
                    }
                    else if (solved == 0)
                    {
                        Debug.WriteLine("student_xml_problem_is_solved---Not Solved");
                        // This doesnt not allow use to break out of the for loop
                        
                        //index = i;
                        Debug.WriteLine("looking at i inside the checkProblem " + i);
                        return index = i;
                    }else
                    {
                        Debug.WriteLine("student_xml_problem_is_solved---Solved");
                    }
                }
            }

            //Console.WriteLine("Second value of i :: " + index);
            //if all falis
            return index;

            //Jorge Torres - depricated code. above code handles the same tasks
           /* if (index == -1)
            {
                Program.save_student_xml_problem(currentUser.userID,
                                                setlist[checkProblemSetInDateRange()].problemSetID
                                                , 0
                                                , DateTime.Now
                                                , ""
                                                , 0);
            }
            for (int i = 0; i < setlist.Count(); i++)
            {
                String dueDateForProblemSet = setlist[i].dueDate;

                //Jorge set the due date
                finalDueDate = DateTime.Parse(dueDateForProblemSet);
                if (loginTime.Date <= finalDueDate.Date)
                {
                    //Console.WriteLine("we can still do this problem set!!! Due date: " + setlist[i].dueDate);
                    //int Id = Convert.ToInt32(setlist[i].problemSetID);
                    int solved = Program.student_xml_problem_is_solved(currentUser.userID, setlist[i].problemSetID);
                    if (solved==0)
                    {
                        index = i;
                        break;
                    }
                }

            }/*/
        }
        /*
        private void loadTheProblemSetForStudent()
        {
            if (validateTheXMLFile())
            {
                StudentXMLFile = XElement.Load(fileName);
                //getting list of problems based on student's group
                setlist = Program.loadProblems(currentUser.group);

                Console.WriteLine("Set List is :" + setlist.Count());

                //If they don't have any file, then they don't have any problems assigned. Say so, and disable inputs to avoid issues.
                //else
                if (valid_problemset_index != -1)
                {
                    //Console.WriteLine("We are starting to set the problems!!!!");
                    buttonSubmit.Enabled = inputAnswer.Enabled = false;
                    labelQuestion.Text = "You have no problems assigned.";
                    labelQuestion.Top -= 40;
                    labelQuestion.Font = new Font("Microsoft Sans Serif", 13);
                    CancelButton = buttonLogout;
                    return;
                }
                //Find out how many problems in the current problem set they have.
                //problemSetSize = StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").Count();
                problemSetSize = setlist[checkProblemSetInDateRange()].problems.Count();
                max = problemSetSize * 2;
                
                //Get the first problem and display it.
                currentProblem = getProblem();
                if (currentProblem != null)
                    displayProblem();
            }
        }*/
        private void loadTheProblemSetForStudent()
        {
            if (validateTheXMLFile())
            {
                StudentXMLFile = XElement.Load(fileName);
                //getting list of problems based on student's group
                setlist = Program.loadProblems(currentUser.group);

                int valid_problemset_index = 0;

                Console.WriteLine("Number of Problems Sets:" + setlist.Count());
                //store problem set that can be solve based on date and if it is not solved
                if (checkProblemSetInDateRange() >= 0)
                {
                    valid_problemset_index = 1;
                }

                //If they don't have any file, then they don't have any problems assigned. Say so, and disable inputs to avoid issues.
                //else

                //Jorge Torres refactored if statement to accurately reflect that the current user is indeed in the
                //same group that the set list (problems being loaded) matches


                //Console.WriteLine("is this the valid problem index that is causing us to crash? :: " + valid_problemset_index);

                if (valid_problemset_index < 0)
                {
                    //if ((setlist[valid_problemset_index].group != currentUser.group))
                    // {
                    //Console.WriteLine("We are starting to set the problems!!!!");
                    buttonSubmit.Enabled = inputAnswer.Enabled = false;
                    labelQuestion.Text = "You have no problems assigned.";
                    labelQuestion.Top = 80;
                    labelQuestion.Font = new Font("Microsoft Sans Serif", 13);
                    CancelButton = buttonLogout;
                    return;
                    //}
                    //Find out how many problems in the current problem set they have.
                    //problemSetSize = StudentXMLFile.Descendants("ProblemSet").ElementAt(setIndex).Descendants("Problem").Count();
                }
                else if (valid_problemset_index > 0)
                {
                    problemSetSize = setlist[valid_problemset_index].problems.Count();
                    Debug.WriteLine("this is the size of the problem sets " + problemSetSize);
                }
                //Console.WriteLine("this is the problem set size)problemSetSize");

                max = problemSetSize * 2;

                //Get the first problem and display it.
                
                    //currentProblem = getProblem();

                if (getProblem() != null)
                {
                    currentProblem = getProblem();
                    displayProblem();
                }
                else
                {
                    //we are done
                    
                }
            }
                
        }
        //load the message for the user
        private bool validateTheXMLFile()
        {
            /*
             * Jorge & Aurelio & Kevin - Uncommenting code that was commented out in second cycle. Commenting this code is causing
             * for an unhandled exception to be thrown because it is trying to read a function 
             */
            fileName = @"c:\users\public\MathDrills\ProblemSets\setGroup" + currentUser.group + ".xml";
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Dialogue Box: No problem sets found for current user. CLick ok.");
                goToLogin();
                return false;
            }
            else
            {
                Console.WriteLine("The XML is valid");

                return true;
            }
=======
            currentUser = new Student();
            //currentUser = Program.Student[Program.currentStudentIndex];
            
            currentUser = Program.students[Program.currentStudentIndex]; //Program.teachers[Program.currentTeacherIndex].students[Program.currentStudentIndex];

            Console.WriteLine(currentUser.fullName);
>>>>>>> c70fcc07f9152a63dce728e6262ddb4a96ec1d13
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            loadAll();
<<<<<<< HEAD
           //loadAll();
        }

       


        //stand in print functionality -- not implemented because we are unable to load problems for the students to take
        //thi=e fucntionality would be simmilar to this to write to the graphs
        /*
       
          
           private Button printPreviewButton;

        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();

        // Declare a string to hold the entire document contents.
        private string documentContents;

        // Declare a variable to hold the portion of the document that
        // is not printed.
        private string stringToPrint;

        public Form1()
        {
            this.printPreviewButton = new System.Windows.Forms.Button();
            this.printPreviewButton.Location = new System.Drawing.Point(12, 12);
            this.printPreviewButton.Size = new System.Drawing.Size(125, 23);
            this.printPreviewButton.Text = "Print Preview";
            this.printPreviewButton.Click += new System.EventHandler(this.printPreviewButton_Click);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.printPreviewButton);
            printDocument1.PrintPage +=
                new PrintPageEventHandler(printDocument1_PrintPage);
        }
        private void ReadDocument()
        {
            string docName = "Student101.xml";
            string docPath = @"C:\Users\Public\MathDrills\Records\";
            printDocument1.DocumentName = docName;
            using (FileStream stream = new FileStream(docPath + docName, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                documentContents = reader.ReadToEnd();
            }

            formatXML(documentContents);

            stringToPrint = documentContents;

        }

        //parse the xlm file for individual report
        void formatXML(string print_string)
        {
            string xml_element="";

            string lastAccess = "<LastAccessed>";
            string endAccess = "</LastAccessed>";

            int y = 0;

            for (int x = 0; x < print_string.Length; x++)
            {
                if (x+lastAccess.Length < print_string.Length && print_string[x].Equals('<') && print_string.Substring(x, lastAccess.Length).Equals(lastAccess))
                {
                    //get the the substring between the tags of LastAccessed
                    while (!print_string.Substring(x + lastAccess.Length, lastAccess.Length).Equals(endAccess))
                    {
                        xml_element += print_string.Substring(x, 1);
                        Console.WriteLine(y);
                    }
                }

                //int first = print_string.IndexOf("LastAccessed") + "LastAccessed".Length;
                //int last = print_string.LastIndexOf("/LastAccessed");

                

                //string str2 = print_string.Substring(first, last - first);
                //stringToPrint = str2;
 
            }
        }
        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);


            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);
            
            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = documentContents;
        }
        private void printPreviewButton_Click(object sender, EventArgs e)
        {
            ReadDocument();

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();


        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
          
         
         */

=======
        }
>>>>>>> c70fcc07f9152a63dce728e6262ddb4a96ec1d13
    }//end StudentForm class
}//end namespace
