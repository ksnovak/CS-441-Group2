using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;


/* update user list after creation
 * ability to remove students?
 */


namespace MathDrillGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        

        public static List<User> users = new List<User>();
        public static int currentUserIndex; //Who is logged in
        public static int targetUser; //For the admin, this is who to generate problems for.
        public static int nextUserID = 101; //Enforces globally unique student IDs. When making new students, do "Program.nextUserID++"
        public static int nextProblemSetID = 1; //Enforces globally unique problem set IDs. When making new problem sets, do "Program.newProblemSetID++"
        public static string USERSFILE = @"c:\users\public\MathDrills\users.xml";
        public static string CONFIGFILE = @"c:\users\public\MathDrills\config.xml";
        public static DateTime MINDATE = new DateTime(2013, 12, 31);

        [STAThread]
        static void Main()
        {
            bool result;
            var mutex = new System.Threading.Mutex(true, "MathDrills", out result);
            if (!result)
            {
                MessageBox.Show("The game is already open in another window.");
                return;

            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Directory.CreateDirectory(@"c:\users\public\MathDrills\ProblemSets"); //Make sure there is a directory into which to save the problems
            
            initializeConfigFile();
            initializeUserList();
            
            Application.Run(new LoginForm());
            GC.KeepAlive(mutex);
        }

        private static void initializeUserList()
        {
            XmlDocument doc;
            if (!File.Exists(USERSFILE))
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
                buserID.InnerText = getNextUserID() + "";
                BillJAdmin.AppendChild(buserID);
                XmlElement blastLogin = doc.CreateElement("LastLogin");
                blastLogin.InnerText = MINDATE.ToString("g");
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
                    userID.InnerText = "" + getNextUserID();
                    newStudent.AppendChild(userID);
                    XmlElement lastLogin = doc.CreateElement("LastLogin");
                    lastLogin.InnerText = MINDATE.ToString("g");
                    newStudent.AppendChild(lastLogin);
                    studentList.AppendChild(newStudent);
                }
                doc.AppendChild(studentList);
                doc.Save(USERSFILE);
            }
            else //If there is already a list of users, make sure to still get the next valid User ID.
            {
                XElement user = XElement.Load(USERSFILE);
                nextUserID = Convert.ToInt32(user.Descendants("Student").Last().Element("UserID").Value)+1;
            }
        }
        private static void initializeConfigFile()
        {
              
              if (!File.Exists(CONFIGFILE))
              {
                  XmlDocument doc = new XmlDocument();
                  XmlElement configs = doc.CreateElement("Configs");
                  XmlElement nextValidUser = doc.CreateElement("NextValidUser");
                  nextValidUser.InnerText = nextUserID.ToString();
                  configs.AppendChild(nextValidUser);
                  XmlElement nextValidSet = doc.CreateElement("NextValidSet");
                  nextValidSet.InnerText = nextProblemSetID.ToString();
                  configs.AppendChild(nextValidSet);
                  doc.AppendChild(configs);
                  doc.Save(CONFIGFILE);
              }
              else
              {
                  XElement doc = XElement.Load(CONFIGFILE);
                  nextUserID = Convert.ToInt32(doc.Element("NextValidUser").Value);
                  nextProblemSetID = Convert.ToInt32(doc.Element("NextValidSet").Value);
              }
        }

        public static int getNextUserID()
        {
            return nextUserID++;
        }

        public static int getNextProblemSetID()
        {
            return nextProblemSetID++;
        }
    }
}
