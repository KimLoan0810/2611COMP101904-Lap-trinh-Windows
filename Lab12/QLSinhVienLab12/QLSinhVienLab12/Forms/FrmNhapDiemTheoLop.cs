using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Data.SqlClient;
using QLSinhVienLab12.DAL;

namespace QLSinhVienLab12.Forms
{
    /// <summary>
    /// Form nhập điểm theo lớp: chọn lớp + môn, tải danh sách sinh viên,
    /// nhập điểm trên lưới và lưu tất cả bằng một transaction.
    /// </summary>
    public partial class FrmNhapDiemTheoLop : Form
    {
        private readonly KetQuaDAL ketQuaDAL = new KetQuaDAL();

        // Cầu nối giữa DataTable (dữ liệu trong RAM) và DataGridView
        private readonly BindingSource ketQuaSource = new BindingSource();

        // Lớp / môn của danh sách ĐANG hiển thị trên lưới (lưu theo 2 giá trị này)
        private string loadedMaLop;
        private string loadedMaMon;
        private string loadedTenLop;
        private string loadedTenMon;

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
        }

        // =====================================================================
        // 1. MỞ FORM: load lớp và môn học vào ComboBox
        // =====================================================================
        private void FrmNhapDiemTheoLop_Load(object sender, EventArgs e)
        {
            dgvKetQua.AutoGenerateColumns = true;
            dgvKetQua.DataSource = ketQuaSource;
            ketQuaSource.ListChanged += (s, ev) => CapNhatThongKe();

            LoadComboBox();
        }

        private void LoadComboBox()
        {
            try
            {
                // Đặt DisplayMember / ValueMember TRƯỚC DataSource
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.DataSource = ketQuaDAL.GetLop();

                cboMonHoc.DisplayMember = "TenMon";
                cboMonHoc.ValueMember = "MaMon";
                cboMonHoc.DataSource = ketQuaDAL.GetMonHoc();

                SetTrangThai("Đã tải " + cboLop.Items.Count + " lớp và " + cboMonHoc.Items.Count
                    + " môn học. Chọn lớp, môn rồi bấm \"Tải danh sách\".", false);
            }
            catch (Exception ex)
            {
                SetTrangThai("Không kết nối được database.", true);
                MessageBox.Show("Lỗi tải lớp / môn học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // 2. TẢI DANH SÁCH sinh viên theo lớp + môn
        // =====================================================================
        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            if (CoThayDoiChuaLuu())
            {
                DialogResult result = MessageBox.Show(
                    "Điểm vừa nhập chưa được lưu. Tải lại sẽ mất các thay đổi này. Tiếp tục?",
                    "Chưa lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;
            }

            TaiDanhSach();
        }

        private void TaiDanhSach()
        {
            string maLop = cboLop.SelectedValue?.ToString();
            string maMon = cboMonHoc.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(maLop) || string.IsNullOrEmpty(maMon))
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable table = ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);

                txtLocTen.Clear();
                ketQuaSource.Filter = null;
                ketQuaSource.DataSource = table;     // binding: DataTable -> BindingSource -> lưới

                loadedMaLop = maLop;
                loadedMaMon = maMon;
                loadedTenLop = cboLop.Text;
                loadedTenMon = cboMonHoc.Text;

                FormatGrid();
                CapNhatThongKe();
                SetTrangThai("Đang nhập điểm: lớp " + loadedTenLop + " - môn " + loadedTenMon
                    + " (" + table.Rows.Count + " sinh viên).", false);
            }
            catch (Exception ex)
            {
                SetTrangThai("Tải danh sách thất bại.", true);
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Tiêu đề cột, cột chỉ đọc, định dạng điểm.</summary>
        private void FormatGrid()
        {
            if (dgvKetQua.Columns.Count == 0) return;

            DataGridViewColumn colMaSV = dgvKetQua.Columns["MaSV"];
            DataGridViewColumn colHoTen = dgvKetQua.Columns["HoTen"];
            DataGridViewColumn colDiem = dgvKetQua.Columns["Diem"];
            DataGridViewColumn colGhiChu = dgvKetQua.Columns["GhiChu"];

            colMaSV.HeaderText = "Mã SV";
            colHoTen.HeaderText = "Họ tên";
            colDiem.HeaderText = "Điểm (0 - 10)";
            colGhiChu.HeaderText = "Ghi chú";

            // Chỉ cho sửa Điểm và Ghi chú
            colMaSV.ReadOnly = true;
            colHoTen.ReadOnly = true;
            colMaSV.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            colHoTen.DefaultCellStyle.BackColor = Color.WhiteSmoke;

            colDiem.DefaultCellStyle.Format = "0.##";
            colDiem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDiem.DefaultCellStyle.Font = new Font(dgvKetQua.Font, FontStyle.Bold);

            colMaSV.FillWeight = 15;
            colHoTen.FillWeight = 35;
            colDiem.FillWeight = 15;
            colGhiChu.FillWeight = 35;
        }

        // =====================================================================
        // 3. NHẬP ĐIỂM: báo lỗi thân thiện khi gõ chữ vào cột Điểm
        // =====================================================================
        private void dgvKetQua_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;   // giữ ô ở chế độ sửa để người dùng gõ lại (Esc để hủy)

            MessageBox.Show("Điểm phải là số, dùng dấu chấm thập phân (ví dụ 8.5).",
                "Điểm không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>Tô màu ô điểm: vàng = chưa nhập, đỏ = ngoài 0..10.</summary>
        private void dgvKetQua_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvKetQua.Columns[e.ColumnIndex].Name != "Diem") return;

            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.CellStyle.BackColor = Color.LightYellow;
            }
            else if (e.Value is double diem && (diem < 0 || diem > 10))
            {
                e.CellStyle.BackColor = Color.MistyRose;
                e.CellStyle.ForeColor = Color.Firebrick;
            }
        }

