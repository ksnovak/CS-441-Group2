using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

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
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\users\public\MathDrills\users.xml");
            XmlElement newStudent = doc.CreateElement("Student");
                XmlElement fullName = doc.CreateElement("FullName");
                    fullName.InnerText = inputFullName.Text;
                    newStudent.AppendChild(fullName);
                XmlElement isAdmin = doc.CreateElement("IsAdmin");
                    isAdmin.InnerText = (checkAdmin.Checked? "1" : "0");
                    newStudent.AppendChild(isAdmin);
                XmlElement userID = doc.CreateElement("UserID");
                    userID.InnerText = "505";
                    newStudent.AppendChild(userID);
            doc.DocumentElement.AppendChild(newStudent);
            doc.Save(@"c:\users\public\MathDrills\users.xml");
        }
    }
}
