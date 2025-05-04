namespace Stuff.Core;

public interface IProjectile
{
    bool Detonated { get; set; }
    void Detonate();
}

public class Projectile : IProjectile
{
    public bool Detonated { get; set; }

    public void Detonate()
    {
        Detonated = true;
    }
}