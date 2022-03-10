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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            appManager.loginForm.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
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

        private void StudentF_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Course Name");
            dt.Columns.Add("Exam ID");
            dt.Columns.Add("Grades");
           

            var studentgrades = from grd in appManager.entities.Exam_Student
                                join cour in appManager.entities.exams on grd.Exam_ID equals cour.exam_ID
                                join courName in appManager.entities.courses on cour.course_ID equals courName.c_ID
                                where grd.St_ID == appManager.currentUser.stud_ID
                                select new { courName.c_name,grd.Exam_ID,grd.st_grade } ;

            foreach (var item in studentgrades)
            {
                DataRow row = dt.NewRow();
                row["Course Name"] = item.c_name;
                row["Exam ID"] = item.Exam_ID; 
                row["Grades"] = item.st_grade;

                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;




        }
    }
}
