using System.Diagnostics;
using System.Globalization;
using System.Text;
using StudentReportDemo.Models;

namespace StudentReportDemo.Forms
{
    /// <summary>
    /// Form báo cáo danh sách sinh viên theo lớp.
    /// Mọi thao tác lọc, sắp xếp, nhóm, thống kê đều dùng LINQ.
    /// </summary>
    public partial class FrmBaoCaoSinhVien : Form
    {
        private const string TAT_CA_LOP = "";          // MaLop của mục "(Tất cả các lớp)"
        private const string KQ_TAT_CA = "Tất cả";
        private const string KQ_DAT = "Đạt";
        private const string KQ_KHONG_DAT = "Không đạt";

        // Dữ liệu gốc
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        // Sinh viên đang hiển thị ở chế độ báo cáo (dùng cho thống kê dưới đáy)
        private List<SinhVien> danhSachDangHienThi = new List<SinhVien>();

        // true = lưới đang hiện bảng "Thống kê theo lớp"
        private bool dangXemThongKe = false;

        // Chặn sự kiện tự lọc chạy khi form đang khởi tạo ComboBox
        private bool dangKhoiTao = true;

        // Font đậm cho cột Kết quả (tạo một lần, dùng lại)
        private Font fontDam;

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        // =====================================================================
        // 1. MỞ FORM
        // =====================================================================
        private void FrmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            TaoDuLieuMau();
            LoadComboBox();
            TrangTriLuoi();
            dangKhoiTao = false;

            XemBaoCao(false);
        }

        // ---------------------------------------------------------------------
        // Màu dùng chung cho giao diện
        // ---------------------------------------------------------------------
        private static readonly Color MauDam = Color.FromArgb(44, 62, 80);        // tiêu đề cột
        private static readonly Color MauDongXen = Color.FromArgb(245, 248, 252); // dòng chẵn
        private static readonly Color MauChon = Color.FromArgb(214, 234, 248);    // dòng đang chọn
        private static readonly Color MauVien = Color.FromArgb(226, 231, 237);    // đường kẻ
        private static readonly Color MauDatNen = Color.FromArgb(230, 247, 237);
        private static readonly Color MauDatChu = Color.FromArgb(30, 132, 73);
        private static readonly Color MauRotNen = Color.FromArgb(253, 236, 234);
        private static readonly Color MauRotChu = Color.FromArgb(192, 57, 43);

        /// <summary>Kiểu dáng DataGridView: tiêu đề cột màu đậm, dòng xen màu, dòng cao.</summary>
        private void TrangTriLuoi()
        {
            dgvBaoCao.EnableHeadersVisualStyles = false;   // cho phép tự tô màu tiêu đề cột
            dgvBaoCao.BorderStyle = BorderStyle.None;
            dgvBaoCao.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBaoCao.GridColor = MauVien;
            dgvBaoCao.BackgroundColor = Color.White;

            dgvBaoCao.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBaoCao.ColumnHeadersHeight = 40;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.BackColor = MauDam;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauDam;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvBaoCao.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);

