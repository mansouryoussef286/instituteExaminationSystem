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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
