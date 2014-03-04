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

namespace MathDrillGame
{
    public partial class ReportsForm : Form
    {
        int targetStudentID;
        string fileName = "";
        List<ProblemSet> usersSets = new List<ProblemSet>();
        List<Problem> problemsInSet = new List<Problem>();
        List<User> adminStudentList = new List<User>();
        string summaryText = "";

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            XElement studentListXML = XElement.Load(Program.USERSFILE);
            adminStudentList.Clear();
            foreach (XElement user in studentListXML.Descendants("Student"))
            {
                if (user.Element("IsAdmin").Value == "0")
                {
                    adminStudentList.Add(new User
                    {
                        isAdmin = (user.Element("IsAdmin").Value == "1" ? true : false),
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


        private void comboStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetStudentID = Program.users[comboStudentList.SelectedIndex].userID;
            fileName = @"c:\users\public\MathDrills\ProblemSets\" + targetStudentID + ".xml";
            findProblemSets();
        }


        public void findProblemSets()
        {
            usersSets.Clear();
            dataGridProblemSets.DataSource = null;
            textBoxReport.Text = "";

            XElement usersfile = XElement.Load(Program.USERSFILE);
            var selectUser = from user in usersfile.Elements("Student")
                             where Convert.ToInt32(user.Element("UserID").Value) == targetStudentID
                             select user;
            
            summaryText = "Student activity report for ";
            foreach (XElement user in selectUser)
            {
                summaryText += user.Element("FullName").Value + " (Student ID #" + user.Element("UserID").Value + ")\r\n";
                if (user.Element("LastLogin").Value == Program.MINDATE.ToString("g"))
                    summaryText += "Never logged in\r\n";
                else
                    summaryText += "Last logged in: " + user.Element("LastLogin").Value + "\r\n";
            }
            if (File.Exists(fileName))
            {
                XElement studentsSetsXML = XElement.Load(fileName);

                foreach (XElement set in studentsSetsXML.Descendants("ProblemSet"))
                {
                    int numSolved = 0;
                    int problemQuantity = 0;

                    var problemsFromXML = from problem in set.Elements("Problem")
                                          select problem;
                    foreach(XElement prob in problemsFromXML) 
                    {
                        if (prob.Element("IsSolved").Value == "1")
                            numSolved++;
                        problemQuantity++;
                    }

                    DateTime lastAccessed = DateTime.Parse(set.Element("LastAccessed").Value);
                    /* Sets which have been attempted have to be within the min and max range
                     * Unattempted problems need the checkbox to be set.
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

                if (usersSets.Count > 0)
                {
                    dataGridProblemSets.DataSource = usersSets;
                    if (dataGridProblemSets.Columns.Count > 1)
                    {
                        dataGridProblemSets.Columns[0].HeaderText = "Set ID";
                        dataGridProblemSets.Columns[1].Visible = false;
                        dataGridProblemSets.Columns[2].HeaderText = "All done?";
                        dataGridProblemSets.Columns[3].Visible = false;
                        dataGridProblemSets.Columns[4].Visible = false;
                        dataGridProblemSets.Columns[5].HeaderText = "Score";
                        dataGridProblemSets.Columns[6].HeaderText = "Attempted on";
                    }

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

