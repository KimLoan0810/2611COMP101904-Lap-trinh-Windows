using System.Data;
using Microsoft.Data.SqlClient;

namespace Buoi11_Lab11
{
    /// <summary>
    /// Form quản lý lớp học: xem, thêm, sửa, xóa, tìm kiếm lớp trong bảng LOP
    /// của database EduManagerDB (SQL Server) bằng ADO.NET.
    /// </summary>
    public partial class FrmLop : Form
    {
        // =====================================================================
        // CHUỖI KẾT NỐI
        // Máy cá nhân: LAPTOP-07ILSFQP, SQL Server mặc định (không có \SQLEXPRESS),
        // đăng nhập bằng Windows Authentication.
        //   - Data Source=.            -> SQL Server mặc định trên máy này
        //   - Nếu máy dùng SQL Express -> đổi thành Data Source=.\SQLEXPRESS
        //   - Nếu dùng LocalDB         -> Data Source=(localdb)\MSSQLLocalDB
        // =====================================================================
        private readonly string connectionString =
            @"Data Source=.;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True";

        public FrmLop()
        {
            InitializeComponent();
        }

        // =====================================================================
        // F1. MỞ FORM -> TẢI DANH SÁCH KHOA VÀ DANH SÁCH LỚP
        // =====================================================================
        private void FrmLop_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            LoadData();
            ClearInput();
        }

        // ---------------------------------------------------------------------
        // CÁC HÀM DÙNG CHUNG ĐỂ LÀM VIỆC VỚI SQL SERVER
        // ---------------------------------------------------------------------

