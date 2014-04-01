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
                    XmlElement tlastlogin = doc.CreateElement("LastLogin");
                    //set data
                    tfullName.InnerText = listofTeachers[i].fullName;
                    tuserid.InnerText = listofTeachers[i].userID.ToString();
                    tpass.InnerText = listofTeachers[i].pass;
                    tlastlogin.InnerText = listofTeachers[i].lastLogin.ToString("g");
                    //add data to xml doc in teacher
                    teacher.AppendChild(tfullName);
                    teacher.AppendChild(tuserid);
                    teacher.AppendChild(tpass);
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
                        XmlElement slastlogin = doc.CreateElement("LastLogin");

                        sfullName.InnerText = listofTeachers[i].students[j].fullName;
                        sgroup.InnerText = listofTeachers[i].students[j].group;
                        suserid.InnerText = listofTeachers[i].students[j].userID.ToString();
                        spass.InnerText = listofTeachers[i].students[j].pass;
                        slastlogin.InnerText = listofTeachers[i].students[j].lastLogin.ToString("g");


                        student.AppendChild(sfullName);
                        student.AppendChild(sgroup);
                        student.AppendChild(suserid);
                        student.AppendChild(spass);
                        student.AppendChild(slastlogin);
                        studentlist.AppendChild(student);
                    }
                    //adding list of students to a teacher
                    teacher.AppendChild(studentlist);
                    userList.AppendChild(teacher);//append teacher student list
                    doc.AppendChild(userList);
                    doc.Save(Program.USERSFILE);
                }//end of teachers loop

                Debug.WriteLine(doc.ToString());
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
            students_1.Add(new Student("Eric Erickson",103,"c","3"));

            students_2.Add( new Student("David Smith",201,"A","1"));
            students_2.Add( new Student("John Wood",202,"B","2"));
            students_2.Add( new Student("Blue Mary",203,"c","3"));

            listofTeachers.Add(new Teacher("Admin",100,students_1,"admin"));
            listofTeachers.Add(new Teacher("Ginder Bridges",200,students_2,"admin1"));
        }
    }
}
