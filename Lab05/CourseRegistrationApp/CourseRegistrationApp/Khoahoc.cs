namespace CourseRegistrationApp;

public class KhoaHoc
{
    public string Ten { get; }
    public decimal HocPhiMotThang { get; }

    public KhoaHoc(string ten, decimal hocPhiMotThang)
    {
        Ten = ten;
        HocPhiMotThang = hocPhiMotThang;
    }

    // ComboBox sẽ hiển thị chuỗi này
    public override string ToString()
    {
        return Ten;
    }
}