using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_system
{
    public class ExamClass
    {
        public QuestionClass[] questions;
        public ExamClass()
        {
            questions = new QuestionClass[10];
        }
    }
    public class QuestionClass
    {
        public int qID;
        public string qDesc;
        public ChoiceClass[] choices;
        public int studentChoiceID;
        public QuestionClass()
        {
            choices = new ChoiceClass[3];
            qID = 0;
            qDesc = null;
            studentChoiceID = 0;
        }
    }
    public class ChoiceClass
    {
        public int cID;
        public string cDesc;
        public ChoiceClass()
        {
            cID = 0;
            cDesc = "";
        }
    }

}
