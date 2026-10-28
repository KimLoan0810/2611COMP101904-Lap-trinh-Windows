namespace StudentCard
{
    partial class FrmStudentCard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStudentCard));
            grpInfo = new GroupBox();
            dtpBirthDate = new DateTimePicker();
            cboGender = new ComboBox();
            cboFaculty = new ComboBox();
            cboCourse = new ComboBox();
            cboClass = new ComboBox();
            txtFullName = new TextBox();
            txtStudentId = new TextBox();
            lblGender = new Label();
            lblBirthDate = new Label();
            lblCourse = new Label();
            lblFaculty = new Label();
            lblClass = new Label();
            lblFullName = new Label();
            lblStudentId = new Label();
            lblImageHint = new Label();
            btnChooseImage = new Button();
            picAvatar = new PictureBox();
            grpPreview = new GroupBox();
            pnlCard = new Panel();
            grpActions = new GroupBox();
            btnExit = new Button();
            btnReset = new Button();
            btnPrint = new Button();
            btnPreviewPrint = new Button();
            ofdAvatar = new OpenFileDialog();
            pdCard = new System.Drawing.Printing.PrintDocument();
            ppdCard = new PrintPreviewDialog();
            pdlgCard = new PrintDialog();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            grpPreview.SuspendLayout();
            grpActions.SuspendLayout();
            SuspendLayout();
            // 
            // grpInfo
            // 
            grpInfo.BackColor = Color.White;
            grpInfo.Controls.Add(dtpBirthDate);
            grpInfo.Controls.Add(cboGender);
            grpInfo.Controls.Add(cboFaculty);
            grpInfo.Controls.Add(cboCourse);
            grpInfo.Controls.Add(cboClass);
            grpInfo.Controls.Add(txtFullName);
            grpInfo.Controls.Add(txtStudentId);
            grpInfo.Controls.Add(lblGender);
            grpInfo.Controls.Add(lblBirthDate);
            grpInfo.Controls.Add(lblCourse);
            grpInfo.Controls.Add(lblFaculty);
            grpInfo.Controls.Add(lblClass);
            grpInfo.Controls.Add(lblFullName);
            grpInfo.Controls.Add(lblStudentId);
            grpInfo.Controls.Add(lblImageHint);
            grpInfo.Controls.Add(btnChooseImage);
            grpInfo.Controls.Add(picAvatar);
            grpInfo.ForeColor = Color.FromArgb(10, 56, 120);
            grpInfo.Location = new Point(12, 12);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(420, 560);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "\tThông tin sinh viên";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.Location = new Point(130, 437);
            dtpBirthDate.MaxDate = new DateTime(2026, 10, 25, 0, 0, 0, 0);
            dtpBirthDate.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(270, 30);
            dtpBirthDate.TabIndex = 16;
            dtpBirthDate.Value = new DateTime(2004, 1, 1, 0, 0, 0, 0);
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(130, 482);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(270, 31);
            cboGender.TabIndex = 15;
            // 
            // cboFaculty
            // 
            cboFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFaculty.FormattingEnabled = true;
            cboFaculty.Items.AddRange(new object[] { "Công nghệ thông tin", "", "Toán - Tin học", "", "Vật lý", "", "Hóa học", "", "Ngữ văn" });
            cboFaculty.Location = new Point(130, 347);
            cboFaculty.Name = "cboFaculty";
            cboFaculty.Size = new Size(270, 31);
            cboFaculty.TabIndex = 14;
            // 
            // cboCourse
            // 
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.FormattingEnabled = true;
            cboCourse.Items.AddRange(new object[] { "K49", "", "K50", "K51" });
            cboCourse.Location = new Point(130, 392);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(270, 31);
            cboCourse.TabIndex = 13;
            // 
            // cboClass
            // 
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.FormattingEnabled = true;
            cboClass.Items.AddRange(new object[] { "49.01.SPTIN.A", "49.01.SPTIN.B", "49.01.CNTT.A", "49.01.CNTT.B", "49.01.CNTT.C", "49.01.CNTT.D", "50.01.SPTIN.A", "50.01.SPTIN.B" });
            cboClass.Location = new Point(130, 302);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(270, 31);
            cboClass.TabIndex = 12;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(130, 257);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(270, 30);
            txtFullName.TabIndex = 11;
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(130, 212);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(270, 30);
            txtStudentId.TabIndex = 10;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(30, 40, 60);
            lblGender.Location = new Point(20, 485);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(79, 23);
            lblGender.TabIndex = 9;
            lblGender.Text = "Giới tính:";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblBirthDate.ForeColor = Color.FromArgb(30, 40, 60);
            lblBirthDate.Location = new Point(20, 440);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(91, 23);
            lblBirthDate.TabIndex = 8;
            lblBirthDate.Text = "Ngày sinh:";
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblCourse.ForeColor = Color.FromArgb(30, 40, 60);
            lblCourse.Location = new Point(20, 395);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(86, 23);
            lblCourse.TabIndex = 7;
            lblCourse.Text = "Khóa học:";
            // 
            // lblFaculty
            // 
            lblFaculty.AutoSize = true;
            lblFaculty.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblFaculty.ForeColor = Color.FromArgb(30, 40, 60);
            lblFaculty.Location = new Point(20, 350);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(53, 23);
            lblFaculty.TabIndex = 6;
            lblFaculty.Text = "Khoa:";
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblClass.ForeColor = Color.FromArgb(30, 40, 60);
            lblClass.Location = new Point(20, 305);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(42, 23);
            lblClass.TabIndex = 5;
            lblClass.Text = "Lớp:";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(30, 40, 60);
            lblFullName.Location = new Point(20, 260);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(67, 23);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ tên:";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblStudentId.ForeColor = Color.FromArgb(30, 40, 60);
            lblStudentId.Location = new Point(20, 215);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(112, 23);
            lblStudentId.TabIndex = 3;
            lblStudentId.Text = "Mã sinh viên:";
            // 
            // lblImageHint
            // 
            lblImageHint.AutoSize = true;
            lblImageHint.ForeColor = Color.DimGray;
            lblImageHint.Location = new Point(155, 72);
            lblImageHint.Name = "lblImageHint";
            lblImageHint.Size = new Size(230, 23);
            lblImageHint.TabIndex = 2;
            lblImageHint.Text = "Hỗ trợ: JPG, JPEG, PNG, BMP";
            // 
            // btnChooseImage
            // 
            btnChooseImage.BackColor = Color.FromArgb(30, 110, 190);
            btnChooseImage.FlatAppearance.BorderSize = 0;
            btnChooseImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 140, 210);
            btnChooseImage.ForeColor = Color.White;
            btnChooseImage.Location = new Point(155, 30);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(120, 34);
            btnChooseImage.TabIndex = 1;
            btnChooseImage.Text = "Chọn ảnh...";
            btnChooseImage.UseVisualStyleBackColor = false;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.WhiteSmoke;
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(20, 30);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(120, 160);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // grpPreview
            // 
            grpPreview.Controls.Add(pnlCard);
            grpPreview.Location = new Point(444, 12);
            grpPreview.Name = "grpPreview";
            grpPreview.Size = new Size(540, 390);
            grpPreview.TabIndex = 1;
            grpPreview.TabStop = false;
            grpPreview.Text = "Xem trước thẻ";
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;
            pnlCard.ForeColor = Color.FromArgb(10, 56, 120);
            pnlCard.Location = new Point(10, 30);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(520, 328);
            pnlCard.TabIndex = 0;
            // 
            // grpActions
            // 
            grpActions.BackColor = Color.White;
            grpActions.Controls.Add(btnExit);
            grpActions.Controls.Add(btnReset);
            grpActions.Controls.Add(btnPrint);
            grpActions.Controls.Add(btnPreviewPrint);
            grpActions.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            grpActions.ForeColor = Color.FromArgb(30, 40, 60);
            grpActions.Location = new Point(444, 412);
            grpActions.Name = "grpActions";
            grpActions.Size = new Size(540, 160);
            grpActions.TabIndex = 1;
            grpActions.TabStop = false;
            grpActions.Text = "Chức năng";
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnExit.ForeColor = Color.FromArgb(30, 40, 60);
            btnExit.Location = new Point(360, 90);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(160, 42);
            btnExit.TabIndex = 3;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnReset.ForeColor = Color.FromArgb(30, 40, 60);
            btnReset.Location = new Point(360, 35);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(160, 42);
            btnReset.TabIndex = 2;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            btnPrint.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnPrint.ForeColor = Color.FromArgb(30, 40, 60);
            btnPrint.Location = new Point(190, 35);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(160, 42);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "In thẻ";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnPreviewPrint
            // 
            btnPreviewPrint.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnPreviewPrint.ForeColor = Color.FromArgb(30, 40, 60);
            btnPreviewPrint.Location = new Point(20, 35);
            btnPreviewPrint.Name = "btnPreviewPrint";
            btnPreviewPrint.Size = new Size(160, 42);
            btnPreviewPrint.TabIndex = 0;
            btnPreviewPrint.Text = "Xem trước in";
            btnPreviewPrint.UseVisualStyleBackColor = true;
            btnPreviewPrint.Click += btnPreviewPrint_Click;
            // 
            // ofdAvatar
            // 
            ofdAvatar.FileName = "openFileDialog1";
            ofdAvatar.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            ofdAvatar.Title = "Chọn ảnh đại diện";
            // 
            // ppdCard
            // 
            ppdCard.AutoScrollMargin = new Size(0, 0);
            ppdCard.AutoScrollMinSize = new Size(0, 0);
            ppdCard.ClientSize = new Size(400, 300);
            ppdCard.Document = pdCard;
            ppdCard.Enabled = true;
            ppdCard.Icon = (Icon)resources.GetObject("ppdCard.Icon");
            ppdCard.Name = "ppdCard";
            ppdCard.Visible = false;
            // 
            // pdlgCard
            // 
            pdlgCard.Document = pdCard;
            pdlgCard.UseEXDialog = true;
            // 
            // FrmStudentCard
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 250);
            ClientSize = new Size(1105, 659);
            Controls.Add(grpPreview);
            Controls.Add(grpActions);
            Controls.Add(grpInfo);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmStudentCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "THIẾT KẾ VÀ IN THẺ SINH VIÊN";
            Load += FrmStudentCard_Load;
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            grpPreview.ResumeLayout(false);
            grpActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInfo;
        private GroupBox grpPreview;
        private GroupBox grpActions;
        private Panel pnlCard;
        private Label lblGender;
        private Label lblBirthDate;
        private Label lblCourse;
        private Label lblFaculty;
        private Label lblClass;
        private Label lblFullName;
        private Label lblStudentId;
        private Label lblImageHint;
        private Button btnChooseImage;
        private PictureBox picAvatar;
        private DateTimePicker dtpBirthDate;
        private ComboBox cboGender;
        private ComboBox cboFaculty;
        private ComboBox cboCourse;
        private ComboBox cboClass;
        private TextBox txtFullName;
        private TextBox txtStudentId;
        private OpenFileDialog ofdAvatar;
        private System.Drawing.Printing.PrintDocument pdCard;
        private PrintPreviewDialog ppdCard;
        private Button btnExit;
        private Button btnReset;
        private Button btnPrint;
        private Button btnPreviewPrint;
        private PrintDialog pdlgCard;
    }
}
