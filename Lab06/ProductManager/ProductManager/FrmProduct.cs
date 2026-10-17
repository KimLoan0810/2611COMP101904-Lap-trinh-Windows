using System.ComponentModel;
using System.Globalization;

namespace ProductManager
{
    public partial class FrmProduct : Form
    {
        // ====== DỮ LIỆU DÙNG CHUNG ======
        private readonly BindingList<Product> products = new BindingList<Product>();
        private readonly BindingSource bs = new BindingSource();
        private readonly ContextMenuStrip ctxGrid = new ContextMenuStrip();
        private string currentImagePath = "";

        public FrmProduct()
        {
            InitializeComponent();

            // Tránh gắn trùng nếu đã gắn Load bằng Designer
            Load -= FrmProduct_Load;
            Load += FrmProduct_Load;

            RegisterEvents();
            BuildContextMenu();
        }

        // ====== LOAD FORM ======
        private void FrmProduct_Load(object? sender, EventArgs e)
        {
            LoadCategories();
            LoadSampleData();

            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;

            bs.DataSource = products;
            dgvProducts.DataSource = bs;
            dgvProducts.ClearSelection();

            UpdateStatus("Sẵn sàng");
        }

        private void LoadCategories()
        {
            cboLoaiSP.Items.Clear();
            cboLoaiSP.Items.AddRange(new string[] { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" });
            cboLoaiSP.SelectedIndex = 0;
        }

        private void LoadSampleData()
        {
            products.Add(new Product("SP001", "Laptop Dell Inspiron", "Điện tử", 15000000m, 10, new DateTime(2026, 9, 1), true));
            products.Add(new Product("SP002", "Bút bi Thiên Long", "Văn phòng", 5000m, 200, new DateTime(2026, 9, 15), true));
            products.Add(new Product("SP003", "Nồi cơm điện Sharp", "Gia dụng", 1200000m, 25, new DateTime(2026, 10, 1), true));
        }

        // ====== GẮN SỰ KIỆN BẰNG CODE ======
        private void RegisterEvents()
        {
            // ToolStrip
            btnThem.Click += (s, e) => AddProduct();
            btnSua.Click += (s, e) => EditProduct();
            btnXoa.Click += (s, e) => DeleteProduct();
            btnLamMoi.Click += (s, e) => RefreshAll();
            btnTimKiem.Click += (s, e) => SearchProduct();

            // MenuStrip
            menuThem.Click += (s, e) => AddProduct();
            menuSua.Click += (s, e) => EditProduct();
            menuXoa.Click += (s, e) => DeleteProduct();
            menuTimKiem.Click += (s, e) => SearchProduct();
            menuFileLamMoi.Click += (s, e) => RefreshAll();
            menuFileThoat.Click += (s, e) => Close();
            menuGioiThieu.Click += (s, e) =>
                MessageBox.Show("ProductManager\nBài thực hành Lab 05 - Windows Forms và DataGridView",
                    "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Nút chọn ảnh
            btnChonAnh.Click += (s, e) => ChooseImage();

            // DataGridView
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
            dgvProducts.CellMouseDown += DgvProducts_CellMouseDown;
            dgvProducts.ContextMenuStrip = ctxGrid;

            // Phím tắt
            KeyPreview = true;
            KeyDown += FrmProduct_KeyDown;

            // Xóa dấu lỗi khi người dùng nhập lại
            txtMaSP.TextChanged += (s, e) => errorProvider1.SetError(txtMaSP, "");
            txtTenSP.TextChanged += (s, e) => errorProvider1.SetError(txtTenSP, "");
            numDonGia.ValueChanged += (s, e) => errorProvider1.SetError(numDonGia, "");
            dtpNgayNhap.ValueChanged += (s, e) => errorProvider1.SetError(dtpNgayNhap, "");
        }

        private void BuildContextMenu()
        {
            var miSua = new ToolStripMenuItem("Sửa");
            var miXoa = new ToolStripMenuItem("Xóa");
            var miChiTiet = new ToolStripMenuItem("Xem chi tiết");

            miSua.Click += (s, e) => PrepareEdit();
            miXoa.Click += (s, e) => DeleteProduct();
            miChiTiet.Click += (s, e) => ShowDetail();

            ctxGrid.Items.AddRange(new ToolStripItem[] { miSua, miXoa, miChiTiet });
        }

        // ====== SỰ KIỆN DATAGRIDVIEW / BÀN PHÍM ======
        private void DgvProducts_SelectionChanged(object? sender, EventArgs e)
        {
            Product? p = GetSelectedProduct();
            if (p != null)
            {
                LoadProductToForm(p);
            }
        }

        // Nhấn chuột phải thì chọn luôn dòng đó
        private void DgvProducts_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvProducts.ClearSelection();
                dgvProducts.Rows[e.RowIndex].Selected = true;
                dgvProducts.CurrentCell = dgvProducts.Rows[e.RowIndex].Cells[Math.Max(e.ColumnIndex, 0)];
            }
        }

        private void FrmProduct_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                AddProduct();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                EditProduct();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                SearchProduct();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                RefreshAll();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete && ActiveControl == dgvProducts)
            {
                DeleteProduct();
                e.SuppressKeyPress = true;
            }
        }

