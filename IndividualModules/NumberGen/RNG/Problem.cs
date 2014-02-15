﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNG
{
    class Problem
    {
        public Problem() { }
        public Problem(int operand1, int operand2, bool operation) 
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
            this.operation = operation;
            this.solution = operand1 + operand2;
        }

        public int operand1 { get; set; }
        public int operand2 { get; set; }
        public int solution { get; set; }
        public bool operation { get; set; } //True = addition
        

        //My way to display the whole problem in the view
        public string printProblem()
        {
            string result;
            if (operation)
                result = operand1 + " + " + operand2 + " = " + solution;
            else
                result = operand1 + " - " + operand2 + " = " + solution;
            return result;
        }
    }
}
