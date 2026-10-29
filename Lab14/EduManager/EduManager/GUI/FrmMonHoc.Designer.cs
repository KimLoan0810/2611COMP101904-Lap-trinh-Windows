namespace EduManager.GUI
{
    partial class FrmMonHoc
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
            lblCheDo = new Label();
            lblMaMonHoc = new Label();
            txtMaMonHoc = new TextBox();
            lblTenMonHoc = new Label();
            txtTenMonHoc = new TextBox();
            lblSoTinChi = new Label();
            nudSoTinChi = new NumericUpDown();
            chkTrangThai = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblGhiChu = new Label();
            pnlTimKiem = new Panel();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            lblDanhSach = new Label();
            pnlLuoi = new Panel();
            dgvMonHoc = new DataGridView();
            statusStrip = new StatusStrip();
            lblThongBao = new ToolStripStatusLabel();
            lblTongSo = new ToolStripStatusLabel();
            pnlHeader.SuspendLayout();
            pnlNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).BeginInit();
            pnlTimKiem.SuspendLayout();
            pnlLuoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(41, 128, 185);
            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Controls.Add(lblAppSub);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(960, 66);
            pnlHeader.TabIndex = 0;
            //
            // lblAppTitle
            //
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(16, 6);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Text = "QUẢN LÝ MÔN HỌC";
            //
            // lblAppSub
            //
            lblAppSub.AutoSize = true;
            lblAppSub.Font = new Font("Segoe UI", 9F);
            lblAppSub.ForeColor = Color.FromArgb(214, 234, 248);
            lblAppSub.Location = new Point(19, 40);
            lblAppSub.Name = "lblAppSub";
            lblAppSub.Text = "EduManager  ·  Entity Framework Core  ·  Mô hình ba lớp GUI - BLL - DAL";
            //
            // pnlNhap - thẻ trắng bên trái: nhập thông tin
            //
            pnlNhap.BackColor = Color.White;
            pnlNhap.Controls.Add(lblNhapTitle);
            pnlNhap.Controls.Add(lblCheDo);
            pnlNhap.Controls.Add(lblMaMonHoc);
            pnlNhap.Controls.Add(txtMaMonHoc);
            pnlNhap.Controls.Add(lblTenMonHoc);
            pnlNhap.Controls.Add(txtTenMonHoc);
            pnlNhap.Controls.Add(lblSoTinChi);
            pnlNhap.Controls.Add(nudSoTinChi);
            pnlNhap.Controls.Add(chkTrangThai);
            pnlNhap.Controls.Add(btnThem);
            pnlNhap.Controls.Add(btnSua);
            pnlNhap.Controls.Add(btnXoa);
            pnlNhap.Controls.Add(btnLamMoi);
            pnlNhap.Controls.Add(lblGhiChu);
            pnlNhap.Location = new Point(16, 80);
            pnlNhap.Name = "pnlNhap";
            pnlNhap.Size = new Size(330, 410);
            pnlNhap.TabIndex = 1;
            //
            // lblNhapTitle
            //
            lblNhapTitle.AutoSize = true;
            lblNhapTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNhapTitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblNhapTitle.Location = new Point(14, 10);
            lblNhapTitle.Name = "lblNhapTitle";
            lblNhapTitle.Text = "THÔNG TIN MÔN HỌC";
            //
            // lblCheDo
            //
            lblCheDo.AutoSize = true;
            lblCheDo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblCheDo.ForeColor = Color.FromArgb(127, 140, 141);
            lblCheDo.Location = new Point(14, 30);
            lblCheDo.Name = "lblCheDo";
            lblCheDo.Text = "Chế độ: thêm môn học mới";
            //
            // lblMaMonHoc
            //
            lblMaMonHoc.AutoSize = true;
            lblMaMonHoc.Location = new Point(14, 60);
            lblMaMonHoc.Name = "lblMaMonHoc";
            lblMaMonHoc.Text = "Mã môn học *";
            //
            // txtMaMonHoc
            //
            txtMaMonHoc.BorderStyle = BorderStyle.FixedSingle;
            txtMaMonHoc.CharacterCasing = CharacterCasing.Upper;
            txtMaMonHoc.Location = new Point(14, 82);
            txtMaMonHoc.MaxLength = 10;
            txtMaMonHoc.Name = "txtMaMonHoc";
            txtMaMonHoc.PlaceholderText = "VD: COMP1019";
            txtMaMonHoc.Size = new Size(300, 25);
            txtMaMonHoc.TabIndex = 0;
            //
            // lblTenMonHoc
            //
            lblTenMonHoc.AutoSize = true;
            lblTenMonHoc.Location = new Point(14, 120);
            lblTenMonHoc.Name = "lblTenMonHoc";
            lblTenMonHoc.Text = "Tên môn học *";
            //
            // txtTenMonHoc
            //
            txtTenMonHoc.BorderStyle = BorderStyle.FixedSingle;
            txtTenMonHoc.Location = new Point(14, 142);
            txtTenMonHoc.MaxLength = 100;
            txtTenMonHoc.Name = "txtTenMonHoc";
            txtTenMonHoc.PlaceholderText = "VD: Lập trình trên Windows";
            txtTenMonHoc.Size = new Size(300, 25);
            txtTenMonHoc.TabIndex = 1;
            //
            // lblSoTinChi
            //
            lblSoTinChi.AutoSize = true;
            lblSoTinChi.Location = new Point(14, 180);
            lblSoTinChi.Name = "lblSoTinChi";
            lblSoTinChi.Text = "Số tín chỉ (1 - 6)";
            //
            // nudSoTinChi
            //
            nudSoTinChi.Location = new Point(14, 202);
            nudSoTinChi.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            nudSoTinChi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoTinChi.Name = "nudSoTinChi";
            nudSoTinChi.Size = new Size(90, 25);
            nudSoTinChi.TabIndex = 2;
            nudSoTinChi.TextAlign = HorizontalAlignment.Center;
            nudSoTinChi.Value = new decimal(new int[] { 3, 0, 0, 0 });
            //
            // chkTrangThai
            //
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = CheckState.Checked;
            chkTrangThai.Location = new Point(130, 204);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.TabIndex = 3;
            chkTrangThai.Text = "Đang sử dụng";
            chkTrangThai.UseVisualStyleBackColor = true;
            //
            // btnThem
            //
            btnThem.BackColor = Color.FromArgb(39, 174, 96);
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 132, 73);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(14, 252);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(145, 42);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            //
            // btnSua
            //
            btnSua.BackColor = Color.FromArgb(41, 128, 185);
            btnSua.Cursor = Cursors.Hand;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatAppearance.MouseOverBackColor = Color.FromArgb(31, 97, 141);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(169, 252);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(145, 42);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            //
            // btnXoa
            //
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(14, 304);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(145, 42);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatAppearance.MouseOverBackColor = Color.FromArgb(127, 140, 141);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(169, 304);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(145, 42);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // lblGhiChu
            //
            lblGhiChu.Font = new Font("Segoe UI", 8.5F);
            lblGhiChu.ForeColor = Color.FromArgb(127, 140, 141);
            lblGhiChu.Location = new Point(14, 358);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(300, 40);
            lblGhiChu.Text = "* bắt buộc. Chọn một dòng trong danh sách để sửa hoặc xóa; bấm Làm mới để thêm môn mới.";
            //
            // pnlTimKiem
            //
            pnlTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTimKiem.BackColor = Color.White;
            pnlTimKiem.Controls.Add(txtTimKiem);
            pnlTimKiem.Controls.Add(btnTimKiem);
            pnlTimKiem.Location = new Point(362, 80);
            pnlTimKiem.Name = "pnlTimKiem";
            pnlTimKiem.Size = new Size(582, 60);
            pnlTimKiem.TabIndex = 2;
            //
            // txtTimKiem
            //
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Location = new Point(14, 18);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm theo mã hoặc tên môn học... (Enter để tìm)";
            txtTimKiem.Size = new Size(420, 25);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            //
            // btnTimKiem
            //
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.FromArgb(44, 62, 80);
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 73, 94);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(446, 13);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(122, 34);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            //
            // lblDanhSach
            //
            lblDanhSach.AutoSize = true;
            lblDanhSach.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDanhSach.ForeColor = Color.FromArgb(44, 62, 80);
            lblDanhSach.Location = new Point(360, 152);
            lblDanhSach.Name = "lblDanhSach";
            lblDanhSach.Text = "DANH SÁCH MÔN HỌC";
            //
            // pnlLuoi
            //
            pnlLuoi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlLuoi.BackColor = Color.White;
            pnlLuoi.Controls.Add(dgvMonHoc);
            pnlLuoi.Location = new Point(362, 180);
            pnlLuoi.Name = "pnlLuoi";
            pnlLuoi.Padding = new Padding(1);
            pnlLuoi.Size = new Size(582, 400);
            pnlLuoi.TabIndex = 3;
            //
            // dgvMonHoc
            //
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AllowUserToDeleteRows = false;
            dgvMonHoc.AllowUserToResizeRows = false;
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonHoc.BackgroundColor = Color.White;
            dgvMonHoc.Dock = DockStyle.Fill;
            dgvMonHoc.MultiSelect = false;
            dgvMonHoc.Name = "dgvMonHoc";
            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.RowHeadersVisible = false;
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonHoc.TabIndex = 0;
            dgvMonHoc.CellClick += dgvMonHoc_CellClick;
            dgvMonHoc.CellFormatting += dgvMonHoc_CellFormatting;
            //
            // statusStrip
            //
            statusStrip.BackColor = Color.White;
            statusStrip.Items.AddRange(new ToolStripItem[] { lblThongBao, lblTongSo });
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(10, 4, 10, 4);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 4;
            //
            // lblThongBao
            //
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Spring = true;
            lblThongBao.Text = "Sẵn sàng";
            lblThongBao.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblTongSo
            //
            lblTongSo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTongSo.ForeColor = Color.FromArgb(44, 62, 80);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Text = "";
            //
            // FrmMonHoc
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 247);
            ClientSize = new Size(960, 620);
            Controls.Add(pnlNhap);
            Controls.Add(pnlTimKiem);
            Controls.Add(lblDanhSach);
            Controls.Add(pnlLuoi);
            Controls.Add(statusStrip);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.75F);
            MinimumSize = new Size(976, 659);
            Name = "FrmMonHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EduManager - Quản lý môn học";
            Load += FrmMonHoc_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlNhap.ResumeLayout(false);
            pnlNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).EndInit();
            pnlTimKiem.ResumeLayout(false);
            pnlTimKiem.PerformLayout();
            pnlLuoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblAppTitle;
        private Label lblAppSub;
        private Panel pnlNhap;
        private Label lblNhapTitle;
        private Label lblCheDo;
        private Label lblMaMonHoc;
        private TextBox txtMaMonHoc;
        private Label lblTenMonHoc;
        private TextBox txtTenMonHoc;
        private Label lblSoTinChi;
        private NumericUpDown nudSoTinChi;
        private CheckBox chkTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblGhiChu;
        private Panel pnlTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Label lblDanhSach;
        private Panel pnlLuoi;
        private DataGridView dgvMonHoc;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblThongBao;
        private ToolStripStatusLabel lblTongSo;
    }
}