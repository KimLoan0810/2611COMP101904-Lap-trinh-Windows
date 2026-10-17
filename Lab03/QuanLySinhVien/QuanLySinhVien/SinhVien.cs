namespace Lab03_QuanLySinhVienOOP;

public class SinhVien : Nguoi
{
    private double _diemTrungBinh;

    public string MaSinhVien { get; set; }
    public string MaLop { get; set; }

    // Property kiểm tra điểm trong khoảng 0-10
    public double DiemTrungBinh
    {
        get => _diemTrungBinh;
        set
        {
            if (value < 0 || value > 10)
                throw new ArgumentOutOfRangeException(nameof(value), "Điểm phải nằm trong khoảng 0 - 10.");
            _diemTrungBinh = value;
        }
    }

    // Constructor: gọi constructor lớp cha bằng base(...)
    public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh)
        : base(hoTen, ngaySinh)
    {
        MaSinhVien = maSinhVien;
        MaLop = maLop;
        DiemTrungBinh = diemTrungBinh;
    }

    public string XepLoai()
    {
        if (DiemTrungBinh >= 8) return "Giỏi";
        if (DiemTrungBinh >= 6.5) return "Khá";
        if (DiemTrungBinh >= 5) return "Trung bình";
        return "Yếu";
    }

    // override: viết lại method của lớp cha
    public override string LayThongTin()
    {
        return $"{MaSinhVien} | {HoTen} | {NgaySinh:dd/MM/yyyy} | Lớp: {MaLop} | Điểm: {DiemTrungBinh:0.0} | Xếp loại: {XepLoai()}";
    }
}