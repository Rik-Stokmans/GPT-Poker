using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LogicLayer.Interfaces;
using Dapper;
using LogicLayer.Core;
using MySql.Data.MySqlClient;

namespace DataLayer.Services;

public class DatabaseEntityService<T> : IDatabaseEntityService<T> where T : new()
{
    private readonly string _tableName = typeof(T).Name.ToLower();

    public async Task<List<T>?> GetFromKey(T objectWithKey)
    {

        var query = "";
        
        var keyProperties = typeof(T).GetProperties().Where(prop => prop.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute))).ToList();
        
        foreach (var keyProperty in keyProperties)
        {
            var keyPropertyValue = keyProperty.GetValue(objectWithKey);
            if (keyPropertyValue == null || keyPropertyValue.Equals(0)) continue;
            
            var key = keyPropertyValue.ToString();
            
            query = "SELECT * FROM " + _tableName + " WHERE " + keyProperty.Name + " = \"" + key + "\"";
            break;
        }
        
        
        if (query == "") return default;
        
        try
        {
            await using var connection = new DatabaseConnection();
            var obj = await connection.Connection.QueryAsync<T>(query);
            return obj.ToList();
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
        
        try
        {
            var obj = await connection.Connection.QueryAsync<T>(query);
            return obj.ToList();
        } catch (MySqlException e)
        {
            Console.WriteLine(e.Message);
            return default;
        }
    }

    
    public async Task<DatabaseResult> Insert(T obj)
    {
        await using var connection = new DatabaseConnection();
        var properties = typeof(T).GetProperties().Where(prop => prop.CustomAttributes.All(attr => attr.AttributeType != typeof(DatabaseGeneratedAttribute))).ToList();
        
        var columns = string.Join(", ", properties.Select(prop => prop.Name));
        var values = string.Join(", ", properties.Select(prop => "@" + prop.Name));
        var query = $"INSERT INTO {_tableName} ({columns}) VALUES ({values});";
        
        try
        {
            await connection.Connection.ExecuteScalarAsync<T>(query, obj);
            
            return DatabaseResult.Success;
        }
        catch (MySqlException e)
        {
            if (e.Message.StartsWith("Duplicate entry"))
            {
                return DatabaseResult.Duplicate;
            }
            Console.WriteLine(e.Message);
        }

        return DatabaseResult.Fail;
    }
    
    
    public Task<DatabaseResult> Update(T obj)
    {
        throw new NotImplementedException();
    }
    

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}