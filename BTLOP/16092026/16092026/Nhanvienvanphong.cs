using System;

namespace _16092026
{
    public class Nhanvienvanphong : Nhanvien
    {
        private int soNgayLamViec;

        public int SoNgayLamViec
        {
            get => soNgayLamViec;
            set => soNgayLamViec = (value >= 0 && value <= 31) ? value : 0;
        }

        public Nhanvienvanphong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + (SoNgayLamViec * 200000);
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Văn Phòng]  Mã NV: {MaNV,-8} | Họ tên: {HoTen,-18} | LCB: {LuongCoBan,10:N0} VNĐ | Số ngày làm: {SoNgayLamViec,2} | Thực nhận: {TinhLuong(),12:N0} VNĐ");
        }
    }
}