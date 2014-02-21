using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathDrillGame
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            buildList();

            listOfUsers.DataSource = Program.users; //The listbox will take elements from the users list
            listOfUsers.DisplayMember = "fullName"; //It will display the value in the fullName attribute
            listOfUsers.ValueMember = "userID";     //The return value for the selected element will be the userID value
        }




        public void buildList()
        {
            Program.users.Add(new User(true, "Bill J. Smith", 101));
            Program.users.Add(new User(false, "Susan M. Doe", 102));
            Program.users.Add(new User(false, "Joe A. Doe", 103));
            Program.users.Add(new User(false, "Edgar L. Park", 104));
            Program.users.Add(new User(false, "Jane G. Kragen", 105));
            Program.users.Add(new User(false, "Matt Y. Herman", 106));
            Program.users.Add(new User(false, "Jessica Q. Booker", 107));
            Program.users.Add(new User(false, "Laura T. Gwinn", 108));
            Program.users.Add(new User(false, "Patrick D. Henry", 109));
            Program.users.Add(new User(false, "Megan P. Nelson", 110));
            Program.users.Add(new User(false, "Brian H. Noll", 111));


        }

        private void listOfUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonLogin.Enabled = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Program.currentUser = Convert.ToInt32(listOfUsers.SelectedIndex);
            textBox1.AppendText("Hello " + Program.currentUser + "\r\n");
            if (Program.users[Program.currentUser].isAdmin)
            {
                AdminForm mainForm = new AdminForm();
                mainForm.Tag = this;
                mainForm.Show(this);
                Hide();
            }
            else
            {
                StudentForm mainForm = new StudentForm();
                mainForm.Tag = this;
                mainForm.Show(this);
                Hide();
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
