/* CS 441
 * Created by: Aurelio Arango
 * Date: 3-25-14
 * Purpose: This is a Teacher class that contains all the information about a teacher and its students
 * 
 * Modification: added a field for password
 * date: 3-26-14
 * Name: Aurelio Arango
 * What/Why? store password after reading xml
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathDrillGame
{
    class Teacher
    {
        public string fullName { get; set; }
        public int userID { get; set; } //Should be unique. When setting, there is a public static function, Program.getNextProblemSetID() that you should use to enforce uniqueness
        public DateTime lastLogin { get; set; }
        public List<Student> students { get; set; }
        public string pass { get; set; }
        //Empty Constructor
        public Teacher() 
        {
        }
        //Aurelio Arango
        //Teacher Constructor, takes in name, user id, a list of students, and password
        public Teacher(string fullName, int userID, List<Student> students, string pass)
        {
            //this.isAdmin = isAdmin;
            this.fullName = fullName;
            this.userID = userID;
            this.students = students;
            this.pass = pass;
        }
        //Aurelio Arango
        //returns the role and its full name
        public string getRoleAndName
        {
            get { return "Teacher - " + this.fullName; }
        }
        
    }
}
