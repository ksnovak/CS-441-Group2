using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* The USER class
 * The official list of users is saved in xml. But when it is read from xml, each user (student or teacher) is a User object.
 * Primarily used for the list views.
 */
namespace MathDrillGame
{
    class User
    {
        public User() { }
        public User(bool isAdmin, string fullName, int userID)
        {
            this.isAdmin = isAdmin;
            this.fullName = fullName;
            this.userID = userID;
        }

        public bool isAdmin { get; set; }
        public string fullName { get; set; }
        public int userID { get; set; } //Should be unique. When setting, there is a public static function, Program.getNextProblemSetID() that you should use to enforce uniqueness
        public DateTime lastLogin { get; set; }

        /* GETROLEANDNAME returns a string that concatenates the role (Teacher or Student) with the username.
         * Used for the listboxes, because only a single member may be the DisplayMember
         * Uriah and Kevin
         */
        public string getRoleAndName { get { return (isAdmin ? "Teacher" : "Student") + " - " + fullName; } } 
    }

}
