using EduManager.BLL;
using EduManager.Models;

namespace EduManager.GUI
{
    /// <summary>
    /// GUI - Form quản lý môn học.
    /// Chỉ nhận dữ liệu từ control, gọi MonHocBLL và hiển thị kết quả.
    /// Không có câu SQL, không có quy tắc nghiệp vụ ở đây.
    /// </summary>
    public partial class FrmMonHoc : Form
    {
        private readonly MonHocBLL monHocBLL = new MonHocBLL();

        // Danh sách đang hiển thị trên lưới (dùng để lấy lại đối tượng khi click dòng)
        private List<MonHoc> danhSachHienThi = new List<MonHoc>();

        // ---- Màu giao diện ----
        private static readonly Color MauChinh = Color.FromArgb(41, 128, 185);
        private static readonly Color MauDam = Color.FromArgb(44, 62, 80);
        private static readonly Color MauDongXen = Color.FromArgb(245, 248, 252);
        private static readonly Color MauChon = Color.FromArgb(214, 234, 248);
        private static readonly Color MauVien = Color.FromArgb(226, 231, 237);
        private static readonly Color MauXanhChu = Color.FromArgb(30, 132, 73);
        private static readonly Color MauXanhNen = Color.FromArgb(230, 247, 237);
        private static readonly Color MauXamChu = Color.FromArgb(127, 140, 141);
        private static readonly Color MauXamNen = Color.FromArgb(236, 240, 241);
        private Font fontDam;

        public FrmMonHoc()
        {
            InitializeComponent();
        }

        // =====================================================================
        // 1. MỞ FORM -> LOAD DANH SÁCH
        // =====================================================================
        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            nudSoTinChi.Minimum = MonHocBLL.SO_TIN_CHI_MIN;
            nudSoTinChi.Maximum = MonHocBLL.SO_TIN_CHI_MAX;

            TrangTriLuoi();
            ClearInput();
            LoadData();
        }

