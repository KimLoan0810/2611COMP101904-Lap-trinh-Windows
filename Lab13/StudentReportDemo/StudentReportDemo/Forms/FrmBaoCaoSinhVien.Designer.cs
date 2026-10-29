namespace StudentReportDemo.Forms
{
    partial class FrmBaoCaoSinhVien
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
            pnlDieuKien = new Panel();
            lblDieuKien = new Label();
            lblLop = new Label();
            cboLop = new ComboBox();
            lblKetQua = new Label();
            cboKetQua = new ComboBox();
            lblTuKhoa = new Label();
            txtTuKhoa = new TextBox();
            btnXemBaoCao = new Button();
            btnThongKe = new Button();
            btnXuatFile = new Button();
            lblTieuDe = new Label();
            pnlLuoi = new Panel();
            dgvBaoCao = new DataGridView();
            statusStrip = new StatusStrip();
            lblThongKe = new ToolStripStatusLabel();
            pnlHeader.SuspendLayout();
            pnlDieuKien.SuspendLayout();
            pnlLuoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader - dải tiêu đề xanh trên cùng
            //
            pnlHeader.BackColor = Color.FromArgb(41, 128, 185);
            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Controls.Add(lblAppSub);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(900, 66);
            pnlHeader.TabIndex = 0;
            //
            // lblAppTitle
            //
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(16, 6);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Text = "BÁO CÁO SINH VIÊN THEO LỚP";
            //
            // lblAppSub
            //
            lblAppSub.AutoSize = true;
            lblAppSub.Font = new Font("Segoe UI", 9F);
            lblAppSub.ForeColor = Color.FromArgb(214, 234, 248);
            lblAppSub.Location = new Point(19, 40);
            lblAppSub.Name = "lblAppSub";
            lblAppSub.Text = "COMP1019 - Lab 13  ·  Lọc, sắp xếp và thống kê bằng LINQ";
            //
            // pnlDieuKien - khung trắng chứa điều kiện lọc
            //
            pnlDieuKien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlDieuKien.BackColor = Color.White;
            pnlDieuKien.Controls.Add(lblDieuKien);
            pnlDieuKien.Controls.Add(lblLop);
            pnlDieuKien.Controls.Add(cboLop);
            pnlDieuKien.Controls.Add(lblKetQua);
            pnlDieuKien.Controls.Add(cboKetQua);
            pnlDieuKien.Controls.Add(lblTuKhoa);
            pnlDieuKien.Controls.Add(txtTuKhoa);
            pnlDieuKien.Location = new Point(16, 80);
            pnlDieuKien.Name = "pnlDieuKien";
            pnlDieuKien.Size = new Size(868, 78);
            pnlDieuKien.TabIndex = 1;
            //
            // lblDieuKien
            //
            lblDieuKien.AutoSize = true;
            lblDieuKien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDieuKien.ForeColor = Color.FromArgb(127, 140, 141);
            lblDieuKien.Location = new Point(14, 8);
            lblDieuKien.Name = "lblDieuKien";
            lblDieuKien.Text = "ĐIỀU KIỆN BÁO CÁO";
            //
            // lblLop
            //
            lblLop.AutoSize = true;
            lblLop.Location = new Point(14, 41);
            lblLop.Name = "lblLop";
            lblLop.Text = "Lớp:";
            //
            // cboLop
            //
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FlatStyle = FlatStyle.Flat;
            cboLop.Location = new Point(55, 37);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(200, 25);
            cboLop.TabIndex = 0;
            cboLop.SelectionChangeCommitted += cboLop_SelectionChangeCommitted;
            //
            // lblKetQua
            //
            lblKetQua.AutoSize = true;
            lblKetQua.Location = new Point(275, 41);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Text = "Kết quả:";
            //
            // cboKetQua
            //
            cboKetQua.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKetQua.FlatStyle = FlatStyle.Flat;
            cboKetQua.Location = new Point(345, 37);
            cboKetQua.Name = "cboKetQua";
            cboKetQua.Size = new Size(130, 25);
            cboKetQua.TabIndex = 1;
            cboKetQua.SelectionChangeCommitted += cboKetQua_SelectionChangeCommitted;
            //
            // lblTuKhoa
            //
            lblTuKhoa.AutoSize = true;
            lblTuKhoa.Location = new Point(495, 41);
            lblTuKhoa.Name = "lblTuKhoa";
            lblTuKhoa.Text = "Từ khóa:";
            //
            // txtTuKhoa
            //
            txtTuKhoa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTuKhoa.BorderStyle = BorderStyle.FixedSingle;
            txtTuKhoa.Location = new Point(565, 37);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Nhập mã SV hoặc họ tên...";
            txtTuKhoa.Size = new Size(285, 25);
            txtTuKhoa.TabIndex = 2;
            txtTuKhoa.TextChanged += txtTuKhoa_TextChanged;
            //
            // btnXemBaoCao
            //
            btnXemBaoCao.BackColor = Color.FromArgb(41, 128, 185);
            btnXemBaoCao.Cursor = Cursors.Hand;
            btnXemBaoCao.FlatAppearance.BorderSize = 0;
            btnXemBaoCao.FlatAppearance.MouseOverBackColor = Color.FromArgb(31, 97, 141);
            btnXemBaoCao.FlatStyle = FlatStyle.Flat;
            btnXemBaoCao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXemBaoCao.ForeColor = Color.White;
            btnXemBaoCao.Location = new Point(16, 172);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(150, 40);
            btnXemBaoCao.TabIndex = 2;
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.UseVisualStyleBackColor = false;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            //
            // btnThongKe
            //
            btnThongKe.BackColor = Color.FromArgb(230, 126, 34);
            btnThongKe.Cursor = Cursors.Hand;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.MouseOverBackColor = Color.FromArgb(202, 111, 30);
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThongKe.ForeColor = Color.White;
            btnThongKe.Location = new Point(176, 172);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(170, 40);
            btnThongKe.TabIndex = 3;
            btnThongKe.Text = "Thống kê theo lớp";
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            //
            // btnXuatFile
            //
            btnXuatFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatFile.BackColor = Color.FromArgb(39, 174, 96);
            btnXuatFile.Cursor = Cursors.Hand;
            btnXuatFile.FlatAppearance.BorderSize = 0;
            btnXuatFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 132, 73);
            btnXuatFile.FlatStyle = FlatStyle.Flat;
            btnXuatFile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXuatFile.ForeColor = Color.White;
            btnXuatFile.Location = new Point(734, 172);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(150, 40);
            btnXuatFile.TabIndex = 4;
            btnXuatFile.Text = "Xuất file CSV / TXT";
            btnXuatFile.UseVisualStyleBackColor = false;
            btnXuatFile.Click += btnXuatFile_Click;
            //
            // lblTieuDe - tiêu đề bảng đang xem
            //
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(44, 62, 80);
            lblTieuDe.Location = new Point(14, 224);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "BÁO CÁO SINH VIÊN";
            //
            // pnlLuoi - viền trắng bao quanh lưới
            //
            pnlLuoi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlLuoi.BackColor = Color.White;
            pnlLuoi.Controls.Add(dgvBaoCao);
            pnlLuoi.Location = new Point(16, 252);
            pnlLuoi.Name = "pnlLuoi";
            pnlLuoi.Padding = new Padding(1);
            pnlLuoi.Size = new Size(868, 342);
            pnlLuoi.TabIndex = 5;
            //
            // dgvBaoCao
            //
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.AllowUserToResizeRows = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.BackgroundColor = Color.White;
            dgvBaoCao.Dock = DockStyle.Fill;
            dgvBaoCao.MultiSelect = false;
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.TabIndex = 0;
            dgvBaoCao.CellFormatting += dgvBaoCao_CellFormatting;
            //
            // statusStrip
            //
            statusStrip.BackColor = Color.White;
            statusStrip.Items.AddRange(new ToolStripItem[] { lblThongKe });
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(10, 4, 10, 4);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 6;
            //
            // lblThongKe
            //
            lblThongKe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Spring = true;
            lblThongKe.Text = "Sẵn sàng";
            lblThongKe.TextAlign = ContentAlignment.MiddleLeft;
            //
            // FrmBaoCaoSinhVien
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 247);
            ClientSize = new Size(900, 640);
            Controls.Add(pnlDieuKien);
            Controls.Add(btnXemBaoCao);
            Controls.Add(btnThongKe);
            Controls.Add(btnXuatFile);
            Controls.Add(lblTieuDe);
            Controls.Add(pnlLuoi);
            Controls.Add(statusStrip);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.75F);
            MinimumSize = new Size(916, 679);
            Name = "FrmBaoCaoSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo sinh viên bằng LINQ - StudentReportDemo";
            Load += FrmBaoCaoSinhVien_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlDieuKien.ResumeLayout(false);
            pnlDieuKien.PerformLayout();
            pnlLuoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblAppTitle;
        private Label lblAppSub;
        private Panel pnlDieuKien;
        private Label lblDieuKien;
        private Label lblLop;
        private ComboBox cboLop;
        private Label lblKetQua;
        private ComboBox cboKetQua;
        private Label lblTuKhoa;
        private TextBox txtTuKhoa;
        private Button btnXemBaoCao;
        private Button btnThongKe;
        private Button btnXuatFile;
        private Label lblTieuDe;
        private Panel pnlLuoi;
        private DataGridView dgvBaoCao;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblThongKe;
    }
}