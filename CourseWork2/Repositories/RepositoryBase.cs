using System.Data;
using System.Data.Common;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public abstract class RepositoryBase
{
    private const string ConnectionString = "Server=localhost;Database=CourseWorkDB;Uid=root;Pwd=562389;";
    public event Action? RepositoryChanged;

    protected static MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }
    
    protected async Task<List<T>> GetAllAsync<T>(MySqlCommand command, MySqlConnection connection, object[] parameters)
        where T : new()
    {
        PrepareCommand(command, connection, parameters);
        await using DbDataReader reader = await command.ExecuteReaderAsync();
        return GetInstancesList<T>(reader);
    }
    
    protected async Task<T?> GetValueAsync<T>(MySqlCommand command, MySqlConnection connection, object[] parameters)
        where T : new()
    {
        PrepareCommand(command, connection, parameters);
        await using DbDataReader reader = await command.ExecuteReaderAsync();
        return !await reader.ReadAsync() ? default : GetInstance<T>(reader);
    }

    protected async Task<int> ExecuteCommandAsync(MySqlCommand command, MySqlConnection connection, object[] parameters)
    {
        PrepareCommand(command, connection, parameters);
        int rowsNumber = await command.ExecuteNonQueryAsync();
        RepositoryChanged?.Invoke();
        return rowsNumber;
    }

    private List<T> GetInstancesList<T>(DbDataReader reader) where T : new()
    {
        Type            type        = typeof(T);
        ConstructorInfo constructor = type.GetConstructor([])!;
        PropertyInfo[] properties = type.GetProperties();
        
        if (reader.FieldCount != properties.Length)
        {
            throw new ArgumentException("Invalid T type", nameof(reader));
        }
        
        var list = new List<T>();
        while (reader.Read())
        {
            var instance = (T)constructor.Invoke([]);
            
            for (var i = 0; i < properties.Length; i++)
            {
                properties[i].SetValue(instance, reader[i]);
            }
            
            list.Add(instance);
        }
        
        return list;
    }

    private void PrepareCommand(MySqlCommand command, MySqlConnection connection, IReadOnlyList<object> parameters)
    {
        if (connection.State is not ConnectionState.Open)
        {
            throw new Exception("Connection is not open");
        }
        if (command.Parameters.Count != parameters.Count)
        {
            throw new Exception("Invalid number of parameters");
        }

        command.Connection = connection;
        for (var i = 0; i < parameters.Count; i++)
        {
            command.Parameters[i].Value = parameters[i];
        }
    }

    private T GetInstance<T>(IDataRecord reader) where T : new()
    {
        Type            type        = typeof(T);
        ConstructorInfo constructor = type.GetConstructor([])!;
        PropertyInfo[]  properties  = type.GetProperties();

        if (reader.FieldCount != properties.Length)
        {
            throw new ArgumentException("Invalid T type", nameof(reader));
        }

        var instance = (T)constructor.Invoke([]);

        for (var i = 0; i < properties.Length; i++)
        {
            properties[i].SetValue(instance, reader[i]);
        }

        return instance;
    }
}