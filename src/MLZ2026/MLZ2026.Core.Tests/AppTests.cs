namespace MLZ2026.Core.Tests;

class AppTests : DatabaseTestsBase
{
    [Test]
    public async Task TestLoadAndSaveData()
    {
        var databaseService = await CreateDatabaseService();
        var externalDataService = CreateService<IExternalDataService>();

        await databaseService.DeleteAll();
        
        var todoItems = await externalDataService.GetTodoItems() ?? throw new InvalidOperationException();

        foreach (var todoItem in todoItems)
        {
            await databaseService.Insert(todoItem);
        }

        var databaseItems = await databaseService.GetItems().ToListAsync();
        
        Assert.That(databaseItems.Count, Is.EqualTo(todoItems.Length));
        Assert.That(databaseItems, Is.EqualTo(todoItems));
    }
}