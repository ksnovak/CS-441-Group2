using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* The PROBLEMSET class
 * This data is stored in XML, but gets read from XML for the reports view
 * Used for data about a set of problems. 
 */

namespace MathDrillGame
{
    class ProblemSet
    {
        public ProblemSet() { }
        public ProblemSet(int problemSetID, string operation, bool isSolved, 
            int solvedQuantity, int totalQuantity, string score, string lastAttempt,string group, int min, int max)
        {
            this.problemSetID = problemSetID;
            this.operation = operation;
            this.isSolved = isSolved;
            this.solvedQuantity = solvedQuantity;
            this.totalQuantity = totalQuantity;
            this.score = score;
            this.lastAttempt = lastAttempt;
            this.group = group;
            this.problems = new List<Problem>();
            
            List<int> problem= new List<int>();//add operands
            for (int i = 0; i < totalQuantity; i++)
            {
                problem = generateProblemSet(min,max);
                problems.Add(new Problem(problem[0], problem[1], operation));
            }
        }

        public int problemSetID { get; set;}
        public string operation { get; set; }
        public bool isSolved { get; set;}       //If the entire set is solved
        public int solvedQuantity { get; set; } //How many problems are set to isSolved
        public int totalQuantity { get; set; }  //How many problems are in a set
        public string score { get; set; }       // Solved / Total = Score
        public string lastAttempt { get; set; } //The last time they attempted a problem set. String form of a DateTime object
        public string group { get; set; }//this set pertains to a class, A, B, or C
        public List<Problem> problems { get; set; }
        
        /* PRINTSUMMARY is used for the reporting view, to get summary details on a set.
         * Kevin and Uriah
         */
        public string printSummary()
        {
            return (problemSetID + "\t" + operation + "\t" + totalQuantity + "\t" + solvedQuantity + "\t" + score + "\t" + lastAttempt +"\t"+group + "\r\n");
        }

        public List<int> generateProblemSet(int min,int max)
        {
            
            List<int> operands = new List<int>();
            int op1=0;
            int op2=1;//initial value
            while (op1 < op2)
            {
                op1 = Program.rng.Next(min, max);   //rng.Next will randomly generate an integer between min and max
                op2 = Program.rng.Next(min, max);
            }
            operands.Add(op1);
            operands.Add(op2);

            return operands;
        }
    }


}
