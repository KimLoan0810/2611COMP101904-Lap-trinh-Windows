namespace ShopManagerMini.Forms
{
    partial class FrmCustomer
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
            lblFullName = new Label();
            lblPhone = new Label();
            lblType = new Label();
            txtId = new TextBox();
            txtPhone = new TextBox();
            txtFullName = new TextBox();
            cboType = new ComboBox();
            btnAdd = new Button();
            dgvCustomers = new DataGridView();
            panel1 = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            grpInfo = new GroupBox();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            grpSearch = new GroupBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            panel1.SuspendLayout();
            grpInfo.SuspendLayout();
            grpSearch.SuspendLayout();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblId.ForeColor = Color.Black;
            lblId.Location = new Point(20, 33);
            lblId.Name = "lblId";
            lblId.Size = new Size(115, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Mã khách hàng";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblFullName.ForeColor = Color.Black;
            lblFullName.Location = new Point(20, 73);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(55, 20);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Họ tên";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblPhone.ForeColor = Color.Black;
            lblPhone.Location = new Point(380, 33);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(99, 20);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Số điện thoại";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblType.ForeColor = Color.Black;
            lblType.Location = new Point(380, 73);
            lblType.Name = "lblType";
            lblType.Size = new Size(121, 20);
            lblType.TabIndex = 3;
            lblType.Text = "Loại khách hàng";
            // 
            // txtId
            // 
            txtId.Location = new Point(140, 30);
            txtId.Name = "txtId";
            txtId.Size = new Size(200, 27);
            txtId.TabIndex = 4;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(500, 30);
            txtPhone.MaxLength = 11;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 27);
            txtPhone.TabIndex = 5;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(140, 70);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(200, 27);
            txtFullName.TabIndex = 6;
            // 
            // cboType
            // 
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.FormattingEnabled = true;
            cboType.Items.AddRange(new object[] { "Thường", "VIP", "Thân thiết" });
            cboType.Location = new Point(500, 70);
            cboType.Name = "cboType";
            cboType.Size = new Size(200, 28);
            cboType.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(31, 78, 121);
            btnAdd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(310, 105);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 32);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomers.ColumnHeadersHeight = 34;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.Location = new Point(20, 320);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.RowTemplate.Height = 30;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(725, 185);
            dgvCustomers.TabIndex = 9;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(31, 78, 121);
            panel1.Controls.Add(lblSubtitle);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(762, 75);
            panel1.TabIndex = 10;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(22, 49);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(304, 20);
            lblSubtitle.TabIndex = 11;
            lblSubtitle.Text = "Thêm mới và theo dõi danh sách khách hàng";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(278, 38);
            lblTitle.TabIndex = 12;
            lblTitle.Text = "Quản lý khách hàng";
            // 
            // grpInfo
            // 
            grpInfo.BackColor = Color.White;
            grpInfo.Controls.Add(btnRefresh);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnEdit);
            grpInfo.Controls.Add(lblId);
            grpInfo.Controls.Add(txtId);
            grpInfo.Controls.Add(lblFullName);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(txtFullName);
            grpInfo.Controls.Add(cboType);
            grpInfo.Controls.Add(lblPhone);
            grpInfo.Controls.Add(lblType);
            grpInfo.Controls.Add(txtPhone);
            grpInfo.ForeColor = Color.FromArgb(31, 78, 121);
            grpInfo.Location = new Point(21, 85);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(725, 150);
            grpInfo.TabIndex = 11;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin khách hàng";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(217, 130, 43);
            btnEdit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(410, 105);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 32);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(192, 57, 43);
            btnDelete.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(510, 105);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 32);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(610, 105);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 32);
            btnRefresh.TabIndex = 11;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // grpSearch
            // 
            grpSearch.BackColor = Color.White;
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Controls.Add(txtSearch);
            grpSearch.Controls.Add(lblSearch);
            grpSearch.ForeColor = Color.FromArgb(31, 78, 121);
            grpSearch.Location = new Point(20, 240);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(725, 65);
            grpSearch.TabIndex = 12;
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
            lblSearch.TabIndex = 12;
            lblSearch.Text = "Từ khóa";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(100, 26);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(330, 27);
            txtSearch.TabIndex = 12;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(31, 78, 121);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(445, 24);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 30);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // FrmCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(762, 513);
            Controls.Add(grpSearch);
            Controls.Add(grpInfo);
            Controls.Add(panel1);
            Controls.Add(dgvCustomers);
            Name = "FrmCustomer";
            Text = "Quản lý khách hàng";
            Load += FrmCustomer_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblId;
        private Label lblFullName;
        private Label lblPhone;
        private Label lblType;
        private TextBox txtId;
        private TextBox txtPhone;
        private TextBox txtFullName;
        private ComboBox cboType;
        private Button btnAdd;
        private DataGridView dgvCustomers;
        private Panel panel1;
        private Label lblTitle;
        private Label lblSubtitle;
        private GroupBox grpInfo;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnRefresh;
        private GroupBox grpSearch;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblSearch;
    }
}