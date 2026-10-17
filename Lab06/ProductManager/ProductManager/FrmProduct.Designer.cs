namespace ProductManager
{
    partial class FrmProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduct));
            menuMain = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            menuFileLamMoi = new ToolStripMenuItem();
            menuFileThoat = new ToolStripMenuItem();
            menuQuanLy = new ToolStripMenuItem();
            menuThem = new ToolStripMenuItem();
            menuSua = new ToolStripMenuItem();
            menuXoa = new ToolStripMenuItem();
            menuTimKiem = new ToolStripMenuItem();
            menuTroGiup = new ToolStripMenuItem();
            menuGioiThieu = new ToolStripMenuItem();
            toolMain = new ToolStrip();
            btnThem = new ToolStripButton();
            btnSua = new ToolStripButton();
            btnXoa = new ToolStripButton();
            btnLamMoi = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnTimKiem = new ToolStripButton();
            statusMain = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblCount = new ToolStripStatusLabel();
            grpThongTin = new GroupBox();
            btnChonAnh = new Button();
            picProduct = new PictureBox();
            chkConKinhDoanh = new CheckBox();
            dtpNgayNhap = new DateTimePicker();
            numSoLuong = new NumericUpDown();
            numDonGia = new NumericUpDown();
            cboLoaiSP = new ComboBox();
            txtTenSP = new TextBox();
            txtMaSP = new TextBox();
            lblNgayNhap = new Label();
            lblSoLuong = new Label();
            lblDonGia = new Label();
            lblLoaiSP = new Label();
            lblTenSP = new Label();
            lblMaSP = new Label();
            openFileDialog1 = new OpenFileDialog();
            errorProvider1 = new ErrorProvider(components);
            dgvProducts = new DataGridView();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colLoaiSP = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colNgayNhap = new DataGridViewTextBoxColumn();
            colConKinhDoanh = new DataGridViewCheckBoxColumn();
            colDuongDanAnh = new DataGridViewTextBoxColumn();
            menuMain.SuspendLayout();
            toolMain.SuspendLayout();
            statusMain.SuspendLayout();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.BackColor = Color.SteelBlue;
            menuMain.ImageScalingSize = new Size(20, 20);
            menuMain.Items.AddRange(new ToolStripItem[] { menuFile, menuQuanLy, menuTroGiup });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(1413, 28);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuFileLamMoi, menuFileThoat });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(46, 24);
            menuFile.Text = "File";
            // 
            // menuFileLamMoi
            // 
            menuFileLamMoi.Name = "menuFileLamMoi";
            menuFileLamMoi.Size = new Size(150, 26);
            menuFileLamMoi.Text = "Làm mới";
            // 
            // menuFileThoat
            // 
            menuFileThoat.Name = "menuFileThoat";
            menuFileThoat.Size = new Size(150, 26);
            menuFileThoat.Text = "Thoát";
            // 
            // menuQuanLy
            // 
            menuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { menuThem, menuSua, menuXoa, menuTimKiem });
            menuQuanLy.Name = "menuQuanLy";
            menuQuanLy.Size = new Size(73, 24);
            menuQuanLy.Text = "Quản lý";
            // 
            // menuThem
            // 
            menuThem.Name = "menuThem";
            menuThem.Size = new Size(197, 26);
            menuThem.Text = "Thêm sản phẩm";
            // 
            // menuSua
            // 
            menuSua.Name = "menuSua";
            menuSua.Size = new Size(197, 26);
            menuSua.Text = "Sửa sản phẩm";
            // 
            // menuXoa
            // 
            menuXoa.Name = "menuXoa";
            menuXoa.Size = new Size(197, 26);
            menuXoa.Text = "Xóa sản phẩm";
            // 
            // menuTimKiem
            // 
            menuTimKiem.Name = "menuTimKiem";
            menuTimKiem.Size = new Size(197, 26);
            menuTimKiem.Text = "Tìm kiếm";
            // 
            // menuTroGiup
            // 
            menuTroGiup.DropDownItems.AddRange(new ToolStripItem[] { menuGioiThieu });
            menuTroGiup.Name = "menuTroGiup";
            menuTroGiup.Size = new Size(78, 24);
            menuTroGiup.Text = "Trợ giúp";
            // 
            // menuGioiThieu
            // 
            menuGioiThieu.Name = "menuGioiThieu";
            menuGioiThieu.Size = new Size(147, 26);
            menuGioiThieu.Text = "Trợ giúp";
            // 
            // toolMain
            // 
            toolMain.ImageScalingSize = new Size(20, 20);
            toolMain.Items.AddRange(new ToolStripItem[] { btnThem, btnSua, btnXoa, btnLamMoi, toolStripSeparator1, btnTimKiem });
            toolMain.Location = new Point(0, 28);
            toolMain.Name = "toolMain";
            toolMain.Size = new Size(1413, 27);
            toolMain.TabIndex = 1;
            toolMain.Text = "toolStrip1";
            // 
            // btnThem
            // 
            btnThem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageTransparentColor = Color.Magenta;
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(50, 24);
            btnThem.Text = "Thêm";
            // 
            // btnSua
            // 
            btnSua.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageTransparentColor = Color.Magenta;
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(38, 24);
            btnSua.Text = "Sửa";
            // 
            // btnXoa
            // 
            btnXoa.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageTransparentColor = Color.Magenta;
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(39, 24);
            btnXoa.Text = "Xóa";
            // 
            // btnLamMoi
            // 
            btnLamMoi.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnLamMoi.Image = (Image)resources.GetObject("btnLamMoi.Image");
            btnLamMoi.ImageTransparentColor = Color.Magenta;
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(71, 24);
            btnLamMoi.Text = "Làm mới";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // btnTimKiem
            // 
            btnTimKiem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTimKiem.Image = (Image)resources.GetObject("btnTimKiem.Image");
            btnTimKiem.ImageTransparentColor = Color.Magenta;
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(74, 24);
            btnTimKiem.Text = "Tìm kiếm";
            // 
            // statusMain
            // 
            statusMain.ImageScalingSize = new Size(20, 20);
            statusMain.Items.AddRange(new ToolStripItem[] { lblStatus, lblCount });
            statusMain.Location = new Point(0, 610);
            statusMain.Name = "statusMain";
            statusMain.Size = new Size(1413, 26);
            statusMain.TabIndex = 2;
            statusMain.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1253, 20);
            lblStatus.Spring = true;
            lblStatus.Text = "Sẵn sàng";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCount
            // 
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(145, 20);
            lblCount.Text = "Tổng số sản phẩm: 0";
            lblCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grpThongTin
            // 
            grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTin.BackColor = Color.White;
            grpThongTin.Controls.Add(btnChonAnh);
            grpThongTin.Controls.Add(picProduct);
            grpThongTin.Controls.Add(chkConKinhDoanh);
            grpThongTin.Controls.Add(dtpNgayNhap);
            grpThongTin.Controls.Add(numSoLuong);
            grpThongTin.Controls.Add(numDonGia);
            grpThongTin.Controls.Add(cboLoaiSP);
            grpThongTin.Controls.Add(txtTenSP);
            grpThongTin.Controls.Add(txtMaSP);
            grpThongTin.Controls.Add(lblNgayNhap);
            grpThongTin.Controls.Add(lblSoLuong);
            grpThongTin.Controls.Add(lblDonGia);
            grpThongTin.Controls.Add(lblLoaiSP);
            grpThongTin.Controls.Add(lblTenSP);
            grpThongTin.Controls.Add(lblMaSP);
            grpThongTin.Location = new Point(12, 70);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(1268, 200);
            grpThongTin.TabIndex = 3;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin sản phẩm";
            // 
            // btnChonAnh
            // 
            btnChonAnh.BackColor = Color.SteelBlue;
            btnChonAnh.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(725, 160);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(100, 35);
            btnChonAnh.TabIndex = 13;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = false;
            // 
            // picProduct
            // 
            picProduct.BorderStyle = BorderStyle.FixedSingle;
            picProduct.Location = new Point(700, 25);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(150, 130);
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;
            picProduct.TabIndex = 12;
            picProduct.TabStop = false;
            // 
            // chkConKinhDoanh
            // 
            chkConKinhDoanh.AutoSize = true;
            chkConKinhDoanh.Checked = true;
            chkConKinhDoanh.CheckState = CheckState.Checked;
            chkConKinhDoanh.Location = new Point(110, 160);
            chkConKinhDoanh.Name = "chkConKinhDoanh";
            chkConKinhDoanh.Size = new Size(154, 27);
            chkConKinhDoanh.TabIndex = 11;
            chkConKinhDoanh.Text = "Còn kinh doanh";
            chkConKinhDoanh.UseVisualStyleBackColor = true;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Format = DateTimePickerFormat.Short;
            dtpNgayNhap.Location = new Point(430, 122);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(170, 30);
            dtpNgayNhap.TabIndex = 10;
            // 
            // numSoLuong
            // 
            numSoLuong.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuong.Location = new Point(430, 77);
            numSoLuong.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(170, 30);
            numSoLuong.TabIndex = 9;
            numSoLuong.ThousandsSeparator = true;
            // 
            // numDonGia
            // 
            numDonGia.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numDonGia.Location = new Point(430, 32);
            numDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(170, 30);
            numDonGia.TabIndex = 0;
            numDonGia.ThousandsSeparator = true;
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Location = new Point(110, 122);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(190, 31);
            cboLoaiSP.TabIndex = 8;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(110, 77);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(190, 30);
            txtTenSP.TabIndex = 7;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(110, 32);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(190, 30);
            txtMaSP.TabIndex = 6;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblNgayNhap.Location = new Point(330, 125);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(99, 23);
            lblNgayNhap.TabIndex = 5;
            lblNgayNhap.Text = "\tNgày nhập:";
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblSoLuong.Location = new Point(330, 80);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(83, 23);
            lblSoLuong.TabIndex = 4;
            lblSoLuong.Text = "Số lượng:";
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblDonGia.Location = new Point(330, 35);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(74, 23);
            lblDonGia.TabIndex = 3;
            lblDonGia.Text = "Đơn giá:";
            // 
            // lblLoaiSP
            // 
            lblLoaiSP.AutoSize = true;
            lblLoaiSP.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblLoaiSP.Location = new Point(20, 125);
            lblLoaiSP.Name = "lblLoaiSP";
            lblLoaiSP.Size = new Size(69, 23);
            lblLoaiSP.TabIndex = 2;
            lblLoaiSP.Text = "Loại SP:";
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTenSP.Location = new Point(20, 80);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(64, 23);
            lblTenSP.TabIndex = 1;
            lblTenSP.Text = "Tên SP:";
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblMaSP.Location = new Point(20, 35);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(63, 23);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã SP:";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colTenSP, colLoaiSP, colDonGia, colSoLuong, colNgayNhap, colConKinhDoanh, colDuongDanAnh });
            dgvProducts.Location = new Point(12, 285);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(1268, 273);
            dgvProducts.TabIndex = 4;
            // 
            // colMaSP
            // 
            colMaSP.DataPropertyName = "MaSP";
            colMaSP.HeaderText = "Mã SP";
            colMaSP.MinimumWidth = 6;
            colMaSP.Name = "colMaSP";
            colMaSP.ReadOnly = true;
            // 
            // colTenSP
            // 
            colTenSP.DataPropertyName = "TenSP";
            colTenSP.HeaderText = "Tên sản phẩm";
            colTenSP.MinimumWidth = 6;
            colTenSP.Name = "colTenSP";
            colTenSP.ReadOnly = true;
            // 
            // colLoaiSP
            // 
            colLoaiSP.DataPropertyName = "LoaiSP";
            colLoaiSP.HeaderText = "Loại";
            colLoaiSP.MinimumWidth = 6;
            colLoaiSP.Name = "colLoaiSP";
            colLoaiSP.ReadOnly = true;
            // 
            // colDonGia
            // 
            colDonGia.DataPropertyName = "DonGia";
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.MinimumWidth = 6;
            colDonGia.Name = "colDonGia";
            colDonGia.ReadOnly = true;
            // 
            // colSoLuong
            // 
            colSoLuong.DataPropertyName = "SoLuong";
            colSoLuong.HeaderText = "Số lượng";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            colSoLuong.ReadOnly = true;
            // 
            // colNgayNhap
            // 
            colNgayNhap.DataPropertyName = "NgayNhap";
            colNgayNhap.HeaderText = "Ngày nhập";
            colNgayNhap.MinimumWidth = 6;
            colNgayNhap.Name = "colNgayNhap";
            colNgayNhap.ReadOnly = true;
            // 
            // colConKinhDoanh
            // 
            colConKinhDoanh.DataPropertyName = "ConKinhDoanh";
            colConKinhDoanh.HeaderText = "Còn kinh doanh";
            colConKinhDoanh.MinimumWidth = 6;
            colConKinhDoanh.Name = "colConKinhDoanh";
            colConKinhDoanh.ReadOnly = true;
            // 
            // colDuongDanAnh
            // 
            colDuongDanAnh.DataPropertyName = "DuongDanAnh";
            colDuongDanAnh.HeaderText = "Đường dẫn ảnh";
            colDuongDanAnh.MinimumWidth = 6;
            colDuongDanAnh.Name = "colDuongDanAnh";
            colDuongDanAnh.ReadOnly = true;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1413, 636);
            Controls.Add(dgvProducts);
            Controls.Add(grpThongTin);
            Controls.Add(statusMain);
            Controls.Add(toolMain);
            Controls.Add(menuMain);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            MainMenuStrip = menuMain;
            MinimumSize = new Size(1010, 683);
            Name = "FrmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sản phẩm";
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            toolMain.ResumeLayout(false);
            toolMain.PerformLayout();
            statusMain.ResumeLayout(false);
            statusMain.PerformLayout();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuMain;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuFileLamMoi;
        private ToolStripMenuItem menuFileThoat;
        private ToolStripMenuItem menuQuanLy;
        private ToolStripMenuItem menuThem;
        private ToolStripMenuItem menuSua;
        private ToolStripMenuItem menuXoa;
        private ToolStripMenuItem menuTimKiem;
        private ToolStripMenuItem menuTroGiup;
        private ToolStripMenuItem menuGioiThieu;
        private ToolStrip toolMain;
        private ToolStripButton btnThem;
        private ToolStripButton btnSua;
        private ToolStripButton btnXoa;
        private ToolStripButton btnLamMoi;
        private ToolStripButton btnTimKiem;
        private ToolStripSeparator toolStripSeparator1;
        private StatusStrip statusMain;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblCount;
        private GroupBox grpThongTin;
        private TextBox txtTenSP;
        private TextBox txtMaSP;
        private Label lblNgayNhap;
        private Label lblSoLuong;
        private Label lblDonGia;
        private Label lblLoaiSP;
        private Label lblTenSP;
        private Label lblMaSP;
        private ComboBox cboLoaiSP;
        private PictureBox picProduct;
        private CheckBox chkConKinhDoanh;
        private DateTimePicker dtpNgayNhap;
        private NumericUpDown numSoLuong;
        private NumericUpDown numDonGia;
        private Button btnChonAnh;
        private OpenFileDialog openFileDialog1;
        private ErrorProvider errorProvider1;
        private DataGridView dgvProducts;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colLoaiSP;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colNgayNhap;
        private DataGridViewCheckBoxColumn colConKinhDoanh;
        private DataGridViewTextBoxColumn colDuongDanAnh;
    }
}
