using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03_QuanLySinhVienOOP
{
    internal class Program
    {
        private static QuanLySinhVien qlsv = new QuanLySinhVien();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool tiepTuc = true;
            while (tiepTuc)
            {
                HienThiMenu();
                Console.Write("Chọn chức năng: ");
                string chon = Console.ReadLine();

                Console.WriteLine("\n--------------------------------------------------");
                switch (chon)
                {
                    case "1":
                        ThucHienThem();
                        break;
                    case "2":
                        HienThiDanhSach(qlsv.LayDanhSach(), "DANH SÁCH SINH VIÊN");
                        break;
                    case "3":
                        ThucHienTimTheoMa();
                        break;
                    case "4":
                        ThucHienTimTheoTen();
                        break;
                    case "5":
                        ThucHienSuaDiem();
                        break;
                    case "6":
                        ThucHienXoa();
                        break;
                    case "7":
                        HienThiDanhSach(qlsv.SapXepTheoDiemGiamDan(), "DANH SÁCH SẮP XẾP THEO ĐIỂM GIẢM DẦN");
                        break;
                    case "8":
                        HienThiDanhSach(qlsv.LocSinhVienDat(), "DANH SÁCH SINH VIÊN ĐẠT (ĐTB >= 5.0)");
                        break;
                    case "0":
                        tiepTuc = false;
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn lại.");
                        break;
                }
                Console.WriteLine("--------------------------------------------------\n");
            }
        }

        static void HienThiMenu()
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
        }

        static void ThucHienThem()
        {
            Console.WriteLine("--- THÊM SINH VIÊN MỚI ---");
            Console.Write("Nhập mã sinh viên: ");
            string maSV = Console.ReadLine().Trim();

            if (qlsv.TimTheoMa(maSV) != null)
            {
                Console.WriteLine("Lỗi: Mã sinh viên này đã tồn tại!");
                return;
            }

            Console.Write("Nhập họ và tên: ");
            string hoTen = Console.ReadLine().Trim();

            DateTime ngaySinh;
            while (true)
            {
                Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
                {
                    break;
                }
                Console.WriteLine("Ngày sinh không đúng định dạng dd/MM/yyyy! Vui lòng nhập lại.");
            }

            Console.Write("Nhập mã lớp: ");
            string maLop = Console.ReadLine().Trim();

            double dtb;
            while (true)
            {
                Console.Write("Nhập điểm trung bình (0 - 10): ");
                if (double.TryParse(Console.ReadLine(), out dtb) && dtb >= 0 && dtb <= 10)
                {
                    break;
                }
                Console.WriteLine("Điểm trung bình không hợp lệ! Vui lòng nhập số từ 0 đến 10.");
            }

            SinhVien sv = new SinhVien(maSV, hoTen, ngaySinh, maLop, dtb);
            if (qlsv.Them(sv))
            {
                Console.WriteLine("Thêm sinh viên thành công!");
            }
        }

        static void HienThiDanhSach(List<SinhVien> danhSach, string tieuDe)
        {
            Console.WriteLine($"--- {tieuDe} ---");
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách trống!");
                return;
            }

            foreach (var sv in danhSach)
            {
                Console.WriteLine(sv.LayThongTin());
            }
        }

        static void ThucHienTimTheoMa()
        {
            Console.Write("Nhập mã sinh viên cần tìm: ");
            string maSV = Console.ReadLine().Trim();
            SinhVien sv = qlsv.TimTheoMa(maSV);

            if (sv != null)
            {
                Console.WriteLine("Tìm thấy sinh viên:");
                Console.WriteLine(sv.LayThongTin());
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên có mã này!");
            }
        }

        static void ThucHienTimTheoTen()
        {
            Console.Write("Nhập từ khóa họ tên cần tìm: ");
            string tuKhoa = Console.ReadLine().Trim();
            var ketQua = qlsv.TimTheoTen(tuKhoa);

            HienThiDanhSach(ketQua, $"KẾT QUẢ TÌM KIẾM THEO TỪ KHÓA '{tuKhoa}'");
        }

        static void ThucHienSuaDiem()
        {
            Console.Write("Nhập mã sinh viên cần sửa điểm: ");
            string maSV = Console.ReadLine().Trim();

            if (qlsv.TimTheoMa(maSV) == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên có mã này!");
                return;
            }

            double diemMoi;
            while (true)
            {
                Console.Write("Nhập điểm trung bình mới (0 - 10): ");
                if (double.TryParse(Console.ReadLine(), out diemMoi) && diemMoi >= 0 && diemMoi <= 10)
                {
                    break;
                }
                Console.WriteLine("Điểm không hợp lệ! Vui lòng nhập số từ 0 đến 10.");
            }

            if (qlsv.SuaDiem(maSV, diemMoi))
            {
                Console.WriteLine("Cập nhật điểm thành công!");
            }
        }

        static void ThucHienXoa()
        {
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string maSV = Console.ReadLine().Trim();

            if (qlsv.Xoa(maSV))
            {
                Console.WriteLine("Xóa sinh viên thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên có mã này để xóa!");
            }
        }
    }
}