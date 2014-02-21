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
        int problemNum = 0;
        Problem currentProblem;

        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = "Welcome, " + Program.users[Program.currentUser].fullName;
            foreach (Problem problem in Program.users[Program.currentUser].problemSet)
            {
                textBox1.AppendText(problem.printProblem() + "\r\n");
            }

            currentProblem = getProblem();
            displayProblem();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }
        /*
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            checkAnswer();
            currentProblem = getProblem();
            displayProblem();
        }*/

        public Problem getProblem()
        {
            Program.users[Program.currentUser].problemSet[problemNum].attemptNumber++;
            return Program.users[Program.currentUser].problemSet[problemNum];
        }

        public void displayProblem()
        {
            labelQuestion.Text = currentProblem.printProblem();
        }
        /*
        public bool checkAnswer()
        {
            if (currentProblem.solution == Convert.ToInt32(inputAnswer.Text))
            {
                Program.users[Program.currentUser].problemSet[problemNum].isSolved = true;
                problemNum++;
                return true;
            }
            else
            {
                problemNum++;
                return false;
            }
        }*/

    }
}
