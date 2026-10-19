using System.Globalization;
using System.Text;

namespace CourseRegistrationApp;

public partial class frmMain : Form
{
    private static readonly CultureInfo ViVN = new("vi-VN");

    public frmMain()
    {
        InitializeComponent();
    }

    // ================= FORM LOAD =================
    private void frmMain_Load(object sender, EventArgs e)
    {
        // Hiển thị tên tháng bằng tiếng Việt
        Thread.CurrentThread.CurrentCulture = ViVN;
        Thread.CurrentThread.CurrentUICulture = ViVN;

        // Số tháng 1 - 12
        numSoThang.Minimum = 1;
        numSoThang.Maximum = 12;
        numSoThang.Value = 1;

        // Nạp danh sách khóa học
        List<KhoaHoc> danhSachKhoaHoc = new()
        {
            new KhoaHoc("C# WinForms cơ bản", 800000),
            new KhoaHoc("SQL Server cơ bản", 700000),
            new KhoaHoc("Web Frontend cơ bản", 750000),
            new KhoaHoc("Lập trình Python cơ bản", 650000)
        };
        cboKhoaHoc.DataSource = danhSachKhoaHoc;
        cboKhoaHoc.SelectedIndex = 0;      // chọn khóa đầu tiên

        radOnline.Checked = true;          // mặc định Online

        HienThiTongTien();
    }

    // ================= TÍNH HỌC PHÍ =================
    private decimal TinhTongTien()
    {
        if (cboKhoaHoc.SelectedItem is not KhoaHoc khoaHoc)
            return 0;

        return khoaHoc.HocPhiMotThang * numSoThang.Value;
    }

    private void HienThiTongTien()
    {
        lblTongTien.Text = $"{TinhTongTien().ToString("N0", ViVN)} VND";
    }

    private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        HienThiTongTien();
    }

    private void numSoThang_ValueChanged(object sender, EventArgs e)
    {
        HienThiTongTien();
    }

    // ================= NÚT ĐĂNG KÝ =================
    private void btnDangKy_Click(object sender, EventArgs e)
    {
        string hoTen = txtHoTen.Text.Trim();
        string soDienThoai = txtSoDienThoai.Text.Trim();

        // 1. Kiểm tra dữ liệu
        if (string.IsNullOrEmpty(hoTen))
        {
            MessageBox.Show("Vui lòng nhập họ tên.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return;
        }

        if (string.IsNullOrEmpty(soDienThoai))
        {
            MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSoDienThoai.Focus();
            return;
        }

        if (cboKhoaHoc.SelectedItem is not KhoaHoc khoaHoc)
        {
            MessageBox.Show("Vui lòng chọn khóa học.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboKhoaHoc.Focus();
            return;
        }

        // 2. Lấy dữ liệu để hiển thị
        string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp";
        string trangThaiEmail = chkNhanEmail.Checked ? "Có" : "Không";
        decimal tongTien = TinhTongTien();

        // 3. Dựng phiếu đăng ký
        StringBuilder phieu = new();
        phieu.AppendLine($"Họ tên: {hoTen}");
        phieu.AppendLine($"Số điện thoại: {soDienThoai}");
        phieu.AppendLine($"Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy}");
        phieu.AppendLine($"Khóa học: {khoaHoc.Ten}");
        phieu.AppendLine($"Hình thức học: {hinhThuc}");
        phieu.AppendLine($"Số tháng: {numSoThang.Value}");
        phieu.AppendLine($"Tổng tiền: {tongTien.ToString("N0", ViVN)} VND");
        phieu.AppendLine($"Nhận email thông báo: {trangThaiEmail}");

        MessageBox.Show(phieu.ToString(), "PHIẾU ĐĂNG KÝ KHÓA HỌC",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // ================= NÚT LÀM MỚI =================
    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        txtHoTen.Clear();
        txtSoDienThoai.Clear();
        dtpNgaySinh.Value = DateTime.Now;
        chkNhanEmail.Checked = false;
        cboKhoaHoc.SelectedIndex = 0;
        radOnline.Checked = true;
        numSoThang.Value = 1;
        txtHoTen.Focus();
    }

    // ================= NÚT THOÁT =================
    private void btnThoat_Click(object sender, EventArgs e)
    {
        DialogResult ketQua = MessageBox.Show(
            "Bạn có chắc chắn muốn thoát chương trình?",
            "Xác nhận thoát",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (ketQua == DialogResult.Yes)
        {
            Close();
        }
    }
}