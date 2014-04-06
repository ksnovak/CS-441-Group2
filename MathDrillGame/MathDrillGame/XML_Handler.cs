/* CS 441
 * Created by: Aurelio Arango
 * Date: 3-31-14
 * Purpose: This class handles reading and saving xml
 * 
 * 
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using System.Diagnostics;

namespace MathDrillGame
{
    class XML_Handler
    {
        XmlDocument doc;
        //XElement teachersListXML;
        List<Teacher> listofTeachers;
        XElement teachersListXML;

        public XML_Handler()
        {
            
        }
        //3-31-14
        //This method checks if the user xml file exists.
        //returns true if it found the xml otherwise 
        public bool check_xml_exists(string path)
        {
            bool found = false;
            if (File.Exists(Program.USERSFILE))
            {
                found = true;
            }
            return found;
        }
        //3-31-14
        //Create an xml with default data if it does not exists otherwise load data
        public void create_xml(bool exists)
        {
            if (!exists)
            {
                load_default_data();
                doc = new XmlDocument();

                XmlElement userList = doc.CreateElement("UserList");//root

                //load teachers
                for (int i = 0; i < listofTeachers.Count; i++)
                {
                    XmlElement teacher = doc.CreateElement("Teacher");
                    XmlElement tpass = doc.CreateElement("pass");
                    XmlElement tfullName = doc.CreateElement("FullName");
                    XmlElement tuserid = doc.CreateElement("UserID");
                    XmlElement tsetpass = doc.CreateElement("SetPass");
                    XmlElement tlastlogin = doc.CreateElement("LastLogin");
                    //set data
                    tfullName.InnerText = listofTeachers[i].fullName;
                    tuserid.InnerText = listofTeachers[i].userID.ToString();
                    tpass.InnerText = listofTeachers[i].pass;
                    tsetpass.InnerText = listofTeachers[i].setpass;
                    tlastlogin.InnerText = listofTeachers[i].lastLogin.ToString("g");
                    //add data to xml doc in teacher
                    teacher.AppendChild(tfullName);
                    teacher.AppendChild(tuserid);
                    teacher.AppendChild(tpass);
                    teacher.AppendChild(tsetpass);
                    teacher.AppendChild(tlastlogin);

                    XmlElement studentlist = doc.CreateElement("StudentList");

                    
                    //adding students to a list
                    for(int j=0; j<listofTeachers[i].students.Count;j++)
                    {

                        XmlElement student = doc.CreateElement("Student");
                        XmlElement sfullName = doc.CreateElement("FullName");
                        XmlElement sgroup = doc.CreateElement("Group");
                        XmlElement suserid = doc.CreateElement("UserID");
                        XmlElement spass = doc.CreateElement("pass");
                        XmlElement sinvisible = doc.CreateElement("Invisible");
                        XmlElement scoins = doc.CreateElement("Coins");
                        XmlElement slastlogin = doc.CreateElement("LastLogin");

                        sfullName.InnerText = listofTeachers[i].students[j].fullName;
                        sgroup.InnerText = listofTeachers[i].students[j].group;
                        suserid.InnerText = listofTeachers[i].students[j].userID.ToString();
                        spass.InnerText = listofTeachers[i].students[j].pass;
                        sinvisible.InnerText = listofTeachers[i].students[j].invisible;
                        scoins.InnerText = listofTeachers[i].students[j].coins.ToString();
                        slastlogin.InnerText = listofTeachers[i].students[j].lastLogin.ToString("g");

                        student.AppendChild(sfullName);
                        student.AppendChild(sgroup);
                        student.AppendChild(suserid);
                        student.AppendChild(spass);
                        student.AppendChild(sinvisible);
                        student.AppendChild(scoins);
                        student.AppendChild(slastlogin);

                        studentlist.AppendChild(student);
                    }
                    //adding list of students to a teacher
                    teacher.AppendChild(studentlist);
                    userList.AppendChild(teacher);//append teacher student list
                    doc.AppendChild(userList);
                    doc.Save(Program.USERSFILE);
                }//end of teachers loop

                
            }//end of if
            else //If there is already a list of users, make sure to still get the next valid User ID.
            {
                //XElement teacher = XElement.Load(Program.USERSFILE);
               //nextUserID = Convert.ToInt32(user.Descendants("Student").Last().Element("UserID").Value) + 1;
            }
        }
        //3-31-14
        //load default data incase data does not exist
        private void load_default_data()
        {
            //setting default data to Teachers object
            //this data will be use when 
            listofTeachers = new List<Teacher>();
            List<Student> students_1= new List<Student>();
            List<Student> students_2 = new List<Student>();

            students_1.Add(new Student("David Davidson",101,"A","1"));
            students_1.Add( new Student("John Smith",102,"B","2"));
            students_1.Add(new Student("Eric Erickson",103,"C","3"));
            students_1.Add(new Student("Rose Bernstein ", 104, "A", "1"));
            students_1[3].invisible = "y";

            students_2.Add( new Student("David Smith",201,"A","1"));
            students_2.Add( new Student("John Wood",202,"B","2"));
            students_2.Add( new Student("Blue Mary",203,"C","3"));
            students_2.Add(new Student("Rugal Bernstein", 204, "U", "1"));

            listofTeachers.Add(new Teacher("Admin",100,students_1,"admin"));
            listofTeachers.Add(new Teacher("Ginger Bridges",200,students_2,"admin1"));
        }
        //This method will save all the current data from the teachers object into xml
        //It includes the students data
        //it will be called by the Program class.
        public void save_data()
        {
            doc = new XmlDocument();

            XmlElement userList = doc.CreateElement("UserList");//root
            
            //load teachers
            for (int i = 0; i < Program.teachers.Count; i++)
            {
                XmlElement teacher = doc.CreateElement("Teacher");
                XmlElement tpass = doc.CreateElement("pass");
                XmlElement tfullName = doc.CreateElement("FullName");
                XmlElement tuserid = doc.CreateElement("UserID");
                XmlElement tsetpass = doc.CreateElement("SetPass");
                XmlElement tlastlogin = doc.CreateElement("LastLogin");
                
                //set data
                tfullName.InnerText = Program.teachers[i].fullName;
                tuserid.InnerText = Program.teachers[i].userID.ToString();
                tpass.InnerText = Program.teachers[i].pass;
                tsetpass.InnerText = Program.teachers[i].setpass;
                tlastlogin.InnerText = Program.teachers[i].lastLogin.ToString("g");
                //add data to xml doc in teacher
                teacher.AppendChild(tfullName);
                teacher.AppendChild(tuserid);
                teacher.AppendChild(tpass);
                teacher.AppendChild(tsetpass);
                teacher.AppendChild(tlastlogin);

                XmlElement studentlist = doc.CreateElement("StudentList");


                //adding students to a list
                for (int j = 0; j < listofTeachers[i].students.Count; j++)
                {

                    XmlElement student = doc.CreateElement("Student");
                    XmlElement sfullName = doc.CreateElement("FullName");
                    XmlElement sgroup = doc.CreateElement("Group");
                    XmlElement suserid = doc.CreateElement("UserID");
                    XmlElement spass = doc.CreateElement("pass");
                    XmlElement slastlogin = doc.CreateElement("LastLogin");
                    XmlElement scoins = doc.CreateElement("Coins");
                    XmlElement sinvisible = doc.CreateElement("Invisible");

                    sfullName.InnerText = Program.teachers[i].students[j].fullName;
                    sgroup.InnerText = Program.teachers[i].students[j].group;
                    suserid.InnerText = Program.teachers[i].students[j].userID.ToString();
                    spass.InnerText = Program.teachers[i].students[j].pass;
                    sinvisible.InnerText = Program.teachers[i].students[j].invisible;//variable to "delete student"
                    scoins.InnerText = Program.teachers[i].students[j].coins.ToString();
                    slastlogin.InnerText = Program.teachers[i].students[j].lastLogin.ToString("g");

                    student.AppendChild(sfullName);
                    student.AppendChild(sgroup);
                    student.AppendChild(suserid);
                    student.AppendChild(spass);
                    student.AppendChild(sinvisible);
                    student.AppendChild(scoins);
                    student.AppendChild(slastlogin);
                    studentlist.AppendChild(student);
                }
                //adding list of students to a teacher
                teacher.AppendChild(studentlist);
                userList.AppendChild(teacher);//append teacher student list
                doc.AppendChild(userList);
                doc.Save(Program.USERSFILE);
            }//end of teachers loop

        }//end of save function

        public void load_users()
        {
            Program.teachers.Clear();
            teachersListXML = XElement.Load(Program.USERSFILE);
            foreach (XElement user in teachersListXML.Descendants("Teacher"))
            {
                string newName = user.Element("FullName").Value;
                string pass = user.Element("pass").Value;
                int userID = Convert.ToInt32(user.Element("UserID").Value);

                List<Student> studentList = getStudentList(user);
                Teacher tempTeacher = new Teacher(newName, userID, studentList, pass);

                Program.teachers.Add(tempTeacher);
                
        
            }
            //Debug code
            /*for (int i = 0; i < Program.teachers.Count; i++)
            {
                for (int j = 0; j < Program.teachers[i].students.Count; j++)
                {
                    Debug.WriteLine(Program.teachers[i].students[j].fullName);
                    Debug.WriteLine(Program.teachers[i].students[j].invisible);
                }
            }*/
        }//end of load_users
        private List<Student> getStudentList(XElement userList)
        {
            List<Student> student_list = new List<Student>();
            int index = 0;
            foreach (XElement user in userList.Descendants("Student"))
            {
                //XElement user_student = user.Parent;
                //string userid = Parent.Name;

                string user_name = user.Element("FullName").Value;
                string user_id = user.Element("UserID").Value;
                int user_id_int = Convert.ToInt32(user_id);
                string user_group = user.Element("Group").Value;
                string user_p = user.Element("pass").Value;
                string user_inv = user.Element("Invisible").Value;
                string user_coins = user.Element("Coins").Value;
                string user_lastlogin = user.Element("LastLogin").Value;

                student_list.Add(new Student(user_name, user_id_int, user_group, user_p));
                student_list[index].invisible = user_inv;//set invisibility
                student_list[index].coins = Convert.ToInt32(user_coins);
                //Debug.WriteLine(student_list[index].fullName);
                //Debug.WriteLine(student_list[index].invisible);

                index++;
            }
            //Debug.WriteLine("done");

            return student_list;
        }//end of getStudentsList
        //Aurelio Arango
        //4-6-14
        public void generate_StudentXMLProblemSet( ProblemSet set)
        {
            XmlDocument doc;
            List<int> problems= new List<int>();
            if (!File.Exists(@"c:\users\public\MathDrills\ProblemSets\setGroup" + set.group + ".xml"))
            {
                doc = new XmlDocument();
                XmlElement allProblemSets = doc.CreateElement("AllProblemSets");
                doc.AppendChild(allProblemSets);
                doc.Save(@"c:\users\public\MathDrills\ProblemSets\setGroup" + set.group + ".xml");
            }

            XDocument xml = XDocument.Load(@"c:\users\public\MathDrills\ProblemSets\setGroup" + set.group + ".xml");
            XElement newProblemSet = new XElement("ProblemSet");
            XElement problemSetID = new XElement("ProblemSetID", Program.getNextProblemSetID());
            XElement problemSetSolved = new XElement("IsSetSolved", "0");
            XElement lastAccessed = new XElement("LastAccessed", Program.MINDATE.ToString("g"));

            newProblemSet.Add(problemSetID);
            newProblemSet.Add(problemSetSolved);
            newProblemSet.Add(lastAccessed);
            
            for(int i=0; i<set.problems.Count; i++)
            {
                XElement newProblem = new XElement("Problem",
                    new XElement("Operator" , set.problems[i].operation),
                    new XElement("Operand1", set.problems[i].operand1.ToString()),
                    new XElement("Operand2", set.problems[i].operand2.ToString()),
                    new XElement("IsSolved", "0"),
                    new XElement("Attempts", "0")
                    );

                    //newProblemSet.Add(operation);
                    
                    newProblemSet.Add(newProblem);

            }
            xml.Root.Add(newProblemSet);
            xml.Save(@"c:\users\public\MathDrills\ProblemSets\setGroup" + set.group + ".xml");

        }

    }
}
