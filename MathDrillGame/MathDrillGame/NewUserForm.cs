using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
/* The NEW USER FORM is used for creating new users.
 * Will save to the XML file, and return to the Administrator form
 * 
 */

namespace MathDrillGame
{
    public partial class NewUserForm : Form
    {
        public NewUserForm()
        {
            InitializeComponent();
        }

        /* SAVE CLICK event, on clicking the Save button, attempts to add the user to the XML file.
         * Kevin and Uriah
         */
        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            if (inputFullName.Text.Length > 0)
            {
                addNewUser();
            }

        }

        /* ADDNEWUSER will add the user to XML
         * Kevin and Uriah
         */
        private void addNewUser()
        {
            string userName = inputFullName.Text;

            XmlDocument doc = new XmlDocument();
            doc.Load(Program.USERSFILE);
            XmlElement newStudent = doc.CreateElement("Student");
                XmlElement fullName = doc.CreateElement("FullName");
                    fullName.InnerText = userName;
                    newStudent.AppendChild(fullName);
                XmlElement isAdmin = doc.CreateElement("IsAdmin");
                    isAdmin.InnerText = (checkAdmin.Checked ? "1" : "0");
                    newStudent.AppendChild(isAdmin);
                XmlElement userID = doc.CreateElement("UserID");
                    userID.InnerText = Program.getNextUserID() + "";
                    newStudent.AppendChild(userID);
                XmlElement lastLogin = doc.CreateElement("LastLogin");
                    lastLogin.InnerText = Program.MINDATE.ToString("g");
                    newStudent.AppendChild(lastLogin);
            doc.DocumentElement.AppendChild(newStudent);
            doc.Save(Program.USERSFILE);

            XElement studentListXML = XElement.Load(Program.USERSFILE);
    
            //Rebuild the list of users to accomodate for the new user.
            Program.users.Add(new User
            {
                //isAdmin = (studentListXML.Descendants("Student").Last().Element("IsAdmin").Value == "1"? true : false),
                fullName = studentListXML.Descendants("Student").Last().Element("FullName").Value,
                userID = Convert.ToInt32(studentListXML.Descendants("Student").Last().Element("UserID").Value)
            });

            //Return to the Admin form
            AdminForm admin = new AdminForm();
            admin.Show();
            Close();
        }

        /* CANCEL CLICK event, triggerd upon clicking the Cancel button. Returns immediately to the teacher form
         * Kevin and Uriah
         */
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.Show();
            Close();
        }
    }
}
