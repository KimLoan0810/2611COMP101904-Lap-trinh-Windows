namespace ProductManager;

public class ProductService
{
    private readonly Repository<Product> _repository = new();

    // Event: nơi khác đăng ký (+=) để được báo khi có thay đổi
    public event Action<Product>? ProductAdded;
    public event Action<Product>? ProductRemoved;

    public void AddProduct(Product product)
    {
        if (_repository.FindById(product.Id) != null)
            throw new DuplicateProductException(product.Id);

        _repository.Add(product);
        ProductAdded?.Invoke(product);      // chỉ chạy khi thêm THÀNH CÔNG
    }

    public void RemoveProduct(string maSP)
    {
        Product product = GetById(maSP);    // không có thì ném ProductNotFoundException
        _repository.Remove(maSP);
        ProductRemoved?.Invoke(product);    // chỉ chạy khi xóa THÀNH CÔNG
    }

    public Product GetById(string maSP)
    {
        return _repository.FindById(maSP)
               ?? throw new ProductNotFoundException(maSP);
    }

    public IReadOnlyList<Product> GetAll() => _repository.GetAll();

    // Hàm lọc tổng quát: nhận điều kiện dưới dạng Func<Product, bool>
    public IEnumerable<Product> Filter(Func<Product, bool> condition)
        => _repository.Find(condition);

    public IEnumerable<Product> SearchByName(string keyword)
        => Filter(p => p.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<Product> FilterByPrice(decimal min, decimal max)
        => Filter(p => p.Price >= min && p.Price <= max);

    public decimal GetTotalValue()
        => _repository.GetAll().Sum(p => p.Price * p.Quantity);
}