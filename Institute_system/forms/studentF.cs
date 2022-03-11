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
    public partial class studentF : Form
    {
        public studentF()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            appManager.examForm.Show();
        }


        private void updateInfoBtn_Click(object sender, EventArgs e)
        {
           string user = textBox1.Text == "" ? appManager.currentUser.stud_Username : textBox1.Text;
           string pass = textBox2.Text == "" ? appManager.currentUser.stud_pw : textBox2.Text;
            if (user == textBox1.Text & pass ==textBox2.Text)
            {

                MessageBox.Show("You didn't enter new password or user name");
            }
            else
            {
                try
                {
                    appManager.entities.students_update(
                        appManager.currentUser.stud_ID, appManager.currentUser.stud_Fname,
                        appManager.currentUser.stud_Lname, appManager.currentUser.dept_ID,
                        user, pass

                        );
                 
                    MessageBox.Show("you update your credintials successfully");
                }
                catch (Exception)
                {

                    MessageBox.Show("could not update credintials");
                }
            }

          
        }

        //on form closing (sigout)
        private void studentF_FormClosing(object sender, FormClosingEventArgs e)
        {
            appManager.loginForm.Show();
        }
    }
}
