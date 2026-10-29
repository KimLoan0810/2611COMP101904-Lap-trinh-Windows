using System.Globalization;
using QuanLySinhVienMVP.Models;
using QuanLySinhVienMVP.Repositories;
using QuanLySinhVienMVP.Views;

namespace QuanLySinhVienMVP.Presenters
{
    /// <summary>
    /// PRESENTER - xử lý nghiệp vụ: đọc dữ liệu từ View, kiểm tra,
    /// gọi Repository, rồi bảo View hiển thị kết quả.
    /// Không đụng tới control giao diện hay hộp thông báo; mọi thứ đi qua IStudentView.
    /// </summary>
    public class StudentPresenter
    {
        private const int MA_SV_TOI_DA = 10;
        private const double DIEM_MIN = 0;
        private const double DIEM_MAX = 10;

        private readonly IStudentView view;
        private readonly IStudentRepository repository;

        public StudentPresenter(IStudentView view, IStudentRepository repository)
        {
            this.view = view;
            this.repository = repository;
        }

        // =====================================================================
        // LOAD DANH SÁCH
        // =====================================================================
        public void LoadStudents()
        {
            List<Student> ds = repository.GetAll();
            HienThi(ds);
            view.ShowStatus("Đã tải " + ds.Count + " sinh viên.", false);
        }

        // =====================================================================
        // THÊM
        // =====================================================================
        public void AddStudent()
        {
            // 1. Đọc + chuẩn hóa dữ liệu từ View
            string ma = (view.StudentCode ?? "").Trim().ToUpper();
            string ten = ChuanHoaKhoangTrang(view.FullName);
            string lop = (view.ClassName ?? "").Trim().ToUpper();
            string diemText = (view.ScoreText ?? "").Trim();

            // 2. Kiểm tra rỗng
            if (ma.Length == 0) { BaoLoi("Mã sinh viên không được để trống.", InputField.StudentCode); return; }
            if (ten.Length == 0) { BaoLoi("Họ tên không được để trống.", InputField.FullName); return; }
            if (lop.Length == 0) { BaoLoi("Lớp không được để trống.", InputField.ClassName); return; }
            if (diemText.Length == 0) { BaoLoi("Điểm không được để trống.", InputField.Score); return; }

            // 3. Kiểm tra định dạng / kiểu dữ liệu
            if (ma.Length > MA_SV_TOI_DA || ma.Contains(' '))
            {
                BaoLoi("Mã sinh viên tối đa " + MA_SV_TOI_DA + " ký tự và không chứa khoảng trắng.", InputField.StudentCode);
                return;
            }

            if (!TryDocDiem(diemText, out double diem))
            {
                BaoLoi("Điểm phải là số, ví dụ 7.5 (bạn nhập \"" + diemText + "\").", InputField.Score);
                return;
            }

            if (diem < DIEM_MIN || diem > DIEM_MAX)
            {
                BaoLoi("Điểm phải nằm trong khoảng " + DIEM_MIN + " đến " + DIEM_MAX + ".", InputField.Score);
                return;
            }

            // 4. Kiểm tra trùng mã
            if (repository.Exists(ma))
            {
                BaoLoi("Mã sinh viên \"" + ma + "\" đã tồn tại.", InputField.StudentCode);
                return;
            }

            // 5. Lưu và báo kết quả
            repository.Add(new Student { MaSV = ma, HoTen = ten, Lop = lop, Diem = diem });

            view.ClearInput();
            view.Keyword = "";
            HienThi(repository.GetAll());
            view.SelectStudentRow(ma);
            view.ShowStatus("Đã thêm sinh viên " + ma + " - " + ten + ".", false);
            view.ShowMessage("Thêm sinh viên thành công:\n" + ma + " - " + ten + " - " + lop + " - điểm " + diem);
        }

