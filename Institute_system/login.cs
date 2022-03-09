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
            //appManager.studentForm.Show();
            if (loginTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("select a type");
            }
            else
            {
                string username = userNameTextBox.Text;
                string password = passwordTextBox.Text;
                bool success = false;
                foreach (var student in appManager.entities.students)
                {
                    if (username == student.stud_Username)
                    {
                        success = student.stud_pw == password ? true : false;
                        if (success)
                        {
                            appManager.currentUser = student;
                        }
                      
                    }
                }
                if (success)
                {
                    MessageBox.Show("logged in");
                    appManager.instructorForm.Show();

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
    }
}
