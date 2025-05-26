using MLZ2025.Core.Model;
using SQLite;

namespace MLZ2025.Core.Tests;

[TestFixture]
public class SqliteTests
{
    [Test]
    public void TestGetAndAddData()
    {
        if (!Directory.Exists(DatabaseFolder))
        {
            Directory.CreateDirectory(DatabaseFolder);
        }

        var options = new SQLiteConnectionString(DatabasePath, true);
        var connection = new SQLiteConnection(options);

        var tableExists = connection.TableMappings.Any(m =>
            m.TableName.Equals(nameof(DatabaseAddress), StringComparison.InvariantCultureIgnoreCase)
        );

        if (!tableExists)
        {
            connection.CreateTable<DatabaseAddress>();
        }

        connection.DeleteAll<DatabaseAddress>();

        var addressCount = connection.Table<DatabaseAddress>().Count();

        Assert.That(addressCount, Is.EqualTo(0));

        var max = connection.Insert(new DatabaseAddress
        {
            FirstName = "Max",
            LastName = "Mustermann"
        });

        addressCount = connection.Table<DatabaseAddress>().Count();

        Assert.That(addressCount, Is.EqualTo(1));
    }

    private static readonly string DatabaseFolder = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MLZ2025");
    private static readonly string DatabasePath = Path.Join(DatabaseFolder, "addresses.db");
}
