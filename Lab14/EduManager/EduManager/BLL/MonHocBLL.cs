using EduManager.DAL;
using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.BLL
{
    /// <summary>
    /// Kết quả một thao tác nghiệp vụ trả về cho GUI.
    /// TruongLoi cho GUI biết ô nào sai để đưa con trỏ tới.
    /// </summary>
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; private set; }
        public string ThongBao { get; private set; }
        public string TruongLoi { get; private set; }   // "MaMonHoc", "TenMonHoc", "SoTinChi" hoặc null

        public static KetQuaXuLy Ok(string thongBao)
            => new KetQuaXuLy { ThanhCong = true, ThongBao = thongBao };

        public static KetQuaXuLy Loi(string thongBao, string truongLoi = null)
            => new KetQuaXuLy { ThanhCong = false, ThongBao = thongBao, TruongLoi = truongLoi };
    }

    /// <summary>
    /// BLL - quy tắc nghiệp vụ của môn học.
    /// Chuẩn hóa và kiểm tra dữ liệu TRƯỚC khi gọi DAL;
    /// đổi lỗi kỹ thuật (database) thành thông báo dễ hiểu.
    /// </summary>
    public class MonHocBLL
    {
        public const int SO_TIN_CHI_MIN = 1;
        public const int SO_TIN_CHI_MAX = 6;

        private const string LOI_KET_NOI =
            "Không kết nối được cơ sở dữ liệu EduManagerDB.\n"
            + "Hãy kiểm tra SQL Server đang chạy, đã chạy script Lab14_MONHOC.sql "
            + "và chuỗi kết nối trong Data/EduManagerContext.cs.";

        private readonly MonHocDAL monHocDAL = new MonHocDAL();

        // =====================================================================
        // ĐỌC DỮ LIỆU
        // =====================================================================

        public List<MonHoc> LayDanhSach()
        {
            try
            {
                return monHocDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                throw new Exception(LOI_KET_NOI + "\n\nChi tiết: " + ex.Message, ex);
            }
        }

        /// <summary>Từ khóa rỗng -> trả về toàn bộ danh sách.</summary>
        public List<MonHoc> TimKiem(string tuKhoa)
        {
            tuKhoa = (tuKhoa ?? "").Trim();
            if (tuKhoa.Length == 0) return LayDanhSach();

            try
            {
                return monHocDAL.TimKiem(tuKhoa);
            }
            catch (Exception ex)
            {
                throw new Exception(LOI_KET_NOI + "\n\nChi tiết: " + ex.Message, ex);
            }
        }

        // =====================================================================
        // CHUẨN HÓA + KIỂM TRA (validation đặt ở BLL)
        // =====================================================================

        /// <summary>Bỏ khoảng trắng thừa, mã môn viết hoa.</summary>
        private static void ChuanHoa(MonHoc mh)
        {
            mh.MaMonHoc = (mh.MaMonHoc ?? "").Trim().ToUpper();
            mh.TenMonHoc = string.Join(" ",
                (mh.TenMonHoc ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>Trả về null nếu hợp lệ, ngược lại trả về lỗi đầu tiên gặp.</summary>
        private static KetQuaXuLy KiemTra(MonHoc mh)
        {
            if (mh.MaMonHoc.Length == 0)
                return KetQuaXuLy.Loi("Mã môn học không được để trống.", "MaMonHoc");

            if (mh.MaMonHoc.Length > 10)
                return KetQuaXuLy.Loi("Mã môn học tối đa 10 ký tự.", "MaMonHoc");

            if (mh.MaMonHoc.Contains(' '))
                return KetQuaXuLy.Loi("Mã môn học không được chứa khoảng trắng.", "MaMonHoc");

            if (mh.TenMonHoc.Length == 0)
                return KetQuaXuLy.Loi("Tên môn học không được để trống.", "TenMonHoc");

            if (mh.TenMonHoc.Length > 100)
                return KetQuaXuLy.Loi("Tên môn học tối đa 100 ký tự.", "TenMonHoc");

            if (mh.SoTinChi < SO_TIN_CHI_MIN || mh.SoTinChi > SO_TIN_CHI_MAX)
                return KetQuaXuLy.Loi("Số tín chỉ phải từ " + SO_TIN_CHI_MIN + " đến " + SO_TIN_CHI_MAX + ".", "SoTinChi");

            return null;
        }

        // =====================================================================
        // THÊM / SỬA / XÓA
        // =====================================================================

        public KetQuaXuLy Them(MonHoc mh)
        {
            ChuanHoa(mh);
            KetQuaXuLy loi = KiemTra(mh);
            if (loi != null) return loi;

            try
            {
                if (monHocDAL.TonTai(mh.MaMonHoc))
                    return KetQuaXuLy.Loi("Mã môn học \"" + mh.MaMonHoc + "\" đã tồn tại.", "MaMonHoc");

                monHocDAL.Them(mh);
                return KetQuaXuLy.Ok("Đã thêm môn học " + mh.MaMonHoc + " - " + mh.TenMonHoc + ".");
            }
            catch (DbUpdateException ex)
            {
                return KetQuaXuLy.Loi("Không lưu được môn học. Dữ liệu vi phạm ràng buộc trong database.\n\nChi tiết: "
                    + (ex.InnerException?.Message ?? ex.Message));
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Loi(LOI_KET_NOI + "\n\nChi tiết: " + ex.Message);
            }
        }

        public KetQuaXuLy Sua(MonHoc mh)
        {
            ChuanHoa(mh);
            KetQuaXuLy loi = KiemTra(mh);
            if (loi != null) return loi;

            try
            {
                bool daSua = monHocDAL.Sua(mh);
                return daSua
                    ? KetQuaXuLy.Ok("Đã cập nhật môn học " + mh.MaMonHoc + ".")
                    : KetQuaXuLy.Loi("Không tìm thấy môn học \"" + mh.MaMonHoc + "\". Có thể đã bị xóa, hãy bấm Làm mới.");
            }
            catch (DbUpdateException ex)
            {
                return KetQuaXuLy.Loi("Không cập nhật được môn học.\n\nChi tiết: "
                    + (ex.InnerException?.Message ?? ex.Message));
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Loi(LOI_KET_NOI + "\n\nChi tiết: " + ex.Message);
            }
        }

        public KetQuaXuLy Xoa(string maMonHoc)
        {
            maMonHoc = (maMonHoc ?? "").Trim().ToUpper();
            if (maMonHoc.Length == 0)
                return KetQuaXuLy.Loi("Chưa chọn môn học cần xóa.");

            try
            {
                bool daXoa = monHocDAL.Xoa(maMonHoc);
                return daXoa
                    ? KetQuaXuLy.Ok("Đã xóa môn học " + maMonHoc + ".")
                    : KetQuaXuLy.Loi("Không tìm thấy môn học \"" + maMonHoc + "\". Có thể đã bị xóa, hãy bấm Làm mới.");
            }
            catch (DbUpdateException)
            {
                // Ví dụ: sau này bảng khác (KETQUA, LICHHOC...) tham chiếu tới môn học này
                return KetQuaXuLy.Loi("Không thể xóa môn học \"" + maMonHoc
                    + "\" vì đang được dữ liệu khác sử dụng.\nCó thể bỏ tích \"Đang sử dụng\" để ngừng môn học thay vì xóa.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Loi(LOI_KET_NOI + "\n\nChi tiết: " + ex.Message);
            }
        }

        // =====================================================================
        // THỐNG KÊ NHỎ CHO THANH TRẠNG THÁI
        // =====================================================================

        public string ThongKe(List<MonHoc> ds)
        {
            int dangDung = ds.Count(m => m.TrangThai);
            int tongTinChi = ds.Where(m => m.TrangThai).Sum(m => m.SoTinChi);
            return "Tổng: " + ds.Count + " môn   |   Đang sử dụng: " + dangDung
                + "   |   Ngừng: " + (ds.Count - dangDung)
                + "   |   Tổng tín chỉ (đang dùng): " + tongTinChi;
        }
    }
}