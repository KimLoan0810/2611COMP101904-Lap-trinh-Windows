using System;
using System.Collections.Generic;

namespace Lab03_QuanLySinhVienOOP
{
    internal class Program
    {
        private static readonly QuanLySinhVien qlsv = new QuanLySinhVien();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            int luaChon = -1;
            do
            {
                HienThiMenu();
                luaChon = NhapSoNguyen("Chọn chức năng: ");
                Console.WriteLine();

                switch (luaChon)
                {
                    case 1:
                        ChucNangThemSinhVien();
                        break;
                    case 2:
                        ChucNangXuatDanhSach(qlsv.LayDanhSach(), "DANH SÁCH SINH VIÊN");
                        break;
                    case 3:
                        ChucNangTimTheoMa();
                        break;
                    case 4:
                        ChucNangTimTheoTen();
                        break;
                    case 5:
                        ChucNangSuaDiem();
                        break;
                    case 6:
                        ChucNangXoaSinhVien();
                        break;
                    case 7:
                        ChucNangXuatDanhSach(qlsv.SapXepTheoDiemGiamDan(), "DANH SÁCH SẮP XẾP THEO ĐIỂM GIẢM DẦN");
                        break;
                    case 8:
                        ChucNangXuatDanhSach(qlsv.LocSinhVienDat(), "DANH SÁCH SINH VIÊN ĐẠT (ĐTB >= 5.0)");
                        break;
                    case 0:
                        Console.WriteLine("Đã thoát chương trình. Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại!");
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine("\nBấm phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (luaChon != 0);
        }

        private static void HienThiMenu()
        {
            Console.WriteLine("===== QUẢN LÝ SINH VIÊN =====");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Xuất danh sách");
            Console.WriteLine("3. Tìm sinh viên theo mã");
            Console.WriteLine("4. Tìm sinh viên theo tên");
            Console.WriteLine("5. Sửa điểm trung bình");
            Console.WriteLine("6. Xóa sinh viên");
            Console.WriteLine("7. Sắp xếp theo điểm giảm dần");
            Console.WriteLine("8. Lọc sinh viên đạt");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("=============================");
        }

        private static void ChucNangThemSinhVien()
        {
            Console.WriteLine("--- THÊM SINH VIÊN MỚI ---");
            string maSV;
            while (true)
            {
                Console.Write("Nhập mã sinh viên: ");
                maSV = Console.ReadLine()?.Trim() ?? "";
                if (string.IsNullOrEmpty(maSV))
                {
                    Console.WriteLine("Mã sinh viên không được để trống!");
                    continue;
                }
                if (qlsv.TimTheoMa(maSV) != null)
                {
                    Console.WriteLine("Mã sinh viên đã tồn tại trong hệ thống! Vui lòng nhập mã khác.");
                    continue;
                }
                break;
            }

            Console.Write("Nhập họ tên sinh viên: ");
            string hoTen = Console.ReadLine()?.Trim() ?? "";

            DateTime ngaySinh = NhapNgaySinh("Nhập ngày sinh (dd/MM/yyyy): ");

            Console.Write("Nhập mã lớp: ");
            string maLop = Console.ReadLine()?.Trim() ?? "";

            double diemTB = NhapDiemTrungBinh("Nhập điểm trung bình (0.0 - 10.0): ");

            SinhVien sv = new SinhVien(maSV, hoTen, ngaySinh, maLop, diemTB);
            if (qlsv.Them(sv))
            {
                Console.WriteLine("Thêm sinh viên thành công!");
            }
            else
            {
                Console.WriteLine("Thêm sinh viên thất bại!");
            }
        }

        private static void ChucNangXuatDanhSach(List<SinhVien> ds, string tieuDe)
        {
            Console.WriteLine($"--- {tieuDe} ---");
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sách trống!");
                return;
            }

            foreach (var sv in ds)
            {
                Console.WriteLine(sv.LayThongTin());
            }
        }

        private static void ChucNangTimTheoMa()
        {
            Console.WriteLine("--- TÌM SINH VIÊN THEO MÃ ---");
            Console.Write("Nhập mã sinh viên cần tìm: ");
            string maSV = Console.ReadLine()?.Trim() ?? "";

            var sv = qlsv.TimTheoMa(maSV);
            if (sv != null)
            {
                Console.WriteLine("Tìm thấy sinh viên:");
                Console.WriteLine(sv.LayThongTin());
            }
            else
            {
                Console.WriteLine($"Không tìm thấy sinh viên có mã: {maSV}");
            }
        }

        private static void ChucNangTimTheoTen()
        {
            Console.WriteLine("--- TÌM SINH VIÊN THEO TÊN ---");
            Console.Write("Nhập từ khóa họ tên cần tìm: ");
            string tuKhoa = Console.ReadLine()?.Trim() ?? "";

            var dsKetQua = qlsv.TimTheoTen(tuKhoa);
            ChucNangXuatDanhSach(dsKetQua, $"KẾT QUẢ TÌM KIẾM THEO TỪ KHÓA \"{tuKhoa}\"");
        }

        private static void ChucNangSuaDiem()
        {
            Console.WriteLine("--- SỬA ĐIỂM TRUNG BÌNH ---");
            Console.Write("Nhập mã sinh viên cần sửa điểm: ");
            string maSV = Console.ReadLine()?.Trim() ?? "";

            var sv = qlsv.TimTheoMa(maSV);
            if (sv == null)
            {
                Console.WriteLine($"Không tìm thấy sinh viên có mã: {maSV}");
                return;
            }

            Console.WriteLine($"Thông tin hiện tại: {sv.LayThongTin()}");
            double diemMoi = NhapDiemTrungBinh("Nhập điểm trung bình mới (0.0 - 10.0): ");

            if (qlsv.SuaDiem(maSV, diemMoi))
            {
                Console.WriteLine("Cập nhật điểm trung bình thành công!");
            }
            else
            {
                Console.WriteLine("Cập nhật thất bại!");
            }
        }

        private static void ChucNangXoaSinhVien()
        {
            Console.WriteLine("--- XÓA SINH VIÊN ---");
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string maSV = Console.ReadLine()?.Trim() ?? "";

            if (qlsv.Xoa(maSV))
            {
                Console.WriteLine($"Đã xóa sinh viên có mã: {maSV}");
            }
            else
            {
                Console.WriteLine($"Không tìm thấy sinh viên có mã: {maSV}");
            }
        }

        #region Hàm hỗ trợ nhập liệu an toàn
        private static int NhapSoNguyen(string thongBao)
        {
            int giaTri;
            while (true)
            {
                Console.Write(thongBao);
                if (int.TryParse(Console.ReadLine(), out giaTri))
                {
                    return giaTri;
                }
                Console.WriteLine("Dữ liệu nhập không hợp lệ. Vui lòng nhập số nguyên!");
            }
        }

        private static double NhapDiemTrungBinh(string thongBao)
        {
            double diem;
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine()?.Replace(',', '.') ?? "";
                if (double.TryParse(input, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out diem))
                {
                    if (diem >= 0.0 && diem <= 10.0)
                    {
                        return diem;
                    }
                }
                Console.WriteLine("Điểm không hợp lệ! Điểm phải là số thực từ 0.0 đến 10.0.");
            }
        }

        private static DateTime NhapNgaySinh(string thongBao)
        {
            DateTime ngaySinh;
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine()?.Trim() ?? "";
                if (DateTime.TryParseExact(input, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out ngaySinh))
                {
                    return ngaySinh;
                }
                Console.WriteLine("Ngày sinh không đúng định dạng dd/MM/yyyy! Ví dụ: 20/11/2004.");
            }
        }
        #endregion
    }
}