using SQLite;

namespace MLZ2026.Core;

public class SqliteDatabaseService : IDatabaseService
{
    private readonly SQLiteConnection _connection;

    public SqliteDatabaseService()
    {
        _connection = CreateConnection();

        EnsureTablesExist();
    }

    private void EnsureTablesExist()
    {
        var tableExists = _connection.TableMappings.Any(
            m => m.TableName.Equals(nameof(TodoItem), StringComparison.InvariantCultureIgnoreCase)
        );

        if (!tableExists)
        {
            // TODO use Async?
            _connection.CreateTable<TodoItem>();
        }
    }

    public IEnumerable<string> GetTables()
    {
        return _connection.TableMappings.Select(t => t.TableName);
    }

    public int Insert(TodoItem item)
    {
        return _connection.Insert(item);
    }

    public IEnumerable<TodoItem> GetItems()
    {
        return _connection.Table<TodoItem>();
    }

    public void DeleteAll()
    {
        _connection.DeleteAll<TodoItem>();
    }

    public void Delete(TodoItem item)
    {
        _connection.Delete(item);
    }

    public void Update(TodoItem todoItem)
    {
        _connection.Update(todoItem);
    }

    public void Dispose()
    {
        _connection.Dispose();
    }

    private static SQLiteConnection CreateConnection()
    {
        SQLiteConnection? connection = null;
        try
        {
            // TODO Do this somewhere else
            if (!Directory.Exists(DatabaseFolder))
            {
                Directory.CreateDirectory(DatabaseFolder);
            }

            // TODO inject settings
            var options = new SQLiteConnectionString(Path.Join(DatabaseFolder, "MLZ2026.db"), true);
            connection = new SQLiteConnection(options);
            
            return connection;
        }
        catch
        {
            connection?.Dispose();
            
            throw;
        }
    }

    private static readonly string DatabaseFolder =
        Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MLZ2026");
}