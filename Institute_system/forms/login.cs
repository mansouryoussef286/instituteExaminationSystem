using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
namespace Institute_system
{
    public partial class login : MaterialForm
    {
        //to delete it after signout
        public MaterialTextBox2 pwTextBox;

        public login()
        {
            InitializeComponent();
            pwTextBox = passwordTextBox;


        }


        private void logInBtn_Click(object sender, EventArgs e)
        {
            //if no type was selected !
            if (loginTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("select a type");
            }
            else
            {
                string username = userNameTextBox.Text;
                string password = passwordTextBox.Text;
                bool success = false;
                //check if the login user is student or staff
                if (loginTypeComboBox.SelectedIndex == 0)   //student
                {
                    foreach (var student in appManager.entities.students)
                    {
                        if (username == student.stud_Username)
                        {
                            success = student.stud_pw == password ? true : false;
                            appManager.currentUser = student;
                        }
                    }
                }
                else   //staff
                {
                    foreach (var instructor in appManager.entities.instructors)
                    {
                        if (username == instructor.inst_username)
                        {
                            success = instructor.inst_pw == password ? true : false;
                            appManager.currentInstructor = instructor;
                        }
                    }
                }
                //chech if the user credintials are correct
                if (success)
                {
                    if (loginTypeComboBox.SelectedIndex == 0)
                    {
                        appManager.studentForm = new studentF();
                        appManager.studentForm.Show();
                    }
                    else
                    {
                        appManager.instructorForm = new instructorF();
                        appManager.instructorForm.Show();
                    }
                    //hide the login form
                    appManager.loginForm.Hide();
                }
                else
                {
                    MessageBox.Show("incorrect credintials");
                }
            }
        }
        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                logInBtn_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            appManager.entities.students_update(-1, "signin", "sign", null, "admin", "123");
            //var std = appManager.entities.students_select(1);
            //std.First().
        }
    }
}

