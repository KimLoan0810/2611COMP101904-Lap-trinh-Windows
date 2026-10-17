using System;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmLogin : Form
    {
        // Property để Program.cs lấy user sau khi đăng nhập thành công
        public User CurrentUser { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // 1. Kiểm tra bỏ trống
            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                (username == "" ? txtUsername : txtPassword).Focus();
                return;
            }

            // 2. Tìm tài khoản khớp
            User user = DataStore.Users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // 3. Thành công: lưu user, trả OK và Form tự đóng
            CurrentUser = user;
            DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}