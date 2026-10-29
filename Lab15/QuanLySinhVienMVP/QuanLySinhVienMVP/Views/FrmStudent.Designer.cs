namespace QuanLySinhVienMVP.Views
{
    partial class FrmStudent
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblAppTitle = new Label();
            lblAppSub = new Label();
            pnlNhap = new Panel();
            lblNhapTitle = new Label();
            lblMaSV = new Label();
            txtMaSV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblLop = new Label();
            txtLop = new TextBox();
            lblDiem = new Label();
            txtDiem = new TextBox();
            btnThem = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblGhiChu = new Label();
            pnlCardTong = new Panel();
            lblCardTongTitle = new Label();
            lblTongSo = new Label();
            pnlCardDiem = new Panel();
            lblCardDiemTitle = new Label();
            lblDiemTB = new Label();
            pnlCardDat = new Panel();
            lblCardDatTitle = new Label();
            lblSoDat = new Label();
            pnlTimKiem = new Panel();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            lblDanhSach = new Label();
            pnlLuoi = new Panel();
            dgvSinhVien = new DataGridView();
            statusStrip = new StatusStrip();
            lblThongBao = new ToolStripStatusLabel();
            SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(22, 160, 133);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 66);
            Controls.Add(pnlHeader);
            // lblAppTitle
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(16, 6);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Text = "QUẢN LÝ SINH VIÊN - MÔ HÌNH MVP";
            pnlHeader.Controls.Add(lblAppTitle);
            // lblAppSub
            lblAppSub.AutoSize = true;
            lblAppSub.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblAppSub.ForeColor = Color.FromArgb(209, 242, 235);
            lblAppSub.Location = new Point(19, 40);
            lblAppSub.Name = "lblAppSub";
            lblAppSub.Text = "Model  ·  View (IStudentView)  ·  Presenter  ·  Repository (List<Student>)";
            pnlHeader.Controls.Add(lblAppSub);
            // pnlNhap
            pnlNhap.BackColor = Color.White;
            pnlNhap.Location = new Point(16, 80);
            pnlNhap.Name = "pnlNhap";
            pnlNhap.Size = new Size(320, 452);
            Controls.Add(pnlNhap);
            // lblNhapTitle
            lblNhapTitle.AutoSize = true;
            lblNhapTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNhapTitle.ForeColor = Color.FromArgb(22, 160, 133);
            lblNhapTitle.Location = new Point(14, 10);
            lblNhapTitle.Name = "lblNhapTitle";
            lblNhapTitle.Text = "THÔNG TIN SINH VIÊN";
            pnlNhap.Controls.Add(lblNhapTitle);
            // lblMaSV
            lblMaSV.AutoSize = true;
            lblMaSV.Location = new Point(14, 40);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Text = "Mã sinh viên *";
            pnlNhap.Controls.Add(lblMaSV);
            // txtMaSV
            txtMaSV.BorderStyle = BorderStyle.FixedSingle;
            txtMaSV.Location = new Point(14, 62);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(290, 25);
            txtMaSV.TabIndex = 0;
            txtMaSV.MaxLength = 10;
            txtMaSV.PlaceholderText = "VD: SV009";
            txtMaSV.CharacterCasing = CharacterCasing.Upper;
            pnlNhap.Controls.Add(txtMaSV);
            // lblHoTen
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(14, 98);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Text = "Họ tên *";
            pnlNhap.Controls.Add(lblHoTen);
            // txtHoTen
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Location = new Point(14, 120);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(290, 25);
            txtHoTen.TabIndex = 1;
            txtHoTen.MaxLength = 100;
            txtHoTen.PlaceholderText = "VD: Nguyễn Thị Mai";
            pnlNhap.Controls.Add(txtHoTen);
            // lblLop
            lblLop.AutoSize = true;
            lblLop.Location = new Point(14, 156);
            lblLop.Name = "lblLop";
            lblLop.Text = "Lớp *";
            pnlNhap.Controls.Add(lblLop);
            // txtLop
            txtLop.BorderStyle = BorderStyle.FixedSingle;
            txtLop.Location = new Point(14, 178);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(290, 25);
            txtLop.TabIndex = 2;
            txtLop.MaxLength = 20;
            txtLop.PlaceholderText = "VD: CTK47A";
            txtLop.CharacterCasing = CharacterCasing.Upper;
            pnlNhap.Controls.Add(txtLop);
            // lblDiem
            lblDiem.AutoSize = true;
            lblDiem.Location = new Point(14, 214);
            lblDiem.Name = "lblDiem";
            lblDiem.Text = "Điểm (0 - 10) *";
            pnlNhap.Controls.Add(lblDiem);
            // txtDiem
            txtDiem.BorderStyle = BorderStyle.FixedSingle;
            txtDiem.Location = new Point(14, 236);
            txtDiem.Name = "txtDiem";
            txtDiem.Size = new Size(290, 25);
            txtDiem.TabIndex = 3;
            txtDiem.MaxLength = 10;
            txtDiem.PlaceholderText = "VD: 7.5";
            pnlNhap.Controls.Add(txtDiem);
            // btnThem
            btnThem.BackColor = Color.FromArgb(39, 174, 96);
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 132, 73);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(14, 282);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(290, 42);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm sinh viên";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            pnlNhap.Controls.Add(btnThem);
            // btnXoa
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(14, 332);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(140, 42);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa theo mã";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            pnlNhap.Controls.Add(btnXoa);
            // btnLamMoi
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatAppearance.MouseOverBackColor = Color.FromArgb(127, 140, 141);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(164, 332);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(140, 42);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            pnlNhap.Controls.Add(btnLamMoi);
            // lblGhiChu
            lblGhiChu.Size = new Size(290, 56);
            lblGhiChu.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            lblGhiChu.ForeColor = Color.FromArgb(127, 140, 141);
            lblGhiChu.Location = new Point(14, 386);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Text = "* bắt buộc. Bấm một dòng trong danh sách để lấy mã rồi bấm Xóa, hoặc tự gõ mã cần xóa.";
            pnlNhap.Controls.Add(lblGhiChu);
            // pnlCardTong
            pnlCardTong.BackColor = Color.FromArgb(41, 128, 185);
            pnlCardTong.Location = new Point(352, 80);
            pnlCardTong.Name = "pnlCardTong";
            pnlCardTong.Size = new Size(200, 70);
            Controls.Add(pnlCardTong);
            // lblCardTongTitle
            lblCardTongTitle.AutoSize = true;
            lblCardTongTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCardTongTitle.ForeColor = Color.FromArgb(235, 245, 251);
            lblCardTongTitle.Location = new Point(12, 8);
            lblCardTongTitle.Name = "lblCardTongTitle";
            lblCardTongTitle.Text = "TỔNG SINH VIÊN";
            pnlCardTong.Controls.Add(lblCardTongTitle);
            // lblTongSo
            lblTongSo.AutoSize = true;
            lblTongSo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTongSo.ForeColor = Color.White;
            lblTongSo.Location = new Point(10, 26);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Text = "0";
            pnlCardTong.Controls.Add(lblTongSo);
            // pnlCardDiem
            pnlCardDiem.BackColor = Color.FromArgb(142, 68, 173);
            pnlCardDiem.Location = new Point(568, 80);
            pnlCardDiem.Name = "pnlCardDiem";
            pnlCardDiem.Size = new Size(200, 70);
            Controls.Add(pnlCardDiem);
            // lblCardDiemTitle
            lblCardDiemTitle.AutoSize = true;
            lblCardDiemTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCardDiemTitle.ForeColor = Color.FromArgb(235, 245, 251);
            lblCardDiemTitle.Location = new Point(12, 8);
            lblCardDiemTitle.Name = "lblCardDiemTitle";
            lblCardDiemTitle.Text = "ĐIỂM TRUNG BÌNH";
            pnlCardDiem.Controls.Add(lblCardDiemTitle);
            // lblDiemTB
            lblDiemTB.AutoSize = true;
            lblDiemTB.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDiemTB.ForeColor = Color.White;
            lblDiemTB.Location = new Point(10, 26);
            lblDiemTB.Name = "lblDiemTB";
            lblDiemTB.Text = "0";
            pnlCardDiem.Controls.Add(lblDiemTB);
            // pnlCardDat
            pnlCardDat.BackColor = Color.FromArgb(230, 126, 34);
            pnlCardDat.Location = new Point(784, 80);
            pnlCardDat.Name = "pnlCardDat";
            pnlCardDat.Size = new Size(200, 70);
            Controls.Add(pnlCardDat);
            // lblCardDatTitle
            lblCardDatTitle.AutoSize = true;
            lblCardDatTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCardDatTitle.ForeColor = Color.FromArgb(235, 245, 251);
            lblCardDatTitle.Location = new Point(12, 8);
            lblCardDatTitle.Name = "lblCardDatTitle";
            lblCardDatTitle.Text = "ĐẠT (ĐIỂM ≥ 5)";
            pnlCardDat.Controls.Add(lblCardDatTitle);
            // lblSoDat
            lblSoDat.AutoSize = true;
            lblSoDat.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblSoDat.ForeColor = Color.White;
            lblSoDat.Location = new Point(10, 26);
            lblSoDat.Name = "lblSoDat";
            lblSoDat.Text = "0";
            pnlCardDat.Controls.Add(lblSoDat);
            // pnlTimKiem
            pnlTimKiem.BackColor = Color.White;
            pnlTimKiem.Location = new Point(352, 162);
            pnlTimKiem.Name = "pnlTimKiem";
            pnlTimKiem.Size = new Size(632, 56);
            pnlTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Controls.Add(pnlTimKiem);
            // txtTimKiem
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Location = new Point(14, 15);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(470, 25);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.PlaceholderText = "Tìm theo mã hoặc họ tên... (Enter để tìm)";
            pnlTimKiem.Controls.Add(txtTimKiem);
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            // btnTimKiem
            btnTimKiem.BackColor = Color.FromArgb(44, 62, 80);
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 73, 94);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(496, 11);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(122, 34);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            pnlTimKiem.Controls.Add(btnTimKiem);
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // lblDanhSach
            lblDanhSach.AutoSize = true;
            lblDanhSach.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDanhSach.ForeColor = Color.FromArgb(44, 62, 80);
            lblDanhSach.Location = new Point(350, 230);
            lblDanhSach.Name = "lblDanhSach";
            lblDanhSach.Text = "DANH SÁCH SINH VIÊN";
            Controls.Add(lblDanhSach);
            // pnlLuoi
            pnlLuoi.BackColor = Color.White;
            pnlLuoi.Location = new Point(352, 256);
            pnlLuoi.Name = "pnlLuoi";
            pnlLuoi.Size = new Size(632, 326);
            pnlLuoi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Controls.Add(pnlLuoi);
            // dgvSinhVien
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AllowUserToResizeRows = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.BackgroundColor = Color.White;
            dgvSinhVien.Dock = DockStyle.Fill;
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            dgvSinhVien.CellFormatting += dgvSinhVien_CellFormatting;
            pnlLuoi.Controls.Add(dgvSinhVien);
            // statusStrip
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Spring = true;
            lblThongBao.Text = "Sẵn sàng";
            lblThongBao.TextAlign = ContentAlignment.MiddleLeft;
            lblThongBao.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            statusStrip.BackColor = Color.White;
            statusStrip.Items.AddRange(new ToolStripItem[] { lblThongBao });
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(10, 4, 10, 4);
            statusStrip.SizingGrip = false;
            Controls.Add(statusStrip);
            // FrmStudent
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 247);
            ClientSize = new Size(1000, 620);
            Font = new Font("Segoe UI", 9.75F);
            MinimumSize = new Size(1016, 659);
            Name = "FrmStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sinh viên - MVP";
            Load += FrmStudent_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblAppTitle;
        private Label lblAppSub;
        private Panel pnlNhap;
        private Label lblNhapTitle;
        private Label lblMaSV;
        private TextBox txtMaSV;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblLop;
        private TextBox txtLop;
        private Label lblDiem;
        private TextBox txtDiem;
        private Button btnThem;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblGhiChu;
        private Panel pnlCardTong;
        private Label lblCardTongTitle;
        private Label lblTongSo;
        private Panel pnlCardDiem;
        private Label lblCardDiemTitle;
        private Label lblDiemTB;
        private Panel pnlCardDat;
        private Label lblCardDatTitle;
        private Label lblSoDat;
        private Panel pnlTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Label lblDanhSach;
        private Panel pnlLuoi;
        private DataGridView dgvSinhVien;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblThongBao;
    }
}