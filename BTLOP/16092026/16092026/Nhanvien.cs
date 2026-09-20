using System;

namespace _16092026
{
    public class Nhanvien
    {
        private string maNV;
        private string hoTen;
        private double luongCoBan;

        public string MaNV
        {
            get => maNV;
            set => maNV = value;
        }

        public string HoTen
        {
            get => hoTen;
            set => hoTen = value;
        }

        public double LuongCoBan
        {
            get => luongCoBan;
            set => luongCoBan = value > 0 ? value : 0;
        }

        public Nhanvien() { }

        public Nhanvien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Mã NV: {MaNV,-8} | Họ tên: {HoTen,-18} | LCB: {LuongCoBan,10:N0} VNĐ | Lương thực nhận: {TinhLuong(),12:N0} VNĐ");
        }
    }
}