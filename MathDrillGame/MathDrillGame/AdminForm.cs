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
    public partial class AdminForm : Form
    {
        int min;
        int max;
        bool isAddition;
        bool isAppending;
        static Random rng = new Random(); //This will set a random seed, so that the things are even more random.
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = "Welcome, " + Program.users[Program.currentUser].fullName;
            listOfStudents.DataSource = Program.users;
            listOfStudents.DisplayMember = "fullName";
            listOfStudents.ValueMember = "userID";
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void listOfStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.targetUser = Convert.ToInt32(listOfStudents.SelectedIndex);
            if (!Program.users[Program.targetUser].isAdmin)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputMin.Text.Length == 0 || inputMax.Text.Length == 0 || inputQuantity.Text.Length == 0)
            {
                return;
            }

            else
            {
                min = Convert.ToInt32(inputMin.Text); //Turn the string input into ints
                max = Convert.ToInt32(inputMax.Text);
                if (min > max) //If users mistook min for max, swap the values.
                {
                    int temp = min;
                    min = max;
                    max = temp;
                }
                int quantity = Convert.ToInt32(inputQuantity.Text);
                isAddition = radioAddition.Checked;
                isAppending = radioAppend.Checked;

                if (!isAppending)
                {
                    Program.users[Program.targetUser].problemSet.Clear();
                }

                for (int i = 0; i < quantity; i++)
                {
                    Program.users[Program.targetUser].problemSet.Add(generateProblem());
                }

                textBox1.Text = "Problem set: \r\n"; 
                foreach (Problem problem in Program.users[Program.targetUser].problemSet)
                {
                    textBox1.AppendText(problem.printProblem() + "\r\n");
                }
            }
        }

        
        private Problem generateProblem()
        {
            Problem problem = new Problem();
            problem.operand1 = rng.Next(min, max);
            problem.operand2 = rng.Next(min, max);
            problem.operation = isAddition; //True = addition selected (default), False = subtraction selected.
            if (problem.operation)
                problem.solution = problem.operand1 + problem.operand2;
            else
                problem.solution = problem.operand1 - problem.operand2;

            return problem;
        }

        private void Operation_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
