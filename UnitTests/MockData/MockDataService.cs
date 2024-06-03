using System.ComponentModel.DataAnnotations;
using LogicLayer.Core;
using LogicLayer.Interfaces;

namespace UnitTests.MockData;


public class MockDataService<T>(IEnumerable<T> data) : IDatabaseEntityService<T>
{
    
    private IEnumerable<T> data = data;
    
    
    public Task<List<T>?> GetFromKey(T objectWithKey)
    {
        var keyProperties = typeof(T).GetProperties().Where(prop => prop.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute))).ToList();
        
        List<T> result = [];
        
        foreach (var keyProperty in keyProperties)
        {
            var keyPropertyValue = keyProperty.GetValue(objectWithKey);
            if (keyPropertyValue == null || keyPropertyValue.Equals(0)) continue;
            
            foreach (var obj in data)
            {
                var objKeyPropertyValue = keyProperty.GetValue(obj);
                if (objKeyPropertyValue == null || objKeyPropertyValue.Equals(0)) continue;
                
                if (objKeyPropertyValue.Equals(keyPropertyValue))
                {
                    result.Add(obj);
                }
            }
            // ReSharper disable once NullableWarningSuppressionIsUsed
            return Task.FromResult(result)!;
        }
        // ReSharper disable once NullableWarningSuppressionIsUsed
        return null!; 
    }

    public Task<List<T>?> GetAll()
    {
        return Task.FromResult(data.ToList());
    }

    public Task<DatabaseResult> Insert(T obj)
    {
        if (data.Contains(obj)) return Task.FromResult(DatabaseResult.Duplicate);

        var list = data.ToList();
        
        list.Add(obj);
        
        data = list;
        
        return Task.FromResult(DatabaseResult.Success);
        
    }

    public Task<DatabaseResult> Update(T obj)
    {
        var keyProperties = typeof(T).GetProperties().Where(prop => prop.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute))).ToList();

        foreach (var keyProperty in keyProperties)
        {
            var keyPropertyValue = keyProperty.GetValue(obj);
            if (keyPropertyValue == null || keyPropertyValue.Equals(0)) continue;
            
            var key = keyPropertyValue.ToString();
            
            var list = data.ToList();
            
            data.ToList().ForEach(o =>
            {
                if (keyProperty.GetValue(o)?.ToString() == key)
                {
                    list.Remove(o);
                    list.Add(obj);
                }
            });

            data = list;
            
            return Task.FromResult(DatabaseResult.Success);
        }
        
        return Task.FromResult(DatabaseResult.Fail);
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}