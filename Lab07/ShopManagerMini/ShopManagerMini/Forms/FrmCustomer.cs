using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            cboType.SelectedIndex = 0;
            LoadData(DataStore.Customers);
        }

        // Đổ dữ liệu lên lưới
        private void LoadData(IEnumerable<Customer> data)
        {
            dgvCustomers.DataSource = data.ToList();
        }

        // Xóa trắng ô nhập, mở khóa ô Mã
        private void ClearInput()
        {
            txtId.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtSearch.Clear();
            cboType.SelectedIndex = 0;
            txtId.ReadOnly = false;
            txtId.Focus();
        }

        // Đọc và kiểm tra dữ liệu nhập. Trả false nếu không hợp lệ
        private bool TryReadInput(out Customer customer)
        {
            customer = null;
            string id = txtId.Text.Trim();
            string name = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (id == "" || name == "" || phone == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!phone.All(char.IsDigit) || phone.Length < 9 || phone.Length > 11)
            {
                MessageBox.Show("Số điện thoại chỉ gồm chữ số, từ 9 đến 11 số.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            customer = new Customer
            {
                Id = id,
                FullName = name,
                Phone = phone,
                CustomerType = cboType.Text
            };
            return true;
        }

        // Tìm khách hàng theo mã (không phân biệt hoa thường)
        private Customer FindById(string id) =>
            DataStore.Customers.FirstOrDefault(c =>
                c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

        // ----- THÊM -----
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Đang chọn một dòng (ô Mã bị khóa) -> yêu cầu làm mới trước
            if (txtId.ReadOnly)
            {
                MessageBox.Show("Bạn đang chọn một khách hàng có sẵn.\nHãy bấm \"Làm mới\" rồi nhập khách hàng mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!TryReadInput(out Customer c)) return;

            if (FindById(c.Id) != null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();
                return;
            }

            DataStore.Customers.Add(c);
            LoadData(DataStore.Customers);
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

            if (!TryReadInput(out Customer c)) return;

            Customer old = FindById(c.Id);
            if (old == null) return;

            old.FullName = c.FullName;
            old.Phone = c.Phone;
            old.CustomerType = c.CustomerType;

            LoadData(DataStore.Customers);
            ClearInput();
        }

        // ----- XÓA -----
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Customer c = FindById(txtId.Text.Trim());
            if (c == null)
            {
                MessageBox.Show("Hãy chọn khách hàng cần xóa trong danh sách.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xóa khách hàng \"{c.FullName}\"?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataStore.Customers.Remove(c);
                LoadData(DataStore.Customers);
                ClearInput();
            }
        }

        // ----- LÀM MỚI -----
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData(DataStore.Customers);
        }

        // ----- TÌM KIẾM (theo mã, họ tên hoặc số điện thoại) -----
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim().ToLower();
            var result = DataStore.Customers.Where(c =>
                c.Id.ToLower().Contains(key) ||
                c.FullName.ToLower().Contains(key) ||
                c.Phone.Contains(key));
            LoadData(result);
        }

        // ----- Bấm vào một dòng -> đổ lên ô nhập -----
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // bấm vào tiêu đề cột thì bỏ qua

            if (dgvCustomers.Rows[e.RowIndex].DataBoundItem is Customer c)
            {
                txtId.Text = c.Id;
                txtFullName.Text = c.FullName;
                txtPhone.Text = c.Phone;
                cboType.Text = c.CustomerType;
                txtId.ReadOnly = true;    // không cho đổi mã khi đang sửa
            }
        }
    }
}