using ProductManager.Models;

namespace ProductManager.Repositories;

public class Repository<T> where T : IEntity
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
    }

    // Trả về true nếu xóa được, false nếu không có
    public bool Remove(string id)
    {
        T? item = FindById(id);
        if (item == null) return false;
        return _items.Remove(item);
    }

    public T? FindById(string id)
    {
        return _items.FirstOrDefault(x =>
            x.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
    }

    // Func<T,bool>: điều kiện lọc được truyền từ bên ngoài vào
    public List<T> Find(Func<T, bool> predicate)
    {
        return _items.Where(predicate).ToList();
    }

    public List<T> GetAll()
    {
        return _items.ToList(); // trả bản sao để bên ngoài không sửa trực tiếp list gốc
    }
}