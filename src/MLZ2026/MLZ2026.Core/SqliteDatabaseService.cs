using SQLite;

namespace MLZ2026.Core;

public class SqliteDatabaseService : IDatabaseService
{
    private readonly SQLiteAsyncConnection _connection;

    public SqliteDatabaseService()
    {
        _connection = CreateConnection();
    }

    public async Task EnsureTablesExist()
    {
        var tableExists = _connection.TableMappings.Any(
            m => m.TableName.Equals(nameof(TodoItem), StringComparison.InvariantCultureIgnoreCase)
        );

        if (!tableExists)
        {
            await _connection.CreateTableAsync<TodoItem>();
        }
    }

    public IEnumerable<string> GetTables()
    {
        return _connection.TableMappings.Select(t => t.TableName);
    }

    public Task<int> Insert(TodoItem item)
    {
        return _connection.InsertAsync(item);
    }

    public AsyncTableQuery<TodoItem> GetItems()
    {
        return _connection.Table<TodoItem>();
    }

    public Task<int> DeleteAll()
    {
        return _connection.DeleteAllAsync<TodoItem>();
    }

    public Task<int> Delete(TodoItem item)
    {
        return _connection.DeleteAsync(item);
    }

    public Task<int> Update(TodoItem todoItem)
    {
        return _connection.UpdateAsync(todoItem);
    }

    private static SQLiteAsyncConnection CreateConnection()
    {
        // TODO Do this somewhere else
        if (!Directory.Exists(DatabaseFolder))
        {
            Directory.CreateDirectory(DatabaseFolder);
        }

        // TODO inject settings
        var options = new SQLiteConnectionString(Path.Join(DatabaseFolder, "MLZ2026.db"), true);

        return new SQLiteAsyncConnection(options);
    }

    private static readonly string DatabaseFolder =
        Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MLZ2026");
}