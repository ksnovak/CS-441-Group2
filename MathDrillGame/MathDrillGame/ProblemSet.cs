using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public bool isSolved { get; set;}
        public int solvedQuantity { get; set; }
        public int totalQuantity { get; set; }
        public string score { get; set; }
        public string lastAttempt { get; set; }
    }


}
