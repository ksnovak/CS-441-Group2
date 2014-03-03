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
            doc.Load(@"c:\users\public\MathDrills\users.xml");
            XmlElement newStudent = doc.CreateElement("Student");
            XmlElement fullName = doc.CreateElement("FullName");
            fullName.InnerText = userName;
            newStudent.AppendChild(fullName);
            XmlElement isAdmin = doc.CreateElement("IsAdmin");
            isAdmin.InnerText = (checkAdmin.Checked ? "1" : "0");
            newStudent.AppendChild(isAdmin);
            XmlElement userID = doc.CreateElement("UserID");
            userID.InnerText = "505";
            newStudent.AppendChild(userID);
            doc.DocumentElement.AppendChild(newStudent);
            doc.Save(@"c:\users\public\MathDrills\users.xml");
            
            XElement studentListXML = XElement.Load(@"c:\users\public\MathDrills\users.xml");
            foreach (XElement user in studentListXML.Descendants("Student"))
            {

                Program.users.Add(new User { isAdmin = (user.Element("IsAdmin").Value == "1"? true : false), 
                                            fullName = user.Element("FullName").Value, 
                                            userID = Convert.ToInt32(user.Element("UserID").Value)
                                            });
            }
             
            Program.users.Add(new User { isAdmin = (checkAdmin.Checked ? true : false),
                                        fullName = userName,
                                        userID = 505
            });

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
