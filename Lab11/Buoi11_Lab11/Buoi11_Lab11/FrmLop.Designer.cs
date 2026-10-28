namespace Buoi11_Lab11
{
    partial class FrmLop
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
            grpThongTin = new GroupBox();
            lblMaLop = new Label();
            txtMaLop = new TextBox();
            lblTenLop = new Label();
            txtTenLop = new TextBox();
            lblKhoa = new Label();
            cboKhoa = new ComboBox();
            grpTimKiem = new GroupBox();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvLop = new DataGridView();
            grpThongTin.SuspendLayout();
            grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblMaLop);
            grpThongTin.Controls.Add(txtMaLop);
            grpThongTin.Controls.Add(lblTenLop);
            grpThongTin.Controls.Add(txtTenLop);
            grpThongTin.Controls.Add(lblKhoa);
            grpThongTin.Controls.Add(cboKhoa);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(390, 160);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin lớp";
            // 
            // lblMaLop
            // 
            lblMaLop.AutoSize = true;
            lblMaLop.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblMaLop.Location = new Point(15, 35);
            lblMaLop.Name = "lblMaLop";
            lblMaLop.Size = new Size(68, 23);
            lblMaLop.TabIndex = 0;
            lblMaLop.Text = "Mã lớp:";
            // 
            // txtMaLop
            // 
            txtMaLop.Location = new Point(110, 32);
            txtMaLop.MaxLength = 20;
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(260, 29);
            txtMaLop.TabIndex = 0;
            // 
            // lblTenLop
            // 
            lblTenLop.AutoSize = true;
            lblTenLop.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblTenLop.Location = new Point(15, 75);
            lblTenLop.Name = "lblTenLop";
            lblTenLop.Size = new Size(69, 23);
            lblTenLop.TabIndex = 1;
            lblTenLop.Text = "Tên lớp:";
            // 
            // txtTenLop
            // 
            txtTenLop.Location = new Point(110, 72);
            txtTenLop.MaxLength = 100;
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(260, 29);
            txtTenLop.TabIndex = 1;
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblKhoa.Location = new Point(15, 115);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(53, 23);
            lblKhoa.TabIndex = 2;
            lblKhoa.Text = "Khoa:";
            // 
            // cboKhoa
            // 
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.Location = new Point(110, 112);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(260, 29);
            cboKhoa.TabIndex = 2;
            // 
            // grpTimKiem
            // 
            grpTimKiem.Controls.Add(txtTimKiem);
            grpTimKiem.Controls.Add(btnTimKiem);
            grpTimKiem.Location = new Point(415, 12);
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.Size = new Size(395, 80);
            grpTimKiem.TabIndex = 1;
            grpTimKiem.TabStop = false;
            grpTimKiem.Text = "Tìm kiếm (mã hoặc tên lớp)";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtTimKiem.Location = new Point(15, 34);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(255, 30);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnTimKiem.Location = new Point(280, 31);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(100, 31);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnThem.Location = new Point(415, 120);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(92, 40);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnSua.Location = new Point(516, 120);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(92, 40);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnXoa.Location = new Point(617, 120);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(92, 40);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnLamMoi.Location = new Point(718, 120);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(92, 40);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvLop
            // 
            dgvLop.AllowUserToAddRows = false;
            dgvLop.AllowUserToDeleteRows = false;
            dgvLop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLop.BackgroundColor = SystemColors.Window;
            dgvLop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLop.Location = new Point(12, 185);
            dgvLop.MultiSelect = false;
            dgvLop.Name = "dgvLop";
            dgvLop.ReadOnly = true;
            dgvLop.RowHeadersVisible = false;
            dgvLop.RowHeadersWidth = 51;
            dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLop.Size = new Size(798, 320);
            dgvLop.TabIndex = 6;
            dgvLop.CellClick += dgvLop_CellClick;
            // 
            // FrmLop
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 517);
            Controls.Add(grpThongTin);
            Controls.Add(grpTimKiem);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(dgvLop);
            Font = new Font("Segoe UI", 9.75F);
            MinimumSize = new Size(840, 556);
            Name = "FrmLop";
            StartPosition = FormStartPosition.CenterScreen;
            Load += FrmLop_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpTimKiem.ResumeLayout(false);
            grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaLop;
        private TextBox txtMaLop;
        private Label lblTenLop;
        private TextBox txtTenLop;
        private Label lblKhoa;
        private ComboBox cboKhoa;
        private GroupBox grpTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvLop;
    }
}