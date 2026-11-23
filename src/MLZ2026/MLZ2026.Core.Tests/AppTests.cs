namespace MLZ2026.Core.Tests;

class AppTests : DatabaseTestsBase
{
    [Test]
    public async Task TestSeedEmptyDatabase()
    {
        var databaseService = await CreateDatabaseService();
        var appService = CreateService<IAppService>();

        await appService.DeleteAll();

        var databaseItems = await databaseService.GetItems().ToListAsync();
        
        Assert.AreEqual(0, databaseItems.Count);

        await appService.SeedIfEmpty();
        
        databaseItems = await databaseService.GetItems().ToListAsync();

        Assert.AreEqual(20, databaseItems.Count);
    }
    
    [Test]
    public async Task TestDoesNotSeedNonEmptyDatabase()
    {
        var databaseService = await CreateDatabaseService();
        var appService = CreateService<IAppService>();

        await appService.DeleteAll();

        await appService.SeedIfEmpty();
        await appService.SeedIfEmpty();
        
        var databaseItems = await databaseService.GetItems().ToListAsync();

        Assert.AreEqual(20, databaseItems.Count);
    }
    
}