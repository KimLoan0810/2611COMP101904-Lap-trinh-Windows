namespace ProductManager;

public class DuplicateProductException : Exception
{
    public string MaSP { get; }

    public DuplicateProductException(string maSP)
        : base($"Ma san pham '{maSP}' da ton tai.")
    {
        MaSP = maSP;
    }
}