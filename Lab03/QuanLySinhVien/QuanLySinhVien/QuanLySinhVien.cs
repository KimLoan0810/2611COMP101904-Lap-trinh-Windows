namespace Lab03_QuanLySinhVienOOP;

public class QuanLySinhVien
{
    // private: bên ngoài không truy cập trực tiếp được
    private readonly List<SinhVien> _danhSach = new();

    // Thêm: trả về false nếu mã đã tồn tại
    public bool Them(SinhVien sv)
    {
        if (TimTheoMa(sv.MaSinhVien) != null)
            return false;

        _danhSach.Add(sv);
        return true;
    }

    // Sửa điểm: trả về false nếu không tìm thấy mã
    public bool SuaDiem(string maSinhVien, double diemMoi)
    {
        var sv = TimTheoMa(maSinhVien);
        if (sv == null) return false;

        sv.DiemTrungBinh = diemMoi;
        return true;
    }

    // Xóa: trả về false nếu không tìm thấy
    public bool Xoa(string maSinhVien)
    {
        var sv = TimTheoMa(maSinhVien);
        if (sv == null) return false;

        return _danhSach.Remove(sv);
    }

    // LINQ: FirstOrDefault - trả về null nếu không có
    public SinhVien? TimTheoMa(string maSinhVien)
    {
        return _danhSach.FirstOrDefault(sv =>
            sv.MaSinhVien.Equals(maSinhVien.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    // LINQ: Where + Contains - tìm theo từ khóa trong họ tên
    public List<SinhVien> TimTheoTen(string tuKhoa)
    {
        return _danhSach
            .Where(sv => sv.HoTen.Contains(tuKhoa.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // LINQ: OrderByDescending - sắp xếp điểm giảm dần
    public List<SinhVien> SapXepTheoDiem()
    {
        return _danhSach
            .OrderByDescending(sv => sv.DiemTrungBinh)
            .ToList();
    }

    // LINQ: Where - lọc sinh viên đạt (điểm >= 5)
    public List<SinhVien> LocSinhVienDat()
    {
        return _danhSach
            .Where(sv => sv.DiemTrungBinh >= 5)
            .ToList();
    }

    // Trả về bản sao để bên ngoài không sửa trực tiếp list gốc
    public List<SinhVien> LayDanhSach()
    {
        return _danhSach.ToList();
    }
}