using System.Data;
using System.Data.Common;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public abstract class RepositoryBase<T> where T : new()
{
    private const string ConnectionString = "Server=localhost;Database=CourseWorkDB;Uid=root;Pwd=562389;";

    private readonly MySqlConnection _connection;

    protected RepositoryBase()
    {
        _connection = new MySqlConnection(ConnectionString);
    }

    public event Action? RepositoryChanged;

    protected MySqlCommand GetByIdCommand { get; init; }

    protected MySqlCommand DeleteCommand { get; init; }

    protected MySqlCommand GetAllCommand { get; init; }

    protected MySqlCommand GetAllByStringCommand { get; init; }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await GetValueAsync(GetByIdCommand, [id]);
    }

    public async Task RemoveAsync(int id)
    {
        await ExecuteCommandAsync(DeleteCommand, [id]);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await GetAllAsync(GetAllCommand, []);
    }

    public async Task<IEnumerable<T>> GetAllByStringAsync(string text)
    {
        return await GetAllAsync(GetAllByStringCommand, [text]);
    }

    protected static MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }

    protected async Task<List<T>> GetAllAsync(MySqlCommand command, object[] parameters)
    {
        await PrepareCommand(command, parameters);
        await using DbDataReader reader = command.ExecuteReader();
        return GetInstancesList(reader);
    }

    protected async Task<T?> GetValueAsync(MySqlCommand command, object[] parameters)
    {
        await PrepareCommand(command, parameters);
        await using DbDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow);
        return !await reader.ReadAsync() ? default(T?) : GetInstance(reader);
    }

    protected async Task<int> ExecuteCommandAsync(MySqlCommand command, object[] parameters)
    {
        await PrepareCommand(command, parameters);
        int rowsNumber = await command.ExecuteNonQueryAsync();
        RepositoryChanged?.Invoke();
        return rowsNumber;
    }

    private List<T> GetInstancesList(DbDataReader reader)
    {
        PropertyInfo[] properties = typeof(T).GetProperties();

        if (reader.FieldCount != properties.Length)
        {
            throw new ArgumentException("Invalid T type", nameof(reader));
        }

        var list = new List<T>();
        while (reader.Read())
        {
            var instance = new T();

            for (var i = 0; i < properties.Length; i++)
            {
                properties[i].SetValue(instance, reader[i]);
            }

            list.Add(instance);
        }

        return list;
    }

    private async Task PrepareCommand(MySqlCommand command, IReadOnlyList<object> parameters)
    {
        if (_connection.State is not ConnectionState.Open)
        {
            await _connection.OpenAsync();
        }

        if (command.Parameters.Count != parameters.Count)
        {
            throw new Exception("Invalid number of parameters");
        }

        command.Connection = _connection;
        for (var i = 0; i < parameters.Count; i++)
        {
            command.Parameters[i].Value = parameters[i];
        }
    }

    private T GetInstance(IDataRecord reader)
    {
        PropertyInfo[] properties = typeof(T).GetProperties();

        if (reader.FieldCount != properties.Length)
        {
            throw new ArgumentException("Invalid T type", nameof(reader));
        }

        var instance = new T();

        for (var i = 0; i < properties.Length; i++)
        {
            properties[i].SetValue(instance, reader[i]);
        }

        return instance;
    }
}