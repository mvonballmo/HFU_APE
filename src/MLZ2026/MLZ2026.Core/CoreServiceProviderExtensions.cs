namespace MLZ2026.Core;

public static class CoreServiceProviderExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<IDatabaseServiceFactory, SqliteDatabaseServiceFactory>()
            .AddSingleton<IExternalDataService, ExternalDataService>()
            .AddSingleton<IAppService, AppService>()
            .AddHttpClient();
    }
}