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

/* The REPORTS form, used by teachers to get statistics on their students
 * Has a list of students. Selection of one will show a list of their problem sets in a dataGrid, as well as printing student information.
 * Has a datagrid of problem sets to a specific user. Selection of one or multiple sets will print information about those sets and their problems
 */

namespace MathDrillGame
{
    public partial class ReportsForm : Form
    {
        int targetStudentID;
        string fileName = ""; //Regularly updates to target the currently-selected student's file
        List<User> adminStudentList = new List<User>();         //List of all students (excludes teachers)
        List<ProblemSet> usersSets = new List<ProblemSet>();    //List of all of the problem sets to a specific students
        List<Problem> problemsInSet = new List<Problem>();      //List of all problems to a specific set
        
        string summaryText = ""; //A string used for printing to the textBox. This is done instead of directly printing just due to the ordering of execution vs. what needs to be printed

        public ReportsForm()
        {
            InitializeComponent();
        }

        /* LOAD event, triggered when the form loads
         * Will read from the student list XML into a List of User objects, and set the default values for the datetimepickers
         * Kevin and Uriah
         */
        private void Reports_Load(object sender, EventArgs e)
        {
            XElement studentListXML = XElement.Load(Program.USERSFILE);
            adminStudentList.Clear();
            foreach (XElement user in studentListXML.Descendants("Student"))
            {
                if (user.Element("IsAdmin").Value == "0") //Exclude the teachers from this list
                {
                    adminStudentList.Add(new User
                    {
                        isAdmin = false,
                        fullName = user.Element("FullName").Value,
                        userID = Convert.ToInt32(user.Element("UserID").Value)
                    });
                }
            }
            comboStudentList.DataSource = adminStudentList;
            comboStudentList.ValueMember = "userID";
            comboStudentList.DisplayMember = "fullName";
            dateTimePickerMin.Value = new DateTime(2014, 1, 1);
            dateTimePickerMax.Value = new DateTime(2014, 12, 31).AddHours(23).AddMinutes(59).AddSeconds(59); //Get the very end of today
        }

        /* COMBOBOX SELECTION event, when a student is selected in the combobox
         * Updates the integer keeping track of the current student's ID, the filename string, and finds the problem sets for that student
         * Kevin and Uriah
         */
        private void comboStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetStudentID = adminStudentList[comboStudentList.SelectedIndex].userID;
            fileName = @"c:\users\public\MathDrills\ProblemSets\" + targetStudentID + ".xml";
            findProblemSets();
        }

        /* FINDPROBLEMSETS will take the selected student, read their problem sets from XML, put it into a List, and then display the sets in a dataGrid
         * Kevin and Uriah
         */
        public void findProblemSets()
        {
            usersSets.Clear(); //Empty the list of problem sets, to avoid problems from viewing multiple students in a session
            dataGridProblemSets.DataSource = null;
            textBoxReport.Text = ""; //Empty the textbox area

            XElement usersfile = XElement.Load(Program.USERSFILE);
            var selectUser = from user in usersfile.Elements("Student") //Find the selected user in the USERS xml file
                             where Convert.ToInt32(user.Element("UserID").Value) == targetStudentID
                             select user;
            
            //Print out general information regarding the student (Name, ID, last login)
            summaryText = "Student activity report for ";
            foreach (XElement user in selectUser)
            {
                summaryText += user.Element("FullName").Value + " (Student ID #" + user.Element("UserID").Value + ")\r\n";
                if (user.Element("LastLogin").Value == Program.MINDATE.ToString("g"))
                    summaryText += "Never logged in\r\n";
                else
                    summaryText += "Last logged in: " + user.Element("LastLogin").Value + "\r\n";
            }

            //Check if they have problem sets file (ie, if they have any problems assigned).
            //If so, start adding problem sets to the List which will then be shown in the dataGrid
            if (File.Exists(fileName))
            {
                XElement studentsSetsXML = XElement.Load(fileName);
                foreach (XElement set in studentsSetsXML.Descendants("ProblemSet"))
                {
                    int numSolved = 0;      //How many problems in the set are solved
                    int problemQuantity = 0; //How many problems are in the set

                    var problemsFromXML = from problem in set.Elements("Problem")
                                          select problem;
                    foreach(XElement prob in problemsFromXML) 
                    {
                        if (prob.Element("IsSolved").Value == "1")
                            numSolved++;
                        problemQuantity++;
                    }

                    DateTime lastAccessed = DateTime.Parse(set.Element("LastAccessed").Value); //Turn the LastLogin string into a DateTime object
                    /* Sets which have been attempted have to be within the min and max range 
                     * Unattempted problems need the checkbox to be set.
                     */
                 
                /* Find the problems which either:
                 * A) have been attempted some point within the date range as specified by the teacher
                 * B) have never been attempted, IF the checkbox to allow un-attempted sets is checked
                 * 
                 * If it meets one of those 2, then add to the list of sets.
                 */
                if (    ((lastAccessed.Date <= dateTimePickerMax.Value) && (lastAccessed >= dateTimePickerMin.Value))   ||   (lastAccessed == Program.MINDATE && checkBoxUnattempted.Checked)   )
                    {
                        usersSets.Add(new ProblemSet
                        {
                            isSolved = (set.Element("IsSolved").Value == "1" ? true : false),
                            operation = set.Element("Operator").Value,
                            problemSetID = Convert.ToInt32(set.Element("ProblemSetID").Value),
                            solvedQuantity = numSolved,
                            totalQuantity = problemQuantity,
                            score = ((float)numSolved / (float)problemQuantity).ToString("p1"), //Forces the division to result in a float, and then converts that into xx.xx%
                            lastAttempt = (set.Element("LastAccessed").Value == DateTime.MinValue.ToString("g")) ? "Never" : set.Element("LastAccessed").Value
                        });
                    }
                                                   
                } 

                //If there has been at least one valid set found, then apply it to the dataGrid
                if (usersSets.Count > 0)
                {
                    dataGridProblemSets.DataSource = usersSets;
                    dataGridProblemSets.Columns[0].HeaderText = "Set ID";
                    dataGridProblemSets.Columns[1].Visible = false;
                    dataGridProblemSets.Columns[2].HeaderText = "All done?";
                    dataGridProblemSets.Columns[3].Visible = false;
                    dataGridProblemSets.Columns[4].Visible = false;
                    dataGridProblemSets.Columns[5].HeaderText = "Score";
                    dataGridProblemSets.Columns[6].HeaderText = "Attempted on";

                    summaryText += "\r\nProblem Set Summary \r\nID \tType \tQty \tCorrect \tScore \tQuiz Date \r\n";
                    foreach (ProblemSet set in usersSets)
                    {
                        summaryText += set.printSummary();
                    }
                }
            }//End of if(file.exists)
            textBoxReport.AppendText(summaryText);
        }

