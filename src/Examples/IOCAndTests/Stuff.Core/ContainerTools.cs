using Microsoft.Extensions.DependencyInjection;

namespace Stuff.Core;

public static class ContainerTools
{
    public static IServiceProvider CreateServiceProvider()
    {
        var serviceCollection = new ServiceCollection();

        var projectile = new Projectile();
                
        serviceCollection
            .AddSingleton<Spaceship>()
            .AddSingleton<Projectile>()
            .AddSingleton<Pilot>()
            .AddSingleton<Weapon>();

        return serviceCollection.BuildServiceProvider();
    }
}