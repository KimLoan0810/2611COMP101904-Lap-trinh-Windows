namespace ProductManager.Models;

public class Product : IEntity
{
    private decimal _price;
    private int _quantity;
    private string _tenSP = string.Empty;

    public string MaSP { get; }

    public string TenSP
    {
        get => _tenSP;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ten san pham khong duoc rong.");
            _tenSP = value.Trim();
        }
    }

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

    // Thỏa mãn IEntity: Id chính là MaSP
    public string Id => MaSP;

    public Product(string maSP, string tenSP, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(maSP))
            throw new ArgumentException("Ma san pham khong duoc rong.");

        MaSP = maSP.Trim();
        TenSP = tenSP;       // đi qua setter nên được kiểm tra
        Price = price;       // đi qua setter nên được kiểm tra
        Quantity = quantity; // đi qua setter nên được kiểm tra
    }

    public override string ToString()
    {
        return $"Ma: {MaSP,-8} | Ten: {TenSP,-20} | Gia: {Price,12:N0} | SL: {Quantity,5}";
    }
}