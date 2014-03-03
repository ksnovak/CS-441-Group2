using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;


/* Update lastLoggedIn          http://www.dotnetperls.com/datetime
 * update user list after creation
 * ability to remove students?
 * force unique ID? (Can hack by just searching for an ID, if found, increment and research)
 */


namespace MathDrillGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //These 3 are static variables so that I can use them throughout the program. The userlist will be XML, but there must be a better way than this for the other 2.
        public static List<User> users = new List<User>();
        public static int currentUserIndex; //Who is logged in
        public static int targetUser; //For the admin, this is who to generate problems for.
        public static int nextUserID = 101; //Enforces globally unique student IDs. When making new students, do "Program.nextUserID++"
        public static int newProblemSetID = 1; //Enforces globally unique problem set IDs. When making new problem sets, do "Program.newProblemSetID++"

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Directory.CreateDirectory(@"c:\users\public\MathDrills\ProblemSets"); //Make sure there is a directory into which to save the problems

            initializeUserList();

            Application.Run(new LoginForm());
        }

        private static void initializeUserList()
        {
            XmlDocument doc;
            if (!File.Exists(@"c:\users\public\MathDrills\users.xml"))
            {
                doc = new XmlDocument();
                XmlElement studentList = doc.CreateElement("StudentList");
                XmlElement BillJAdmin = doc.CreateElement("Student");
                XmlElement bfullName = doc.CreateElement("FullName");
                bfullName.InnerText = "Bill J. Admin";
                BillJAdmin.AppendChild(bfullName);
                XmlElement bisAdmin = doc.CreateElement("IsAdmin");
                bisAdmin.InnerText = "1";
                BillJAdmin.AppendChild(bisAdmin);
                XmlElement buserID = doc.CreateElement("UserID");
                buserID.InnerText = nextUserID++ + "";
                BillJAdmin.AppendChild(buserID);
                XmlElement blastLogin = doc.CreateElement("LastLogin");
                blastLogin.InnerText = DateTime.MinValue.ToString();
                BillJAdmin.AppendChild(blastLogin);
                studentList.AppendChild(BillJAdmin);

                String[] students = new String[10] { "Susan M. Doe", "Joe A. Doe", "Edgar L. Park", "Jane G. Kragen", "Matt Y. Herman", "Jessica Q. Booker", "Laura T. Gwinn", "Patrick D. Henry", "Megan P. Nelson", "Brian H. Noll" };
                for (int i = 0; i < students.Length; i++)
                {
                    XmlElement newStudent = doc.CreateElement("Student");
                    XmlElement fullName = doc.CreateElement("FullName");
                    fullName.InnerText = students[i];
                    newStudent.AppendChild(fullName);
                    XmlElement isAdmin = doc.CreateElement("IsAdmin");
                    isAdmin.InnerText = "0";
                    newStudent.AppendChild(isAdmin);
                    XmlElement userID = doc.CreateElement("UserID");
                    userID.InnerText = "" + nextUserID++;
                    newStudent.AppendChild(userID);
                    XmlElement lastLogin = doc.CreateElement("LastLogin");
                    lastLogin.InnerText = DateTime.MinValue.ToString();
                    newStudent.AppendChild(lastLogin);
                    studentList.AppendChild(newStudent);
                }
                doc.AppendChild(studentList);
                doc.Save(@"c:\users\public\MathDrills\users.xml");
            }
            else
            {
                XElement user = XElement.Load(@"c:\users\public\MathDrills\users.xml");
                nextUserID = Convert.ToInt32(user.Descendants("Student").Last().Element("UserID").Value)+1;
            }
        }
    }
}
