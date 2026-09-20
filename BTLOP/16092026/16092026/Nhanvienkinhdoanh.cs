using System;

namespace _16092026
{
    public class Nhanvienkinhdoanh : Nhanvien
    {
        private double doanhSo;

        public double DoanhSo
        {
            get => doanhSo;
            set => doanhSo = value >= 0 ? value : 0;
        }

        public Nhanvienkinhdoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + (0.05 * DoanhSo);
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Kinh Doanh] Mã NV: {MaNV,-8} | Họ tên: {HoTen,-18} | LCB: {LuongCoBan,10:N0} VNĐ | Doanh số: {DoanhSo,12:N0} | Thực nhận: {TinhLuong(),12:N0} VNĐ");
        }
    }
}