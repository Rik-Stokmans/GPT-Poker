using System.ComponentModel.DataAnnotations;
using LogicLayer.Core;
using LogicLayer.Interfaces;

namespace UnitTests.MockData;


public class MockDataService<T>(IEnumerable<T> data) : IDatabaseEntityService<T>
{
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
        throw new NotImplementedException();
    }

    public Task<DatabaseResult> Insert(T obj)
    {
        throw new NotImplementedException();
    }

    public Task Update(T obj)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}