            dgvBaoCao.RowTemplate.Height = 34;
            dgvBaoCao.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgvBaoCao.DefaultCellStyle.SelectionBackColor = MauChon;
            dgvBaoCao.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvBaoCao.AlternatingRowsDefaultCellStyle.BackColor = MauDongXen;
        }

        /// <summary>15 sinh viên, 3 lớp.</summary>
        private void TaoDuLieuMau()
        {
            danhSachSinhVien = new List<SinhVien>
            {
                new SinhVien { MaSV = "SV001", HoTen = "Nguyễn Văn An",   MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 8.2 },
                new SinhVien { MaSV = "SV002", HoTen = "Trần Thị Bình",   MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 6.5 },
                new SinhVien { MaSV = "SV003", HoTen = "Lê Minh Cường",   MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 4.8 },
                new SinhVien { MaSV = "SV004", HoTen = "Phạm Thanh Dung", MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 9.1 },
                new SinhVien { MaSV = "SV005", HoTen = "Võ Thị Hồng",     MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 5.0 },

                new SinhVien { MaSV = "SV006", HoTen = "Hoàng Quốc Huy",  MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4 },
                new SinhVien { MaSV = "SV007", HoTen = "Võ Gia Khang",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 3.9 },
                new SinhVien { MaSV = "SV008", HoTen = "Đặng Minh Khôi",  MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 5.5 },
                new SinhVien { MaSV = "SV009", HoTen = "Bùi Thảo Linh",   MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 8.0 },
                new SinhVien { MaSV = "SV010", HoTen = "Trương Văn Nam",  MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 4.5 },

                new SinhVien { MaSV = "SV011", HoTen = "Ngô Tuấn Minh",   MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 6.0 },
                new SinhVien { MaSV = "SV012", HoTen = "Đỗ Bảo Ngọc",     MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 9.3 },
                new SinhVien { MaSV = "SV013", HoTen = "Huỳnh Gia Phúc",  MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 4.2 },
                new SinhVien { MaSV = "SV014", HoTen = "Mai Anh Thư",     MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 7.8 },
                new SinhVien { MaSV = "SV015", HoTen = "Lý Thanh Tâm",    MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 6.0 },
            };
        }

        /// <summary>Đổ danh sách lớp (lấy bằng LINQ) và lựa chọn kết quả vào ComboBox.</summary>
        private void LoadComboBox()
        {
            // LINQ: Select lấy (mã, tên) lớp -> Distinct bỏ trùng -> OrderBy sắp xếp
            var dsLop = danhSachSinhVien
                .Select(sv => new { sv.MaLop, sv.TenLop })
                .Distinct()
                .OrderBy(lop => lop.MaLop)
                .Prepend(new { MaLop = TAT_CA_LOP, TenLop = "(Tất cả các lớp)" })
                .ToList();

            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            cboLop.DataSource = dsLop;
            cboLop.SelectedIndex = 1;   // mặc định chọn lớp đầu tiên

            cboKetQua.Items.Clear();
            cboKetQua.Items.AddRange(new object[] { KQ_TAT_CA, KQ_DAT, KQ_KHONG_DAT });
            cboKetQua.SelectedIndex = 0;
        }

        // =====================================================================
        // 2-3. XEM BÁO CÁO: lọc theo lớp, kết quả, từ khóa; sắp xếp giảm dần theo điểm
        // =====================================================================
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            XemBaoCao(true);
        }

        // Tự cập nhật khi đổi điều kiện (không bật hộp thông báo mỗi lần gõ phím)
        private void cboLop_SelectionChangeCommitted(object sender, EventArgs e) => XemBaoCao(false);
        private void cboKetQua_SelectionChangeCommitted(object sender, EventArgs e) => XemBaoCao(false);

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            if (!dangKhoiTao) XemBaoCao(false);
        }

        /// <param name="thongBaoKhiRong">true: bật MessageBox nếu không có kết quả (khi bấm nút).</param>
        private void XemBaoCao(bool thongBaoKhiRong)
        {
            string maLop = cboLop.SelectedValue as string ?? TAT_CA_LOP;
            string ketQua = cboKetQua.SelectedItem as string ?? KQ_TAT_CA;
            string tuKhoa = txtTuKhoa.Text.Trim();

            // ---- LINQ lọc: mỗi điều kiện thêm một Where ----
            IEnumerable<SinhVien> query = danhSachSinhVien;

            if (maLop != TAT_CA_LOP)
                query = query.Where(sv => sv.MaLop == maLop);

            if (ketQua != KQ_TAT_CA)
                query = query.Where(sv => sv.KetQua == ketQua);

            if (tuKhoa.Length > 0)
                query = query.Where(sv =>
                    sv.MaSV.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase) ||
                    sv.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase));

            // ---- LINQ sắp xếp: điểm giảm dần, cùng điểm thì theo họ tên ----
            danhSachDangHienThi = query
                .OrderByDescending(sv => sv.Diem)
                .ThenBy(sv => sv.HoTen)
                .ToList();

            // ---- LINQ chọn cột hiển thị, đánh số thứ tự ----
            var baoCao = danhSachDangHienThi
                .Select((sv, index) => new
                {
                    STT = index + 1,
                    sv.MaSV,
                    sv.HoTen,
                    sv.TenLop,
                    sv.Diem,
                    sv.KetQua
                })
                .ToList();

            dangXemThongKe = false;
            dgvBaoCao.DataSource = baoCao;
            FormatGrid();

            lblTieuDe.Text = "BÁO CÁO " + cboLop.Text.ToUpper() + " - " + ketQua.ToUpper();
            CapNhatThongKe(danhSachDangHienThi);

            // 6. Không có dữ liệu phù hợp -> thông báo rõ
            if (baoCao.Count == 0 && thongBaoKhiRong)
            {
                MessageBox.Show(
                    "Không có sinh viên nào phù hợp với điều kiện:\n"
                    + "- Lớp: " + cboLop.Text + "\n"
                    + "- Kết quả: " + ketQua + "\n"
                    + "- Từ khóa: " + (tuKhoa.Length > 0 ? "\"" + tuKhoa + "\"" : "(trống)"),
                    "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Thống kê nhanh trên danh sách ĐANG HIỂN THỊ (LINQ Count, Average, Max).</summary>
        private void CapNhatThongKe(List<SinhVien> ds)
        {
            if (ds.Count == 0)
            {
                lblThongKe.Text = "Không có sinh viên phù hợp với điều kiện lọc.";
                lblThongKe.ForeColor = Color.Firebrick;
                return;
            }

            int tongSo = ds.Count;
            int soDat = ds.Count(sv => sv.Diem >= 5);
            int soKhongDat = ds.Count(sv => sv.Diem < 5);
            double diemTB = ds.Average(sv => sv.Diem);     // an toàn vì ds không rỗng
            double diemCao = ds.Max(sv => sv.Diem);

            lblThongKe.Text = "Tổng số: " + tongSo + " SV   |   Đạt: " + soDat
                + "   |   Không đạt: " + soKhongDat
                + "   |   Điểm TB: " + diemTB.ToString("0.00")
                + "   |   Cao nhất: " + diemCao.ToString("0.0");
            lblThongKe.ForeColor = Color.DarkGreen;
        }

        // =====================================================================
        // 4. THỐNG KÊ THEO LỚP: GroupBy
        // =====================================================================
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeTheoLop();
        }

        private void ThongKeTheoLop()
        {
            var thongKe = danhSachSinhVien
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .Select(g => new
                {
                    g.Key.MaLop,
                    g.Key.TenLop,
                    SoLuong = g.Count(),
                    SoDat = g.Count(sv => sv.Diem >= 5),
                    SoKhongDat = g.Count(sv => sv.Diem < 5),
                    TiLeDat = Math.Round(100.0 * g.Count(sv => sv.Diem >= 5) / g.Count(), 1),
                    DiemTB = Math.Round(g.Average(sv => sv.Diem), 2),
                    DiemCaoNhat = g.Max(sv => sv.Diem)
                })
                .OrderBy(x => x.MaLop)
                .ToList();

            dangXemThongKe = true;
            dgvBaoCao.DataSource = thongKe;
            FormatGrid();

            lblTieuDe.Text = "THỐNG KÊ THEO LỚP (" + danhSachSinhVien.Count + " SINH VIÊN)";

            // Dòng tổng của toàn bộ dữ liệu
            int tongDat = danhSachSinhVien.Count(sv => sv.Diem >= 5);
            lblThongKe.Text = "Số lớp: " + thongKe.Count
                + "   |   Tổng: " + danhSachSinhVien.Count + " SV"
                + "   |   Đạt: " + tongDat
                + "   |   Không đạt: " + (danhSachSinhVien.Count - tongDat)
                + "   |   Điểm TB toàn khóa: " + danhSachSinhVien.Average(sv => sv.Diem).ToString("0.00");
            lblThongKe.ForeColor = Color.DarkBlue;
        }

        // =====================================================================
        // Định dạng lưới (dùng chung cho báo cáo và thống kê)
        // =====================================================================
        private static readonly Dictionary<string, string> TieuDeCot = new Dictionary<string, string>
        {
            ["STT"] = "STT",
            ["MaSV"] = "Mã SV",
            ["HoTen"] = "Họ tên",
            ["TenLop"] = "Lớp",
            ["Diem"] = "Điểm TB",
            ["KetQua"] = "Kết quả",
            ["MaLop"] = "Mã lớp",
            ["SoLuong"] = "Sĩ số",
            ["SoDat"] = "Số đạt",
            ["SoKhongDat"] = "Không đạt",
            ["TiLeDat"] = "Tỉ lệ đạt (%)",
            ["DiemTB"] = "Điểm TB",
            ["DiemCaoNhat"] = "Cao nhất"
        };

        // Tỉ lệ độ rộng từng cột (cột không có trong bảng thì dùng 12)
        private static readonly Dictionary<string, float> DoRongCot = new Dictionary<string, float>
        {
            ["STT"] = 7,
            ["MaSV"] = 12,
            ["HoTen"] = 30,
            ["TenLop"] = 16,
            ["Diem"] = 12,
            ["KetQua"] = 15,
            ["MaLop"] = 11,
            ["SoLuong"] = 9,
            ["SoDat"] = 9,
            ["SoKhongDat"] = 11,
            ["TiLeDat"] = 13,
            ["DiemTB"] = 11,
            ["DiemCaoNhat"] = 11
        };

        private void FormatGrid()
        {
            foreach (DataGridViewColumn col in dgvBaoCao.Columns)
            {
                string ten = col.DataPropertyName;

                if (TieuDeCot.TryGetValue(ten, out string tieuDe))
                    col.HeaderText = tieuDe;

                col.FillWeight = DoRongCot.TryGetValue(ten, out float rong) ? rong : 12;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;   // thứ tự do LINQ quyết định

                // Cột số và cột Kết quả căn giữa, cột chữ căn trái
                bool canGiua = col.ValueType == typeof(int) || col.ValueType == typeof(double) || ten == "KetQua";
                col.DefaultCellStyle.Alignment = canGiua
                    ? DataGridViewContentAlignment.MiddleCenter
                    : DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Alignment = col.DefaultCellStyle.Alignment;
            }

            if (dgvBaoCao.Columns.Contains("STT")) dgvBaoCao.Columns["STT"].MinimumWidth = 50;
            if (dgvBaoCao.Columns.Contains("HoTen")) dgvBaoCao.Columns["HoTen"].MinimumWidth = 180;
            if (dgvBaoCao.Columns.Contains("Diem"))
            {
                dgvBaoCao.Columns["Diem"].DefaultCellStyle.Format = "0.0";
                dgvBaoCao.Columns["Diem"].DefaultCellStyle.Font = new Font(dgvBaoCao.Font, FontStyle.Bold);
            }
            if (dgvBaoCao.Columns.Contains("DiemTB"))
            {
                dgvBaoCao.Columns["DiemTB"].DefaultCellStyle.Format = "0.00";
                dgvBaoCao.Columns["DiemTB"].DefaultCellStyle.Font = new Font(dgvBaoCao.Font, FontStyle.Bold);
            }

            dgvBaoCao.ClearSelection();
        }

        /// <summary>Tô màu cột Kết quả: Đạt xanh, Không đạt đỏ.</summary>
        private void dgvBaoCao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvBaoCao.Columns[e.ColumnIndex].DataPropertyName != "KetQua") return;

            // Kiểu "nhãn": nền nhạt + chữ đậm cùng tông màu
            bool khongDat = (e.Value as string) == KQ_KHONG_DAT;
            e.CellStyle.ForeColor = khongDat ? MauRotChu : MauDatChu;
            e.CellStyle.BackColor = khongDat ? MauRotNen : MauDatNen;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            fontDam ??= new Font(dgvBaoCao.Font, FontStyle.Bold);
            e.CellStyle.Font = fontDam;
        }

        // =====================================================================
        // 5. XUẤT FILE CSV / TXT (dữ liệu đang hiển thị trên lưới)
        // =====================================================================
        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            XuatFile();
        }

        private void XuatFile()
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất. Hãy chọn điều kiện khác rồi bấm \"Xem báo cáo\".",
                    "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Lưu file báo cáo";
            sfd.Filter = "CSV - mở bằng Excel (*.csv)|*.csv|Văn bản (*.txt)|*.txt";
            sfd.FileName = TenFileMacDinh();

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                bool laTxt = Path.GetExtension(sfd.FileName).Equals(".txt", StringComparison.OrdinalIgnoreCase);
                string noiDung = laTxt ? TaoNoiDungTxt() : TaoNoiDungCsv();

                // UTF-8 có BOM để Excel / Notepad hiển thị đúng tiếng Việt
                File.WriteAllText(sfd.FileName, noiDung, new UTF8Encoding(true));

                DialogResult moFile = MessageBox.Show(
                    "Xuất file thành công (" + dgvBaoCao.Rows.Count + " dòng):\n" + sfd.FileName
                    + "\n\nMở file vừa xuất?",
                    "Xuất file", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (moFile == DialogResult.Yes)
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
            }
            catch (IOException ex)
            {
                MessageBox.Show("Không ghi được file. File có thể đang mở trong Excel hoặc chương trình khác."
                    + "\nHãy đóng file rồi thử lại.\n\nChi tiết: " + ex.Message,
                    "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Không có quyền ghi vào thư mục này. Hãy chọn thư mục khác (ví dụ Documents).",
                    "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message,
                    "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TenFileMacDinh()
        {
            string ngay = DateTime.Now.ToString("yyyyMMdd");
            if (dangXemThongKe) return "ThongKeTheoLop_" + ngay + ".csv";

            string maLop = cboLop.SelectedValue as string;
            return "BaoCaoSinhVien_" + (string.IsNullOrEmpty(maLop) ? "TatCaLop" : maLop) + "_" + ngay + ".csv";
        }

        // ---- Lấy dữ liệu đang hiển thị trên lưới (dùng chung cho CSV và TXT) ----

        private List<DataGridViewColumn> CotHienThi()
        {
            return dgvBaoCao.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .ToList();
        }

        /// <summary>Giá trị ô dạng chữ; số luôn dùng dấu chấm thập phân.</summary>
        private static string GiaTriO(object value)
        {
            return value switch
            {
                null => "",
                double d => d.ToString("0.##", CultureInfo.InvariantCulture),
                IFormattable f => f.ToString(null, CultureInfo.InvariantCulture),
                _ => value.ToString()
            };
        }

        private List<string[]> DongDuLieu(List<DataGridViewColumn> cot)
        {
            return dgvBaoCao.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Select(r => cot.Select(c => GiaTriO(r.Cells[c.Index].Value)).ToArray())
                .ToList();
        }

        /// <summary>CSV chuẩn: giá trị có dấu phẩy / ngoặc kép được đặt trong "...".</summary>
        private string TaoNoiDungCsv()
        {
            List<DataGridViewColumn> cot = CotHienThi();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Join(",", cot.Select(c => CsvEscape(c.HeaderText))));
            foreach (string[] dong in DongDuLieu(cot))
                sb.AppendLine(string.Join(",", dong.Select(CsvEscape)));

            return sb.ToString();
        }

        private static string CsvEscape(string s)
        {
            if (s.IndexOfAny(new[] { ',', '"', '\n', '\r' }) >= 0)
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }

        /// <summary>TXT dạng báo cáo: tiêu đề, điều kiện lọc, bảng căn cột, dòng thống kê.</summary>
        private string TaoNoiDungTxt()
        {
            List<DataGridViewColumn> cot = CotHienThi();
            List<string[]> dong = DongDuLieu(cot);

            // Độ rộng mỗi cột = độ dài dài nhất (tiêu đề hoặc dữ liệu)
            int[] rong = cot.Select((c, i) =>
                Math.Max(c.HeaderText.Length, dong.Select(d => d[i].Length).DefaultIfEmpty(0).Max()))
                .ToArray();

            string KeDong() => new string('-', rong.Sum() + 3 * rong.Length + 1);
            string GhepDong(string[] gt) =>
                "| " + string.Join(" | ", gt.Select((g, i) => g.PadRight(rong[i]))) + " |";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(lblTieuDe.Text);
            sb.AppendLine("Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            if (!dangXemThongKe)
            {
                sb.AppendLine("Điều kiện: Lớp = " + cboLop.Text
                    + "; Kết quả = " + cboKetQua.Text
                    + "; Từ khóa = " + (txtTuKhoa.Text.Trim().Length > 0 ? txtTuKhoa.Text.Trim() : "(trống)"));
            }
            sb.AppendLine();
            sb.AppendLine(KeDong());
            sb.AppendLine(GhepDong(cot.Select(c => c.HeaderText).ToArray()));
            sb.AppendLine(KeDong());
            foreach (string[] d in dong) sb.AppendLine(GhepDong(d));
            sb.AppendLine(KeDong());
            sb.AppendLine(lblThongKe.Text.Replace("   |   ", " | "));

            return sb.ToString();
        }
    }
}