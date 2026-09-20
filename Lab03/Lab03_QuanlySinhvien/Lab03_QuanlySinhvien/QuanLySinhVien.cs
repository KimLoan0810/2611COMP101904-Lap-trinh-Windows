using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    public class QuanLySinhVien
    {
        private readonly List<SinhVien> _danhSachSinhVien;

        public QuanLySinhVien()
        {
            _danhSachSinhVien = new List<SinhVien>();
        }

        // Lấy toàn bộ danh sách
        public List<SinhVien> LayDanhSach()
        {
            return _danhSachSinhVien;
        }

        // Thêm sinh viên (Kiểm tra trùng mã)
        public bool Them(SinhVien sv)
        {
            if (TimTheoMa(sv.MaSinhVien) != null)
            {
                return false; // Mã đã tồn tại
            }
            _danhSachSinhVien.Add(sv);
            return true;
        }

        // Tìm sinh viên theo mã (LINQ)
        public SinhVien? TimTheoMa(string maSV)
        {
            return _danhSachSinhVien.FirstOrDefault(sv => sv.MaSinhVien.Equals(maSV, StringComparison.OrdinalIgnoreCase));
        }

        // Tìm sinh viên theo từ khóa tên (LINQ)
        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            return _danhSachSinhVien
                .Where(sv => sv.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Sửa điểm trung bình
        public bool SuaDiem(string maSV, double diemMoi)
        {
            var sv = TimTheoMa(maSV);
            if (sv == null) return false;

            sv.DiemTrungBinh = diemMoi;
            return true;
        }

        // Xóa sinh viên
        public bool Xoa(string maSV)
        {
            var sv = TimTheoMa(maSV);
            if (sv == null) return false;

            _danhSachSinhVien.Remove(sv);
            return true;
        }

        // Sắp xếp danh sách theo điểm giảm dần (LINQ)
        public List<SinhVien> SapXepTheoDiemGiamDan()
        {
            return _danhSachSinhVien.OrderByDescending(sv => sv.DiemTrungBinh).ToList();
        }

        // Lọc sinh viên đạt (Điểm >= 5.0) (LINQ)
        public List<SinhVien> LocSinhVienDat()
        {
            return _danhSachSinhVien.Where(sv => sv.DiemTrungBinh >= 5.0).ToList();
        }
    }
}