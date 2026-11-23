namespace MLZ2026.Core.Tests;

public static class TestCoreServiceProviderExtensions
{
    public static IServiceCollection AddTestCore(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<IDatabaseServiceFactory, SqliteDatabaseServiceFactory>()
            .AddSingleton<IDialogService, TestDialogService>();
    }
}