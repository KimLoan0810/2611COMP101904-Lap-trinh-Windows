using System;

class Program
{
    static void Main(string[] args)
    {
        // Khung chương trình chính sẽ viết ở đây sau
        int[] arr = null; // Khởi tạo mảng ban đầu chưa có dữ liệu
        int choice;

        do
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max/min");
            Console.WriteLine("5. Dem chan/le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");

            choice = NhapSoNguyen("Chon chuc nang: ");

            // Kiểm tra ràng buộc: Chưa nhập mảng thì không cho chọn chức năng từ 2 đến 7
            if (choice >= 2 && choice <= 7 && arr == null)
            {
                Console.WriteLine("--> Vui long chon chuc nang 1 de nhap mang truoc!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    arr = NhapMang();
                    break;
                case 2:
                    XuatMang(arr);
                    break;
                case 3:
                    Console.WriteLine($"Tong cac phan tu trong mang = {TinhTong(arr)}");
                    break;
                case 4:
                    Console.WriteLine($"Gia tri lon nhat (max) = {TimMax(arr)}");
                    Console.WriteLine($"Gia tri nho nhat (min) = {TimMin(arr)}");
                    break;
                case 5:
                    Console.WriteLine($"So luong phan tu chan = {DemChan(arr)}");
                    Console.WriteLine($"So luong phan tu le = {DemLe(arr)}");
                    break;
                case 6:
                    SapXepTangDan(arr);
                    Console.Write("Mang sau khi sap xep: ");
                    XuatMang(arr);
                    break;
                case 7:
                    int x = NhapSoNguyen("Nhap gia tri x can tim: ");
                    int pos = TimKiem(arr, x);
                    if (pos != -1)
                        Console.WriteLine($"Tim thay {x} tai vi tri dau tien index = {pos}");
                    else
                        Console.WriteLine($"Khong tim thay {x} trong mang.");
                    break;
                case 0:
                    Console.WriteLine("Da thoat chuong trinh.");
                    break;
                default:
                    Console.WriteLine("Loi: Chuc nang khong hop le, vui long chon lai!");
                    break;
            }
        } while (choice != 0);
    }

    // --- CÁC PHƯƠNG THỨC HỖ TRỢ NHẬP DỮ LIỆU ---

    // Hàm nhập số nguyên, tự kiểm tra nếu nhập chữ sẽ báo lỗi nhập lại
    static int NhapSoNguyen(string message)
    {
        int res;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out res))
                return res;
            Console.WriteLine("Loi: Vui long nhap mot so nguyen hop le!");
        }
    }

    // Hàm nhập số nguyên dương > 0 (dùng cho số lượng phần tử n)
    static int NhapSoNguyenDuong(string message)
    {
        int res;
        while (true)
        {
            res = NhapSoNguyen(message);
            if (res > 0)
                return res;
            Console.WriteLine("Loi: So luong phan tu phai la so nguyen duong (> 0)!");
        }
    }
    // --- CÁC PHƯƠNG THỨC NHẬP VÀ XUẤT MẢNG ---

    // Hàm nhập mảng n phần tử
    static int[] NhapMang()
    {
        int n = NhapSoNguyenDuong("Nhap so luong phan tu n: ");
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = NhapSoNguyen($"Nhap a[{i}]: ");
        }
        Console.WriteLine("--> Nhap mang thanh cong!");
        return a;
    }

    // Hàm xuất toàn bộ phần tử trong mảng
    static void XuatMang(int[] a)
    {
        Console.Write("Cac phan tu trong mang: ");
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine();
    }
    // --- CÁC PHƯƠNG THỨC XỬ LÝ VÀ TÍNH TOÁN MẢNG ---

    // Tính tổng các phần tử trong mảng
    static int TinhTong(int[] a)
    {
        int sum = 0;
        foreach (int item in a) sum += item;
        return sum;
    }

    // Tìm giá trị lớn nhất (max)
    static int TimMax(int[] a)
    {
        int max = a[0];
        for (int i = 1; i < a.Length; i++)
            if (a[i] > max) max = a[i];
        return max;
    }

    // Tìm giá trị nhỏ nhất (min)
    static int TimMin(int[] a)
    {
        int min = a[0];
        for (int i = 1; i < a.Length; i++)
            if (a[i] < min) min = a[i];
        return min;
    }

    // Đếm số lượng phần tử chẵn
    static int DemChan(int[] a)
    {
        int count = 0;
        foreach (int item in a)
            if (item % 2 == 0) count++;
        return count;
    }

    // Đếm số lượng phần tử lẻ
    static int DemLe(int[] a)
    {
        int count = 0;
        foreach (int item in a)
            if (item % 2 != 0) count++;
        return count;
    }

    // Sắp xếp mảng tăng dần
    static void SapXepTangDan(int[] a)
    {
        Array.Sort(a);
    }

    // Tìm kiếm vị trí đầu tiên xuất hiện của x, không thấy trả về -1
    static int TimKiem(int[] a, int x)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == x) return i;
        }
        return -1;
    }
}