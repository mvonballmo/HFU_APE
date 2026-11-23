namespace MLZ2026.Core;

public interface IDatabaseServiceFactory
{
    IDatabaseService CreateService();
}