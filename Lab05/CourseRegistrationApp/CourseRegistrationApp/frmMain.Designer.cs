namespace CourseRegistrationApp
{
    partial class frmMain
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
            grpHocVien = new GroupBox();
            dtpNgaySinh = new DateTimePicker();
            txtSoDienThoai = new TextBox();
            txtHoTen = new TextBox();
            chkNhanEmail = new CheckBox();
            lblNgaySinh = new Label();
            lblSoDienThoai = new Label();
            lblHoTen = new Label();
            grpKhoaHoc = new GroupBox();
            numSoThang = new NumericUpDown();
            radOffline = new RadioButton();
            radOnline = new RadioButton();
            cboKhoaHoc = new ComboBox();
            lblSoThang = new Label();
            lblTongTien = new Label();
            lblHinhThuc = new Label();
            lblTongTienTieuDe = new Label();
            lblKhoaHoc = new Label();
            btnDangKy = new Button();
            btnLamMoi = new Button();
            btnThoat = new Button();
            grpHocVien.SuspendLayout();
            grpKhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
            SuspendLayout();
            // 
            // grpHocVien
            // 
            grpHocVien.Controls.Add(dtpNgaySinh);
            grpHocVien.Controls.Add(txtSoDienThoai);
            grpHocVien.Controls.Add(txtHoTen);
            grpHocVien.Controls.Add(chkNhanEmail);
            grpHocVien.Controls.Add(lblNgaySinh);
            grpHocVien.Controls.Add(lblSoDienThoai);
            grpHocVien.Controls.Add(lblHoTen);
            grpHocVien.Location = new Point(20, 15);
            grpHocVien.Name = "grpHocVien";
            grpHocVien.Size = new Size(470, 220);
            grpHocVien.TabIndex = 0;
            grpHocVien.TabStop = false;
            grpHocVien.Text = "THÔNG TIN HỌC VIÊN";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd MMMM yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(171, 129);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(250, 27);
            dtpNgaySinh.TabIndex = 2;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(171, 81);
            txtSoDienThoai.MaxLength = 11;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(250, 27);
            txtSoDienThoai.TabIndex = 1;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(171, 35);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(250, 27);
            txtHoTen.TabIndex = 0;
            // 
            // chkNhanEmail
            // 
            chkNhanEmail.AutoSize = true;
            chkNhanEmail.Font = new Font("Segoe UI", 10.2F);
            chkNhanEmail.Location = new Point(26, 178);
            chkNhanEmail.Name = "chkNhanEmail";
            chkNhanEmail.Size = new Size(205, 27);
            chkNhanEmail.TabIndex = 3;
            chkNhanEmail.Text = "Nhận email thông báo";
            chkNhanEmail.UseVisualStyleBackColor = true;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 10.2F);
            lblNgaySinh.Location = new Point(26, 133);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(90, 23);
            lblNgaySinh.TabIndex = 2;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI", 10.2F);
            lblSoDienThoai.Location = new Point(26, 85);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(115, 23);
            lblSoDienThoai.TabIndex = 1;
            lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10.2F);
            lblHoTen.Location = new Point(26, 39);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(66, 23);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên:";
            // 
            // grpKhoaHoc
            // 
            grpKhoaHoc.Controls.Add(numSoThang);
            grpKhoaHoc.Controls.Add(radOffline);
            grpKhoaHoc.Controls.Add(radOnline);
            grpKhoaHoc.Controls.Add(cboKhoaHoc);
            grpKhoaHoc.Controls.Add(lblSoThang);
            grpKhoaHoc.Controls.Add(lblTongTien);
            grpKhoaHoc.Controls.Add(lblHinhThuc);
            grpKhoaHoc.Controls.Add(lblTongTienTieuDe);
            grpKhoaHoc.Controls.Add(lblKhoaHoc);
            grpKhoaHoc.Location = new Point(20, 254);
            grpKhoaHoc.Name = "grpKhoaHoc";
            grpKhoaHoc.Size = new Size(470, 207);
            grpKhoaHoc.TabIndex = 1;
            grpKhoaHoc.TabStop = false;
            grpKhoaHoc.Text = "THÔNG TIN KHÓA HỌC";
            // 
            // numSoThang
            // 
            numSoThang.Location = new Point(171, 119);
            numSoThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numSoThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.Name = "numSoThang";
            numSoThang.Size = new Size(189, 27);
            numSoThang.TabIndex = 3;
            numSoThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.ValueChanged += numSoThang_ValueChanged;
            // 
            // radOffline
            // 
            radOffline.AutoSize = true;
            radOffline.Location = new Point(272, 79);
            radOffline.Name = "radOffline";
            radOffline.Size = new Size(88, 24);
            radOffline.TabIndex = 2;
            radOffline.Text = "Trực tiếp";
            radOffline.UseVisualStyleBackColor = true;
            // 
            // radOnline
            // 
            radOnline.AutoSize = true;
            radOnline.Checked = true;
            radOnline.Location = new Point(171, 79);
            radOnline.Name = "radOnline";
            radOnline.Size = new Size(73, 24);
            radOnline.TabIndex = 1;
            radOnline.TabStop = true;
            radOnline.Text = "Online";
            radOnline.UseVisualStyleBackColor = true;
            // 
            // cboKhoaHoc
            // 
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(171, 26);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(189, 28);
            cboKhoaHoc.TabIndex = 0;
            cboKhoaHoc.SelectedIndexChanged += cboKhoaHoc_SelectedIndexChanged;
            // 
            // lblSoThang
            // 
            lblSoThang.AutoSize = true;
            lblSoThang.Font = new Font("Segoe UI", 10.2F);
            lblSoThang.Location = new Point(26, 123);
            lblSoThang.Name = "lblSoThang";
            lblSoThang.Size = new Size(148, 23);
            lblSoThang.TabIndex = 5;
            lblSoThang.Text = "Số tháng đăng ký:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblTongTien.Location = new Point(171, 164);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(109, 23);
            lblTongTien.TabIndex = 4;
            lblTongTien.Text = "800.000 VND";
            // 
            // lblHinhThuc
            // 
            lblHinhThuc.AutoSize = true;
            lblHinhThuc.Font = new Font("Segoe UI", 10.2F);
            lblHinhThuc.Location = new Point(26, 80);
            lblHinhThuc.Name = "lblHinhThuc";
            lblHinhThuc.Size = new Size(122, 23);
            lblHinhThuc.TabIndex = 3;
            lblHinhThuc.Text = "Hình thức học:";
            // 
            // lblTongTienTieuDe
            // 
            lblTongTienTieuDe.AutoSize = true;
            lblTongTienTieuDe.Font = new Font("Segoe UI", 10.2F);
            lblTongTienTieuDe.Location = new Point(26, 164);
            lblTongTienTieuDe.Name = "lblTongTienTieuDe";
            lblTongTienTieuDe.Size = new Size(115, 23);
            lblTongTienTieuDe.TabIndex = 2;
            lblTongTienTieuDe.Text = "Tổng học phí:";
            // 
            // lblKhoaHoc
            // 
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Font = new Font("Segoe UI", 10.2F);
            lblKhoaHoc.Location = new Point(26, 32);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(86, 23);
            lblKhoaHoc.TabIndex = 1;
            lblKhoaHoc.Text = "Khóa học:";
            // 
            // btnDangKy
            // 
            btnDangKy.Font = new Font("Segoe UI", 10.2F);
            btnDangKy.Location = new Point(119, 480);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(94, 29);
            btnDangKy.TabIndex = 0;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI", 10.2F);
            btnLamMoi.Location = new Point(248, 480);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 10.2F);
            btnThoat.Location = new Point(381, 480);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 2;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 532);
            Controls.Add(btnThoat);
            Controls.Add(btnLamMoi);
            Controls.Add(btnDangKy);
            Controls.Add(grpKhoaHoc);
            Controls.Add(grpHocVien);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ĐĂNG KÝ KHÓA HỌC";
            Load += frmMain_Load;
            grpHocVien.ResumeLayout(false);
            grpHocVien.PerformLayout();
            grpKhoaHoc.ResumeLayout(false);
            grpKhoaHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpHocVien;
        private GroupBox grpKhoaHoc;
        private Label lblNgaySinh;
        private Label lblSoDienThoai;
        private Label lblHoTen;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtSoDienThoai;
        private TextBox txtHoTen;
        private CheckBox chkNhanEmail;
        private Label lblHinhThuc;
        private Label lblTongTienTieuDe;
        private Label lblKhoaHoc;
        private Label lblSoThang;
        private Label lblTongTien;
        private RadioButton radOffline;
        private RadioButton radOnline;
        private ComboBox cboKhoaHoc;
        private NumericUpDown numSoThang;
        private Button btnDangKy;
        private Button btnLamMoi;
        private Button btnThoat;
    }
}
