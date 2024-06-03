namespace LogicLayer.Interfaces;

public interface IDatabaseEntityService<T>
{
    public Task<List<T>?> GetFromKey(T objectWithKey);

    public Task<List<T>?> GetAll();
    
    public Task<Core.DatabaseResult> Insert(T obj);
    
    public Task<Core.DatabaseResult> Update(T obj);
    
    public Task Delete(int id);

}