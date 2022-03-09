using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Institute_system
{
    public partial class instructorF : Form
    {
        //member data 
        int select_dep_id;//to refresh the data grid

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

        

        #region instructor form -> exams tab -> students grade tab
        //a function to fill the students grades tab on form load
        public void fillStudentsGradesTab()
        {
            //fill departments
            foreach (var dept in appManager.entities.departments)
            {
                dept_nameComboBox.Items.Add(dept.dept_name);
            }
            //fill students
            foreach (var student in appManager.entities.students)
            {
                studentsListBox.Items.Add($"{student.stud_ID}: {student.stud_Fname} {student.stud_Lname}");
            }
            //fill exams
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
        private void deptNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptID = 0;
            foreach (var dept in appManager.entities.departments)
            {
                if (dept.dept_name == dept_nameComboBox.SelectedItem.ToString())
                    deptID = dept.dept_ID;
            }
            studentsListBox.Items.Clear();
            foreach (var student in appManager.entities.students)
            {
                if (student.dept_ID == deptID)
                    studentsListBox.Items.Add($"{student.stud_ID}: {student.stud_Fname} {student.stud_Lname}");
            }
            examsIDsListBox.Items.Clear();
            foreach (var exam in appManager.entities.Exam_Student)
            {
                examsIDsListBox.Items.Add($"{exam.Exam_ID}, {exam.exam.cours.c_name}");
            }
        }
        #endregion

        #region instructor form -> exams tab -> editing exam db tab
        //a function to fill the editing exams tab on form load
        public void fillEditingExamTab()
        {
            coursesComboBox3.Items.Add("All courses");
            foreach (var course in appManager.entities.courses)
            {
                if (appManager.currentInstructor.courses.Contains(course))
                {
                    coursesComboBox3.Items.Add(course.c_name);
                }

            }
        }
        private void coursesComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coursesComboBox3.SelectedIndex > 0)
            {
                int courseID = 0;
                //assign the course ID
                foreach (var course in appManager.entities.courses)
                {
                    if (course.c_name == coursesComboBox3.SelectedItem.ToString())
                        courseID = course.c_ID;
                }
                //populate the questions list box
                questionsListBox.Items.Clear();
                foreach (var question in appManager.entities.questions)
                {
                    if (question.c_ID == courseID)
                        questionsListBox.Items.Add($"{question.q_ID}: {question.q_desc}");
                }
            }
            else
            {
                questionsListBox.Items.Clear();
                foreach (var question in appManager.entities.questions)
                {
                    questionsListBox.Items.Add($"{question.q_ID}: {question.q_desc}");
                }
            }

<<<<<<< HEAD
        //student

        //insert
        private void insertStdBtn_Click(object sender, EventArgs e)
        {
            if (text_id.Text == String.Empty || text_name.Text == String.Empty || text_dep.Text == String.Empty || text_userName.Text == String.Empty)
            {
                MessageBox.Show("pleasee Enter all data");
            }
            else
            {
                int St_id = int.Parse(text_id.Text);

                string St_name = text_name.Text;
                string[] words = St_name.Split(' ');//split name to first and last name 
                string st_Fname = words[0];
                string st_Lname = words[1];

                MessageBox.Show(st_Fname + " " + st_Lname);

                int dept_id = int.Parse(text_dep.Text);
                string St_userName = text_userName.Text;
                string st_password = text_password.Text;


                appManager.entities.students_insert(St_id, st_Fname, st_Lname, dept_id, St_userName, st_password);
                MessageBox.Show("Student inserted");
                text_id.Text = text_name.Text = text_dep.Text = text_userName.Text = text_password.Text = String.Empty;
                appManager.entities.SaveChanges();

            }
        }
        //show dropdown list items
        private void deptDropDown_Enter(object sender, EventArgs e)
        {
            deptDropDown.Items.Clear();
            var department = from c in appManager.entities.departments
                          select c;
            foreach (var dep in department)
            {
                deptDropDown.Items.Add(dep.dept_ID);
            }
        
        }
        //show student inselected department
        private void deptDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fill datagrid

             select_dep_id =int.Parse( deptDropDown.SelectedItem.ToString());

            var std = from c in appManager.entities.students
                          where c.dept_ID==select_dep_id
                          select c;
           
            dataGridView1.DataSource = std.ToList();
        }
        //selecting from datagrid view
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedCells.Count>1)
            {
                //get the id of cell choosen
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["stud_ID"].Value);
                //fill the textbox with data
               
                text_id.Text = selectedRow.Cells["stud_ID"].Value.ToString();
                text_name.Text = selectedRow.Cells["stud_Fname"].Value+" "+ selectedRow.Cells["stud_Lname"].Value.ToString();
                text_dep.Text =selectedRow.Cells["dept_ID"].Value.ToString();
                text_userName.Text =selectedRow.Cells["stud_Username"].Value.ToString(); 
                text_password.Text = selectedRow.Cells["stud_pw"].Value.ToString();

            }
            
        }
        //update
        private void updateStdBtn_Click(object sender, EventArgs e)
        {
            if (text_id.Text == String.Empty || text_name.Text == String.Empty || text_dep.Text == String.Empty || text_userName.Text == String.Empty)
            {
                MessageBox.Show("pleasee Enter all data");
            }
            else
            {
                int St_id = int.Parse(text_id.Text);

                string St_name = text_name.Text;
                string[] words = St_name.Split(' ');//split name to first and last name 
                string st_Fname = words[0];
                string st_Lname = words[1];

                int dept_id = int.Parse(text_dep.Text);
                string St_userName = text_userName.Text;
                string st_password = text_password.Text;


                var student_update = (from s in appManager.entities.students
                            where s.stud_ID==St_id
                            select s).First();
                if (student_update != null)
                {
                    student_update.stud_ID = St_id;
                    student_update.stud_Lname = st_Lname;
                    student_update.stud_Fname = st_Fname;
                    student_update.dept_ID = dept_id;
                    student_update.stud_Username = St_userName;
                    student_update.stud_pw = st_password;

                    appManager.entities.SaveChanges();
                    MessageBox.Show("Name is Changed");
                }

                //stored proc fehaa moskelaaa
                //appManager.entities.students_update(St_id, st_Fname, st_Lname, dept_id, St_userName, st_password);
                //appManager.entities.SaveChanges();
                //MessageBox.Show("Student updated");
                text_id.Text = text_name.Text = text_dep.Text = text_userName.Text = text_password.Text = String.Empty;

                
               

            }
        }
        //delete
        private void deleteStdBtn_Click(object sender, EventArgs e)
        {
            if (text_id.Text == String.Empty)
            {
                MessageBox.Show("pleasee Enter Id field");
            }
            else
            {
                int St_id = int.Parse(text_id.Text);
                appManager.entities.students_delete(St_id);
                MessageBox.Show("Student deleted");
                appManager.entities.SaveChanges();
            }

        }

       
