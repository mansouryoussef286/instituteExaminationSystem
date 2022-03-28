using MaterialSkin.Controls;
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
    public partial class login : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        //to delete it after signout
        public MaterialSkin.Controls.MaterialTextBox2 pwTextBox;

        public login()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme=new MaterialSkin.ColorScheme(MaterialSkin.Primary.Red900, MaterialSkin. Primary.Red800,
           MaterialSkin. Primary.Red900, MaterialSkin. Accent.Red700, MaterialSkin.TextShade.BLACK);



            pwTextBox = PasswordTextBox;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            appManager.entities.students_update(-1, "signin", "sign", null, "admin", "123");
            //var std = appManager.entities.students_select(1);
            //std.First().
        }

        private void materialButton1_Click(object sender, EventArgs e)//login
        {
            //if no type was selected !
            if (materialComboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("select a type");
            }
            else
            {
                string username = LoginTextBox.Text;
                string password = PasswordTextBox.Text;
                bool success = false;
                //check if the login user is student or staff
                if (materialComboBox1.SelectedIndex == 0)   //student
                {
                    foreach (var student in appManager.entities.students)
                    {
                        if (username == student.stud_Username)
                        {
                            success = student.stud_pw == password ? true : false;
                            appManager.currentUser = student;
                        }
                    }
                }
                else   //staff
                {
                    foreach (var instructor in appManager.entities.instructors)
                    {
                        if (username == instructor.inst_username)
                        {
                            success = instructor.inst_pw == password ? true : false;
                            appManager.currentInstructor = instructor;
                        }
                    }
                }
                //chech if the user credintials are correct
                if (success)
                {
                    if (materialComboBox1.SelectedIndex == 0)
                    {
                        appManager.studentForm = new studentF();
                        appManager.studentForm.Show();
                    }
                    else
                    {
                        appManager.instructorForm = new instructorF();
                        appManager.instructorForm.Show();
                    }
                    //hide the login form
                    appManager.loginForm.Hide();
                }
                else
                {
                    MessageBox.Show("incorrect credintials");
                }
            }
        }

        private void PasswordTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                materialButton1_Click(null, null);
            }
        }
    }
}

