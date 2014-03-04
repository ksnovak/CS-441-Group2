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
            int solvedQuantity, int totalQuantity, string score, string lastAttempt)
        {
            this.problemSetID = problemSetID;
            this.operation = operation;
            this.isSolved = isSolved;
            this.solvedQuantity = solvedQuantity;
            this.totalQuantity = totalQuantity;
            this.score = score;
            this.lastAttempt = lastAttempt;
        }

        public int problemSetID { get; set;}
        public string operation { get; set; }
        public bool isSolved { get; set;}       //If the entire set is solved
        public int solvedQuantity { get; set; } //How many problems are set to isSolved
        public int totalQuantity { get; set; }  //How many problems are in a set
        public string score { get; set; }       // Solved / Total = Score
        public string lastAttempt { get; set; } //The last time they attempted a problem set. String form of a DateTime object

        /* PRINTSUMMARY is used for the reporting view, to get summary details on a set.
         * 
         */
        public string printSummary()
        {
            return (problemSetID + "\t" + operation + "\t" + totalQuantity + "\t" + solvedQuantity + "\t" + score + "\t" + lastAttempt + "\r\n");
        }
    }


}
