namespace MLZ2026.Core.Tests;

public sealed class DatabaseServiceTests
{
    [Test]
    public void TestTablesAreCreatedAtConstruction()
    {
        var databaseService = CreateDatabaseService();

        var tables = databaseService.GetTables().ToList();

        Assert.That(tables, Does.Contain(nameof(TodoItem)));
    }    
    
    private static IDatabaseService CreateDatabaseService()
    {
        var provider = new ServiceCollection()
            .AddTestCore()
            .BuildServiceProvider();

        return provider.GetRequiredService<IDatabaseService>();
    }

}