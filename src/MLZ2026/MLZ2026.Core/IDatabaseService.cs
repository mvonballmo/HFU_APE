using SQLite;

namespace MLZ2026.Core;

public interface  IDatabaseService
{
    IEnumerable<string> GetTables();
    
    // TODO Can we make this generic?
    int Insert(TodoItem item);
    
    IEnumerable<TodoItem> GetItems();
    
    void DeleteAll();
}

public class TodoItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
}

public class DatabaseService : IDatabaseService
{
    public DatabaseService()
    {
        using var connection = CreateConnection();

        var tableExists = connection.TableMappings.Any(
            m => m.TableName.Equals(nameof(TodoItem), StringComparison.InvariantCultureIgnoreCase)
        );
        
        if (!tableExists)
        {
            // TODO use Async?
            connection.CreateTable<TodoItem>();
        }
    }

    public IEnumerable<string> GetTables()
    {
        // TODO Make this a local field
        using var connection = CreateConnection();
        
        return connection.TableMappings.Select(t => t.TableName).ToArray();
    }

    public int Insert(TodoItem item)
    {
        using var connection = CreateConnection();
        
        return connection.Insert(item);
    }

    public IEnumerable<TodoItem> GetItems()
    {
        using var connection = CreateConnection();

        return connection.Table<TodoItem>().ToList();
    }

    public void DeleteAll()
    {
        using var connection = CreateConnection();

        connection.DeleteAll<TodoItem>();
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