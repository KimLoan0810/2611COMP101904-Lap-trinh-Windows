using System;

namespace _16092026
{
    public class Nhanvienthoivu : Nhanvien
    {
        private double soGioLam;
        private double luongTheoGio;

        public double SoGioLam
        {
            get => soGioLam;
            set => soGioLam = value >= 0 ? value : 0;
        }

        public double LuongTheoGio
        {
            get => luongTheoGio;
            set => luongTheoGio = value >= 0 ? value : 0;
        }

        public Nhanvienthoivu(string maNV, string hoTen, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, 0)
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Thời Vụ]    Mã NV: {MaNV,-8} | Họ tên: {HoTen,-18} | Giờ làm: {SoGioLam,5}h | Lương/Giờ: {LuongTheoGio,7:N0} | Thực nhận: {TinhLuong(),12:N0} VNĐ");
        }
    }
}