namespace ProductManager;

public class Repository<T> where T : IEntity
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public bool Remove(string id)
    {
        T? item = FindById(id);
        return item != null && _items.Remove(item);
    }

    public T? FindById(string id)
    {
        return _items.FirstOrDefault(
            x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<T> Find(Func<T, bool> predicate)
    {
        return _items.Where(predicate);
    }

    public IReadOnlyList<T> GetAll()
    {
        return _items.AsReadOnly();
    }
}