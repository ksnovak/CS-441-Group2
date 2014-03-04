using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* The PROBLEM class
 * The official list of problems is saved in XML. But when it is read from XML, each problem is a Problem object
 * Used primarily for showing problems to students during the drills.
 */

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
            this.attemptNumber = 0; 
        }

        public int operand1 { get; set; }
        public int operand2 { get; set; }
        public int solution { get; set; }
        public string operation { get; set; } //Currently just addition or subtraction
        public bool isSolved { get; set; } //Gets set to 1 when the student correctly answers. Then the problem will not show up for them any more.
        public int attemptNumber { get; set; } //How many times a student has submitted an answer. Currently DOES keep track, but does NOT have consequences


        /* PRINTPROBLEM will return the problem as a string, for displaying in various places
         * Uriah and Kevin
         */
        public string printProblem()
        {
            return (operand1 + " " + operation  + " " + operand2);
        }
    }
}
