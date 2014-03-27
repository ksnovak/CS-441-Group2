using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathDrillGame
{
    class Student
    {
        public string fullName { get; set; }
        public int userID { get; set; } //Should be unique. When setting, there is a public static function, Program.getNextProblemSetID() that you should use to enforce uniqueness
        public DateTime lastLogin { get; set; }
        public string group { get; set; }
        public string pass { get; set; }
        public Student()
        {
        }
        public Student(string fullName, int userID, string group, string pass )
        {
            this.fullName = fullName;
            this.userID = userID;
            this.group = group;
            this.pass = pass;
        }
        public string getRoleAndName
        {
            get { return "Student - " + this.fullName; }
        }
    }
}
