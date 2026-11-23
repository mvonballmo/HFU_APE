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

    [Test]
    public void TestAddData()
    {
        var databaseService = CreateDatabaseService();

        databaseService.DeleteAll();

        TodoItem item = new()
        {
            Title = "Test"
        };
        
        var itemCountInserted = databaseService.Insert(item);
        
        Assert.That(itemCountInserted, Is.EqualTo(1));

        var items = databaseService.GetItems().ToList();

        Assert.That(items, Has.Count.EqualTo(1));
        Assert.That(items[0].Title, Is.EqualTo("Test"));
    }

    [Test]
    public void TestUpdateData()
    {
        var databaseService = CreateDatabaseService();

        databaseService.DeleteAll();

        TodoItem item = new()
        {
            Title = "Test"
        };
        
        var itemCountInserted = databaseService.Insert(item);
        
        Assert.That(itemCountInserted, Is.EqualTo(1));

        var items = databaseService.GetItems().ToList();

        Assert.That(items, Has.Count.EqualTo(1));
        var todoItem = items[0];
        Assert.That(todoItem.Title, Is.EqualTo("Test"));
        
        todoItem.Title = "Updated Test";
        
        databaseService.Update(todoItem);
    }

    [Test]
    public void TestDeleteData()
    {
        var databaseService = CreateDatabaseService();

        databaseService.DeleteAll();

        TodoItem item = new()
        {
            Title = "Test"
        };
        
        var itemCountInserted = databaseService.Insert(item);
        
        Assert.That(itemCountInserted, Is.EqualTo(1));

        var items = databaseService.GetItems().ToList();

        Assert.That(items, Has.Count.EqualTo(1));
        Assert.That(items[0].Title, Is.EqualTo("Test"));
        
        databaseService.Delete(item);
    }
    
    private static IDatabaseService CreateDatabaseService()
    {
        var provider = new ServiceCollection()
            .AddTestCore()
            .BuildServiceProvider();

        return provider.GetRequiredService<IDatabaseService>();
    }

}