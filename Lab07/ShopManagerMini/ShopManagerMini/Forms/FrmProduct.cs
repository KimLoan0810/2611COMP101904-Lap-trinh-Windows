using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cboCategory.SelectedIndex = 0;
            LoadData(DataStore.Products);
        }

        // Đổ dữ liệu lên lưới
        private void LoadData(IEnumerable<Product> data)
        {
            dgvProducts.DataSource = data.ToList();
            if (dgvProducts.Columns["Price"] != null)
                dgvProducts.Columns["Price"].DefaultCellStyle.Format = "N0";
        }

        // Xóa trắng ô nhập, mở khóa ô Mã
        private void ClearInput()
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtSearch.Clear();
            cboCategory.SelectedIndex = 0;
            txtId.ReadOnly = false;
            txtId.Focus();
        }

        // Đọc và kiểm tra dữ liệu nhập. Trả false nếu không hợp lệ
        private bool TryReadInput(out Product product)
        {
            product = null;
            string id = txtId.Text.Trim();
            string name = txtName.Text.Trim();

            if (id == "" || name == "")
            {
                MessageBox.Show("Mã và tên sản phẩm không được để trống.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Đơn giá phải là số và không được âm.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên và không được âm.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return false;
            }

            product = new Product
            {
                Id = id,
                Name = name,
                Category = cboCategory.Text,
                Price = price,
                Quantity = qty
            };
            return true;
        }

        // Tìm sản phẩm theo mã (không phân biệt hoa thường)
        private Product FindById(string id) =>
            DataStore.Products.FirstOrDefault(p =>
                p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

        // ----- THÊM -----
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Đang chọn một dòng (ô Mã bị khóa) -> yêu cầu làm mới trước
            if (txtId.ReadOnly)
            {
                MessageBox.Show("Bạn đang chọn một sản phẩm có sẵn.\nHãy bấm \"Làm mới\" rồi nhập sản phẩm mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!TryReadInput(out Product p)) return;

            if (FindById(p.Id) != null)
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();
                return;
            }

            DataStore.Products.Add(p);
            LoadData(DataStore.Products);
            ClearInput();
        }

        // ----- SỬA -----
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!txtId.ReadOnly)
            {
                MessageBox.Show("Hãy bấm chọn một dòng trong danh sách để sửa.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryReadInput(out Product p)) return;

            Product old = FindById(p.Id);
            if (old == null) return;

            old.Name = p.Name;
            old.Category = p.Category;
            old.Price = p.Price;
            old.Quantity = p.Quantity;

            LoadData(DataStore.Products);
            ClearInput();
        }

        // ----- XÓA -----
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product p = FindById(txtId.Text.Trim());
            if (p == null)
            {
                MessageBox.Show("Hãy chọn sản phẩm cần xóa trong danh sách.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xóa sản phẩm \"{p.Name}\"?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataStore.Products.Remove(p);
                LoadData(DataStore.Products);
                ClearInput();
            }
        }

        // ----- LÀM MỚI -----
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData(DataStore.Products);
        }

        // ----- TÌM KIẾM (theo mã hoặc tên) -----
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim().ToLower();
            var result = DataStore.Products.Where(p =>
                p.Id.ToLower().Contains(key) || p.Name.ToLower().Contains(key));
            LoadData(result);
        }

        // ----- Bấm vào một dòng -> đổ lên ô nhập -----
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // bấm vào tiêu đề cột thì bỏ qua

            if (dgvProducts.Rows[e.RowIndex].DataBoundItem is Product p)
            {
                txtId.Text = p.Id;
                txtName.Text = p.Name;
                cboCategory.Text = p.Category;
                txtPrice.Text = p.Price.ToString();
                txtQuantity.Text = p.Quantity.ToString();
                txtId.ReadOnly = true;    // không cho đổi mã khi đang sửa
            }
        }
    }
}