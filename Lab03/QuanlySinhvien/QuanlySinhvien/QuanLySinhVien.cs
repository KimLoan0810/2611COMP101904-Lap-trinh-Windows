using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    public class QuanLySinhVien
    {
        private List<SinhVien> _danhSachSinhVien = new List<SinhVien>();

        public bool Them(SinhVien sv)
        {
            if (TimTheoMa(sv.MaSinhVien) != null)
            {
                return false; // Mã sinh viên đã tồn tại
            }
            _danhSachSinhVien.Add(sv);
            return true;
        }

        public List<SinhVien> LayDanhSach()
        {
            return _danhSachSinhVien;
        }

        public SinhVien TimTheoMa(string maSV)
        {
            return _danhSachSinhVien.FirstOrDefault(sv => sv.MaSinhVien.Equals(maSV, StringComparison.OrdinalIgnoreCase));
        }

        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            return _danhSachSinhVien
                .Where(sv => sv.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public bool SuaDiem(string maSV, double diemMoi)
        {
            var sv = TimTheoMa(maSV);
            if (sv == null) return false;

            sv.DiemTrungBinh = diemMoi;
            return true;
        }

        public bool Xoa(string maSV)
        {
            var sv = TimTheoMa(maSV);
            if (sv == null) return false;

            _danhSachSinhVien.Remove(sv);
            return true;
        }

        public List<SinhVien> SapXepTheoDiemGiamDan()
        {
            return _danhSachSinhVien.OrderByDescending(sv => sv.DiemTrungBinh).ToList();
        }

        public List<SinhVien> LocSinhVienDat()
        {
            return _danhSachSinhVien.Where(sv => sv.DiemTrungBinh >= 5.0).ToList();
        }
    }
}