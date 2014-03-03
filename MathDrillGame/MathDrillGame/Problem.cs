using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace MathDrillGame
{
    public class Problem
    {
        public Problem() { }
        public Problem(int operand1, int operand2, string operation)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
            this.operation = operation;
            this.solution = operand1 + operand2;
            this.isSolved = false;
            this.attemptNumber = 0; //For future cases, where we're restricting to 2 attempts on a problem only
        }

        public int operand1 { get; set; }
        public int operand2 { get; set; }
        public int solution { get; set; }
        public string operation { get; set; } //True = addition
        public bool isSolved { get; set; }
        public int attemptNumber { get; set; }


        //My way to display the whole problem in the view
        public string printProblem()
        {
            string result = operand1 + " " + operation  + " " + operand2;
            return result;
        }
    }
}