        // =====================================================================
        // 4. KIỂM TRA ĐIỂM: không rỗng, là số, trong 0..10
        //    Trả về null nếu hợp lệ; ngược lại trả về thông báo + dòng bị lỗi.
        // =====================================================================
        private string ValidateData(DataTable table, out DataRow dongLoi)
        {
            dongLoi = null;

            foreach (DataRow row in table.Rows)
            {
                string maSV = row["MaSV"].ToString();
                string hoTen = row["HoTen"].ToString();
                object giaTri = row["Diem"];

                if (giaTri == null || giaTri == DBNull.Value)
                {
                    dongLoi = row;
                    return "Sinh viên " + maSV + " - " + hoTen + " chưa có điểm.";
                }

                if (!double.TryParse(Convert.ToString(giaTri), out double diem))
                {
                    dongLoi = row;
                    return "Điểm của sinh viên " + maSV + " - " + hoTen + " không phải là số.";
                }

                if (diem < 0 || diem > 10)
                {
                    dongLoi = row;
                    return "Điểm của sinh viên " + maSV + " - " + hoTen + " là " + diem
                        + ", phải nằm trong khoảng 0 đến 10.";
                }

                if (row["GhiChu"].ToString().Length > 255)
                {
                    dongLoi = row;
                    return "Ghi chú của sinh viên " + maSV + " dài quá 255 ký tự.";
                }
            }

            return null;
        }

