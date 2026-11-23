namespace MLZ2026.Core.Tests;

public sealed class DatabaseServiceTests : DatabaseTestsBase
{
    [Test]
    public async Task TestTablesAreCreatedAtConstruction()
    { 
        var databaseService = await CreateDatabaseService();

        var tables = databaseService.GetTables().ToList();

        Assert.That(tables, Does.Contain(nameof(TodoItem)));
    }    

    [Test]
    public async Task TestAddData()
    {
        var databaseService = await CreateDatabaseService();

        await databaseService.DeleteAll();

        TodoItem item = new()
        {
            Title = "Test"
        };
        
        var itemCountInserted = await databaseService.Insert(item);
        
        Assert.That(itemCountInserted, Is.EqualTo(1));

        var items = await databaseService.GetItems().ToListAsync();

        Assert.That(items, Has.Count.EqualTo(1));
        Assert.That(items[0].Title, Is.EqualTo("Test"));
    }

    [Test]
    public async Task TestUpdateData()
    {
        var databaseService = await CreateDatabaseService();

        await databaseService.DeleteAll();

        TodoItem item = new()
        {
            Title = "Test"
        };
        
        var itemCountInserted = await databaseService.Insert(item);
        
        Assert.That(itemCountInserted, Is.EqualTo(1));

        var items = await databaseService.GetItems().ToListAsync();

        Assert.That(items, Has.Count.EqualTo(1));
        var todoItem = items[0];
        Assert.That(todoItem.Title, Is.EqualTo("Test"));
        
        todoItem.Title = "Updated Test";
        
        await databaseService.Update(todoItem);
    }

    [Test]
    public async Task TestDeleteData()
    {
        var databaseService = await CreateDatabaseService();

        await databaseService.DeleteAll();

        TodoItem item = new()
        {
            Title = "Test"
        };
        
        var itemCountInserted = await databaseService.Insert(item);
        
        Assert.That(itemCountInserted, Is.EqualTo(1));

        var items = await databaseService.GetItems().ToListAsync();

        Assert.That(items, Has.Count.EqualTo(1));
        Assert.That(items[0].Title, Is.EqualTo("Test"));
        
        await databaseService.Delete(item);
    }
}