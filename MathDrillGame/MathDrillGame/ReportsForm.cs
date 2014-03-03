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
            dataGridProblemSets.ColumnHeadersBorderStyle = ProperColumnHeadersBorderStyle;
        }
        static DataGridViewHeaderBorderStyle ProperColumnHeadersBorderStyle
        {
            get
            {
                return (SystemFonts.MessageBoxFont.Name == "Segoe UI") ?
                DataGridViewHeaderBorderStyle.None :
                DataGridViewHeaderBorderStyle.Raised;
            }
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
                    usersSets.Add(new ProblemSet { isSolved = (set.Element("IsSolved").Value == "1"? true : false),
                                                operation = set.Element("Operator").Value,
                                                problemSetID = Convert.ToInt32(set.Element("ProblemSetID").Value)});
                                                   
                }

                foreach (ProblemSet set in usersSets)
                {
                    var problemsFromXML = from problem in studentsSetsXML.Elements("AllProblemSets").Elements("ProblemSet").Elements("Problem")
                                          where problem.Parent.Element("ProblemSetID").Value == Convert.ToString(set.problemSetID)
                                          select problem;

                    int numSolved = 0;
                    foreach (XElement prob in problemsFromXML)
                    {
                        if (prob.Element("IsSolved").Value == "1")
                            numSolved++;
                    }
                    set.solvedQuantity = numSolved;
                    set.totalQuantity = problemsFromXML.Count();
                    if (set.totalQuantity != 0)
                        set.score = numSolved / problemsFromXML.Count();
                    else
                        set.score = 0.0;

                   

                }
                dataGridProblemSets.DataSource = usersSets;
                dataGridProblemSets.Columns[0].HeaderText = "Select";
                dataGridProblemSets.Columns[1].HeaderText = "Set ID";
                dataGridProblemSets.Columns[2].HeaderText = "Operation";
                dataGridProblemSets.Columns[3].HeaderText = "Completed?";


                    
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

            labelDiag.Text = "Number of problems: " + problemsFromXML.Count();
            int numSolved = 0;
            foreach (XElement prob in problemsFromXML)
            {
                textBox1.AppendText(prob.Value + "\r\n");
                if (prob.Element("IsSolved").Value == "1")
                    numSolved++;
                
               problemsInSet.Add(new Problem
                {
                    isSolved = (prob.Element("IsSolved").Value == "1" ? true : false),
                    operand1 = Convert.ToInt32(prob.Element("Operand1").Value),
                    operand2 = Convert.ToInt32(prob.Element("Operand2").Value),
                    attemptNumber = Convert.ToInt32(prob.Element("Attempts").Value)

                });
            }
            labelDiag.Text = "Score: " + numSolved + "/" + problemsFromXML.Count();
            usersSets[selectedSet].score = numSolved / problemsFromXML.Count();
            dataGridProblemSets.DataSource = null;
            dataGridProblemSets.DataSource = usersSets;

            dataGridProblems.DataSource = problemsInSet;
            dataGridProblems.Columns[0].HeaderText = "First Operand";
            dataGridProblems.Columns[1].HeaderText = "Second Operand";
            dataGridProblems.Columns[2].HeaderText = "Answer";
            dataGridProblems.Columns[3].HeaderText = "Operation";
            dataGridProblems.Columns[4].HeaderText = "Solved?";
            dataGridProblems.Columns[5].HeaderText = "Attempts taken";


        }



    }
}

