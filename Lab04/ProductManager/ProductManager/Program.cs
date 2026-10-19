using ProductManager.Exceptions;
using ProductManager.Models;
using ProductManager.Services;

namespace ProductManager;

internal class Program
{
    private static readonly ProductService _service = new();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        RegisterEvents();

        bool running = true;
        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine()?.Trim() ?? "";

            try
            {
                switch (choice)
                {
                    case "1": AddProduct(); break;
                    case "2": ShowAllProducts(); break;
                    case "3": FindById(); break;
                    case "4": FindByName(); break;
                    case "5": FilterByPrice(); break;
                    case "6": RemoveProduct(); break;
                    case "7": ShowTotalValue(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Lua chon khong hop le!"); break;
                }
            }
            catch (DuplicateProductException ex)
            {
                Console.WriteLine($"[LOI TRUNG MA] {ex.Message}");
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine($"[LOI KHONG TIM THAY] {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[LOI DU LIEU] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LOI KHONG XAC DINH] {ex.Message}");
            }

            if (running)
            {
                Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
                Console.ReadKey(true);
            }
        }

        Console.WriteLine("Tam biet!");
    }

    // ---------- EVENT ----------
    private static void RegisterEvents()
    {
        _service.ProductAdded += p =>
            Console.WriteLine($"[EVENT] Da them san pham: {p.TenSP} ({p.MaSP})");

        _service.ProductRemoved += p =>
            Console.WriteLine($"[EVENT] Da xoa san pham: {p.TenSP} ({p.MaSP})");
    }

    // ---------- MENU ----------
    private static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("===== PRODUCT MANAGER =====");
        Console.WriteLine("1. Them san pham");
        Console.WriteLine("2. Xuat danh sach");
        Console.WriteLine("3. Tim theo ma");
        Console.WriteLine("4. Tim theo ten");
        Console.WriteLine("5. Loc theo khoang gia");
        Console.WriteLine("6. Xoa san pham");
        Console.WriteLine("7. Tinh tong gia tri kho");
        Console.WriteLine("0. Thoat");
        Console.Write("Chon: ");
    }

    // ---------- CHỨC NĂNG ----------
    private static void AddProduct()
    {
        string id = ReadNonEmptyString("Nhap ma san pham: ");
        string name = ReadNonEmptyString("Nhap ten san pham: ");
        decimal price = ReadDecimal("Nhap don gia: ");
        int quantity = ReadInt("Nhap so luong: ");

        // Constructor sẽ throw ArgumentException nếu giá/SL âm
        Product product = new(id, name, price, quantity);
        _service.AddProduct(product);
    }

    private static void ShowAllProducts()
    {
        PrintProducts(_service.GetAll());
    }

    private static void FindById()
    {
        string id = ReadNonEmptyString("Nhap ma can tim: ");
        Product? product = _service.FindById(id);

        if (product == null)
            Console.WriteLine("Khong tim thay san pham.");
        else
            Console.WriteLine(product);
    }

    private static void FindByName()
    {
        string keyword = ReadNonEmptyString("Nhap tu khoa: ");
        PrintProducts(_service.SearchByName(keyword));
    }

    private static void FilterByPrice()
    {
        decimal min = ReadDecimal("Nhap gia nho nhat: ");
        decimal max = ReadDecimal("Nhap gia lon nhat: ");
        PrintProducts(_service.FilterByPrice(min, max));
    }

    private static void RemoveProduct()
    {
        string id = ReadNonEmptyString("Nhap ma san pham can xoa: ");
        _service.RemoveProduct(id);
    }

    private static void ShowTotalValue()
    {
        Console.WriteLine($"Tong gia tri kho: {_service.CalculateTotalValue():N0}");
    }

    // ---------- HÀM HỖ TRỢ IN ----------
    private static void PrintProducts(List<Product> products)
    {
        if (products.Count == 0)
        {
            Console.WriteLine("Danh sach rong / khong co san pham phu hop.");
            return;
        }

        foreach (Product p in products)
            Console.WriteLine(p);
    }

    // ---------- HÀM HỖ TRỢ NHẬP (KHÔNG BAO GIỜ CRASH) ----------
    private static string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            Console.WriteLine("Khong duoc de trong. Vui long nhap lai.");
        }
    }

    private static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out decimal value))
                return value;

            Console.WriteLine("Vui long nhap mot so hop le.");
        }
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value))
                return value;

            Console.WriteLine("Vui long nhap mot so nguyen hop le.");
        }
    }
}