        private void dataGridProblemSets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBoxReport.Text = summaryText + "\r\n";

            int selectedSet;
            if (!File.Exists(fileName))
                return;
            XDocument thefile = XDocument.Load(fileName);
            foreach (DataGridViewRow row in dataGridProblemSets.SelectedRows)
            {
                selectedSet = row.Index;
                var problemsFromXML = from problem in thefile.Elements("AllProblemSets").Elements("ProblemSet").Elements("Problem")
                                      where problem.Parent.Element("ProblemSetID").Value == Convert.ToString(usersSets[selectedSet].problemSetID)
                                      select problem;

                textBoxReport.AppendText("Problem Set #" + usersSets[selectedSet].problemSetID + " Details");
                if (thefile.Elements("AllProblemSets").Elements("ProblemSet").ElementAt(selectedSet).Element("LastAccessed").Value == Program.MINDATE.ToString("g"))
                {
                    textBoxReport.AppendText("(NOT TAKEN)");
                }
                textBoxReport.AppendText(" \r\n");



                List<Problem> problemsInSet = new List<Problem>();
                int numSolved = 0;

                int iterator = 0;
                foreach (XElement prob in problemsFromXML)
                {
                    iterator++;
                    if (prob.Element("IsSolved").Value == "1")
                        numSolved++;

                    problemsInSet.Add(new Problem
                    {
                        isSolved = (prob.Element("IsSolved").Value == "1" ? true : false),
                        operand1 = Convert.ToInt32(prob.Element("Operand1").Value),
                        operand2 = Convert.ToInt32(prob.Element("Operand2").Value),
                        attemptNumber = Convert.ToInt32(prob.Element("Attempts").Value),

                    });

                    /*Examples of how the next line will actually appear, under different circumstances
                         1) 	66 + 63	 2 attempts  (Solved)
                         2) 	60 + 66	 1 attempt 
                         3) 	62 + 67	 no attempts */
                    textBoxReport.AppendText(iterator + ")\t" + prob.Element("Operand1").Value + " " + prob.Parent.Element("Operator").Value + " " + prob.Element("Operand2").Value
                        + "\t " + (prob.Element("Attempts").Value != "0" ? prob.Element("Attempts").Value : "no")
                        + (prob.Element("Attempts").Value == "1" ? " attempt " : " attempts ")
                        + (prob.Element("IsSolved").Value == "1" ? " (Solved)" : "") + "\r\n");
                }//End of foreach
                textBoxReport.AppendText("\r\n");
            }
        }            
        

        
        private void buttonExit_Click(object sender, EventArgs e)
        {
            /*var admin = (AdminForm)Tag;
            admin.Show();
            admin.Activate();
            Close();*/
            Close();
        }

        private void checkBoxUnattempted_CheckedChanged(object sender, EventArgs e)
        {
            findProblemSets();
        }

        private void dateTimePickerMin_ValueChanged(object sender, EventArgs e)
        {
            findProblemSets();
        }

        private void dateTimePickerMax_ValueChanged(object sender, EventArgs e)
        {
            findProblemSets();
        }
    }
}

