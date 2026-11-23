using SQLite;

namespace MLZ2026.Core;

public interface IDatabaseService
{
    IEnumerable<string> GetTables();
}

public class TodoItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public required string Title { get; set; }
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
        using var connection = CreateConnection();
        
        return connection.TableMappings.Select(t => t.TableName);
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