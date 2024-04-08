namespace LogicLayer.Interfaces;

public interface IDatabaseEntityService<T>
{
    public Task<T?> GetFromKey(T objectWithKey);

    public Task<List<T>?> GetAll();
    
    public Task<string?> Insert(T obj);
    
    public Task Update(T obj);
    
    public Task Delete(int id);

}