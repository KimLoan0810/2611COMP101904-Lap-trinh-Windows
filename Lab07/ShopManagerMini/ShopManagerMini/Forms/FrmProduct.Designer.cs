namespace ShopManagerMini.Forms
{
    partial class FrmProduct
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
            lblId = new Label();
            txtId = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvProducts = new DataGridView();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            grpInfo = new GroupBox();
            grpSearch = new GroupBox();
            lblSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            pnlHeader.SuspendLayout();
            grpInfo.SuspendLayout();
            grpSearch.SuspendLayout();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblId.ForeColor = Color.Black;
            lblId.Location = new Point(20, 113);
            lblId.Name = "lblId";
            lblId.Size = new Size(101, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Mã sản phẩm";
            // 
            // txtId
            // 
            txtId.Location = new Point(140, 110);
            txtId.Name = "txtId";
            txtId.Size = new Size(151, 27);
            txtId.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(20, 33);
            lblName.Name = "lblName";
            lblName.Size = new Size(103, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Tên sản phẩm";
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 27);
            txtName.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblCategory.ForeColor = Color.Black;
            lblCategory.Location = new Point(20, 73);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(107, 20);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Loại sản phẩm";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Items.AddRange(new object[] { "Thực phẩm", "Đồ uống", "Gia dụng", "Khác" });
            cboCategory.Location = new Point(140, 70);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(151, 28);
            cboCategory.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblPrice.ForeColor = Color.Black;
            lblPrice.Location = new Point(430, 33);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(63, 20);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Đơn giá";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(520, 30);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(137, 27);
            txtPrice.TabIndex = 7;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblQuantity.ForeColor = Color.Black;
            lblQuantity.Location = new Point(430, 73);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(70, 20);
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "Số lượng";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(520, 70);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(137, 27);
            txtQuantity.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(31, 78, 121);
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(430, 110);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(217, 130, 43);
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(530, 110);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(192, 57, 43);
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(630, 110);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(730, 110);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(100, 26);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(330, 27);
            txtSearch.TabIndex = 14;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(31, 78, 121);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(445, 24);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 30);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.ColumnHeadersHeight = 34;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.GridColor = Color.FromArgb(230, 230, 230);
            dgvProducts.Location = new Point(20, 325);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(845, 250);
            dgvProducts.TabIndex = 16;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(31, 78, 121);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.ForeColor = Color.White;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(882, 72);
            pnlHeader.TabIndex = 17;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(253, 38);
            lblTitle.TabIndex = 18;
            lblTitle.Text = "Quản lý sản phẩm";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(22, 47);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(256, 20);
            lblSubtitle.TabIndex = 19;
            lblSubtitle.Text = "Thêm, sửa, xóa và tìm kiếm sản phẩm";
            // 
            // grpInfo
            // 
            grpInfo.BackColor = Color.White;
            grpInfo.Controls.Add(lblName);
            grpInfo.Controls.Add(txtName);
            grpInfo.Controls.Add(lblCategory);
            grpInfo.Controls.Add(cboCategory);
            grpInfo.Controls.Add(lblId);
            grpInfo.Controls.Add(btnRefresh);
            grpInfo.Controls.Add(txtId);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(lblPrice);
            grpInfo.Controls.Add(btnEdit);
            grpInfo.Controls.Add(txtPrice);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(lblQuantity);
            grpInfo.Controls.Add(txtQuantity);
            grpInfo.ForeColor = Color.FromArgb(31, 78, 121);
            grpInfo.Location = new Point(20, 85);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(845, 150);
            grpInfo.TabIndex = 18;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin sản phẩm";
            // 
            // grpSearch
            // 
            grpSearch.BackColor = Color.White;
            grpSearch.Controls.Add(lblSearch);
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Controls.Add(txtSearch);
            grpSearch.ForeColor = Color.FromArgb(31, 78, 121);
            grpSearch.Location = new Point(20, 245);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(845, 65);
            grpSearch.TabIndex = 19;
            grpSearch.TabStop = false;
            grpSearch.Text = "Tìm kiếm";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblSearch.ForeColor = Color.Black;
            lblSearch.Location = new Point(20, 29);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(64, 20);
            lblSearch.TabIndex = 14;
            lblSearch.Text = "Từ khóa";
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(882, 593);
            Controls.Add(grpSearch);
            Controls.Add(grpInfo);
            Controls.Add(pnlHeader);
            Controls.Add(dgvProducts);
            Name = "FrmProduct";
            Text = "Quản lý sản phẩm";
            Load += FrmProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblId;
        private TextBox txtId;
        private Label lblName;
        private TextBox txtName;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvProducts;
        private Panel pnlHeader;
        private Label lblSubtitle;
        private Label lblTitle;
        private GroupBox grpInfo;
        private GroupBox grpSearch;
        private Label lblSearch;
    }
}