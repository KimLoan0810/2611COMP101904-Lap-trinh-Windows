namespace ProductManager;

public class ProductNotFoundException : Exception
{
    public string MaSP { get; }

    public ProductNotFoundException(string maSP)
        : base($"Khong tim thay san pham co ma '{maSP}'.")
    {
        MaSP = maSP;
    }
}