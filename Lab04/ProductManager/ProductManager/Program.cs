using System.Text;
using ProductManager;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

var service = new ProductService();

// Đăng ký nhận event: phần "thông báo ra màn hình" nằm ở Program, không nằm trong Service
service.ProductAdded += p => Console.WriteLine($"[EVENT] Da them san pham: {p.TenSP} ({p.MaSP})");
service.ProductRemoved += p => Console.WriteLine($"[EVENT] Da xoa san pham: {p.TenSP} ({p.MaSP})");

bool running = true;
while (running)
{
    ShowMenu();
    string choice = Console.ReadLine()?.Trim() ?? "";

    try
    {
        switch (choice)
        {
            case "1": AddProduct(service); break;
            case "2": ShowAll(service); break;
            case "3": FindById(service); break;
            case "4": FindByName(service); break;
            case "5": FilterByPrice(service); break;
            case "6": RemoveProduct(service); break;
            case "7": ShowTotalValue(service); break;
            case "0": running = false; break;
            default: Console.WriteLine("Lua chon khong hop le."); break;
        }
    }
    catch (DuplicateProductException ex) { Console.WriteLine($"Loi: {ex.Message}"); }
    catch (ProductNotFoundException ex) { Console.WriteLine($"Loi: {ex.Message}"); }
    catch (ArgumentException ex) { Console.WriteLine($"Du lieu khong hop le: {ex.Message}"); }
    catch (Exception ex) { Console.WriteLine($"Loi khong xac dinh: {ex.Message}"); }
}

Console.WriteLine("Tam biet!");

// ===================== Cac ham chuc nang =====================

static void ShowMenu()
{
    Console.WriteLine();
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

static void AddProduct(ProductService service)
{
    string ma = ReadString("Nhap ma: ");
    string ten = ReadString("Nhap ten: ");
    decimal gia = ReadDecimal("Nhap don gia: ");
    int sl = ReadInt("Nhap so luong: ");

    // Constructor ném ArgumentException nếu giá/số lượng âm
    // AddProduct ném DuplicateProductException nếu trùng mã
    service.AddProduct(new Product(ma, ten, gia, sl));
}

static void ShowAll(ProductService service)
{
    var list = service.GetAll();
    if (list.Count == 0)
    {
        Console.WriteLine("Danh sach san pham dang rong.");
        return;
    }
    PrintProducts(list);
}

static void FindById(ProductService service)
{
    string ma = ReadString("Nhap ma can tim: ");
    Console.WriteLine(service.GetById(ma));   // không thấy -> ProductNotFoundException
}

static void FindByName(ProductService service)
{
    string keyword = ReadString("Nhap tu khoa: ");
    PrintProducts(service.SearchByName(keyword).ToList());
}

static void FilterByPrice(ProductService service)
{
    decimal min = ReadDecimal("Gia nho nhat: ");
    decimal max = ReadDecimal("Gia lon nhat: ");
    if (min > max)
    {
        Console.WriteLine("Gia nho nhat khong duoc lon hon gia lon nhat.");
        return;
    }
    PrintProducts(service.FilterByPrice(min, max).ToList());
}

static void RemoveProduct(ProductService service)
{
    string ma = ReadString("Nhap ma can xoa: ");
    service.RemoveProduct(ma);
}

static void ShowTotalValue(ProductService service)
{
    Console.WriteLine($"Tong gia tri kho: {service.GetTotalValue():N0}");
}

static void PrintProducts(IReadOnlyList<Product> products)
{
    if (products.Count == 0)
    {
        Console.WriteLine("Khong co san pham nao phu hop.");
        return;
    }
    foreach (var p in products)
        Console.WriteLine(p);
}

// ===================== Ham nhap lieu an toan =====================

static string ReadString(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) return input.Trim();
        Console.WriteLine("Khong duoc de trong.");
    }
}

static decimal ReadDecimal(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (decimal.TryParse(Console.ReadLine(), out decimal value)) return value;
        Console.WriteLine("Vui long nhap mot so hop le.");
    }
}

static int ReadInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int value)) return value;
        Console.WriteLine("Vui long nhap mot so nguyen hop le.");
    }
}