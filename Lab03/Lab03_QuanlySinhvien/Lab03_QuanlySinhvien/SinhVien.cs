using System;

namespace Lab03_QuanLySinhVienOOP
{
    public class SinhVien : Nguoi
    {
        private double _diemTrungBinh;

        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }

        public double DiemTrungBinh
        {
            get => _diemTrungBinh;
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Điểm trung bình phải nằm trong khoảng từ 0.0 đến 10.0!");
                }
                _diemTrungBinh = value;
            }
        }

        public SinhVien() : base()
        {
            MaSinhVien = string.Empty;
            MaLop = string.Empty;
            _diemTrungBinh = 0.0;
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh;
        }

        public string XepLoai()
        {
            if (DiemTrungBinh >= 8.5) return "Xuất sắc";
            if (DiemTrungBinh >= 8.0) return "Giỏi";
            if (DiemTrungBinh >= 6.5) return "Khá";
            if (DiemTrungBinh >= 5.0) return "Trung bình";
            return "Yếu";
        }

        public override string LayThongTin()
        {
            return $"MSSV: {MaSinhVien,-10} | Họ tên: {HoTen,-20} | Ngay sinh: {NgaySinh:dd/MM/yyyy} | Lớp: {MaLop,-10} | ĐTB: {DiemTrungBinh,4:F1} | Xếp loại: {XepLoai()}";
        }
    }
}