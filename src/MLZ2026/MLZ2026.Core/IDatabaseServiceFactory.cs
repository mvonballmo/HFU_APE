namespace MLZ2026.Core;

public interface IDatabaseServiceFactory
{
    Task<IDatabaseService> CreateService();
}