=======
        }
        private void questionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the question ID
            int qID = int.Parse(questionsListBox.SelectedItem.ToString().Split(':')[0]);
            //retreive the question row
            var question = appManager.entities.questions.Find(qID);
            //asssign the form fields related to that question
            questionDescTextBox.Text = question.q_desc;
            choiceTypeComboBox.SelectedIndex = question.q_type == "mcq" ? 0 : 1;
            choice1_textBox.Text = question.choices.ElementAt(0).choice_desc;
            choice2_textBox.Text = question.choices.ElementAt(1).choice_desc;
            radioButton1.Checked = question.choices.ElementAt(0).isCorrect == "T" || question.choices.ElementAt(0).isCorrect == "t" ? true : false;
            radioButton2.Checked = question.choices.ElementAt(1).isCorrect == "T" || question.choices.ElementAt(1).isCorrect == "t" ? true : false;
            if (question.q_type == "mcq")
            {
                choice3_textBox.Text = question.choices.ElementAt(2).choice_desc;
                radioButton3.Checked = question.choices.ElementAt(2).isCorrect == "T" ? true : false;
            }
            else
            {
                choice3_textBox.Text = "";
                radioButton3.Checked = false;
            }
        }
        private void choiceTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (choiceTypeComboBox.SelectedIndex == 0)
            {
                choice1_textBox.Enabled = true;
                choice2_textBox.Enabled = true;
                choice3_textBox.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
            else
            {
                choice1_textBox.Enabled = true;
                choice2_textBox.Enabled = true;
                choice3_textBox.Enabled = false;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = false;
            }
        }
        private void insertQBtn_Click(object sender, EventArgs e)
        {
            int courseID = 0;
            string qDesc = questionDescTextBox.Text;
            string qType = choiceTypeComboBox.SelectedItem.ToString();
            //assign the course ID
            foreach (var course in appManager.entities.courses)
            {
                if (course.c_name == coursesComboBox3.SelectedItem.ToString())
                    courseID = course.c_ID;
            }
            //appManager.entities.Questions_Insert();
            //--------------------------------------------------
            //insert the choices for the question
            int qIDEntered = 0;
            string choiceDesc = "";
            //string isCorrect = "F";
            //assign the question ID just entered
            foreach (var question in appManager.entities.questions)
            {
                if (question.q_desc == qDesc)
                    qIDEntered = question.q_ID;
            }
            int j = choiceTypeComboBox.SelectedItem.ToString() == "mcq" ? 3 : 2;
            string[] choices = { choice1_textBox.Text, choice2_textBox.Text, choice3_textBox.Text };
            RadioButton[] radioButtons = { radioButton1, radioButton2, radioButton3};
            for (int i = 0; i < j; i++)
            {
                choiceDesc = choices[i];
                if (radioButtons[i].Checked)
                {
                    //isCorrect = "T";
                }
                //appManager.entities.choices_insert();
            }

        }
        private void updateQBtn_Click(object sender, EventArgs e)
        {
            //we need update to take all parameters
            int courseID = 0;
            //assign the course ID
            foreach (var course in appManager.entities.courses)
            {
                if (course.c_name == coursesComboBox3.SelectedItem.ToString())
                    courseID = course.c_ID;
            }
            string qDesc = questionDescTextBox.Text;
            string qType = choiceTypeComboBox.SelectedItem.ToString();
            int qID = int.Parse(questionsListBox.SelectedItem.ToString().Split(':')[0]);
            //appManager.entities.Questions_Update()
        }
        private void deleteQBtn_Click(object sender, EventArgs e)
        {
            int qID = int.Parse(questionsListBox.SelectedItem.ToString().Split(':')[0]);
            appManager.entities.Questions_Delete(qID);
        }
        #endregion
        //on form closing (signout)
        private void instructorF_FormClosing(object sender, FormClosingEventArgs e)
        {
            appManager.loginForm.Show();
            appManager.loginForm.pwTextBox.Text = "";
        }
>>>>>>> fe67778d292da61ab1bc19907e3190a865e918f3
    }
}
