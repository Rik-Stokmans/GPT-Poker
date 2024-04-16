using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LogicLayer.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace DataLayer.Services;

public class DatabaseEntityService<T> : IDatabaseEntityService<T> where T : new()
{
    private readonly string _tableName = typeof(T).Name.ToLower();

    public async Task<T?> GetFromKey(T objectWithKey)
    {

        var query = "";
        
        var keyProperties = typeof(T).GetProperties().Where(prop => prop.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute))).ToList();
        
        foreach (var keyProperty in keyProperties)
        {
            var keyPropertyValue = keyProperty.GetValue(objectWithKey);
            if (keyPropertyValue == null || keyPropertyValue.Equals(0)) continue;
            
            var key = keyPropertyValue.ToString();
                
            
            //todo: fix "\"" + email + "\""; in the player model to work just like a normal string
            query = "SELECT * FROM " + _tableName + " WHERE " + keyProperty.Name + " = " + key;
            break;
        }
        
        
        if (query == "")
        {
            Console.WriteLine("No key with a value found in object.");
            return default;
        }
        
        try
        {
            await using var connection = new DatabaseConnection();
            return await connection.Connection.QueryFirstOrDefaultAsync<T>(query);
        } catch (MySqlException e)
        {
            Console.WriteLine(e.Message);
            return default;
        }
        
        
    }

    public async Task<List<T>?> GetAll()
    {
        await using var connection = new DatabaseConnection();
        var query = "SELECT * FROM " + _tableName;
        
        var obj = await connection.Connection.QueryAsync<T>(query);
        return obj.ToList();
    }

    public async Task<string?> Insert(T obj)
    {
        await using var connection = new DatabaseConnection();
        var properties = typeof(T).GetProperties().Where(prop => prop.CustomAttributes.All(attr => attr.AttributeType != typeof(DatabaseGeneratedAttribute))).ToList();
        
        var columns = string.Join(", ", properties.Select(prop => prop.Name));
        var values = string.Join(", ", properties.Select(prop => "@" + prop.Name));
        var query = $"INSERT INTO {_tableName} ({columns}) VALUES ({values}); SELECT last_insert_rowid();";
        
        try
        {
            var result = await connection.Connection.ExecuteScalarAsync<T>(query, obj);

            if (result != null)
            {
                Console.WriteLine("Inserted: ");
                var prop = result.GetType().GetProperties().ToList();
                
                foreach (var propertyInfo in prop)
                {
                    var result1 = propertyInfo.GetValue(result);
                    Console.WriteLine(result1);
                }
            }
        }
        catch (MySqlException e)
        {
            if (e.Message.StartsWith("Duplicate entry"))
            {
                
                var failedColumn = e.Message.Split("'");

                return failedColumn[1];
            }
        }

        return null;
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