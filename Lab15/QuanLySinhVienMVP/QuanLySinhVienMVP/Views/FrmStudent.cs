using QuanLySinhVienMVP.Models;
using QuanLySinhVienMVP.Presenters;
using QuanLySinhVienMVP.Repositories;

namespace QuanLySinhVienMVP.Views
{
    /// <summary>
    /// VIEW - Form implements IStudentView.
    /// Mỗi nút bấm chỉ gọi MỘT phương thức của Presenter.
    /// Form chỉ lo hiển thị: không kiểm tra dữ liệu, không lưu dữ liệu.
    /// </summary>
    public partial class FrmStudent : Form, IStudentView
    {
        private readonly StudentPresenter _presenter;

        // ---- Màu giao diện ----
        private static readonly Color MauDam = Color.FromArgb(44, 62, 80);
        private static readonly Color MauDongXen = Color.FromArgb(244, 250, 249);
        private static readonly Color MauChon = Color.FromArgb(209, 242, 235);
        private static readonly Color MauVien = Color.FromArgb(226, 231, 237);
        private static readonly Color MauDatChu = Color.FromArgb(30, 132, 73);
        private static readonly Color MauDatNen = Color.FromArgb(230, 247, 237);
        private static readonly Color MauRotChu = Color.FromArgb(192, 57, 43);
        private static readonly Color MauRotNen = Color.FromArgb(253, 236, 234);
        private Font fontDam;

        public FrmStudent()
        {
            InitializeComponent();

            // Tạo Presenter, truyền chính Form này (dưới dạng IStudentView) và Repository
            _presenter = new StudentPresenter(this, new StudentRepository());
        }

        // =====================================================================
        // SỰ KIỆN: mỗi hàm chỉ gọi Presenter
        // =====================================================================
        private void FrmStudent_Load(object sender, EventArgs e)
        {
            TrangTriLuoi();
            _presenter.LoadStudents();
        }

        private void btnThem_Click(object sender, EventArgs e) => _presenter.AddStudent();

        private void btnXoa_Click(object sender, EventArgs e) => _presenter.DeleteStudent();

        private void btnTimKiem_Click(object sender, EventArgs e) => _presenter.SearchStudent();

        private void btnLamMoi_Click(object sender, EventArgs e) => _presenter.ResetForm();

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string ma = dgvSinhVien.Rows[e.RowIndex].Cells["MaSV"].Value?.ToString();
            _presenter.SelectStudent(ma);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _presenter.SearchStudent();
            }
        }

        // =====================================================================
        // IStudentView - THUỘC TÍNH (Presenter đọc / ghi qua đây)
        // =====================================================================
        public string StudentCode
        {
            get => txtMaSV.Text;
            set => txtMaSV.Text = value;
        }

        public string FullName
        {
            get => txtHoTen.Text;
            set => txtHoTen.Text = value;
        }

        public string ClassName
        {
            get => txtLop.Text;
            set => txtLop.Text = value;
        }

        public string ScoreText
        {
            get => txtDiem.Text;
            set => txtDiem.Text = value;
        }

        public string Keyword
        {
            get => txtTimKiem.Text;
            set => txtTimKiem.Text = value;
        }

        // =====================================================================
        // IStudentView - PHƯƠNG THỨC (Presenter yêu cầu hiển thị)
        // =====================================================================
        public void ShowStudents(List<Student> students)
        {
            dgvSinhVien.DataSource = students
                .Select(s => new { s.MaSV, s.HoTen, s.Lop, s.Diem, s.KetQua })
                .ToList();

            if (dgvSinhVien.Columns.Count > 0)
            {
                dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
                dgvSinhVien.Columns["HoTen"].HeaderText = "Họ tên";
                dgvSinhVien.Columns["Lop"].HeaderText = "Lớp";
                dgvSinhVien.Columns["Diem"].HeaderText = "Điểm";
                dgvSinhVien.Columns["KetQua"].HeaderText = "Kết quả";

                dgvSinhVien.Columns["MaSV"].FillWeight = 15;
                dgvSinhVien.Columns["HoTen"].FillWeight = 38;
                dgvSinhVien.Columns["Lop"].FillWeight = 16;
                dgvSinhVien.Columns["Diem"].FillWeight = 12;
                dgvSinhVien.Columns["KetQua"].FillWeight = 19;

                dgvSinhVien.Columns["Diem"].DefaultCellStyle.Format = "0.0";
                foreach (string cot in new[] { "Diem", "KetQua" })
                {
                    dgvSinhVien.Columns[cot].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSinhVien.Columns[cot].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                foreach (DataGridViewColumn col in dgvSinhVien.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvSinhVien.ClearSelection();
        }

        public void ShowStatistics(int total, double average, int passed)
        {
            lblTongSo.Text = total.ToString();
            lblDiemTB.Text = total > 0 ? average.ToString("0.00") : "-";
            lblSoDat.Text = passed + " / " + total;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message, InputField field)
        {
            MessageBox.Show(message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            TextBox o = field switch
            {
                InputField.StudentCode => txtMaSV,
                InputField.FullName => txtHoTen,
                InputField.ClassName => txtLop,
                InputField.Score => txtDiem,
                InputField.Keyword => txtTimKiem,
                _ => null
            };
            if (o != null)
            {
                o.Focus();
                o.SelectAll();
            }
        }

        public void ShowStatus(string text, bool isError)
        {
            lblThongBao.Text = text;
            lblThongBao.ForeColor = isError ? MauRotChu : MauDatChu;
        }

        public bool Confirm(string message)
        {
            return MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public void ClearInput()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtLop.Clear();
            txtDiem.Clear();
            dgvSinhVien.ClearSelection();
            txtMaSV.Focus();
        }

        public void SelectStudentRow(string studentCode)
        {
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.Cells["MaSV"].Value?.ToString() == studentCode)
                {
                    row.Selected = true;
                    dgvSinhVien.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }
        }

        // =====================================================================
        // TRANG TRÍ (chỉ liên quan giao diện nên nằm ở View)
        // =====================================================================
        private void TrangTriLuoi()
        {
            dgvSinhVien.EnableHeadersVisualStyles = false;
            dgvSinhVien.BorderStyle = BorderStyle.None;
            dgvSinhVien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSinhVien.GridColor = MauVien;
            dgvSinhVien.BackgroundColor = Color.White;

            dgvSinhVien.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSinhVien.ColumnHeadersHeight = 40;
            dgvSinhVien.ColumnHeadersDefaultCellStyle.BackColor = MauDam;
            dgvSinhVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSinhVien.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauDam;
            dgvSinhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSinhVien.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);

            dgvSinhVien.RowTemplate.Height = 34;
            dgvSinhVien.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgvSinhVien.DefaultCellStyle.SelectionBackColor = MauChon;
            dgvSinhVien.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvSinhVien.AlternatingRowsDefaultCellStyle.BackColor = MauDongXen;
        }

        private void dgvSinhVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvSinhVien.Columns[e.ColumnIndex].Name != "KetQua") return;

            bool khongDat = (e.Value as string) == "Không đạt";
            e.CellStyle.ForeColor = khongDat ? MauRotChu : MauDatChu;
            e.CellStyle.BackColor = khongDat ? MauRotNen : MauDatNen;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            fontDam ??= new Font(dgvSinhVien.Font, FontStyle.Bold);
            e.CellStyle.Font = fontDam;
        }
    }
}