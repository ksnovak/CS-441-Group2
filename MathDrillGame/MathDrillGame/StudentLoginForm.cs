/* Aurelio Arango
 * 3-25-14
 * This form is to authenticate the current student and allows him/her to move to take the drills
 * 
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

namespace MathDrillGame
{
    public partial class StudentLoginForm : Form
    {
        public StudentLoginForm()
        {
            InitializeComponent();
        }
        //3-25-14
        private void triangle_button_Click(object sender, EventArgs e)
        {
            if (authenticateUser(1))
            {
                buildStudentForm();
                Debug.WriteLine("1");
            }
            else
            {
                goBack();
            }
        }
        //3-25-14
        private void pentagon_button_Click(object sender, EventArgs e)
        {
            if (authenticateUser(2))
            {
                buildStudentForm();
                Debug.WriteLine("2");
            }
            else
            {
                goBack();
            }
        }
        //3-25-14
        private void button3_Click(object sender, EventArgs e)
        {
            if (authenticateUser(3))
            {
                buildStudentForm();
                Debug.WriteLine("3");
            }
            else 
            {
                goBack();
            }

        }
        //4-1-14
        //Aurelio Arango
        //This function authenticates the user againts its saved password
        private bool authenticateUser(int itemclicked)
        {
            bool toggle = false;//temp_variable this will be provided by the teacher
            int pass = Convert.ToInt32 (Program.teachers[Program.currentTeacherIndex].students[Program.currentStudentIndex].pass);//get current password
            Debug.WriteLine("User pass"+pass);

            if(!toggle && (itemclicked == pass) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Aurelio Arango 4-1-14
        //This function looks for the previous form (LoginForm)
        private void goBack()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(LoginForm))
                {
                    f.Show();
                    this.Hide();
                }
            }
        }
        //4-1-14
        //Aurelio Arango
        //When button is clicked the back function is called.
        private void back_button_Click(object sender, EventArgs e)
        {
            goBack();
        }
        //Aurelio Arango 4-1-14
        //This funtion creates a new form for the student to take the test
        private void buildStudentForm()
        {
            
            bool foundForm = false; 
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(StudentForm))
                {
                    f.Show();
                    foundForm = true;
                    this.Hide();
                }
            }
            if (!foundForm)
            { 
                StudentForm loginForm = new StudentForm();
                loginForm.Tag = this;
                loginForm.Show(this);
                this.Hide(); 
            }
        }

    }
}
