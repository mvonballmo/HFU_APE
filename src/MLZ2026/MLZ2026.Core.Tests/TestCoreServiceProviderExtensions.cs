namespace MLZ2026.Core.Tests;

public static class TestCoreServiceProviderExtensions
{
    public static IServiceCollection AddTestCore(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddCore()
            .AddSingleton<IDialogService, TestDialogService>();
    }
}