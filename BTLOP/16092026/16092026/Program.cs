using System;
using System.Collections.Generic;
using System.Text;

namespace _16092026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Nhanvien> danhSach = new List<Nhanvien>();

            // Danh sách sẵn 5 nhân viên thuộc các loại
            danhSach.Add(new Nhanvienvanphong("NV01", "Nguyễn Văn A", 5000000, 22));
            danhSach.Add(new Nhanvienkinhdoanh("NV02", "Trần Thị B", 4000000, 50000000));
            danhSach.Add(new Nhanvienvanphong("NV03", "Lê Văn C", 6000000, 26));
            danhSach.Add(new Nhanvienkinhdoanh("NV04", "Phạm Thị D", 4500000, 120000000));
            danhSach.Add(new Nhanvienthoivu("NV05", "Hoàng Văn E", 80, 50000));

            int chon = -1;
            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Xuất danh sách nhân viên");
                Console.WriteLine("2. Tìm nhân viên theo mã");
                Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
                Console.WriteLine("4. Tính tổng lương công ty phải trả");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("==========================");
                Console.Write("Lựa chọn của bạn: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Vui lòng nhập số hợp lệ!");
                    continue;
                }

                switch (chon)
                {
                    case 1:
                        Console.WriteLine("\n--- DANH SÁCH NHÂN VIÊN ---");
                        foreach (var nv in danhSach)
                        {
                            nv.HienThiThongTin(); // Đa hình
                        }
                        break;

                    case 2:
                        Console.Write("\nNhập mã nhân viên cần tìm: ");
                        string maTim = Console.ReadLine()?.Trim();
                        bool timThay = false;
                        foreach (var nv in danhSach)
                        {
                            if (nv.MaNV.Equals(maTim, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Thông tin nhân viên tìm thấy:");
                                nv.HienThiThongTin(); // Đa hình
                                timThay = true;
                                break;
                            }
                        }
                        if (!timThay)
                        {
                            Console.WriteLine("Không tìm thấy nhân viên có mã này!");
                        }
                        break;

                    case 3:
                        if (danhSach.Count == 0)
                        {
                            Console.WriteLine("Danh sách trống!");
                            break;
                        }

                        Nhanvien nvMax = danhSach[0];
                        foreach (var nv in danhSach)
                        {
                            if (nv.TinhLuong() > nvMax.TinhLuong()) // Đa hình
                            {
                                nvMax = nv;
                            }
                        }

                        Console.WriteLine("\n--- NHÂN VIÊN CÓ LƯƠNG CAO NHẤT ---");
                        nvMax.HienThiThongTin();
                        break;

                    case 4:
                        double tongLuong = 0;
                        foreach (var nv in danhSach)
                        {
                            tongLuong += nv.TinhLuong(); // Đa hình
                        }
                        Console.WriteLine($"\nTổng tiền lương công ty phải trả: {tongLuong:N0} VNĐ");
                        break;

                    case 0:
                        Console.WriteLine("Đã thoát chương trình!");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            } while (chon != 0);
        }
    }
}