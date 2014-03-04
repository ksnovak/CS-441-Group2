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

namespace MathDrillGame
{
    public partial class NewUserForm : Form
    {
        public NewUserForm()
        {
            InitializeComponent();
        }

        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            addNewUser();

        }

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
    
            Program.users.Add(new User
            {
                isAdmin = (studentListXML.Descendants("Student").Last().Element("IsAdmin").Value == "1"? true : false),
                fullName = studentListXML.Descendants("Student").Last().Element("FullName").Value,
                userID = Convert.ToInt32(studentListXML.Descendants("Student").Last().Element("UserID").Value)
            });

            /*var admin = (AdminForm)Tag;
            admin.Show();*/
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            /*var admin = (AdminForm)Tag;
            admin.Show();*/
            Close();
        }
    }
}
