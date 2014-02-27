using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

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
                    buserID.InnerText = "101";
                    BillJAdmin.AppendChild(buserID);
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
                            userID.InnerText = "" + (102 + i);
                            newStudent.AppendChild(userID);
                            studentList.AppendChild(newStudent);
                }
                doc.AppendChild(studentList);
                doc.Save(@"c:\users\public\MathDrills\users.xml");
            }
        }
    }
}
