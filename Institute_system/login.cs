using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Institute_system
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
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
                        }
                    }
                }
                //chech if the user credintials are correct
                if (success)
                {
                    if (loginTypeComboBox.SelectedIndex == 0)
                        appManager.studentForm.Show();
                    else
                        appManager.instructorForm.Show();
                    //hide the login form
                    appManager.loginForm.Hide();
                }
                else
                {
                    MessageBox.Show("incorrect credintials");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            appManager.entities.students_update(-1, "signin", "sign", null, "admin", "123");
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                logInBtn_Click(null, null);
            }
        }
    }
}

