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
        KeyValuePair<int, string> SelectedDepartment;
        KeyValuePair<int, string> SelectedStudent;
        KeyValuePair<int, string> SelectedInstructor;
        KeyValuePair<int, string> Selected_Course;
        KeyValuePair<int, string> Selected_ExamStudent;


        int questionNo = 10;
        instructor instructor;
        int select_dep_id;
        public instructorF()
        {
            InitializeComponent();
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

        #region instructor form -> courses tab 

        int CurrentInst_ID = appManager.currentInstructor.inst_ID; //ID of current instructor
        KeyValuePair<int, string> SelectedCourse; //Selected course in courses tab

        /*******************fill topics of specific course in grid view************************/
        public void FillTopicsGrid()
        {
            appManager.entities = new sqlProjectEntities();
            cours C = appManager.entities.courses.Find(SelectedCourse.Key);
            topicsdatagrid.Rows.Clear();
            foreach (topic Topic in C.topics)
            {
                topicsdatagrid.Rows.Add(Topic.topic_ID.ToString(), Topic.topic_name);
            }
            if (topicsdatagrid.CurrentCell != null)
            {
                topicsdatagrid.CurrentCell.Selected = false;
            }
            TopicID.Text = TopicName.Text = string.Empty;
        }
        /*******************fill textboxes with selected course info**********************/
        public void FillCourseInfo(string Cour_name, int Cour_ID)
        {
            courseName.Text = Cour_name;
            CourseID.Text = Cour_ID.ToString();
        }
        /*******************fill combobox with courses names**********************/
        public void FillCoursesDropDown()
        {
            appManager.entities = new sqlProjectEntities();
            instructor = (from i in appManager.entities.instructors
                              where i.inst_ID == CurrentInst_ID
                              select i).First();
            coursesDropDown.Items.Clear();
            foreach (var course in instructor.courses)
            {
                coursesDropDown.Items.Add(new KeyValuePair<int, string>(course.c_ID, course.c_name));
            }
            coursesDropDown.ValueMember = "Key";
            coursesDropDown.DisplayMember = "Value";

            coursesDropDown.Text = string.Empty;
            topicsdatagrid.Rows.Clear();
            CourseID.Text = courseName.Text = string.Empty;
            TopicID.Text = TopicName.Text = string.Empty;
        }

        /*******************************************Events********************************************/

        /******************************Select course from combobox handler****************************/
        private void coursesDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCourse = (KeyValuePair<int, string>)coursesDropDown.SelectedItem;
            FillTopicsGrid();
            FillCourseInfo(coursesDropDown.Text, SelectedCourse.Key);
        }
        /******************************Select specific row from gridview handler****************************/
        private void topicsdatagrid_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in topicsdatagrid.SelectedRows)
            {
                TopicID.Text = row.Cells[0].Value.ToString();
                TopicName.Text = row.Cells[1].Value.ToString();
            }
        }
        /******************************Update Course name by course ID****************************/
        private void updateCourseBtn_Click(object sender, EventArgs e)
        {
            int CID = int.Parse(CourseID.Text);
            var Course = (from c in appManager.entities.courses  //edit on stored procedure courses_select
                          where c.c_ID == CID
                          select c).First();
            if (Course != null)
            {
                Course.c_name = courseName.Text;
                appManager.entities.SaveChanges();
                FillCoursesDropDown();
                fillExamCourses(coursesComboBox1);
                fillExamCourses(coursesComboBox2);
                MessageBox.Show("Course Name is Updated");
            }
        }
        /******************************Insert Course****************************/
        private void insertCourseBtn_Click(object sender, EventArgs e)
        {
            int CID = int.Parse(CourseID.Text);
            string CName = courseName.Text.ToString();
            if (appManager.entities.courses_insert(CID, CName) == 1)
            {
                appManager.entities = new sqlProjectEntities();
                appManager.entities.ins_courseInsert(CurrentInst_ID, CID); //>>>>stored procedure de feha mo4kla
            }
            //appManager.entities.ins_courseInsert(CurrentInst_ID, CID); //Exception?????????????

            FillCoursesDropDown();
            fillExamCourses(coursesComboBox1);
            fillExamCourses(coursesComboBox2);
            MessageBox.Show("Course is inserted");

        }
        /******************************Delete course****************************/
        private void deleteCourseBtn_Click(object sender, EventArgs e)
        {
            appManager.entities.ins_courseDelete(CurrentInst_ID, int.Parse(CourseID.Text));
            FillCoursesDropDown();
            fillExamCourses(coursesComboBox1);
            fillExamCourses(coursesComboBox2);
            MessageBox.Show("Course is Deleted");
        }

        /******************************Update Topic name by course ID***************************/
        private void updateTopicBtn_Click(object sender, EventArgs e)
        {
            int TID = int.Parse(TopicID.Text);
            var Topic = (from t in appManager.entities.topics //edit topic_select procedure
                         where t.topic_ID == TID
                         select t).First();
            if (Topic != null)
            {
                Topic.topic_name = TopicName.Text;
                appManager.entities.SaveChanges();
                FillTopicsGrid();
                MessageBox.Show("Topic Name is Updated");
            }
        }
        /******************************Insert Topic****************************/
        private void insertTopicBtn_Click(object sender, EventArgs e)
        {
            appManager.entities.topic_insert(int.Parse(TopicID.Text), TopicName.Text.ToString(), SelectedCourse.Key);
            FillTopicsGrid();
            MessageBox.Show("Topic is inserted");
        }
        /******************************Delete Topic****************************/
        private void deleteTopicBtn_Click(object sender, EventArgs e)
        {
            appManager.entities.topic_delete(int.Parse(TopicID.Text));
            FillTopicsGrid();
            MessageBox.Show("Course is Deleted");
        }
        #endregion

        #region instructor form -> exams tab -> generating exam tab


        /*******************************Fill Exam Courses ComboBox******************************/
        private void fillExamCourses(ComboBox coursesComboBox)
        {
            appManager.entities = new sqlProjectEntities();
            //courses_select no arguments and selects c.ID or all
            coursesComboBox.Items.Clear();
            var courses = from c in instructor.courses
                          select c;
            foreach (var course in courses)
            {
                coursesComboBox.Items.Add(course.c_name);
            }

        }

        /*******************************Fill MCQ ComboBox*****************************/

        private void fillMcq(int qNo)
        {
            examMcqComboBox.Items.Clear();
            for (int i = 0; i <= qNo; i++)
            {
                examMcqComboBox.Items.Add(i);
            }

        }

        /*******************************Fill TF ComboBox******************************/

        private void fillTF(int qNo)
        {
            examTFComboBox.Items.Clear();
            for (int i = 0; i <= qNo; i++)
            {
                examTFComboBox.Items.Add(i);
            }
        }

        /******************************Fill Exam ID TextBox*****************************/

        private void fillExamIDTextBox()
        {
            //SP for exams_questions to select last generated exam
            var examID = (from ex in appManager.entities.exams_questions
                          select ex.exam_ID).OrderByDescending(ex => ex).First();

            examIDTextBox1.Text = examID.ToString();

        }

        /******************************Fill Exam ID ComboBox*****************************/

        private void fillExamIDComboBox()
        {
            examsIDComboBox1.Items.Clear();
            var courseID = (from cID in appManager.entities.courses
                            where cID.c_name == coursesComboBox2.Text
                            select cID.c_ID).First();

            var examID = from eID in appManager.entities.exams
                         where eID.course_ID == courseID
                         select eID.exam_ID;

            foreach (var exID in examID)
            {
                examsIDComboBox1.Items.Add(exID);
            }


        }

        /*******************************Fill Students Grid******************************/

        private void fillStudentsGridView()
        {
            studentsExamGridView.Rows.Clear();

            int id = (from cs in appManager.entities.courses
                      where cs.c_name == coursesComboBox2.Text
                      select cs.c_ID).First();

            var course = appManager.entities.courses.Find(id);


            foreach (student std in course.students)
            {
                studentsExamGridView.Rows.Add(false, std.stud_ID, std.stud_Fname + " " + std.stud_Lname);
            }

            if (studentsExamGridView.CurrentCell != null)
            {
                studentsExamGridView.CurrentCell.Selected = false;
            }

        }

        /**************************Check If Student Assigned*************************/

        private bool isStudentAssigned(int Studentid, int examID)
        {
            var stID = from std in appManager.entities.exams_questions
                       select std;

            foreach (var st in stID)
            {
                if (st.St_ID == Studentid && examID == st.exam_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /*****************************Remove Assigned Students*****************************/

        private void removeAssignedStudents()
        {
            for (int i = 0; i < studentsExamGridView.RowCount; i++)
            {
                int stdID = int.Parse(studentsExamGridView.Rows[i].Cells[1].Value.ToString());
                int examsID = int.Parse(examsIDComboBox1.Text);

                if (isStudentAssigned(stdID, examsID))
                {
                    studentsExamGridView.Rows.RemoveAt(i);
                    i -= 1;
                }
            }
        }

        /********************************Events*****************************************/

        /*****************************Exams MCQ Index Change****************************/

        private void ExamMcq_SelectedIndexChanged(object sender, EventArgs e)
        {

            int McqNo = int.Parse(examMcqComboBox.Text);
            int remQuestions = questionNo - McqNo;
            fillTF(remQuestions);
            examTFComboBox.Text = remQuestions.ToString();
            examTFComboBox.Enabled = false;

        }

        /*****************************Exam TF Index Change****************************/

        private void ExamTF_SelectedIndexChanged(object sender, EventArgs e)
        {

            int TFNo = int.Parse(examTFComboBox.Text);
            int remQuestions = questionNo - TFNo;
            //fillMcq(remQuestions);
            examMcqComboBox.Text = remQuestions.ToString();

        }

        /**************************Exams ID ComboBox Index Change*************************/
        private void CoursesComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillStudentsGridView();
            fillExamIDComboBox();
        }

        /**************************Exams ID ComboBox Index Change*************************/

        private void ExamsIDComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillStudentsGridView();
            removeAssignedStudents();
        }

        /*******************************Generate Exam Btn******************************/

        private void GenerateExamBtn_Click(object sender, EventArgs e)
        {
            string course = coursesComboBox1.Text;
            int McqNo = int.Parse(examMcqComboBox.Text);
            int TFNo = int.Parse(examTFComboBox.Text);
            appManager.entities.generateExam(course, TFNo, McqNo);
            MessageBox.Show("Exam Generated Successfully");

            fillExamIDTextBox();
        }


        /*******************************Assign Students Btn*******************************/

        private void assignStudentBtn_Click(object sender, EventArgs e)
        {
            int stdCount = 0;
            List<string> checkedStds = new List<string>();
            for (int i = 0; i < studentsExamGridView.RowCount; i++)
            {

                if (Convert.ToBoolean(studentsExamGridView.Rows[i].Cells[0].Value))
                {
                    checkedStds.Add(studentsExamGridView.Rows[i].Cells[1].Value.ToString());
                }

            }

            foreach (string checkedStd in checkedStds)
            {
                stdCount++;
                int examID = int.Parse(examsIDComboBox1.Text);

                appManager.entities.AssignExamStudent(examID, int.Parse(checkedStd));

                if (stdCount == checkedStds.Count)
                {
                    MessageBox.Show("Student assigned to exam successfully");
                }

            }
            checkedStds.Clear();
            removeAssignedStudents();

        }

        #endregion

        #region Load and Close

        /*********************************Load Event************************************/
        #region report1 tab
        public void FillDepartmentsComboBox()
        {
            DepartmentcomboBox.Items.Clear();
            foreach(var dept in appManager.entities.departments)
            {
                DepartmentcomboBox.Items.Add(new KeyValuePair<int, string>(dept.dept_ID, dept.dept_name));
            }
            DepartmentcomboBox.DisplayMember = "Value";
            DepartmentcomboBox.ValueMember = "Key";
        }
        private void DepartmentcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedDepartment = (KeyValuePair<int, string>)DepartmentcomboBox.SelectedItem;
        }
        private void showbutton_Click(object sender, EventArgs e)
        {
            report_studentInfo_ResultBindingSource.DataSource = appManager.entities.report_studentInfo(SelectedDepartment.Key);
            this.reportViewer1.RefreshReport();
        }
        #endregion
        #region report2 tab
        public void FillStudentsComboBox()
        {
            StudentcomboBox1.Items.Clear();
            foreach (var std in appManager.entities.students)
            {
                StudentcomboBox1.Items.Add(new KeyValuePair<int, string>(std.stud_ID,std.stud_Fname+" "+std.stud_Lname));
            }
            StudentcomboBox1.DisplayMember = "Value";
            StudentcomboBox1.ValueMember = "Key";
        }
        private void StudentcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedStudent = (KeyValuePair<int, string>)StudentcomboBox1.SelectedItem;
        }

        private void Show2button_Click(object sender, EventArgs e)
        {
            finalResults_ResultBindingSource.DataSource = appManager.entities.finalResults(SelectedStudent.Key);
            this.reportViewer2.RefreshReport();
        }
        #endregion
        #region report3 tab
        public void FillInstructorsComboBox()
        {
            InstructorcomboBox1.Items.Clear();
            foreach (var inst in appManager.entities.instructors)
            {
                InstructorcomboBox1.Items.Add(new KeyValuePair<int, string>(inst.inst_ID,inst.inst_name));
            }
            InstructorcomboBox1.DisplayMember = "Value";
            InstructorcomboBox1.ValueMember = "Key";
        }
        private void InstructorcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedInstructor = (KeyValuePair<int, string>)InstructorcomboBox1.SelectedItem;
        }

        private void Show3button1_Click(object sender, EventArgs e)
        {
            Report_3_ResultBindingSource.DataSource = appManager.entities.Report_3(SelectedInstructor.Key);
            this.reportViewer3.RefreshReport();
        }
        #endregion
        #region report4 tab
        public void FillCoursesComboBox()
        {
            CoursecomboBox.Items.Clear();
            foreach (var crs in appManager.entities.courses)
            {
                CoursecomboBox.Items.Add(new KeyValuePair<int, string>(crs.c_ID,crs.c_name));
            }
            CoursecomboBox.DisplayMember = "Value";
            CoursecomboBox.ValueMember = "Key";
        }
        private void CoursecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected_Course = (KeyValuePair<int, string>)CoursecomboBox.SelectedItem;
        }

        private void Show3button_Click(object sender, EventArgs e)
        {
            report_courseTopics_ResultBindingSource.DataSource = appManager.entities.report_courseTopics(Selected_Course.Key);
            this.reportViewer4.RefreshReport();
        }
        #endregion
        #region report5 tab

        public void FillExamIDsComboBox(ComboBox c)
        {
            c.Items.Clear();
            foreach (var ex in appManager.entities.exams)
            {
                c.Items.Add(ex.exam_ID);
            }
        }

        private void Show5button1_Click(object sender, EventArgs e)
        {
            report_examQandA_ResultBindingSource.DataSource = appManager.entities.report_examQandA(int.Parse(ExamNocomboBox1.Text));
            this.reportViewer5.RefreshReport();
        }
        #endregion
        #region report6 tab
        private void ExamcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentscomboBox1.Items.Clear();
            foreach(ExamStudents_Result s in appManager.entities.ExamStudents(int.Parse(ExamcomboBox1.Text)).ToList())
            {
                MessageBox.Show(s.FullName.ToString());
                StudentscomboBox1.Items.Add(new KeyValuePair<int, string>(s.stud_ID, s.FullName));
            }
            StudentscomboBox1.DisplayMember = "Value";
            StudentscomboBox1.ValueMember = "Key";
        }
        private void StudentscomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected_ExamStudent = (KeyValuePair<int, string>)StudentscomboBox1.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            report_StudentExMA_ResultBindingSource.DataSource = appManager.entities.report_StudentExMA(int.Parse(ExamcomboBox1.Text), Selected_ExamStudent.Key);
            this.reportViewer6.RefreshReport();
        }
        #endregion

        private void instructorF_Load(object sender, EventArgs e)
        {

            //Exams Tab
            //Generate Exam Tab

            coursesComboBox1.Items.Clear();
            var courses = from c in appManager.entities.courses
                          select c;
            foreach (var course in courses)
            {
                coursesComboBox1.Items.Add(course.c_ID);
            }
            fillStudentsGradesTab();
            fillEditingExamTab();
            //Courses Tab
            FillCoursesDropDown();
            //Exam Generation Tab
            //Exam Generation
            fillExamCourses(coursesComboBox1);
            fillMcq(questionNo);
            fillTF(questionNo);
            //Students Assignment
            fillExamCourses(coursesComboBox2);

            //Report1 tab
            FillDepartmentsComboBox();
            //Report2 tab
            FillStudentsComboBox();
            //Report3 tab
            FillInstructorsComboBox();
            //Report4 tab
            FillCoursesComboBox();
            //Report5 tab
            FillExamIDsComboBox(ExamNocomboBox1);
            //Report6 tab
            FillExamIDsComboBox(ExamcomboBox1);

            
        }
        /****************************on form closing (signout)**************************/
        private void instructorF_FormClosing(object sender, FormClosingEventArgs e)
        {
            appManager.loginForm.Show();
            appManager.loginForm.pwTextBox.Text = "";
        }

        #endregion
        #region student tab
        //student

        //refreshh datagriddd
        public void RefreshDatagrid()
        {
            this.dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            var std = from c in appManager.entities.students
                      where c.dept_ID == select_dep_id
                      select c;

            dataGridView1.DataSource = std.ToList();
        }
        //insert
        private void insertStdBtn_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty || textBox5.Text == String.Empty)
            {
                MessageBox.Show("pleasee Enter all data");
            }
            else
            {
                int St_id = int.Parse(textBox2.Text);

                string St_name = textBox1.Text;
                string[] words = St_name.Split(' ');//split name to first and last name 
                string st_Fname = words[0];
                string st_Lname = words[1];

                // MessageBox.Show(st_Fname + " " + st_Lname);

                int dept_id = int.Parse(textBox3.Text);
                string St_userName = textBox5.Text;
                string st_password = textBox4.Text;

                ///checkk for id duplicates and username duplicates

                //for the id
                var stud_id = (from s in appManager.entities.students
                               where s.stud_ID == St_id
                               select s).Count();
                //for the username
                var stud_username = (from s in appManager.entities.students
                                     where s.stud_Username == St_userName
                                     select s).Count();
                //check for dep_id
                var depp_id = (from s in appManager.entities.departments
                               where s.dept_ID == dept_id
                               select s).Count();


                if (stud_id == 0 && stud_username == 0)
                {
                    if(depp_id!=0)
                    {
                        appManager.entities.students_insert(St_id, st_Fname, st_Lname, dept_id, St_userName, st_password);
                        MessageBox.Show("Student inserted");
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox5.Text = textBox4.Text = String.Empty;
                        appManager.entities.SaveChanges();

                        RefreshDatagrid();
                    }
                    else
                    {
                        MessageBox.Show("department not available");
                    }
                   
                }
                else
                {
                    if (stud_id > 0)
                        MessageBox.Show("This id is already used");
                    else if (stud_username > 0)
                        MessageBox.Show("This username is already used");
                }





            }
        }
        //show dropdown list items
        private void deptDropDown_Enter_1(object sender, EventArgs e)
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
        private void deptDropDown_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //fill datagrid

            select_dep_id = int.Parse(deptDropDown.SelectedItem.ToString());

            var std = from c in appManager.entities.students
                      where c.dept_ID == select_dep_id
                      select c;

            dataGridView1.DataSource = std.ToList();
        }

        //selecting from datagrid view
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)

        {
            if (dataGridView1.SelectedCells.Count > 1)
            {
                //get the id of cell choosen
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["stud_ID"].Value);
                //fill the textbox with data

                textBox2.Text = selectedRow.Cells["stud_ID"].Value.ToString();
                textBox1.Text = selectedRow.Cells["stud_Fname"].Value + " " + selectedRow.Cells["stud_Lname"].Value.ToString();
                textBox3.Text = selectedRow.Cells["dept_ID"].Value.ToString();
                textBox5.Text = selectedRow.Cells["stud_Username"].Value.ToString();
                textBox4.Text = selectedRow.Cells["stud_pw"].Value.ToString();

            }

        }


        //update
        private void updateStdBtn_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty || textBox5.Text == String.Empty)
            {
                MessageBox.Show("pleasee Enter all data");
            }
            else
            {
                int St_id = int.Parse(textBox2.Text);

                string St_name = textBox1.Text;
                string[] words = St_name.Split(' ');//split name to first and last name 
                string st_Fname = words[0];
                string st_Lname = words[1];

                int dept_id = int.Parse(textBox3.Text);
                string St_userName = textBox5.Text;
                string st_password = textBox4.Text;

                //for the id
                var stud_id = (from s in appManager.entities.students
                               where s.stud_ID == St_id
                               select s).Count();
                if (stud_id > 0)
                {

                    var student_update = (from s in appManager.entities.students
                                          where s.stud_ID == St_id
                                          select s).First();
                    //check for dep_id
                    var depp_id = (from s in appManager.entities.departments
                                   where s.dept_ID == dept_id
                                   select s).Count();

                    if (student_update != null)
                    {
                        if (depp_id != 0)
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
                        else
                        {
                            MessageBox.Show("department not available");
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("No data found");
                }
                //stored proc fehaa moskelaaa
                //appManager.entities.students_update(St_id, st_Fname, st_Lname, dept_id, St_userName, st_password);
                //appManager.entities.SaveChanges();
                //MessageBox.Show("Student updated");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox5.Text = textBox4.Text = String.Empty;

                RefreshDatagrid();


            }
        }

        //delete
        private void deleteStdBtn_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == String.Empty)
            {
                MessageBox.Show("pleasee Enter Id field");
            }
            else
            {
                int St_id = int.Parse(textBox2.Text);

                var stud_id = (from s in appManager.entities.students
                               where s.stud_ID == St_id
                               select s).Count();
                if (stud_id > 0)
                {
                    appManager.entities.students_delete(St_id);
                    MessageBox.Show("Student deleted");
                    appManager.entities.SaveChanges();
                    RefreshDatagrid();
                }
                else
                {
                    MessageBox.Show("No student with that id");
                }
            }

        }





        #endregion

        
    }
}
