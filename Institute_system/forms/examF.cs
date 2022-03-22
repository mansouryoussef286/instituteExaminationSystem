using Institute_system.forms.controls;
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
    public partial class examF : Form
    {
        ExamClass exam;
        QuestionClass q;
        ChoiceClass c;

        public examF()
        {
            InitializeComponent();
            
        }

        
        private void examF_Load(object sender, EventArgs e)
        {
            exam = new ExamClass();
            //get the 10 questions of that exam and student
            var examQuestions = appManager.entities.exams_questions.Where(eq => eq.St_ID == 0 && eq.exam_ID== studentF.SelectedExamID )
                .Select(eq => eq);
            Question ques;
            int i = 0;
            foreach(var examQuestion in examQuestions)
            {
                q = new QuestionClass();
                var question = appManager.entities.questions.Where(eq => eq.q_ID == examQuestion.q_ID)
                    .Select(eq => eq).FirstOrDefault();
                var choices = appManager.entities.choices.Where(qAns => qAns.q_ID == examQuestion.q_ID)
                    .Select(qAns => qAns);
                //add the question to the object in exam object
                q.qID = question.q_ID;
                q.qDesc = question.q_desc;

                //get the question choices and add them to the question object
                int j = 0;
                foreach (var choice in choices)
                {
                    c = new ChoiceClass();
                    c.cID = choice.choice_ID;
                    c.cDesc = choice.choice_desc;
                    q.choices[j] = c;
                    j++;
                }
                exam.questions[i] = q;
                //generate the question control and add it to the form
                ques = new Question(i+1, exam.questions[i].qDesc, exam.questions[i].choices[0].cDesc, exam.questions[i].choices[1].cDesc, exam.questions[i].choices[2]==null? null: exam.questions[i].choices[2].cDesc); //there was a problem with null refrencing so i had to check on it
                questionFlowLayoutPanel.Controls.Add(ques);
                i++;
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            appManager.confirmDlg = new forms.ConfirmDialog("Are you sure to submit exam?");
            DialogResult res = appManager.confirmDlg.ShowDialog();
            if(res == DialogResult.OK)
            {
                int i = 0;
                foreach (var q in questionFlowLayoutPanel.Controls)
                {
                    //get the checked answer from the form
                    int checkedID = 0;
                    checkedID = ((Question)q).radioButton1.Checked ? exam.questions[i].choices[0].cID : checkedID;
                    checkedID = ((Question)q).radioButton2.Checked ? exam.questions[i].choices[1].cID : checkedID;
                    checkedID = ((Question)q).radioButton3.Checked ? exam.questions[i].choices[2].cID : checkedID;
                    //assign the student answer 
                    exam.questions[i].studentChoiceID = checkedID;
                    i++;
                }
                MessageBox.Show("submitted!");
                MessageBox.Show($"{exam.questions[0].studentChoiceID},{exam.questions[1].studentChoiceID},{exam.questions[2].studentChoiceID},{exam.questions[3].studentChoiceID},{exam.questions[4].studentChoiceID},{exam.questions[5].studentChoiceID},{exam.questions[6].studentChoiceID},{exam.questions[7].studentChoiceID},{exam.questions[8].studentChoiceID},{exam.questions[9].studentChoiceID}");
                appManager.examForm.Close();
            }
        }

        //on form closing show the student form again
        private void examF_FormClosing(object sender, FormClosingEventArgs e)
        {
            appManager.studentForm.Show();
        }

    }
}
