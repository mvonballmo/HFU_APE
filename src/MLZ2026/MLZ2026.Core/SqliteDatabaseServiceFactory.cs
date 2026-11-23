namespace MLZ2026.Core;

public class SqliteDatabaseServiceFactory : IDatabaseServiceFactory
{
    public async Task<IDatabaseService> CreateService()
    {
        var result = new SqliteDatabaseService();

        await result.EnsureTablesExist();

        return result;
    }
}