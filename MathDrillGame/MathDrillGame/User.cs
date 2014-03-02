using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

/*
 *<AllUsers>
	<User>
		<UserID>1</UserID>
		<FullName>Fred Smith</FullName>
		<Password>icecream</Password>
		<IsAdmin>0</IsAdmin>
		<LastLogin>2/1/2014</LastLogin>
	</User>
</AllUsers> 
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
        public int userID { get; set; }
        public string getRoleAndName { get { return (isAdmin ? "Teacher" : "Student") + " - " + fullName; } }
        //public List<Problem> problemSet = new List<Problem>(); //Where each individual has their problems stored.
    }
}
