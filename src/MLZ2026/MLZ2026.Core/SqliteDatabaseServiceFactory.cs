namespace MLZ2026.Core;

public class SqliteDatabaseServiceFactory : IDatabaseServiceFactory
{
    public IDatabaseService CreateService()
    {
        return new SqliteDatabaseService();
    }
}