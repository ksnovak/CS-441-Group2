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

                        //adding a field to keep score of the student
                        //XmlElement 
                        //field for the assigned problems for the student

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
        //Aurelio arango
        //3-31-14
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
                for (int j = 0; j < Program.teachers[i].students.Count(); j++)
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
                    slastlogin.InnerText = Program.teachers[i].students[j].lastLogin.ToString();

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
        //Aurelio Arango
        //3-31-14
        //This method loads the current user from the xml
        public void load_users()
        {
            Program.teachers.Clear();
            teachersListXML = XElement.Load(Program.USERSFILE);
            int index = 0;
            foreach (XElement user in teachersListXML.Descendants("Teacher"))
            {
                string newName = user.Element("FullName").Value;
                string pass = user.Element("pass").Value;
                int userID = Convert.ToInt32(user.Element("UserID").Value);

                /*
                 * Jorge and Aurelio. Making sure that the security settings set by the teacer are being loaded appropirately.
                 */

                String setPass = user.Element("SetPass").Value;

                List<Student> studentList = getStudentList(user);
                Teacher tempTeacher = new Teacher(newName, userID, studentList, pass);

                Program.teachers.Add(tempTeacher);
                Program.teachers[index].lastLogin = Convert.ToDateTime(user.Element("LastLogin").Value);
                Program.teachers[index].setpass = setPass;
                index++;
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
        //Aurelio Arango
        //3-31-14
        //This method gets the student from the xml and returns a list of all the students that belong to that teacher
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
                student_list[index].lastLogin = Convert.ToDateTime(user_lastlogin);
                //Debug.WriteLine(student_list[index].fullName);
                //Debug.WriteLine(student_list[index].invisible);

                index++;
            }
            //Debug.WriteLine("done");

            return student_list;
        }//end of getStudentsList
        //Aurelio Arango
        //4-6-14
        //This method generates the problems sets into xml
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
            //Read and update nextProblemSetID
            XElement problemSetID = new XElement("ProblemSetID", Program.nextProblemSetID);
            XElement problemSetSolved = new XElement("IsSetSolved", "0");
            XElement availableUntil = new XElement("AvailableUntil", set.dueDate);

            newProblemSet.Add(problemSetID);
            newProblemSet.Add(problemSetSolved);
            newProblemSet.Add(availableUntil);
            
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
        //Aurelio Arango and Stephanie Yao, 4-8-14
        /*  NOTE: Heavy code reference from load_users(...)         */
        public List<ProblemSet> load_ProblemSet(string group)
        {
            List<ProblemSet> problemSets = new List<ProblemSet>();
            XElement problemSetsXML = XElement.Load(@"c:\users\public\MathDrills\ProblemSets\setGroup" + group + ".xml");
            int index = 0;
            if (File.Exists(@"c:\users\public\MathDrills\ProblemSets\setGroup" + group + ".xml"))
                foreach (XElement set in problemSetsXML.Descendants("ProblemSet"))
            {
                string problemsetId = set.Element("ProblemSetID").Value;
                string dueDate = set.Element("AvailableUntil").Value;
                List<Problem> problems = load_Problem(set);
                //List<Student> studentList = getStudentList(user);
                //Teacher tempTeacher = new Teacher(newName, userID, studentList, pass);
                
                int psI = Convert.ToInt32(problemsetId);
                //Global Problem set ID
                Program.nextProblemSetID=psI;
                //string problem_set_id, string operation, bool isSolved, int solvedQuant, int totalQuant, string score, string last attempt, string group, int min, int max
                ProblemSet prob_set = new ProblemSet(psI, problems[0].operation, false, 0, problems.Count, "0", dueDate, group, 0, 0);

                //Debug.WriteLine(" handler op1" + problems[index].operand1 + " handler op2" + problems[index].operand2);   
                Debug.Write("Problems Count: " + problems.Count);
                //problemSets[index].problems = problems;
                 prob_set.problems = problems; 
                problemSets.Add(prob_set);
                
                index++;
            }
            //Program.nextProblemSetID++;
            return problemSets;
        }
        //Aurelio Arango and Stephanie Yao, 4-8-14
        /*  NOTE: Function component of load_ProblemSet(...)*/
        public List<Problem> load_Problem(XElement setList)
        {
            List<Problem> problem_list = new List<Problem>();
            int index = 0;
            foreach (XElement problem in setList.Descendants("Problem"))
            {
                //XElement user_student = user.Parent;
                //string userid = Parent.Name;

                string operation = problem.Element("Operator").Value;
                string operand1 = problem.Element("Operand1").Value;
                string operand2 = problem.Element("Operand2").Value;
                // string solved = problem.Element("IsSolved").Value;
                // string attempts = problem.Element("Attempts").Value;

                int op1 = Convert.ToInt32(operand1);
                int op2 = Convert.ToInt32(operand2);

                Problem newproblem = new Problem(op1, op2, operation);
                problem_list.Add(newproblem);

               // Debug.Write("OP1: " + problem_list[index].operand1 + " \n OP2: " + problem_list[index].operand2 + "\n");
                index++;
            }
                return problem_list; 
        }//end function


        /*----------------------------------------------------------------
         * JORGE TORRES - Creating a new XML file that will save the number
         * of problems correct, the total number of problems for the student, 
         * and
         * ---------------------------------------------------------------*/

        XmlDocument studentDocument;

        public void create_Student_XML_File(int user_ID, int num_problems, string studentName)
        {
            //JT: refactoring 
            String path = "c:\\users\\public\\MathDrills\\Records\\Student" + user_ID + ".xml";

            if (!File.Exists(@path))
            {
                studentDocument = new XmlDocument(); //object to write the student documents

                XmlElement user_problem_sets = studentDocument.CreateElement("Student" + user_ID);//root

                studentDocument.AppendChild(user_problem_sets);
                studentDocument.Save(@path);
            }

          //create the elements for the xml file
            XDocument xml = XDocument.Load(@path);
            XElement newProblemSet = new XElement("ProblemSet");
            XElement problemSetID = new XElement("ProblemSetID", Program.getNextProblemSetID());
            XElement problemSetSolved = new XElement("IsSetSolved", "0");
            XElement lastAccessed = new XElement("LastAccessed", Program.MINDATE.ToString("g"));
            XElement studentWithLastAccess = new XElement("StudentName", studentName);
            XElement incorrectProblems = new XElement("IncorrectProblems","");
            XElement totalProblems = new XElement("TotalProblems", num_problems);
            XElement lastProblemAttempted = new XElement("LastProblemAttempted",-1);

            newProblemSet.Add(problemSetID);
            newProblemSet.Add(problemSetSolved);
            newProblemSet.Add(lastAccessed);
            newProblemSet.Add(studentWithLastAccess);
            newProblemSet.Add(incorrectProblems);
            newProblemSet.Add(totalProblems);
            newProblemSet.Add(lastProblemAttempted);

            xml.Root.Add(newProblemSet);
            xml.Save(@path);
         
        }
        
        //Jorge Torres & Aurelio Arango
        public void replaceXMLChild(int userID, int problemSetId, int solved, DateTime lastAccessed, String incorrectProblems, int lastProblemAttempted)
        {

            String path = "c:\\users\\public\\MathDrills\\Records\\Student" + userID + ".xml";
            int problemSetId_xml;
           // XmlDocument tempXML = new XmlDocument();
            XElement replace_this = new XElement("ProblemSetID","");

            if (File.Exists(@path))
            {
                Debug.WriteLine("XML_HANDLER---replaceXMLChild---FOUND");
                //tempXML.Load(@path);
                XElement student_problem_set_xml = XElement.Load(@path);

                foreach (XElement set in student_problem_set_xml.Descendants("ProblemSet"))
                {
                    problemSetId_xml = Convert.ToInt32(set.Element("ProblemSetID").Value);
                    if (problemSetId_xml == problemSetId)
                    {
                        set.Element("IsSetSolved").Value =  solved.ToString();
                        set.Element("LastAccessed").Value = lastAccessed.ToString("g");
                        set.Element("IncorrectProblems").Value = incorrectProblems;
                        set.Element("LastProblemAttempted").Value = lastProblemAttempted.ToString();
                        Debug.WriteLine("XML_HANDLER---replaceXMLChild---DONE");
                    }
                }
                /*
                XElement newProblemSet = new XElement("ProblemSet");
               
                XElement problemSetID = new XElement("ProblemSetID", problemSetId);
                XElement problemSetSolved = new XElement("IsSetSolved", solved);
                XElement lastA = new XElement("LastAccessed", lastAccessed.ToString("g"));
                XElement incorrectP = new XElement("IncorrectProblems", incorrectProblems);
                XElement lastProblemA = new XElement("LastProblemAttempted", lastProblemAttempted);

               // root element
                XmlNode root = tempXML.DocumentElement;


                newProblemSet.Add(problemSetID);
                newProblemSet.Add(problemSetSolved);
                newProblemSet.Add(lastA);
                newProblemSet.Add(incorrectP);
                newProblemSet.Add(lastProblemA);

                replace_this.ReplaceWith(newProblemSet);
                Debug.WriteLine(newProblemSet);
                Debug.WriteLine(replace_this);


                XmlNode 
                XmlNodeList listofchildren=root.ChildNodes;
                listofchildren.Item(0).ReplaceChild(newProblemSet);*/

                //tempXML.ReplaceChild(newProblemSet, replace_this);
               // tempXML.Save(@path);
                student_problem_set_xml.Save(@path);

            }
            else
            {
                Debug.WriteLine("XML_HANDLER---replaceXMLChild---NOT FOUND");
           

            }
            
            

      

            
        }
        //5-2-14 Jorge and Aurelio
        // This method looks for a problemID in the xml for a given user.
        public void read_Student_XML_File(int userID,int ProblemId)
        {


            String path = "c:\\users\\public\\MathDrills\\Records\\Student" + userID + ".xml";
            //bool problemFound = false;
            int problemSetId;
            int solved;
            string lastAccessed;
            //Debug.WriteLine("XML_HANDLER--read_sudent_xml_file");
            if (File.Exists(@path))
            {
                XElement student_problem_set_xml = XElement.Load(@path);

                foreach (XElement set in student_problem_set_xml.Descendants("ProblemSet"))
                {
                    problemSetId = Convert.ToInt32( set.Element("ProblemSetID").Value);
                    if (problemSetId == ProblemId)
                    {
                        solved = Convert.ToInt32(set.Element("IsSetSolved").Value);
                        lastAccessed = set.Element("LastAccessed").Value;
                        //Debug.WriteLine("Set id: " + problemSetId + " solved:" + solved + " Last Accessed:" + lastAccessed);
                        //problemFound = true;
                    }
                    
                }
                


            }else
            {
                //Debug.WriteLine("XML_HANDLER---NOT FOUND");

            }

            //----------------Return data to the user-----------------//
            //return problemFound;

        }
        //this method looks for a problem set and returns -1 if not found, 0 if is not solved
        //and returns 1 if found
        public int student_xml_problem_is_solved(int userID, int ProblemId)
        {


            String path = "c:\\users\\public\\MathDrills\\Records\\Student" + userID + ".xml";
            //bool problemFound = false;
            int problemSetId;
            int solved=-1;
            //string lastAccessed;
            //Debug.WriteLine("XML_HANDLER--read_sudent_xml_file");
            if (File.Exists(@path))
            {
                XElement student_problem_set_xml = XElement.Load(@path);

                foreach (XElement set in student_problem_set_xml.Descendants("ProblemSet"))
                {
                    problemSetId = Convert.ToInt32(set.Element("ProblemSetID").Value);
                    if (problemSetId == ProblemId)
                    {
                        solved = Convert.ToInt32(set.Element("IsSetSolved").Value);

                        Debug.WriteLine("the current value of solved inside the xml_handler" + solved);
                        //lastAccessed = set.Element("LastAccessed").Value;
                        //Debug.WriteLine("Set id: " + problemSetId + " solved:" + solved + " Last Accessed:" + lastAccessed);
                        //problemFound = true;
                    }

                }
            }

            return solved;

        }
        public string student_xml_incorrect_problems(int userID,int ProblemId)
        {
            String path = "c:\\users\\public\\MathDrills\\Records\\Student" + userID + ".xml";
            int problemSetId;
            string problems_wrong="";
            if (File.Exists(@path))
            {
                XElement student_problem_set_xml = XElement.Load(@path);

                foreach (XElement set in student_problem_set_xml.Descendants("ProblemSet"))
                {
                    problemSetId = Convert.ToInt32(set.Element("ProblemSetID").Value);
                    if (problemSetId == ProblemId)
                    {
                        problems_wrong = set.Element("IncorrectProblems").Value;
                    }
                }
            }
            return problems_wrong;
        }
        public int student_xml_last_problem_attempted(int userID, int ProblemId)
        {
            String path = "c:\\users\\public\\MathDrills\\Records\\Student" + userID + ".xml";
            int problemSetId;
            int last_problem_attempted = 0;
            if (File.Exists(@path))
            {
                XElement student_problem_set_xml = XElement.Load(@path);

                foreach (XElement set in student_problem_set_xml.Descendants("ProblemSet"))
                {
                    problemSetId = Convert.ToInt32(set.Element("ProblemSetID").Value);
                    if (problemSetId == ProblemId)
                    {
                        last_problem_attempted = Convert.ToInt32( set.Element("LastProblemAttempted").Value);
                    }
                }
            }
            return last_problem_attempted;
        }
    }

}
