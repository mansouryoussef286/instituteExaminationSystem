
namespace Institute_system
{
    partial class studentF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ExamscomboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.startExamBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.studCoursesComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StudentPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.StudentUsernameTextBox = new System.Windows.Forms.TextBox();
            this.updateInfoBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1007, 531);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ExamscomboBox1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.startExamBtn);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.studCoursesComboBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(999, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "exams";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ExamscomboBox1
            // 
            this.ExamscomboBox1.FormattingEnabled = true;
            this.ExamscomboBox1.Location = new System.Drawing.Point(572, 105);
            this.ExamscomboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExamscomboBox1.Name = "ExamscomboBox1";
            this.ExamscomboBox1.Size = new System.Drawing.Size(180, 28);
            this.ExamscomboBox1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 109);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Courses ";
            // 
            // startExamBtn
            // 
            this.startExamBtn.Location = new System.Drawing.Point(343, 272);
            this.startExamBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startExamBtn.Name = "startExamBtn";
            this.startExamBtn.Size = new System.Drawing.Size(219, 35);
            this.startExamBtn.TabIndex = 4;
            this.startExamBtn.Text = "start exam";
            this.startExamBtn.UseVisualStyleBackColor = true;
            this.startExamBtn.Click += new System.EventHandler(this.startExamBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(486, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "exams";
            // 
            // studCoursesComboBox
            // 
            this.studCoursesComboBox.FormattingEnabled = true;
            this.studCoursesComboBox.Location = new System.Drawing.Point(227, 105);
            this.studCoursesComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.studCoursesComboBox.Name = "studCoursesComboBox";
            this.studCoursesComboBox.Size = new System.Drawing.Size(180, 28);
            this.studCoursesComboBox.TabIndex = 2;
            this.studCoursesComboBox.SelectedIndexChanged += new System.EventHandler(this.studCoursesComboBox_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(999, 498);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "grade progress";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label6.Location = new System.Drawing.Point(63, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Transcript:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(199, 39);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(585, 422);
            this.dataGridView1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.StudentPasswordTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.StudentUsernameTextBox);
            this.tabPage1.Controls.Add(this.updateInfoBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(999, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "username";
            // 
            // StudentPasswordTextBox
            // 
            this.StudentPasswordTextBox.Location = new System.Drawing.Point(174, 171);
            this.StudentPasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StudentPasswordTextBox.Name = "StudentPasswordTextBox";
            this.StudentPasswordTextBox.Size = new System.Drawing.Size(148, 26);
            this.StudentPasswordTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "update login info";
            // 
            // StudentUsernameTextBox
            // 
            this.StudentUsernameTextBox.Location = new System.Drawing.Point(174, 111);
            this.StudentUsernameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StudentUsernameTextBox.Name = "StudentUsernameTextBox";
            this.StudentUsernameTextBox.Size = new System.Drawing.Size(148, 26);
            this.StudentUsernameTextBox.TabIndex = 1;
            // 
            // updateInfoBtn
            // 
            this.updateInfoBtn.Location = new System.Drawing.Point(210, 218);
            this.updateInfoBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updateInfoBtn.Name = "updateInfoBtn";
            this.updateInfoBtn.Size = new System.Drawing.Size(112, 35);
            this.updateInfoBtn.TabIndex = 0;
            this.updateInfoBtn.Text = "update info";
            this.updateInfoBtn.UseVisualStyleBackColor = true;
            this.updateInfoBtn.Click += new System.EventHandler(this.updateInfoBtn_Click);
            // 
            // studentF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 538);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "studentF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "student";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.studentF_FormClosing);
            this.Load += new System.EventHandler(this.StudentF_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox studCoursesComboBox;
        private System.Windows.Forms.Button startExamBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox StudentPasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StudentUsernameTextBox;
        private System.Windows.Forms.Button updateInfoBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ExamscomboBox1;
    }
}