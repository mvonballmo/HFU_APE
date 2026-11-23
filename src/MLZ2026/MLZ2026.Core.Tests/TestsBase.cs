namespace MLZ2026.Core.Tests;

public class TestsBase
{
    protected static T CreateService<T>() 
        where T : notnull
    {
        return ServiceProviderServiceExtensions.GetRequiredService<T>(CreateServiceProvider());
    }

    protected static ServiceProvider CreateServiceProvider()
    {
        return new ServiceCollection()
            .AddTestCore()
            .BuildServiceProvider();
    }
}