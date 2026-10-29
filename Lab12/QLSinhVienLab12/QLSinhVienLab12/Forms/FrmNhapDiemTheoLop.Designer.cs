namespace QLSinhVienLab12.Forms
{
    partial class FrmNhapDiemTheoLop
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
            grpChon = new GroupBox();
            lblLop = new Label();
            cboLop = new ComboBox();
            lblMonHoc = new Label();
            cboMonHoc = new ComboBox();
            btnTaiDanhSach = new Button();
            lblLocTen = new Label();
            txtLocTen = new TextBox();
            chkBoQuaKiemTra = new CheckBox();
            btnLuuTatCa = new Button();
            dgvKetQua = new DataGridView();
            statusStrip = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            lblThongKe = new ToolStripStatusLabel();
            grpChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            //
            // grpChon
            //
            grpChon.Controls.Add(lblLop);
            grpChon.Controls.Add(cboLop);
            grpChon.Controls.Add(lblMonHoc);
            grpChon.Controls.Add(cboMonHoc);
            grpChon.Controls.Add(btnTaiDanhSach);
            grpChon.Location = new Point(12, 12);
            grpChon.Name = "grpChon";
            grpChon.Size = new Size(836, 75);
            grpChon.TabIndex = 0;
            grpChon.TabStop = false;
            grpChon.Text = "Chọn lớp và môn học";
            //
            // lblLop
            //
            lblLop.AutoSize = true;
            lblLop.Location = new Point(15, 34);
            lblLop.Name = "lblLop";
            lblLop.Text = "Lớp:";
            //
            // cboLop
            //
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Location = new Point(60, 31);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(230, 25);
            cboLop.TabIndex = 0;
            //
            // lblMonHoc
            //
            lblMonHoc.AutoSize = true;
            lblMonHoc.Location = new Point(310, 34);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Text = "Môn học:";
            //
            // cboMonHoc
            //
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.Location = new Point(385, 31);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(230, 25);
            cboMonHoc.TabIndex = 1;
            //
            // btnTaiDanhSach
            //
            btnTaiDanhSach.Location = new Point(635, 26);
            btnTaiDanhSach.Name = "btnTaiDanhSach";
            btnTaiDanhSach.Size = new Size(185, 34);
            btnTaiDanhSach.TabIndex = 2;
            btnTaiDanhSach.Text = "Tải danh sách";
            btnTaiDanhSach.UseVisualStyleBackColor = true;
            btnTaiDanhSach.Click += btnTaiDanhSach_Click;
            //
            // lblLocTen
            //
            lblLocTen.AutoSize = true;
            lblLocTen.Location = new Point(12, 106);
            lblLocTen.Name = "lblLocTen";
            lblLocTen.Text = "Lọc theo tên / mã:";
            //
            // txtLocTen
            //
            txtLocTen.Location = new Point(135, 103);
            txtLocTen.Name = "txtLocTen";
            txtLocTen.Size = new Size(240, 25);
            txtLocTen.TabIndex = 1;
            txtLocTen.TextChanged += txtLocTen_TextChanged;
            //
            // chkBoQuaKiemTra
            //
            chkBoQuaKiemTra.AutoSize = true;
            chkBoQuaKiemTra.ForeColor = Color.Firebrick;
            chkBoQuaKiemTra.Location = new Point(395, 105);
            chkBoQuaKiemTra.Name = "chkBoQuaKiemTra";
            chkBoQuaKiemTra.TabIndex = 2;
            chkBoQuaKiemTra.Text = "Bỏ qua kiểm tra (demo rollback)";
            chkBoQuaKiemTra.UseVisualStyleBackColor = true;
            //
            // btnLuuTatCa
            //
            btnLuuTatCa.BackColor = Color.SeaGreen;
            btnLuuTatCa.FlatStyle = FlatStyle.Flat;
            btnLuuTatCa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuuTatCa.ForeColor = Color.White;
            btnLuuTatCa.Location = new Point(688, 96);
            btnLuuTatCa.Name = "btnLuuTatCa";
            btnLuuTatCa.Size = new Size(160, 36);
            btnLuuTatCa.TabIndex = 3;
            btnLuuTatCa.Text = "Lưu tất cả";
            btnLuuTatCa.UseVisualStyleBackColor = false;
            btnLuuTatCa.Click += btnLuuTatCa_Click;
            //
            // dgvKetQua
            //
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQua.BackgroundColor = SystemColors.Window;
            dgvKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKetQua.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvKetQua.Location = new Point(12, 142);
            dgvKetQua.MultiSelect = false;
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.RowHeadersWidth = 30;
            dgvKetQua.Size = new Size(836, 390);
            dgvKetQua.TabIndex = 4;
            dgvKetQua.CellFormatting += dgvKetQua_CellFormatting;
            dgvKetQua.DataError += dgvKetQua_DataError;
            //
            // statusStrip
            //
            statusStrip.Items.AddRange(new ToolStripItem[] { lblTrangThai, lblThongKe });
            statusStrip.Name = "statusStrip";
            statusStrip.TabIndex = 5;
            //
            // lblTrangThai
            //
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Spring = true;
            lblTrangThai.Text = "Sẵn sàng";
            lblTrangThai.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblThongKe
            //
            lblThongKe.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Text = "";
            //
            // FrmNhapDiemTheoLop
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 570);
            Controls.Add(grpChon);
            Controls.Add(lblLocTen);
            Controls.Add(txtLocTen);
            Controls.Add(chkBoQuaKiemTra);
            Controls.Add(btnLuuTatCa);
            Controls.Add(dgvKetQua);
            Controls.Add(statusStrip);
            Font = new Font("Segoe UI", 9.75F);
            MinimumSize = new Size(876, 609);
            Name = "FrmNhapDiemTheoLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhập điểm theo lớp - QLSinhVienLab12";
            Load += FrmNhapDiemTheoLop_Load;
            grpChon.ResumeLayout(false);
            grpChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpChon;
        private Label lblLop;
        private ComboBox cboLop;
        private Label lblMonHoc;
        private ComboBox cboMonHoc;
        private Button btnTaiDanhSach;
        private Label lblLocTen;
        private TextBox txtLocTen;
        private CheckBox chkBoQuaKiemTra;
        private Button btnLuuTatCa;
        private DataGridView dgvKetQua;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel lblThongKe;
    }
}