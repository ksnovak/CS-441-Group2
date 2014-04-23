/* CS 441
 * Created by: Aurelio Arango
 * Date: 3-25-14
 * Purpose: This is a Student class that contains all the information about a single student
 * 
 * Modification: added a field for password
 * date: 3-26-14
 * Name: Aurelio Arango
 * What/Why? store password
 * 
 * Modificiation: added a field for invisible
 * date:4-2-14
 * NAme: Aurelio Arango
 * What/Why? This field will set student to invisible, instead of deleting a student from the system.
 * This field takes a string n or y to set it.
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathDrillGame
{
    public class Student
    {
        public string fullName { get; set; }
        public int userID { get; set; } //Should be unique. When setting, there is a public static function, Program.getNextProblemSetID() that you should use to enforce uniqueness
        public DateTime lastLogin { get; set; }
        public string group { get; set; }
        public string pass { get; set; }
        public string invisible { get; set; }
        public int coins { get; set; }
        public Student()
        {
        }
        //Aurelio Arango
        //Constructor to set all the values
        public Student(string fullName, int userID, string group, string pass )
        {
            this.fullName = fullName;
            this.userID = userID;
            this.group = group;
            this.pass = pass;
            this.invisible = "n";
            this.coins = 0;
        }
        //function that gets the role and the name of the student.
        public string getRoleAndName
        {
            get { return "Student - " + this.fullName; }
        }
        /*---------------------------------------------------------------------------------------
        * JORGE TORRES: This method bellow will allow us to access the group the student is in.
        *--------------------------------------------------------------------------------------*/
        public string getGroup
        {
            get { return group; }
        }
    }
}
