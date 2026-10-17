namespace ShopManagerMini.Forms
{
    partial class FrmAbout
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
            lblAppName = new Label();
            lblSlogan = new Label();
            btnClose = new Button();
            pnlHeader = new Panel();
            lblTechTitle = new Label();
            lblCourseTitle = new Label();
            lblStudentTitle = new Label();
            lblClassTitle = new Label();
            lblVersion = new Label();
            lblClass = new Label();
            lblCourse = new Label();
            lblStudent = new Label();
            lblVersionTitle = new Label();
            lblDescription = new Label();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.BackColor = Color.Transparent;
            lblAppName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(25, 14);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(261, 38);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "ShopManagerMini";
            // 
            // lblSlogan
            // 
            lblSlogan.AutoSize = true;
            lblSlogan.BackColor = Color.Transparent;
            lblSlogan.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblSlogan.ForeColor = Color.White;
            lblSlogan.Location = new Point(28, 53);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(262, 23);
            lblSlogan.TabIndex = 2;
            lblSlogan.Text = "Ứng dụng quản lý cửa hàng mini";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(31, 78, 121);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(376, 288);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 6;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(31, 78, 121);
            pnlHeader.Controls.Add(lblAppName);
            pnlHeader.Controls.Add(lblSlogan);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(507, 90);
            pnlHeader.TabIndex = 7;
            // 
            // lblTechTitle
            // 
            lblTechTitle.AutoSize = true;
            lblTechTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblTechTitle.Location = new Point(30, 144);
            lblTechTitle.Name = "lblTechTitle";
            lblTechTitle.Size = new Size(95, 23);
            lblTechTitle.TabIndex = 8;
            lblTechTitle.Text = "Công nghệ";
            // 
            // lblCourseTitle
            // 
            lblCourseTitle.AutoSize = true;
            lblCourseTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblCourseTitle.Location = new Point(31, 179);
            lblCourseTitle.Name = "lblCourseTitle";
            lblCourseTitle.Size = new Size(78, 23);
            lblCourseTitle.TabIndex = 9;
            lblCourseTitle.Text = "Môn học";
            // 
            // lblStudentTitle
            // 
            lblStudentTitle.AutoSize = true;
            lblStudentTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblStudentTitle.Location = new Point(30, 212);
            lblStudentTitle.Name = "lblStudentTitle";
            lblStudentTitle.Size = new Size(79, 23);
            lblStudentTitle.TabIndex = 10;
            lblStudentTitle.Text = "Sinh viên";
            // 
            // lblClassTitle
            // 
            lblClassTitle.AutoSize = true;
            lblClassTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblClassTitle.Location = new Point(31, 248);
            lblClassTitle.Name = "lblClassTitle";
            lblClassTitle.Size = new Size(38, 23);
            lblClassTitle.TabIndex = 11;
            lblClassTitle.Text = "Lớp";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblVersion.Location = new Point(144, 109);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(30, 23);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "1.0";
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblClass.Location = new Point(144, 248);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(110, 23);
            lblClass.TabIndex = 5;
            lblClass.Text = "49.01.SPTINA";
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblCourse.Location = new Point(144, 179);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(288, 23);
            lblCourse.TabIndex = 3;
            lblCourse.Text = "COMP1019 - Lập trình trên Windows";
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblStudent.Location = new Point(144, 212);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(248, 23);
            lblStudent.TabIndex = 4;
            lblStudent.Text = "Lê Thị Kim Loan - 49.01.103.045";
            // 
            // lblVersionTitle
            // 
            lblVersionTitle.AutoSize = true;
            lblVersionTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblVersionTitle.Location = new Point(30, 109);
            lblVersionTitle.Name = "lblVersionTitle";
            lblVersionTitle.Size = new Size(87, 23);
            lblVersionTitle.TabIndex = 12;
            lblVersionTitle.Text = "Phiên bản";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblDescription.Location = new Point(144, 144);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(157, 23);
            lblDescription.TabIndex = 13;
            lblDescription.Text = "C# WinForms, .NET";
            // 
            // FrmAbout
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(507, 340);
            Controls.Add(lblDescription);
            Controls.Add(lblVersionTitle);
            Controls.Add(lblClassTitle);
            Controls.Add(lblStudentTitle);
            Controls.Add(lblCourseTitle);
            Controls.Add(lblTechTitle);
            Controls.Add(pnlHeader);
            Controls.Add(btnClose);
            Controls.Add(lblClass);
            Controls.Add(lblStudent);
            Controls.Add(lblCourse);
            Controls.Add(lblVersion);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Giới thiệu";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private Label lblSlogan;
        private Button btnClose;
        private Panel pnlHeader;
        private Label lblStudent;
        private Label lblCourse;
        private Label lblTechTitle;
        private Label lblCourseTitle;
        private Label lblStudentTitle;
        private Label lblClassTitle;
        private Label lblVersion;
        private Label lblClass;
        private Label lblVersionTitle;
        private Label lblDescription;
    }
}