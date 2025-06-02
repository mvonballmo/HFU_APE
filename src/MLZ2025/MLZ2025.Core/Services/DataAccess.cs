using SQLite;

namespace MLZ2025.Core.Services;

public class DataAccess<T> : IDisposable
    where T : new()
{
    public DataAccess()
    {
        if (!Directory.Exists(DatabaseFolder))
        {
            Directory.CreateDirectory(DatabaseFolder);
        }

        var options = new SQLiteConnectionString(DatabasePath, true);

        _connection = new SQLiteConnection(options);

        var tableExists = _connection.TableMappings.Any(m =>
            m.TableName.Equals(nameof(T), StringComparison.InvariantCultureIgnoreCase)
        );

        if (!tableExists)
        {
            _connection.CreateTable<T>();
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _connection.Dispose();
        }
    }

    public void DeleteAll()
    {
        _connection.DeleteAll<T>();
    }

    public TableQuery<T> Table()
    {
        return _connection.Table<T>();
    }

    public int Insert(T item)
    {
        return _connection.Insert(item);
    }

    private static readonly string DatabaseFolder =
        Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MLZ2025");

    private static readonly string DatabasePath = Path.Join(DatabaseFolder, "addresses.db");
    private readonly SQLiteConnection _connection;
}
