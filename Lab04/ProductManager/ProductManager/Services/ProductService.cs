using ProductManager.Exceptions;
using ProductManager.Models;
using ProductManager.Repositories;

namespace ProductManager.Services;

public class ProductService
{
    private readonly Repository<Product> _repository = new();

    // EVENT: thông báo khi thêm / xóa thành công
    public event Action<Product>? ProductAdded;
    public event Action<Product>? ProductRemoved;

    public void AddProduct(Product product)
    {
        if (_repository.FindById(product.MaSP) != null)
            throw new DuplicateProductException(product.MaSP);

        _repository.Add(product);
        ProductAdded?.Invoke(product);      // phát event SAU KHI thêm thành công
    }

    public void RemoveProduct(string id)
    {
        Product? product = _repository.FindById(id);
        if (product == null)
            throw new ProductNotFoundException(id);

        _repository.Remove(id);
        ProductRemoved?.Invoke(product);    // phát event SAU KHI xóa thành công
    }

    public List<Product> GetAll() => _repository.GetAll();

    public Product? FindById(string id) => _repository.FindById(id);

    // Hàm lọc tổng quát nhận Func
    public List<Product> Filter(Func<Product, bool> condition)
    {
        return _repository.Find(condition);
    }

    public List<Product> SearchByName(string keyword)
    {
        return Filter(p => p.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase));
    }

    public List<Product> FilterByPrice(decimal min, decimal max)
    {
        if (min > max)
            throw new ArgumentException("Gia nho nhat khong duoc lon hon gia lon nhat.");

        Func<Product, bool> inRange = p => p.Price >= min && p.Price <= max;
        return Filter(inRange);
    }

    public decimal CalculateTotalValue()
    {
        return _repository.GetAll().Sum(p => p.Price * p.Quantity);
    }
}