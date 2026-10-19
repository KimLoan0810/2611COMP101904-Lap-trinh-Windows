namespace StudentCardApp
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStudentCard));
            grpInfo = new GroupBox();
            cboGender = new ComboBox();
            lblGender = new Label();
            dtpBirthDate = new DateTimePicker();
            lblBirthDate = new Label();
            cboCourse = new ComboBox();
            lblCourse = new Label();
            cboFaculty = new ComboBox();
            lblFaculty = new Label();
            cboClass = new ComboBox();
            lblClass = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtStudentId = new TextBox();
            lblStudentId = new Label();
            grpPhoto = new GroupBox();
            lblImageHint = new Label();
            btnRemoveImage = new Button();
            btnChooseImage = new Button();
            picAvatar = new PictureBox();
            grpOptions = new GroupBox();
            chkShowQR = new CheckBox();
            pnlColorSample = new Panel();
            btnCardColor = new Button();
            grpPreview = new GroupBox();
            pnlCard = new Panel();
            grpList = new GroupBox();
            btnRemoveFromList = new Button();
            btnAddToList = new Button();
            lstStudents = new ListBox();
            btnReset = new Button();
            btnSavePng = new Button();
            btnPrintPreview = new Button();
            btnPrint = new Button();
            btnExit = new Button();
            ofdAvatar = new OpenFileDialog();
            sfdPng = new SaveFileDialog();
            colorDialog = new ColorDialog();
            pdCard = new System.Drawing.Printing.PrintDocument();
            ppdCard = new PrintPreviewDialog();
            printDialog = new PrintDialog();
            errProvider = new ErrorProvider(components);
            grpInfo.SuspendLayout();
            grpPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            grpOptions.SuspendLayout();
            grpPreview.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(cboGender);
            grpInfo.Controls.Add(lblGender);
            grpInfo.Controls.Add(dtpBirthDate);
            grpInfo.Controls.Add(lblBirthDate);
            grpInfo.Controls.Add(cboCourse);
            grpInfo.Controls.Add(lblCourse);
            grpInfo.Controls.Add(cboFaculty);
            grpInfo.Controls.Add(lblFaculty);
            grpInfo.Controls.Add(cboClass);
            grpInfo.Controls.Add(lblClass);
            grpInfo.Controls.Add(txtFullName);
            grpInfo.Controls.Add(lblFullName);
            grpInfo.Controls.Add(txtStudentId);
            grpInfo.Controls.Add(lblStudentId);
            grpInfo.Location = new Point(12, 12);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(440, 310);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin sinh viên";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(145, 258);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(280, 31);
            cboGender.TabIndex = 6;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(15, 261);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(79, 23);
            lblGender.TabIndex = 12;
            lblGender.Text = "Giới tính:";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.Location = new Point(145, 220);
            dtpBirthDate.MaxDate = new DateTime(2026, 10, 18, 0, 0, 0, 0);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(280, 30);
            dtpBirthDate.TabIndex = 5;
            dtpBirthDate.Value = new DateTime(2026, 10, 18, 0, 0, 0, 0);
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Location = new Point(15, 223);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(90, 23);
            lblBirthDate.TabIndex = 10;
            lblBirthDate.Text = "Ngày sinh:";
            // 
            // cboCourse
            // 
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.FormattingEnabled = true;
            cboCourse.Items.AddRange(new object[] { "K49", "K50", "K51", "K52" });
            cboCourse.Location = new Point(145, 182);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(280, 31);
            cboCourse.TabIndex = 4;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(15, 185);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(86, 23);
            lblCourse.TabIndex = 8;
            lblCourse.Text = "Khóa học:";
            // 
            // cboFaculty
            // 
            cboFaculty.FormattingEnabled = true;
            cboFaculty.Items.AddRange(new object[] { "Công nghệ thông tin", "Toán - Tin học", "Vật lý", "Hóa học", "Ngữ văn", "Tiếng Anh" });
            cboFaculty.Location = new Point(145, 144);
            cboFaculty.Name = "cboFaculty";
            cboFaculty.Size = new Size(280, 31);
            cboFaculty.TabIndex = 3;
            // 
            // lblFaculty
            // 
            lblFaculty.AutoSize = true;
            lblFaculty.Location = new Point(15, 147);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(53, 23);
            lblFaculty.TabIndex = 6;
            lblFaculty.Text = "Khoa:";
            // 
            // cboClass
            // 
            cboClass.FormattingEnabled = true;
            cboClass.Items.AddRange(new object[] { "49.01.SPTIN.A", "49.01.SPTIN.B", "49.01.CNTT.A", "49.01.CNTT.B", "50.01.CNTT.A", "50.01.CNTT.B", "51.01.CNTT.A" });
            cboClass.Location = new Point(145, 106);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(280, 31);
            cboClass.TabIndex = 2;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(15, 109);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(42, 23);
            lblClass.TabIndex = 4;
            lblClass.Text = "Lớp:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(145, 68);
            txtFullName.MaxLength = 50;
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(280, 30);
            txtFullName.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(15, 71);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(110, 23);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên (*):";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(145, 30);
            txtStudentId.MaxLength = 15;
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(280, 30);
            txtStudentId.TabIndex = 0;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(15, 33);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(132, 23);
            lblStudentId.TabIndex = 0;
            lblStudentId.Text = "Mã sinh viên (*):";
            // 
            // grpPhoto
            // 
            grpPhoto.Controls.Add(lblImageHint);
            grpPhoto.Controls.Add(btnRemoveImage);
            grpPhoto.Controls.Add(btnChooseImage);
            grpPhoto.Controls.Add(picAvatar);
            grpPhoto.Location = new Point(12, 332);
            grpPhoto.Name = "grpPhoto";
            grpPhoto.Size = new Size(440, 230);
            grpPhoto.TabIndex = 1;
            grpPhoto.TabStop = false;
            grpPhoto.Text = "Ảnh đại diện (*)";
            // 
            // lblImageHint
            // 
            lblImageHint.AutoSize = true;
            lblImageHint.ForeColor = Color.Gray;
            lblImageHint.Location = new Point(185, 140);
            lblImageHint.Name = "lblImageHint";
            lblImageHint.Size = new Size(230, 23);
            lblImageHint.TabIndex = 3;
            lblImageHint.Text = "Hỗ trợ: JPG, JPEG, PNG, BMP";
            // 
            // btnRemoveImage
            // 
            btnRemoveImage.Location = new Point(185, 88);
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new Size(235, 38);
            btnRemoveImage.TabIndex = 2;
            btnRemoveImage.Text = "✖ Xóa ảnh";
            btnRemoveImage.UseVisualStyleBackColor = true;
            btnRemoveImage.Click += btnRemoveImage_Click;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(185, 40);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(235, 38);
            btnChooseImage.TabIndex = 0;
            btnChooseImage.Text = "📁 Chọn ảnh...";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.White;
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(15, 28);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(150, 190);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // grpOptions
            // 
            grpOptions.Controls.Add(chkShowQR);
            grpOptions.Controls.Add(pnlColorSample);
            grpOptions.Controls.Add(btnCardColor);
            grpOptions.Location = new Point(12, 570);
            grpOptions.Name = "grpOptions";
            grpOptions.Size = new Size(440, 92);
            grpOptions.TabIndex = 2;
            grpOptions.TabStop = false;
            grpOptions.Text = "Tùy chọn thẻ";
            // 
            // chkShowQR
            // 
            chkShowQR.AutoSize = true;
            chkShowQR.Checked = true;
            chkShowQR.CheckState = CheckState.Checked;
            chkShowQR.Location = new Point(260, 40);
            chkShowQR.Name = "chkShowQR";
            chkShowQR.Size = new Size(149, 27);
            chkShowQR.TabIndex = 2;
            chkShowQR.Text = "Hiển thị mã QR";
            chkShowQR.UseVisualStyleBackColor = true;
            // 
            // pnlColorSample
            // 
            pnlColorSample.BackColor = Color.LightSkyBlue;
            pnlColorSample.BorderStyle = BorderStyle.FixedSingle;
            pnlColorSample.Location = new Point(195, 30);
            pnlColorSample.Name = "pnlColorSample";
            pnlColorSample.Size = new Size(40, 40);
            pnlColorSample.TabIndex = 1;
            // 
            // btnCardColor
            // 
            btnCardColor.Location = new Point(15, 30);
            btnCardColor.Name = "btnCardColor";
            btnCardColor.Size = new Size(170, 40);
            btnCardColor.TabIndex = 0;
            btnCardColor.Text = "🎨 Chọn màu thẻ";
            btnCardColor.UseVisualStyleBackColor = true;
            // 
            // grpPreview
            // 
            grpPreview.Controls.Add(pnlCard);
            grpPreview.Location = new Point(470, 12);
            grpPreview.Name = "grpPreview";
            grpPreview.Size = new Size(688, 400);
            grpPreview.TabIndex = 3;
            grpPreview.TabStop = false;
            grpPreview.Text = "Xem trước thẻ sinh viên";
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Location = new Point(74, 38);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(540, 340);
            pnlCard.TabIndex = 0;
            // 
            // grpList
            // 
            grpList.Controls.Add(btnRemoveFromList);
            grpList.Controls.Add(btnAddToList);
            grpList.Controls.Add(lstStudents);
            grpList.Location = new Point(470, 420);
            grpList.Name = "grpList";
            grpList.Size = new Size(688, 186);
            grpList.TabIndex = 4;
            grpList.TabStop = false;
            grpList.Text = "Danh sách sinh viên (lưu tạm)";
            // 
            // btnRemoveFromList
            // 
            btnRemoveFromList.Location = new Point(540, 78);
            btnRemoveFromList.Name = "btnRemoveFromList";
            btnRemoveFromList.Size = new Size(133, 42);
            btnRemoveFromList.TabIndex = 2;
            btnRemoveFromList.Text = "➖ Xóa khỏi DS";
            btnRemoveFromList.UseVisualStyleBackColor = true;
            // 
            // btnAddToList
            // 
            btnAddToList.Location = new Point(540, 28);
            btnAddToList.Name = "btnAddToList";
            btnAddToList.Size = new Size(133, 42);
            btnAddToList.TabIndex = 1;
            btnAddToList.Text = "➕ Thêm vào DS";
            btnAddToList.UseVisualStyleBackColor = true;
            // 
            // lstStudents
            // 
            lstStudents.FormattingEnabled = true;
            lstStudents.ItemHeight = 23;
            lstStudents.Location = new Point(15, 28);
            lstStudents.Name = "lstStudents";
            lstStudents.Size = new Size(510, 142);
            lstStudents.TabIndex = 0;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(470, 618);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(130, 44);
            btnReset.TabIndex = 5;
            btnReset.Text = "🔄 Làm mới";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += this.btnReset_Click;
            // 
            // btnSavePng
            // 
            btnSavePng.Location = new Point(610, 618);
            btnSavePng.Name = "btnSavePng";
            btnSavePng.Size = new Size(130, 44);
            btnSavePng.TabIndex = 6;
            btnSavePng.Text = "💾 Lưu PNG";
            btnSavePng.UseVisualStyleBackColor = true;
            btnSavePng.Click += this.btnSavePng_Click;
            // 
            // btnPrintPreview
            // 
            btnPrintPreview.Location = new Point(750, 618);
            btnPrintPreview.Name = "btnPrintPreview";
            btnPrintPreview.Size = new Size(130, 44);
            btnPrintPreview.TabIndex = 7;
            btnPrintPreview.Text = "🔍 Xem trước in";
            btnPrintPreview.UseVisualStyleBackColor = true;
            btnPrintPreview.Click += btnPrintPreview_Click;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(890, 618);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(130, 44);
            btnPrint.TabIndex = 8;
            btnPrint.Text = "🖨 In thẻ";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(1030, 618);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(130, 44);
            btnExit.TabIndex = 9;
            btnExit.Text = "🚪 Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += this.btnExit_Click;
            // 
            // ofdAvatar
            // 
            ofdAvatar.FileName = "openFileDialog1";
            ofdAvatar.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            ofdAvatar.Title = "Chọn ảnh đại diện";
            // 
            // sfdPng
            // 
            sfdPng.DefaultExt = "png";
            sfdPng.Filter = "PNG Image (*.png)|*.png";
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
            // printDialog
            // 
            printDialog.Document = pdCard;
            printDialog.UseEXDialog = true;
            // 
            // errProvider
            // 
            errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errProvider.ContainerControl = this;
            // 
            // FrmStudentCard
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 728);
            Controls.Add(btnExit);
            Controls.Add(btnPrint);
            Controls.Add(btnSavePng);
            Controls.Add(btnReset);
            Controls.Add(btnPrintPreview);
            Controls.Add(grpList);
            Controls.Add(grpPreview);
            Controls.Add(grpOptions);
            Controls.Add(grpPhoto);
            Controls.Add(grpInfo);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmStudentCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thiết kế và in thẻ sinh viên";
            Load += this.FrmStudentCard_Load;
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpPhoto.ResumeLayout(false);
            grpPhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            grpOptions.ResumeLayout(false);
            grpOptions.PerformLayout();
            grpPreview.ResumeLayout(false);
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInfo;
        private Label lblClass;
        private TextBox txtFullName;
        private Label lblFullName;
        private TextBox txtStudentId;
        private Label lblStudentId;
        private ComboBox cboGender;
        private Label lblGender;
        private DateTimePicker dtpBirthDate;
        private Label lblBirthDate;
        private ComboBox cboCourse;
        private Label lblCourse;
        private ComboBox cboFaculty;
        private Label lblFaculty;
        private ComboBox cboClass;
        private GroupBox grpPhoto;
        private PictureBox picAvatar;
        private Label lblImageHint;
        private Button btnRemoveImage;
        private Button btnChooseImage;
        private GroupBox grpOptions;
        private Panel pnlColorSample;
        private Button btnCardColor;
        private CheckBox chkShowQR;
        private GroupBox grpPreview;
        private Panel pnlCard;
        private GroupBox grpList;
        private Button btnRemoveFromList;
        private Button btnAddToList;
        private ListBox lstStudents;
        private Button btnReset;
        private Button btnSavePng;
        private Button btnPrintPreview;
        private Button btnPrint;
        private Button btnExit;
        private OpenFileDialog ofdAvatar;
        private SaveFileDialog sfdPng;
        private ColorDialog colorDialog;
        private System.Drawing.Printing.PrintDocument pdCard;
        private PrintPreviewDialog ppdCard;
        private PrintDialog printDialog;
        private ErrorProvider errProvider;
    }
}