        // =====================================================================
        // 5-6-7. LƯU TẤT CẢ bằng transaction (commit / rollback)
        // =====================================================================
        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            LuuTatCa();
        }

        private void LuuTatCa()
        {
            if (ketQuaSource.DataSource is not DataTable table || loadedMaMon == null)
            {
                MessageBox.Show("Chưa có danh sách để lưu. Hãy bấm \"Tải danh sách\" trước.",
                    "Chưa tải danh sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đẩy giá trị đang gõ dở trên lưới về DataTable
            dgvKetQua.EndEdit();
            ketQuaSource.EndEdit();

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Lớp này chưa có sinh viên.", "Không có dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra phía Form (có thể tắt bằng ô "demo rollback")
            if (!chkBoQuaKiemTra.Checked)
            {
                string loi = ValidateData(table, out DataRow dongLoi);
                if (loi != null)
                {
                    ChonDongLoi(dongLoi);
                    SetTrangThai("Chưa lưu: " + loi, true);
                    MessageBox.Show(loi + "\nChưa lưu dòng nào.", "Dữ liệu không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                int count = ketQuaDAL.SaveAll(loadedMaMon, table);   // COMMIT bên trong DAL

                SetTrangThai("Đã lưu " + count + " dòng (COMMIT) - lớp " + loadedTenLop
                    + ", môn " + loadedTenMon + ".", false);
                MessageBox.Show("Đã lưu thành công " + count + " dòng.", "Lưu thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                TaiDanhSach();   // tải lại từ database để thấy dữ liệu sau khi lưu
            }
            catch (SqlException ex)
            {
                SetTrangThai("Lưu thất bại - đã ROLLBACK, không dòng nào được lưu.", true);
                MessageBox.Show("Lưu thất bại, toàn bộ thao tác đã được hủy (ROLLBACK).\n\nLỗi từ SQL Server: "
                    + ex.Message, "Rollback", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SetTrangThai("Lưu thất bại - đã ROLLBACK.", true);
                MessageBox.Show("Không thể lưu dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>Chọn và cuộn tới ô Điểm của dòng bị lỗi.</summary>
        private void ChonDongLoi(DataRow dongLoi)
        {
            if (dongLoi == null) return;

            foreach (DataGridViewRow gridRow in dgvKetQua.Rows)
            {
                if (gridRow.DataBoundItem is DataRowView view && view.Row == dongLoi)
                {
                    dgvKetQua.CurrentCell = gridRow.Cells["Diem"];
                    return;
                }
            }

            // Dòng lỗi đang bị ẩn bởi bộ lọc -> bỏ lọc rồi chọn lại
            if (!string.IsNullOrEmpty(txtLocTen.Text))
            {
                txtLocTen.Clear();
                ChonDongLoi(dongLoi);
            }
        }

        private bool CoThayDoiChuaLuu()
        {
            return ketQuaSource.DataSource is DataTable table && table.GetChanges() != null;
        }

        // =====================================================================
        // MỞ RỘNG: lọc nhanh theo tên / mã và thống kê
        // =====================================================================
        private void txtLocTen_TextChanged(object sender, EventArgs e)
        {
            if (ketQuaSource.DataSource == null) return;

            string tuKhoa = txtLocTen.Text.Trim();
            if (tuKhoa.Length == 0)
            {
                ketQuaSource.Filter = null;
            }
            else
            {
                string an = EscapeFilter(tuKhoa);
                ketQuaSource.Filter = "HoTen LIKE '%" + an + "%' OR MaSV LIKE '%" + an + "%'";
            }
        }

        /// <summary>Thoát ký tự đặc biệt trong biểu thức lọc của DataView.</summary>
        private static string EscapeFilter(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if (c == '\'') sb.Append("''");
                else if (c == '*' || c == '%' || c == '[' || c == ']') sb.Append('[').Append(c).Append(']');
                else sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>Sĩ số, số SV đã có điểm hợp lệ, điểm trung bình.</summary>
        private void CapNhatThongKe()
        {
            if (ketQuaSource.DataSource is not DataTable table)
            {
                lblThongKe.Text = "";
                return;
            }

            int siSo = table.Rows.Count;
            int coDiem = 0;
            double tong = 0;

            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                if (row["Diem"] is double diem && diem >= 0 && diem <= 10)
                {
                    coDiem++;
                    tong += diem;
                }
            }

            string dtb = coDiem > 0 ? (tong / coDiem).ToString("0.00") : "-";
            lblThongKe.Text = "Sĩ số: " + siSo + "   |   Có điểm: " + coDiem + "   |   ĐTB: " + dtb;
        }

        private void SetTrangThai(string noiDung, bool laLoi)
        {
            lblTrangThai.Text = noiDung;
            lblTrangThai.ForeColor = laLoi ? Color.Firebrick : Color.DarkGreen;
        }
    }
}