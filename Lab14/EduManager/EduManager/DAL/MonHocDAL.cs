using EduManager.Data;
using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.DAL
{
    /// <summary>
    /// DAL - truy cập bảng MONHOC bằng Entity Framework Core.
    /// Chỉ đọc / ghi dữ liệu, KHÔNG kiểm tra nghiệp vụ, KHÔNG hiện MessageBox.
    /// Mỗi hàm tạo một DbContext mới và giải phóng ngay (using).
    /// </summary>
    public class MonHocDAL
    {
        /// <summary>Lấy toàn bộ môn học, sắp theo mã.</summary>
        public List<MonHoc> LayTatCa()
        {
            using var db = new EduManagerContext();
            return db.MonHocs
                     .AsNoTracking()               // chỉ đọc, không cần theo dõi thay đổi
                     .OrderBy(m => m.MaMonHoc)
                     .ToList();
        }

        /// <summary>Tìm theo mã hoặc tên (EF Core dịch Contains thành LIKE '%...%').</summary>
        public List<MonHoc> TimKiem(string tuKhoa)
        {
            using var db = new EduManagerContext();
            return db.MonHocs
                     .AsNoTracking()
                     .Where(m => m.MaMonHoc.Contains(tuKhoa) || m.TenMonHoc.Contains(tuKhoa))
                     .OrderBy(m => m.MaMonHoc)
                     .ToList();
        }

        /// <summary>Lấy một môn theo mã (null nếu không có).</summary>
        public MonHoc LayTheoMa(string maMonHoc)
        {
            using var db = new EduManagerContext();
            return db.MonHocs.AsNoTracking().FirstOrDefault(m => m.MaMonHoc == maMonHoc);
        }

        /// <summary>Mã môn học đã tồn tại chưa.</summary>
        public bool TonTai(string maMonHoc)
        {
            using var db = new EduManagerContext();
            return db.MonHocs.Any(m => m.MaMonHoc == maMonHoc);
        }

        /// <summary>Thêm mới -> EF Core sinh lệnh INSERT.</summary>
        public void Them(MonHoc monHoc)
        {
            using var db = new EduManagerContext();
            db.MonHocs.Add(monHoc);
            db.SaveChanges();
        }

        /// <summary>Cập nhật theo mã -> EF Core sinh lệnh UPDATE. Trả về false nếu không tìm thấy.</summary>
        public bool Sua(MonHoc monHoc)
        {
            using var db = new EduManagerContext();
            MonHoc tonTai = db.MonHocs.Find(monHoc.MaMonHoc);
            if (tonTai == null) return false;

            tonTai.TenMonHoc = monHoc.TenMonHoc;
            tonTai.SoTinChi = monHoc.SoTinChi;
            tonTai.TrangThai = monHoc.TrangThai;

            db.SaveChanges();
            return true;
        }

        /// <summary>Xóa theo mã -> EF Core sinh lệnh DELETE. Trả về false nếu không tìm thấy.</summary>
        public bool Xoa(string maMonHoc)
        {
            using var db = new EduManagerContext();
            MonHoc tonTai = db.MonHocs.Find(maMonHoc);
            if (tonTai == null) return false;

            db.MonHocs.Remove(tonTai);
            db.SaveChanges();
            return true;
        }
    }
}