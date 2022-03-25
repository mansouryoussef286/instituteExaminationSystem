
namespace Institute_system
{
    partial class examF
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
            this.examCourseName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.questionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.submitBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // examCourseName
            // 
            this.examCourseName.AutoSize = true;
            this.examCourseName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.examCourseName.Location = new System.Drawing.Point(12, 9);
            this.examCourseName.Name = "examCourseName";
            this.examCourseName.Size = new System.Drawing.Size(137, 19);
            this.examCourseName.TabIndex = 1;
            this.examCourseName.Text = "examCourseName";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.questionFlowLayoutPanel);
            this.groupBox1.Location = new System.Drawing.Point(0, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 253);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exam:";
            // 
            // questionFlowLayoutPanel
            // 
            this.questionFlowLayoutPanel.AutoScroll = true;
            this.questionFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.questionFlowLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.questionFlowLayoutPanel.Name = "questionFlowLayoutPanel";
            this.questionFlowLayoutPanel.Size = new System.Drawing.Size(676, 234);
            this.questionFlowLayoutPanel.TabIndex = 1;
            this.questionFlowLayoutPanel.WrapContents = false;
            // 
            // submitBtn
            // 
            this.submitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.submitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Tahoma", 10F);
            this.submitBtn.Location = new System.Drawing.Point(470, 318);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(200, 23);
            this.submitBtn.TabIndex = 3;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // examF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 345);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.examCourseName);
            this.Name = "examF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "examF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.examF_FormClosing);
            this.Load += new System.EventHandler(this.examF_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label examCourseName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel questionFlowLayoutPanel;
        private System.Windows.Forms.Button submitBtn;
    }
}