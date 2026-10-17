using System;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmMain : Form
    {
        private readonly User _currentUser;
        public bool IsLogout { get; private set; }   // true nếu chọn Đăng xuất

        // Nhận user từ FrmLogin qua constructor
        public FrmMain(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            tsslUser.Text = "Người dùng: " + _currentUser.FullName;
            tsslRole.Text = "Vai trò: " + _currentUser.Role;
            tsslTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            tsslTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // Mở Form con MDI, không mở trùng
        private void OpenChild<T>() where T : Form, new()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is T)
                {
                    if (f.WindowState == FormWindowState.Minimized)
                        f.WindowState = FormWindowState.Normal;
                    f.Activate();
                    return;
                }
            }

            T child = new T();
            child.MdiParent = this;
            child.Show();
        }

        private void mnuProduct_Click(object sender, EventArgs e) => OpenChild<FrmProduct>();
        private void mnuCustomer_Click(object sender, EventArgs e) => OpenChild<FrmCustomer>();
        private void mnuAbout_Click(object sender, EventArgs e) => OpenChild<FrmAbout>();

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IsLogout = true;
                Close();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();   // đi qua FormClosing để hỏi xác nhận
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsLogout) return;

            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}