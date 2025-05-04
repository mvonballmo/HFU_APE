using Microsoft.Extensions.DependencyInjection;

namespace Stuff.Core.Tests;

public class SpaceshipTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestFightDetonatesProjectile()
    {
        var serviceProvider = CreateContainer();
        var spaceship = serviceProvider.GetRequiredService<Spaceship>();
        var projectile = serviceProvider.GetRequiredService<Projectile>();
        
        Assert.That(projectile.Detonated, Is.False);

        spaceship.Fight();
        
        Assert.That(projectile.Detonated, Is.True);
    }

    [Test]
    public void TestPilotPulledTrigger()
    {
        var serviceProvider = CreateContainer();
        var spaceship = serviceProvider.GetRequiredService<Spaceship>();
        var pilot = serviceProvider.GetRequiredService<Pilot>();
        
        Assert.That(pilot.PulledTrigger, Is.False);
        
        spaceship.Fight();
        
        Assert.That(pilot.PulledTrigger, Is.True);
    }

    private IServiceProvider CreateContainer()
    {
        return ContainerTools.CreateServiceProvider();
    }
}