        // =====================================================================
        // XÓA THEO MÃ
        // =====================================================================
        public void DeleteStudent()
        {
            string ma = (view.StudentCode ?? "").Trim().ToUpper();

            if (ma.Length == 0)
            {
                BaoLoi("Nhập mã sinh viên hoặc chọn một dòng trong danh sách để xóa.", InputField.StudentCode);
                return;
            }

            Student sv = repository.GetByCode(ma);
            if (sv == null)
            {
                BaoLoi("Không tìm thấy sinh viên có mã \"" + ma + "\".", InputField.StudentCode);
                return;
            }

            if (!view.Confirm("Bạn có chắc muốn xóa sinh viên " + sv.MaSV + " - " + sv.HoTen + "?"))
            {
                view.ShowStatus("Đã hủy xóa sinh viên " + sv.MaSV + ".", false);
                return;
            }

            repository.Delete(sv.MaSV);

            view.ClearInput();
            view.Keyword = "";
            HienThi(repository.GetAll());
            view.ShowStatus("Đã xóa sinh viên " + sv.MaSV + " - " + sv.HoTen + ".", false);
            view.ShowMessage("Xóa sinh viên thành công: " + sv.MaSV + " - " + sv.HoTen + ".");
        }

        // =====================================================================
        // TÌM KIẾM THEO MÃ HOẶC TÊN
        // =====================================================================
        public void SearchStudent()
        {
            string tuKhoa = (view.Keyword ?? "").Trim();

            if (tuKhoa.Length == 0)
            {
                LoadStudents();
                view.ShowStatus("Từ khóa trống - hiển thị toàn bộ sinh viên.", false);
                return;
            }

            List<Student> ketQua = repository.Search(tuKhoa);
            HienThi(ketQua);

            if (ketQua.Count == 0)
            {
                view.ShowStatus("Không tìm thấy sinh viên với từ khóa \"" + tuKhoa + "\".", true);
                view.ShowMessage("Không tìm thấy sinh viên nào có mã hoặc họ tên chứa \"" + tuKhoa + "\".");
            }
            else
            {
                view.ShowStatus("Tìm thấy " + ketQua.Count + " sinh viên với từ khóa \"" + tuKhoa + "\".", false);
            }
        }

        // =====================================================================
        // CHỌN DÒNG -> ĐƯA DỮ LIỆU LÊN Ô NHẬP
        // =====================================================================
        public void SelectStudent(string maSV)
        {
            Student sv = repository.GetByCode(maSV);
            if (sv == null) return;

            view.StudentCode = sv.MaSV;
            view.FullName = sv.HoTen;
            view.ClassName = sv.Lop;
            view.ScoreText = sv.Diem.ToString("0.##", CultureInfo.InvariantCulture);
            view.ShowStatus("Đang chọn sinh viên " + sv.MaSV + ". Bấm Xóa để xóa theo mã này.", false);
        }

        // =====================================================================
        // LÀM MỚI
        // =====================================================================
        public void ResetForm()
        {
            view.ClearInput();
            view.Keyword = "";
            LoadStudents();
        }

        // =====================================================================
        // HÀM PHỤ
        // =====================================================================

        /// <summary>Hiển thị danh sách và thống kê (tổng, điểm TB, số đạt).</summary>
        private void HienThi(List<Student> ds)
        {
            view.ShowStudents(ds);

            int tong = ds.Count;
            double tb = tong > 0 ? ds.Average(s => s.Diem) : 0;
            int dat = ds.Count(s => s.Diem >= 5);
            view.ShowStatistics(tong, tb, dat);
        }

        private void BaoLoi(string thongBao, InputField truong)
        {
            view.ShowStatus(thongBao, true);
            view.ShowError(thongBao, truong);
        }

        /// <summary>Đọc điểm, chấp nhận cả 7.5 và 7,5.</summary>
        private static bool TryDocDiem(string text, out double diem)
        {
            // IsFinite: chặn các chuỗi "NaN", "Infinity" mà TryParse vẫn chấp nhận
            return double.TryParse(text.Replace(',', '.'), NumberStyles.Float,
                       CultureInfo.InvariantCulture, out diem)
                   && double.IsFinite(diem);
        }

        private static string ChuanHoaKhoangTrang(string s)
        {
            return string.Join(" ", (s ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}