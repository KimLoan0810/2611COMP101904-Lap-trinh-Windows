namespace ProductManager;

public class Product : IEntity
{
    private decimal _price;
    private int _quantity;

    public string MaSP { get; }
    public string TenSP { get; set; }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentException("Don gia khong duoc am.");
            _price = value;
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value < 0)
                throw new ArgumentException("So luong khong duoc am.");
            _quantity = value;
        }
    }

    // Thực thi IEntity: Id chính là MaSP
    public string Id => MaSP;

    public Product(string maSP, string tenSP, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(maSP))
            throw new ArgumentException("Ma san pham khong duoc rong.");
        if (string.IsNullOrWhiteSpace(tenSP))
            throw new ArgumentException("Ten san pham khong duoc rong.");

        MaSP = maSP.Trim();
        TenSP = tenSP.Trim();
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
        => $"{MaSP,-8} | {TenSP,-25} | {Price,12:N0} | SL: {Quantity,5}";
}