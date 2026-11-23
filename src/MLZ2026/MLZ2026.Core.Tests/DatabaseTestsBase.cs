namespace MLZ2026.Core.Tests;

public class DatabaseTestsBase : TestsBase
{
    protected static async Task<IDatabaseService> CreateDatabaseService()
    {
        return await CreateService<IDatabaseServiceFactory>().CreateService();
    }
}