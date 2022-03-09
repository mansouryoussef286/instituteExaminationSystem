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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

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

       
    }
}
