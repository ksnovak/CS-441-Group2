using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
/* The PROGRAM class
 * This is the class of the main program itself which runs
 * It holds some static values, including a user list and file paths
 * Makes use of a mutex to allow only one instance of the program.
 * Generates a list of sample users in XML
 */

namespace MathDrillGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static List<User> users = new List<User>();
        public static List<Teacher> teachers = new List<Teacher>();// stores all the teachers
        public static List<Student> students = new List<Student>();// stores the students for a given teacher

        public static int currentUserIndex; //Who is logged in
        public static int currentTeacherIndex;//Aurelio Arango 3-25-14 - admin logged in
        public static int currentStudentIndex;//Aurelio Arango 3-25-14 - student logged in
        public static int targetUser; //For the admin, this is who to generate problems for
        public static int nextUserID = 101; //Enforces globally unique student IDs. When making new students, do "Program.nextUserID++"
        public static int nextProblemSetID = 1; //Enforces globally unique problem set IDs. When making new problem sets, do "Program.newProblemSetID++"
        //public static string USERSFILE = @"c:\users\public\MathDrills\users.xml";
        public static string USERSFILE = @"c:\users\public\MathDrills\users_v2.xml";
        public static string CONFIGFILE = @"c:\users\public\MathDrills\config.xml";
        public static DateTime MINDATE = new DateTime(2013, 12, 31);

        [STAThread]
        /* mutex tries to create a mutex lock, titled "MathDrills". result will be whether or not that succeeded. It won't succeed if it is already locked
         * GC.KeepAlive means that the garbage collector will never release that mutex.
         * 
         * If it could not get the mutex lock, then don't bother running the rest of the program.
         */
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

            Application.Run(new StartForm());

            //Application.Run(new LoginForm());
            GC.KeepAlive(mutex);
        }


        /* INITIALIZEUSERLIST will create a list of default users in XML, including an administrator
         * 
         * Kevin and Uriah
         */
        private static void initializeUserList()
        {
            XmlDocument doc;
            if (!File.Exists(USERSFILE))
            {
                doc = new XmlDocument();
                XmlElement studentList = doc.CreateElement("StudentList");
                XmlElement DefaultAdmin = doc.CreateElement("Student");
                XmlElement afullName = doc.CreateElement("FullName");
                afullName.InnerText = "Default Admin";
                DefaultAdmin.AppendChild(afullName);
                XmlElement aisAdmin = doc.CreateElement("IsAdmin");
                aisAdmin.InnerText = "1";
                DefaultAdmin.AppendChild(aisAdmin);
                XmlElement auserID = doc.CreateElement("UserID");
                auserID.InnerText = getNextUserID() + "";
                DefaultAdmin.AppendChild(auserID);
                XmlElement alastLogin = doc.CreateElement("LastLogin");
                alastLogin.InnerText = MINDATE.ToString("g");
                DefaultAdmin.AppendChild(alastLogin);
                studentList.AppendChild(DefaultAdmin);

                String[] students = new String[5] { "Susan M. Doe", "Joe A. Doe", "Edgar L. Park", "Jane G. Kragen", "Matt Y. Herman"};
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

        /* INITIALIZECONFIGFILE will create a config file 
         * Currently, it is used for ensuring unique IDs (for students and for problem sets)
         * If the file is not found, then set values in the file to some default ones.
         * If the file is found, then set the program's statics to the values in the file.
         */
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

        /* GETNEXTUSERID will both return a unique ID and increment the static to the next one
         * Kevin and Uriah 
         */
        public static int getNextUserID()
        {
            return nextUserID++;
        }

        /* GETNEXTPROBLEMSETID will both return a unique ID and increment the static to the next one
         * Kevin and Uriah 
         */
        public static int getNextProblemSetID()
        {
            return nextProblemSetID++;
        }
    }
}
