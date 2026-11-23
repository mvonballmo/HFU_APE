namespace MLZ2026.Core;

public interface IAppService
{
    public Task SeedIfEmpty();

    public Task DeleteAll();
}