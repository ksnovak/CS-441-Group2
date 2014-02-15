using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNG
{
    public partial class Form1 : Form
    {
        int min;
        int max;
        bool isAddition;
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            //Check that every field has a value in it.
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
                isAddition = addButton.Checked;
                List<Problem> problems = new List<Problem>(); //For storing the problems
                outputProblems.Text = "Please wait, generating problems.\r\n";
                this.Refresh();

                //Generate problems and store in the list
                for (int i = 0; i < quantity; i++)
                {
                    problems.Add(generateProblem());
                }


                //Show the problems that were generated. Note that doing .Text (rather than .AppendText) will clear all the previous stuff in the textbox.
                outputProblems.Text = "Problem set: \r\n"; 
                foreach (Problem problem in problems)
                {
                    outputProblems.AppendText(problem.printProblem() + "\r\n");
                }
            }
        }

        static Random rng = new Random(); //This will also set a random seed, so that the things are even more random.
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
    }
}
