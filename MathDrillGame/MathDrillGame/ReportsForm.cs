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

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            comboStudentList.DataSource = Program.users;
            comboStudentList.ValueMember = "userID";
            comboStudentList.DisplayMember = "getRoleAndName";
            dataGridProblemSets.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.Show();
            this.Close();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

            //  if (!File.Exists(@"c:\users\public\MathDrills\users.xml"))

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

                    usersSets.Add(new ProblemSet { isSolved = (set.Element("IsSolved").Value == "1"? true : false),
                                    operation = set.Element("Operator").Value,
                                    problemSetID = Convert.ToInt32(set.Element("ProblemSetID").Value),
                                    solvedQuantity = numSolved,
                                    totalQuantity = problemQuantity,
                                    score = ((float)numSolved / (float)problemQuantity).ToString("p1") //Forces the division to result in a float, and then converts that into xx.xx%
                    });
                                                   
                }
                dataGridProblemSets.DataSource = usersSets;
                if (dataGridProblemSets.Columns.Count > 1)
                {
                    dataGridProblemSets.Columns[0].HeaderText = "Select";
                    dataGridProblemSets.Columns[1].HeaderText = "Set ID";
                    dataGridProblemSets.Columns[2].HeaderText = "Operation";
                    dataGridProblemSets.Columns[3].HeaderText = "All done?";
                    dataGridProblemSets.Columns[4].HeaderText = "# Solved";
                    dataGridProblemSets.Columns[5].HeaderText = "# Total";
                    dataGridProblemSets.Columns[6].HeaderText = "Score";
                }

                

                    
            }//End if file exists
        }

        private void dataGridProblemSets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedSet = dataGridProblemSets.CurrentCellAddress.Y;

            dataGridProblems.DataSource = null;
            
            XDocument thefile = XDocument.Load(fileName);
            var problemsFromXML = from problem in thefile.Elements("AllProblemSets").Elements("ProblemSet").Elements("Problem")
                                  where problem.Parent.Element("ProblemSetID").Value == Convert.ToString(usersSets[selectedSet].problemSetID)
                                  select problem;

            List<Problem> problemsInSet = new List<Problem>();
            int numSolved = 0;
            textBoxReport.Text = "";

            string tempString = "";
            foreach (XElement prob in problemsFromXML)
            {
                if (prob.Element("IsSolved").Value == "1")
                    numSolved++;
                
               problemsInSet.Add(new Problem
                {
                    isSolved = (prob.Element("IsSolved").Value == "1" ? true : false),
                    operand1 = Convert.ToInt32(prob.Element("Operand1").Value),
                    operand2 = Convert.ToInt32(prob.Element("Operand2").Value),
                    //operation = 
                    attemptNumber = Convert.ToInt32(prob.Element("Attempts").Value)

                });
               tempString += prob.Element("Operand1").Value + " " + prob.Parent.Element("Operator").Value + " " + prob.Element("Operand2").Value + (prob.Element("Attempts").Value != "0" ? "\tTried " + prob.Element("Attempts").Value + " times" : "") + (prob.Element("IsSolved").Value == "1" ? " (Solved)" : "") + "\r\n";
            }
            textBoxReport.AppendText("Report for problem set " + Convert.ToString(usersSets[selectedSet].problemSetID) + "\r\n");

            textBoxReport.AppendText("Last attempted on " + "asdf" + "\r\n");

            textBoxReport.AppendText("Questions solved: " + numSolved + "\r\n" + "Questions in the set: " + problemsFromXML.Count() + "\r\n");

            textBoxReport.AppendText("\r\nProblems in set: \r\n-----\r\n");
            textBoxReport.AppendText(tempString);
            
            dataGridProblemSets.DataSource = null;
            dataGridProblemSets.DataSource = usersSets;

            dataGridProblems.DataSource = problemsInSet;
            dataGridProblems.Columns[0].HeaderText = "First Operand";
            dataGridProblems.Columns[1].HeaderText = "Second Operand";
            dataGridProblems.Columns[2].HeaderText = "Answer";
            dataGridProblems.Columns[3].Visible = false; //Operation section
            dataGridProblems.Columns[4].HeaderText = "Solved?";
            dataGridProblems.Columns[5].HeaderText = "Attempts taken";
        }
    }
}