        // ====== CHỨC NĂNG CHÍNH ======
        private void AddProduct()
        {
            if (!ValidateInput(null))
            {
                return;
            }

            Product p = ReadFromForm();
            products.Add(p);

            ShowAll();
            ClearInput();
            UpdateStatus("Đã thêm sản phẩm " + p.MaSP);
        }

        private void EditProduct()
        {
            Product? p = GetSelectedProduct();
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput(p))
            {
                return;
            }

            Product data = ReadFromForm();
            p.MaSP = data.MaSP;
            p.TenSP = data.TenSP;
            p.LoaiSP = data.LoaiSP;
            p.DonGia = data.DonGia;
            p.SoLuong = data.SoLuong;
            p.NgayNhap = data.NgayNhap;
            p.ConKinhDoanh = data.ConKinhDoanh;
            p.DuongDanAnh = data.DuongDanAnh;

            bs.ResetBindings(false);
            SelectProduct(p);
            UpdateStatus("Đã cập nhật sản phẩm " + p.MaSP);
        }

        // Dùng cho menu chuột phải "Sửa": đưa dữ liệu lên form để chỉnh
        private void PrepareEdit()
        {
            Product? p = GetSelectedProduct();
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadProductToForm(p);
            txtTenSP.Focus();
            UpdateStatus("Hãy chỉnh sửa thông tin rồi bấm nút Sửa để lưu");
        }

        private void DeleteProduct()
        {
            Product? p = GetSelectedProduct();
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm \"{p.TenSP}\" ({p.MaSP}) không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            products.Remove(p);
            ShowAll();
            ClearInput();
            UpdateStatus("Đã xóa sản phẩm " + p.MaSP);
        }

        private void SearchProduct()
        {
            string? keyword = ShowInputDialog("Tìm kiếm", "Nhập mã hoặc tên sản phẩm:");
            if (keyword == null)
            {
                return; // người dùng bấm Cancel
            }

            keyword = keyword.Trim();
            if (keyword == "")
            {
                ShowAll();
                UpdateStatus("Hiển thị tất cả sản phẩm");
                return;
            }

            List<Product> result = products
                .Where(p => p.MaSP.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                         || p.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            bs.DataSource = new BindingList<Product>(result);
            dgvProducts.ClearSelection();
            UpdateStatus($"Tìm thấy {result.Count} sản phẩm với từ khóa \"{keyword}\"");
        }

        private void RefreshAll()
        {
            ClearInput();
            ShowAll();
            UpdateStatus("Đã làm mới");
        }

        private void ChooseImage()
        {
            openFileDialog1.Title = "Chọn ảnh sản phẩm";
            openFileDialog1.Filter = "Tệp ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả tệp|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SetImage(openFileDialog1.FileName);
                UpdateStatus("Đã chọn ảnh: " + Path.GetFileName(openFileDialog1.FileName));
            }
        }

        private void ShowDetail()
        {
            Product? p = GetSelectedProduct();
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var vn = new CultureInfo("vi-VN");
            string info =
                $"Mã SP: {p.MaSP}\n" +
                $"Tên SP: {p.TenSP}\n" +
                $"Loại: {p.LoaiSP}\n" +
                $"Đơn giá: {p.DonGia.ToString("N0", vn)} đ\n" +
                $"Số lượng: {p.SoLuong}\n" +
                $"Ngày nhập: {p.NgayNhap:dd/MM/yyyy}\n" +
                $"Trạng thái: {(p.ConKinhDoanh ? "Còn kinh doanh" : "Ngừng kinh doanh")}\n" +
                $"Đường dẫn ảnh: {(string.IsNullOrEmpty(p.DuongDanAnh) ? "(không có)" : p.DuongDanAnh)}";

            MessageBox.Show(info, "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ====== CÁC HÀM HỖ TRỢ (theo yêu cầu đề) ======
        private bool ValidateInput(Product? editing)
        {
            errorProvider1.Clear();
            var errors = new List<Control>();

            void SetError(Control c, string message)
            {
                errorProvider1.SetError(c, message);
                errors.Add(c);
            }

            string ma = txtMaSP.Text.Trim();
            if (ma == "")
            {
                SetError(txtMaSP, "Mã sản phẩm không được để trống");
            }
            else if (products.Any(x => !ReferenceEquals(x, editing)
                                       && string.Equals(x.MaSP, ma, StringComparison.OrdinalIgnoreCase)))
            {
                SetError(txtMaSP, "Mã sản phẩm đã tồn tại");
            }

            if (txtTenSP.Text.Trim() == "")
            {
                SetError(txtTenSP, "Tên sản phẩm không được để trống");
            }

            if (cboLoaiSP.SelectedIndex < 0)
            {
                SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm");
            }

            if (numDonGia.Value <= 0)
            {
                SetError(numDonGia, "Đơn giá phải lớn hơn 0");
            }

            if (numSoLuong.Value < 0)
            {
                SetError(numSoLuong, "Số lượng phải lớn hơn hoặc bằng 0");
            }

            if (dtpNgayNhap.Value.Date > DateTime.Today)
            {
                SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn ngày hiện tại");
            }

            if (errors.Count > 0)
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ, vui lòng xem các dấu lỗi màu đỏ.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errors[0].Focus();
                return false;
            }

            return true;
        }

        private void ClearInput()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 0;
            numSoLuong.Value = 0;
            dtpNgayNhap.Value = DateTime.Today;
            chkConKinhDoanh.Checked = true;
            SetImage("");
            errorProvider1.Clear();
            dgvProducts.ClearSelection();
            txtMaSP.Focus();
        }

        private void LoadProductToForm(Product p)
        {
            txtMaSP.Text = p.MaSP;
            txtTenSP.Text = p.TenSP;

            int index = cboLoaiSP.Items.IndexOf(p.LoaiSP);
            cboLoaiSP.SelectedIndex = index >= 0 ? index : 0;

            numDonGia.Value = Math.Clamp(p.DonGia, numDonGia.Minimum, numDonGia.Maximum);
            numSoLuong.Value = Math.Clamp(p.SoLuong, (int)numSoLuong.Minimum, (int)numSoLuong.Maximum);

            DateTime d = p.NgayNhap;
            if (d < dtpNgayNhap.MinDate) d = dtpNgayNhap.MinDate;
            if (d > dtpNgayNhap.MaxDate) d = dtpNgayNhap.MaxDate;
            dtpNgayNhap.Value = d;

            chkConKinhDoanh.Checked = p.ConKinhDoanh;
            SetImage(p.DuongDanAnh);
            errorProvider1.Clear();
        }

        private void UpdateStatus(string message)
        {
            lblStatus.Text = message;
            lblCount.Text = "Tổng số sản phẩm: " + products.Count;
        }

        // ====== HÀM PHỤ ======
        private Product ReadFromForm()
        {
            return new Product
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                LoaiSP = cboLoaiSP.SelectedItem?.ToString() ?? "",
                DonGia = numDonGia.Value,
                SoLuong = (int)numSoLuong.Value,
                NgayNhap = dtpNgayNhap.Value.Date,
                ConKinhDoanh = chkConKinhDoanh.Checked,
                DuongDanAnh = currentImagePath
            };
        }

        private Product? GetSelectedProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                return null;
            }
            return dgvProducts.SelectedRows[0].DataBoundItem as Product;
        }

        private void ShowAll()
        {
            bs.DataSource = products;
            bs.ResetBindings(false);
            dgvProducts.ClearSelection();
        }

        private void SelectProduct(Product p)
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (ReferenceEquals(row.DataBoundItem, p))
                {
                    dgvProducts.ClearSelection();
                    row.Selected = true;
                    dgvProducts.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        // Đọc ảnh qua stream để không bị khóa file
        private void SetImage(string path)
        {
            picProduct.Image?.Dispose();
            picProduct.Image = null;
            currentImagePath = path ?? "";

            if (string.IsNullOrWhiteSpace(currentImagePath) || !File.Exists(currentImagePath))
            {
                return;
            }

            try
            {
                using var fs = new FileStream(currentImagePath, FileMode.Open, FileAccess.Read);
                using var img = Image.FromStream(fs);
                picProduct.Image = new Bitmap(img);
            }
            catch
            {
                currentImagePath = "";
                MessageBox.Show("Không đọc được tệp ảnh này.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Hộp nhập liệu đơn giản dùng cho Tìm kiếm
        private string? ShowInputDialog(string title, string prompt)
        {
            using var f = new Form
            {
                Text = title,
                ClientSize = new Size(380, 120),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = Font
            };

            var lbl = new Label { Text = prompt, Left = 12, Top = 12, AutoSize = true };
            var txt = new TextBox { Left = 12, Top = 40, Width = 356 };
            var ok = new Button { Text = "Tìm", Left = 200, Top = 78, Width = 80, DialogResult = DialogResult.OK };
            var cancel = new Button { Text = "Hủy", Left = 288, Top = 78, Width = 80, DialogResult = DialogResult.Cancel };

            f.Controls.AddRange(new Control[] { lbl, txt, ok, cancel });
            f.AcceptButton = ok;
            f.CancelButton = cancel;

            return f.ShowDialog(this) == DialogResult.OK ? txt.Text : null;
        }
    }
}