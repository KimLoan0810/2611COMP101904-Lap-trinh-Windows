using System.Globalization;
using System.Text;
using Lab03_QuanLySinhVienOOP;

class Program
{
    static readonly QuanLySinhVien quanLy = new();

    static void Main()
    {
        // Để console hiển thị/nhập được tiếng Việt có dấu
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        while (true)
        {
            HienMenu();
            string luaChon = Console.ReadLine()?.Trim() ?? "";

            switch (luaChon)
            {
                case "1": ThemSinhVien(); break;
                case "2": XuatDanhSach(); break;
                case "3": TimTheoMa(); break;
                case "4": TimTheoTen(); break;
                case "5": SuaDiem(); break;
                case "6": XoaSinhVien(); break;
                case "7": SapXepTheoDiem(); break;
                case "8": LocSinhVienDat(); break;
                case "0":
                    Console.WriteLine("Tạm biệt!");
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                    break;
            }

            Console.WriteLine("\nNhấn Enter để tiếp tục...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    // ---------- MENU ----------
    static void HienMenu()
    {
        Console.WriteLine("===== QUAN LY SINH VIEN =====");
        Console.WriteLine("1. Them sinh vien");
        Console.WriteLine("2. Xuat danh sach");
        Console.WriteLine("3. Tim sinh vien theo ma");
        Console.WriteLine("4. Tim sinh vien theo ten");
        Console.WriteLine("5. Sua diem trung binh");
        Console.WriteLine("6. Xoa sinh vien");
        Console.WriteLine("7. Sap xep theo diem giam dan");
        Console.WriteLine("8. Loc sinh vien dat");
        Console.WriteLine("0. Thoat");
        Console.Write("Chon chuc nang: ");
    }

    // ---------- CÁC CHỨC NĂNG ----------
    static void ThemSinhVien()
    {
        Console.WriteLine("--- THÊM SINH VIÊN ---");

        // Kiểm tra mã trùng NGAY khi nhập để người dùng nhập lại mã khác
        string ma;
        while (true)
        {
            ma = NhapChuoi("Mã sinh viên: ");
            if (quanLy.TimTheoMa(ma) == null) break;
            Console.WriteLine("Mã sinh viên đã tồn tại, vui lòng nhập mã khác.");
        }

        string hoTen = NhapChuoi("Họ tên: ");
        DateTime ngaySinh = NhapNgay("Ngày sinh (dd/MM/yyyy): ");
        string maLop = NhapChuoi("Mã lớp: ");
        double diem = NhapDiem("Điểm trung bình (0-10): ");

        var sv = new SinhVien(ma, hoTen, ngaySinh, maLop, diem);

        if (quanLy.Them(sv))
            Console.WriteLine($"Thêm thành công! Xếp loại: {sv.XepLoai()}");
        else
            Console.WriteLine("Mã sinh viên đã tồn tại.");
    }

    static void XuatDanhSach()
    {
        Console.WriteLine("--- DANH SÁCH SINH VIÊN ---");
        InDanhSach(quanLy.LayDanhSach());
    }

    static void TimTheoMa()
    {
        Console.WriteLine("--- TÌM THEO MÃ ---");
        string ma = NhapChuoi("Nhập mã sinh viên: ");
        var sv = quanLy.TimTheoMa(ma);

        if (sv == null)
            Console.WriteLine("Không tìm thấy sinh viên.");
        else
            Console.WriteLine(sv.LayThongTin());
    }

    static void TimTheoTen()
    {
        Console.WriteLine("--- TÌM THEO TÊN ---");
        string tuKhoa = NhapChuoi("Nhập từ khóa họ tên: ");
        var ketQua = quanLy.TimTheoTen(tuKhoa);

        if (ketQua.Count == 0)
            Console.WriteLine("Không tìm thấy sinh viên nào.");
        else
            InDanhSach(ketQua);
    }

    static void SuaDiem()
    {
        Console.WriteLine("--- SỬA ĐIỂM ---");
        string ma = NhapChuoi("Nhập mã sinh viên: ");

        if (quanLy.TimTheoMa(ma) == null)
        {
            Console.WriteLine("Không tìm thấy sinh viên.");
            return;
        }

        double diemMoi = NhapDiem("Nhập điểm mới (0-10): ");
        quanLy.SuaDiem(ma, diemMoi);
        Console.WriteLine("Cập nhật điểm thành công.");
    }

    static void XoaSinhVien()
    {
        Console.WriteLine("--- XÓA SINH VIÊN ---");
        string ma = NhapChuoi("Nhập mã sinh viên: ");

        if (quanLy.Xoa(ma))
            Console.WriteLine("Xóa thành công.");
        else
            Console.WriteLine("Không tìm thấy sinh viên.");
    }

    static void SapXepTheoDiem()
    {
        Console.WriteLine("--- SẮP XẾP THEO ĐIỂM GIẢM DẦN ---");
        InDanhSach(quanLy.SapXepTheoDiem());
    }

    static void LocSinhVienDat()
    {
        Console.WriteLine("--- SINH VIÊN ĐẠT (ĐIỂM >= 5) ---");
        var ketQua = quanLy.LocSinhVienDat();

        if (ketQua.Count == 0)
            Console.WriteLine("Không có sinh viên nào đạt.");
        else
            InDanhSach(ketQua);
    }

    // ---------- HÀM IN BẢNG ----------
    static void InDanhSach(List<SinhVien> ds)
    {
        if (ds.Count == 0)
        {
            Console.WriteLine("Danh sách trống.");
            return;
        }

        Console.WriteLine($"{"Mã",-10}{"Họ tên",-25}{"Lớp",-12}{"Điểm",-8}{"Xếp loại",-12}");
        Console.WriteLine(new string('-', 67));

        foreach (var sv in ds)
        {
            Console.WriteLine($"{sv.MaSinhVien,-10}{sv.HoTen,-25}{sv.MaLop,-12}{sv.DiemTrungBinh,-8:0.0}{sv.XepLoai(),-12}");
        }
    }

    // ---------- HÀM NHẬP LIỆU AN TOÀN ----------
    // Mỗi hàm lặp lại cho đến khi người dùng nhập đúng => không bao giờ crash

    static string NhapChuoi(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (!string.IsNullOrWhiteSpace(input))
                return input;

            Console.WriteLine("Không được để trống, vui lòng nhập lại.");
        }
    }

    static DateTime NhapNgay(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime ngay) && ngay <= DateTime.Today)
                return ngay;

            Console.WriteLine("Ngày sinh không hợp lệ (đúng định dạng dd/MM/yyyy, không ở tương lai).");
        }
    }

    static double NhapDiem(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            // Cho phép gõ 8,5 hoặc 8.5
            string input = (Console.ReadLine() ?? "").Trim().Replace(',', '.');

            if (!double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double diem))
            {
                Console.WriteLine("Vui lòng nhập một số hợp lệ.");
                continue;
            }

            if (diem < 0 || diem > 10)
            {
                Console.WriteLine("Điểm không hợp lệ, phải trong khoảng 0 - 10. Nhập lại.");
                continue;
            }

            return diem;
        }
    }
}