        /// <summary>Chạy câu SELECT, trả về DataTable.</summary>
        private DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);

            using SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);            // Fill tự mở và tự đóng kết nối
            return dt;
        }

        /// <summary>Chạy INSERT / UPDATE / DELETE, trả về số dòng bị ảnh hưởng.</summary>
        private int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        /// <summary>Chạy câu trả về một giá trị duy nhất (ví dụ COUNT(*)).</summary>
        private object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);

            conn.Open();
            return cmd.ExecuteScalar();
        }

        // ---------------------------------------------------------------------
        // TẢI DỮ LIỆU
        // ---------------------------------------------------------------------

        /// <summary>Đổ danh sách khoa vào ComboBox cboKhoa.</summary>
        private void LoadKhoa()
        {
            try
            {
                DataTable dt = ExecuteQuery("SELECT MaKhoa, TenKhoa FROM KHOA ORDER BY TenKhoa");

                cboKhoa.DisplayMember = "TenKhoa";  // chữ hiển thị
                cboKhoa.ValueMember = "MaKhoa";     // giá trị lưu xuống DB
                cboKhoa.DataSource = dt;
                cboKhoa.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khoa: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải danh sách lớp (kèm tên khoa và số sinh viên) lên dgvLop.
        /// keyword rỗng -> lấy tất cả; có keyword -> tìm theo mã hoặc tên lớp (F6).
        /// Trả về số lớp tìm được.
        /// </summary>
        private int LoadData(string keyword = "")
        {
            try
            {
                string sql = @"
                    SELECT l.MaLop, l.TenLop, l.MaKhoa, k.TenKhoa,
                           COUNT(sv.MaSV) AS SoSinhVien
                    FROM LOP l
                    INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa
                    LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
                    WHERE l.MaLop LIKE @kw OR l.TenLop LIKE @kw
                    GROUP BY l.MaLop, l.TenLop, l.MaKhoa, k.TenKhoa
                    ORDER BY l.MaLop";

                // F8: dùng SqlParameter, không nối chuỗi keyword vào câu SQL
                SqlParameter pKeyword = new SqlParameter("@kw", SqlDbType.NVarChar, 102)
                {
                    Value = "%" + keyword + "%"
                };

                DataTable dt = ExecuteQuery(sql, pKeyword);
                dgvLop.DataSource = dt;
                FormatGrid();
                return dt.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu lớp: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>Đặt tiêu đề cột tiếng Việt, ẩn cột MaKhoa.</summary>
        private void FormatGrid()
        {
            if (dgvLop.Columns.Count == 0) return;

            dgvLop.Columns["MaLop"].HeaderText = "Mã lớp";
            dgvLop.Columns["TenLop"].HeaderText = "Tên lớp";
            dgvLop.Columns["TenKhoa"].HeaderText = "Khoa";
            dgvLop.Columns["SoSinhVien"].HeaderText = "Số SV";
            dgvLop.Columns["MaKhoa"].Visible = false;

            dgvLop.Columns["MaLop"].FillWeight = 20;
            dgvLop.Columns["TenLop"].FillWeight = 40;
            dgvLop.Columns["TenKhoa"].FillWeight = 30;
            dgvLop.Columns["SoSinhVien"].FillWeight = 12;

            dgvLop.ClearSelection();
        }

        // ---------------------------------------------------------------------
        // KIỂM TRA DỮ LIỆU (VALIDATION)
        // ---------------------------------------------------------------------

        /// <summary>Kiểm tra rỗng và độ dài trước khi gửi xuống database.</summary>
        private bool ValidateInput()
        {
            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng nhập mã lớp.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return false;
            }

            if (ma.Length > 20 || ma.Contains(' '))
            {
                MessageBox.Show("Mã lớp tối đa 20 ký tự và không chứa khoảng trắng.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập tên lớp.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return false;
            }

            if (ten.Length > 100)
            {
                MessageBox.Show("Tên lớp tối đa 100 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return false;
            }

            if (cboKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khoa.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return false;
            }

            return true;
        }

        /// <summary>Đúng nếu mã lớp đã có trong bảng LOP.</summary>
        private bool IsMaLopExists(string maLop)
        {
            object result = ExecuteScalar(
                "SELECT COUNT(*) FROM LOP WHERE MaLop = @ma",
                new SqlParameter("@ma", SqlDbType.VarChar, 20) { Value = maLop });

            return Convert.ToInt32(result) > 0;
        }

        /// <summary>Đếm số sinh viên đang thuộc lớp.</summary>
        private int CountSinhVienByLop(string maLop)
        {
            object result = ExecuteScalar(
                "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @ma",
                new SqlParameter("@ma", SqlDbType.VarChar, 20) { Value = maLop });

            return Convert.ToInt32(result);
        }

        /// <summary>Đúng khi đang có một lớp được chọn từ lưới (txtMaLop bị khóa).</summary>
        private bool IsDangChonLop()
        {
            return txtMaLop.ReadOnly;
        }

        // =====================================================================
        // F2. CHỌN DÒNG TRÊN LƯỚI -> ĐƯA DỮ LIỆU LÊN TEXTBOX
        // =====================================================================
        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // bấm vào tiêu đề cột thì bỏ qua

            DataGridViewRow row = dgvLop.Rows[e.RowIndex];
            txtMaLop.Text = row.Cells["MaLop"].Value?.ToString();
            txtTenLop.Text = row.Cells["TenLop"].Value?.ToString();
            cboKhoa.SelectedValue = row.Cells["MaKhoa"].Value?.ToString();

            // Khóa mã lớp: MaLop là khóa chính, không cho sửa
            txtMaLop.ReadOnly = true;
            txtTenLop.Focus();
        }

        // =====================================================================
        // F3. THÊM LỚP
        // =====================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            string maKhoa = cboKhoa.SelectedValue.ToString();

            try
            {
                if (IsMaLopExists(ma))
                {
                    MessageBox.Show("Mã lớp \"" + ma + "\" đã tồn tại.", "Trùng mã",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLop.Focus();
                    return;
                }

                string sql = "INSERT INTO LOP (MaLop, TenLop, MaKhoa) VALUES (@ma, @ten, @khoa)";
                int rows = ExecuteNonQuery(sql,
                    new SqlParameter("@ma", SqlDbType.VarChar, 20) { Value = ma },
                    new SqlParameter("@ten", SqlDbType.NVarChar, 100) { Value = ten },
                    new SqlParameter("@khoa", SqlDbType.VarChar, 20) { Value = maKhoa });

                if (rows > 0)
                {
                    MessageBox.Show("Thêm lớp thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm lớp: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // F4. SỬA LỚP (theo mã lớp đang chọn)
        // =====================================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!IsDangChonLop())
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa trong danh sách.", "Chưa chọn lớp",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            string maKhoa = cboKhoa.SelectedValue.ToString();

            try
            {
                string sql = "UPDATE LOP SET TenLop = @ten, MaKhoa = @khoa WHERE MaLop = @ma";
                int rows = ExecuteNonQuery(sql,
                    new SqlParameter("@ma", SqlDbType.VarChar, 20) { Value = ma },
                    new SqlParameter("@ten", SqlDbType.NVarChar, 100) { Value = ten },
                    new SqlParameter("@khoa", SqlDbType.VarChar, 20) { Value = maKhoa });

                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật lớp thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp cần sửa.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật lớp: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // F5. XÓA LỚP (hỏi xác nhận, không xóa lớp đang có sinh viên)
        // =====================================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!IsDangChonLop())
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa trong danh sách.", "Chưa chọn lớp",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ma = txtMaLop.Text.Trim();

            try
            {
                int soSinhVien = CountSinhVienByLop(ma);
                if (soSinhVien > 0)
                {
                    MessageBox.Show("Không thể xóa lớp \"" + ma + "\" vì đang có "
                        + soSinhVien + " sinh viên.", "Không thể xóa",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa lớp \"" + ma + "\"?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                int rows = ExecuteNonQuery(
                    "DELETE FROM LOP WHERE MaLop = @ma",
                    new SqlParameter("@ma", SqlDbType.VarChar, 20) { Value = ma });

                if (rows > 0)
                {
                    MessageBox.Show("Xóa lớp thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                    LoadData();
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                // 547 = vi phạm khóa ngoại (phòng trường hợp có sinh viên vừa được thêm)
                MessageBox.Show("Không thể xóa vì lớp đang được bảng khác tham chiếu.",
                    "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa lớp: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // F6. TÌM KIẾM theo mã lớp hoặc tên lớp
        // =====================================================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            int count = LoadData(keyword);

            if (count == 0)
            {
                MessageBox.Show("Không tìm thấy lớp phù hợp với \"" + keyword + "\".",
                    "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Nhấn Enter trong ô tìm kiếm cũng tìm luôn.</summary>
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // tắt tiếng "bíp"
                btnTimKiem.PerformClick();
            }
        }

        // =====================================================================
        // F7. LÀM MỚI: xóa ô nhập, mở khóa txtMaLop, tải lại dữ liệu
        // =====================================================================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            txtTimKiem.Clear();
            LoadData();
        }

        /// <summary>Xóa nội dung nhập và mở khóa txtMaLop.</summary>
        private void ClearInput()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            cboKhoa.SelectedIndex = -1;
            txtMaLop.ReadOnly = false;
            dgvLop.ClearSelection();
            txtMaLop.Focus();
        }
    }
}