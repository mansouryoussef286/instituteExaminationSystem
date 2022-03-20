using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Institute_system.forms.controls
{
    public partial class Question : UserControl
    {
        public Question(int qnum, string qdesc, string ans1, string ans2, string ans3)
        {
            InitializeComponent();
            qNum.Text = $"{qnum})";
            qDescLabel.Text = qdesc;
            label1.Text = ans1;
            label2.Text = ans2;
            label3.Text = ans3;
            if(ans3 == null)
            {
                label3.Visible = false;
                radioButton3.Visible = false;
                this.Size = new Size(650, 150);
            }
        }
    }
}