        /// <summary>Tải danh sách (có từ khóa thì tìm kiếm). Trả về số dòng.</summary>
        private int LoadData(string tuKhoa = null)
        {
            try
            {
                danhSachHienThi = string.IsNullOrWhiteSpace(tuKhoa)
                    ? monHocBLL.LayDanhSach()
                    : monHocBLL.TimKiem(tuKhoa);

                HienThiDanhSach();
                return danhSachHienThi.Count;
            }
            catch (Exception ex)
            {
                danhSachHienThi = new List<MonHoc>();
                HienThiDanhSach();
                SetTrangThai("Không tải được dữ liệu.", true);
                MessageBox.Show(ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>Đổ danh sách lên lưới với tiêu đề cột tiếng Việt.</summary>
        private void HienThiDanhSach()
        {
            dgvMonHoc.DataSource = danhSachHienThi
                .Select(m => new
                {
                    m.MaMonHoc,
                    m.TenMonHoc,
                    m.SoTinChi,
                    TrangThai = m.TrangThai ? "Đang sử dụng" : "Ngừng sử dụng"
                })
                .ToList();

            if (dgvMonHoc.Columns.Count > 0)
            {
                dgvMonHoc.Columns["MaMonHoc"].HeaderText = "Mã môn học";
                dgvMonHoc.Columns["TenMonHoc"].HeaderText = "Tên môn học";
                dgvMonHoc.Columns["SoTinChi"].HeaderText = "Số tín chỉ";
                dgvMonHoc.Columns["TrangThai"].HeaderText = "Trạng thái";

                dgvMonHoc.Columns["MaMonHoc"].FillWeight = 18;
                dgvMonHoc.Columns["TenMonHoc"].FillWeight = 45;
                dgvMonHoc.Columns["SoTinChi"].FillWeight = 14;
                dgvMonHoc.Columns["TrangThai"].FillWeight = 23;

                foreach (string cot in new[] { "SoTinChi", "TrangThai" })
                {
                    dgvMonHoc.Columns[cot].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvMonHoc.Columns[cot].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                foreach (DataGridViewColumn col in dgvMonHoc.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvMonHoc.ClearSelection();
            lblTongSo.Text = monHocBLL.ThongKe(danhSachHienThi);
        }

        // =====================================================================
        // 6. CHỌN DÒNG -> ĐƯA DỮ LIỆU LÊN Ô NHẬP
        // =====================================================================
        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // bấm vào tiêu đề cột

            string ma = dgvMonHoc.Rows[e.RowIndex].Cells["MaMonHoc"].Value?.ToString();
            MonHoc mh = danhSachHienThi.FirstOrDefault(m => m.MaMonHoc == ma);
            if (mh == null) return;

            txtMaMonHoc.Text = mh.MaMonHoc;
            txtTenMonHoc.Text = mh.TenMonHoc;
            nudSoTinChi.Value = Math.Clamp(mh.SoTinChi, MonHocBLL.SO_TIN_CHI_MIN, MonHocBLL.SO_TIN_CHI_MAX);
            chkTrangThai.Checked = mh.TrangThai;

            // Mã là khóa chính -> khóa lại, không cho sửa
            txtMaMonHoc.ReadOnly = true;
            txtMaMonHoc.BackColor = MauXamNen;
            lblCheDo.Text = "Đang chọn: " + mh.MaMonHoc;
            lblCheDo.ForeColor = MauChinh;
            txtTenMonHoc.Focus();
        }

        private bool DangChonMonHoc()
        {
            return txtMaMonHoc.ReadOnly;
        }

        /// <summary>Gom dữ liệu trên form thành đối tượng MonHoc (không kiểm tra ở đây).</summary>
        private MonHoc LayMonHocTuForm()
        {
            return new MonHoc
            {
                MaMonHoc = txtMaMonHoc.Text,
                TenMonHoc = txtTenMonHoc.Text,
                SoTinChi = (int)nudSoTinChi.Value,
                TrangThai = chkTrangThai.Checked
            };
        }

        // =====================================================================
        // 2. THÊM
        // =====================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (DangChonMonHoc())
            {
                MessageBox.Show("Bạn đang chọn một môn có sẵn. Hãy bấm \"Làm mới\" rồi nhập môn học mới.",
                    "Thêm môn học", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MonHoc mh = LayMonHocTuForm();
            KetQuaXuLy kq = monHocBLL.Them(mh);
            XuLyKetQua(kq, "Thêm môn học", mh.MaMonHoc);
        }

        // =====================================================================
        // 3. SỬA
        // =====================================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!DangChonMonHoc())
            {
                MessageBox.Show("Vui lòng chọn môn học cần sửa trong danh sách.",
                    "Chưa chọn môn học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MonHoc mh = LayMonHocTuForm();
            KetQuaXuLy kq = monHocBLL.Sua(mh);
            XuLyKetQua(kq, "Sửa môn học", mh.MaMonHoc);
        }

        // =====================================================================
        // 4. XÓA (hỏi xác nhận)
        // =====================================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!DangChonMonHoc())
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa trong danh sách.",
                    "Chưa chọn môn học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ma = txtMaMonHoc.Text;
            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa môn học \"" + ma + " - " + txtTenMonHoc.Text + "\"?\n"
                + "Thao tác này không thể hoàn tác.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (xacNhan != DialogResult.Yes) return;

            KetQuaXuLy kq = monHocBLL.Xoa(ma);
            XuLyKetQua(kq, "Xóa môn học", null);
        }

        /// <summary>Hiển thị kết quả từ BLL: thành công thì tải lại, lỗi thì đưa con trỏ về ô sai.</summary>
        private void XuLyKetQua(KetQuaXuLy kq, string tieuDe, string maCanChon)
        {
            if (kq.ThanhCong)
            {
                SetTrangThai(kq.ThongBao, false);
                MessageBox.Show(kq.ThongBao, tieuDe, MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTimKiem.Clear();
                ClearInput();
                LoadData();
                ChonDongTheoMa(maCanChon);
            }
            else
            {
                SetTrangThai(kq.ThongBao.Split('\n')[0], true);
                MessageBox.Show(kq.ThongBao, tieuDe, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                switch (kq.TruongLoi)
                {
                    case "MaMonHoc": txtMaMonHoc.Focus(); txtMaMonHoc.SelectAll(); break;
                    case "TenMonHoc": txtTenMonHoc.Focus(); txtTenMonHoc.SelectAll(); break;
                    case "SoTinChi": nudSoTinChi.Focus(); break;
                }
            }
        }

        /// <summary>Tô chọn dòng vừa thêm / sửa để người dùng thấy ngay.</summary>
        private void ChonDongTheoMa(string ma)
        {
            if (string.IsNullOrEmpty(ma)) return;
            ma = ma.Trim().ToUpper();

            foreach (DataGridViewRow row in dgvMonHoc.Rows)
            {
                if (row.Cells["MaMonHoc"].Value?.ToString() == ma)
                {
                    row.Selected = true;
                    dgvMonHoc.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }
        }

        // =====================================================================
        // 5. TÌM KIẾM
        // =====================================================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            int soDong = LoadData(tuKhoa);

            if (tuKhoa.Length == 0)
            {
                SetTrangThai("Đang hiển thị toàn bộ môn học.", false);
            }
            else if (soDong == 0)
            {
                SetTrangThai("Không tìm thấy môn học với từ khóa \"" + tuKhoa + "\".", true);
                MessageBox.Show("Không tìm thấy môn học nào có mã hoặc tên chứa \"" + tuKhoa + "\".",
                    "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SetTrangThai("Tìm thấy " + soDong + " môn học với từ khóa \"" + tuKhoa + "\".", false);
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTimKiem.PerformClick();
            }
        }

        // =====================================================================
        // 7. LÀM MỚI
        // =====================================================================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            ClearInput();
            LoadData();
            SetTrangThai("Đã làm mới danh sách.", false);
        }

        /// <summary>Xóa ô nhập, mở khóa mã môn học, về chế độ thêm mới.</summary>
        private void ClearInput()
        {
            txtMaMonHoc.Clear();
            txtTenMonHoc.Clear();
            nudSoTinChi.Value = 3;
            chkTrangThai.Checked = true;

            txtMaMonHoc.ReadOnly = false;
            txtMaMonHoc.BackColor = Color.White;
            lblCheDo.Text = "Chế độ: thêm môn học mới";
            lblCheDo.ForeColor = MauXamChu;

            dgvMonHoc.ClearSelection();
            txtMaMonHoc.Focus();
        }

        private void SetTrangThai(string noiDung, bool laLoi)
        {
            lblThongBao.Text = noiDung;
            lblThongBao.ForeColor = laLoi ? Color.Firebrick : MauXanhChu;
        }

        // =====================================================================
        // TRANG TRÍ LƯỚI
        // =====================================================================
        private void TrangTriLuoi()
        {
            dgvMonHoc.EnableHeadersVisualStyles = false;
            dgvMonHoc.BorderStyle = BorderStyle.None;
            dgvMonHoc.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMonHoc.GridColor = MauVien;
            dgvMonHoc.BackgroundColor = Color.White;

            dgvMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMonHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMonHoc.ColumnHeadersHeight = 40;
            dgvMonHoc.ColumnHeadersDefaultCellStyle.BackColor = MauDam;
            dgvMonHoc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMonHoc.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauDam;
            dgvMonHoc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvMonHoc.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);

            dgvMonHoc.RowTemplate.Height = 34;
            dgvMonHoc.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgvMonHoc.DefaultCellStyle.SelectionBackColor = MauChon;
            dgvMonHoc.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvMonHoc.AlternatingRowsDefaultCellStyle.BackColor = MauDongXen;
        }

        /// <summary>Cột Trạng thái dạng nhãn màu: xanh = đang dùng, xám = ngừng.</summary>
        private void dgvMonHoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvMonHoc.Columns[e.ColumnIndex].Name != "TrangThai") return;

            bool dangDung = (e.Value as string) == "Đang sử dụng";
            e.CellStyle.ForeColor = dangDung ? MauXanhChu : MauXamChu;
            e.CellStyle.BackColor = dangDung ? MauXanhNen : MauXamNen;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            fontDam ??= new Font(dgvMonHoc.Font, FontStyle.Bold);
            e.CellStyle.Font = fontDam;
        }
    }
}