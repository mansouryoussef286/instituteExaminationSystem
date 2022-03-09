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
    public partial class instructorF : Form
    {
        public instructorF()
        {
            InitializeComponent();

            //Exams Tab
            //Generate Exam Tab

            examCourses.Items.Clear();
            var courses = from c in appManager.entities.courses
                          select c;
            foreach (var course in courses)
            {
                examCourses.Items.Add(course.c_ID);
            }
            fillStudentsGradesTab();
            fillEditingExamTab();
        }
        
        #region instructor form -> exams tab -> editing exam db tab
        public void fillEditingExamTab()
        {
            coursesComboBox3.Items.Add("All courses");
            foreach (var course in appManager.entities.courses)
            {
                if(appManager.currentInstructor.courses.Contains(course))
                {
                    coursesComboBox3.Items.Add(course.c_name);
                }

            }
        }




        #endregion

        #region instructor form -> exams tab -> students grade tab
        //a function to fill the students grades tab on form load
        public void fillStudentsGradesTab()
        {
            foreach(var student in appManager.entities.students)
            {
                studentsListBox.Items.Add($"{student.stud_ID}: {student.stud_Fname} {student.stud_Lname}");
            }
            foreach (var exam in appManager.entities.Exam_Student)
            {
                examsIDsListBox.Items.Add($"{exam.Exam_ID}, {exam.exam.cours.c_name}");
            }
        }

        private void studentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var studentID = int.Parse(studentsListBox.SelectedItem.ToString().Split(':')[0]);
            var studentName = studentsListBox.SelectedItem.ToString().Split(':')[1].Remove(0,1);
            //MessageBox.Show(studentID.ToString());
            examsIDsListBox.Items.Clear();
            foreach (var exam in appManager.entities.Exam_Student)
            {
                if (exam.St_ID == studentID)
                {
                    examsIDsListBox.Items.Add($"{exam.Exam_ID}, {exam.exam.cours.c_name}");
                }
            }
            stdNameTextBox.Text = studentName;
            examIDTextBox.Text = "";
            gradeTextBox.Text = "";
            correctExamBtn.Enabled = false;
        }

        private void examsIDsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (studentsListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Select a student first");
            }
            else
            {
                var studentID = int.Parse(studentsListBox.SelectedItem.ToString().Split(':')[0]);
                var examID = int.Parse(examsIDsListBox.SelectedItem.ToString().Split(',')[0]);
                var grade = appManager.entities.Exam_Student.Where(row => row.St_ID == studentID && row.Exam_ID == examID).Select(row => row.st_grade).First();
                examIDTextBox.Text = examID.ToString();
                gradeTextBox.Text = grade == null? "N/A yet" : grade.ToString();
                gradeTextBox.Text = grade == null? "N/A yet" : grade.ToString();
                correctExamBtn.Enabled = gradeTextBox.Text == "N/A yet"? true: false;
            }
        }
       
        private void correctExamBtn_Click(object sender, EventArgs e)
        {
            var studentID = int.Parse(studentsListBox.SelectedItem.ToString().Split(':')[0]);
            var retval = appManager.entities.correctExam(int.Parse(examIDTextBox.Text), studentID);
            if (retval == 1)
            {
                MessageBox.Show("exam is corrected successfully!");
                examsIDsListBox_SelectedIndexChanged(null, null);
            }
        }
        #endregion

        private void coursesComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int courseID = appManager.entities.courses.
            //foreach (var question in appManager.entities.questions)
            //{
            //    if(question.c_ID = )
            //    coursesComboBox3.Items.Add();
            //}
        }

    }
}
