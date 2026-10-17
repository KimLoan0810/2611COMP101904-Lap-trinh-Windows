namespace Lab03_QuanLySinhVienOOP;

public class Nguoi
{
    private string _hoTen = "";

    // Property có kiểm tra: họ tên không được rỗng
    public string HoTen
    {
        get => _hoTen;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Họ tên không được để trống.");
            _hoTen = value.Trim();
        }
    }

    public DateTime NgaySinh { get; set; }

    // Constructor
    public Nguoi(string hoTen, DateTime ngaySinh)
    {
        HoTen = hoTen;        // đi qua setter nên được kiểm tra
        NgaySinh = ngaySinh;
    }

    // virtual: cho phép lớp con override
    public virtual string LayThongTin()
    {
        return $"Họ tên: {HoTen}, Ngày sinh: {NgaySinh:dd/MM/yyyy}";
    }
}
