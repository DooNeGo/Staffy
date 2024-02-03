using System.Data;
using System.Data.Common;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public abstract class RepositoryBase<T> : IAsyncDisposable, IDisposable where T : new()
{
    private const string ConnectionString = "Server=localhost;Database=CourseWorkDB;Uid=user;Pwd=1111;";

    private readonly MySqlConnection _connection = new(ConnectionString);

    private bool _isDisposed;

    protected MySqlCommand GetByIdCommand { get; set; } = new();

    protected MySqlCommand DeleteCommand { get; set; } = new();

    protected MySqlCommand GetAllCommand { get; set; } = new();

    protected MySqlCommand GetAllByStringCommand { get; set; } = new();

    protected MySqlCommand AddCommand { get; set; } = new();

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
        GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public event Action? RepositoryChanged;

    public Task<T?> GetByIdAsync(int id)
    {
        return GetValueAsync(GetByIdCommand, [id]);
    }

    public Task RemoveAsync(int id)
    {
        return ExecuteCommandAsync(DeleteCommand, [id]);
    }

    public Task<List<T>> GetAllAsync()
    {
        return GetAllAsync(GetAllCommand, []);
    }

    public Task AddAsync(T item)
    {
        PropertyInfo[] properties = typeof(T).GetProperties();
        IEnumerable<object> result = from property in properties
                                     select property.GetValue(item);
        return ExecuteCommandAsync(AddCommand, result.ToArray());
    }

    public Task<List<T>> GetAllByStringAsync(string text)
    {
        return GetAllAsync(GetAllByStringCommand, [text]);
    }

    protected static MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }

    protected async Task<List<T>> GetAllAsync(MySqlCommand command, object?[] parameters)
    {
        await PrepareCommand(command, parameters);
        await using DbDataReader reader = await command.ExecuteReaderAsync();
        return GetInstancesList(reader);
    }

    protected async Task<T?> GetValueAsync(MySqlCommand command, object?[] parameters)
    {
        await PrepareCommand(command, parameters);
        await using DbDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow);
        return !await reader.ReadAsync() ? default(T?) : GetInstance(reader);
    }

    protected async Task<int> ExecuteCommandAsync(MySqlCommand command, object?[] parameters)
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

    private async Task PrepareCommand(MySqlCommand command, IReadOnlyList<object?> parameters)
    {
        if (command.Parameters.Count != parameters.Count)
        {
            throw new Exception("Invalid number of parameters");
        }

        if (_connection.State is not ConnectionState.Open)
        {
            await _connection.OpenAsync();
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

    private void Dispose(bool disposing)
    {
        if (!disposing || _isDisposed)
        {
            return;
        }

        _connection.Dispose();
        GetByIdCommand.Dispose();
        DeleteCommand.Dispose();
        GetAllCommand.Dispose();
        GetAllByStringCommand.Dispose();

        _isDisposed = true;
    }

    private async ValueTask DisposeAsyncCore()
    {
        if (_isDisposed)
        {
            return;
        }

        await _connection.DisposeAsync();
        await GetByIdCommand.DisposeAsync();
        await DeleteCommand.DisposeAsync();
        await GetAllCommand.DisposeAsync();
        await GetAllByStringCommand.DisposeAsync();

        _isDisposed = true;
    }
}