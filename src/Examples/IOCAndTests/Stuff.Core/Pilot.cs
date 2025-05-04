namespace Stuff.Core;

public class Pilot
{
    public void Fire(Weapon weapon)
    {
        PulledTrigger = true;
        weapon.Fire();
    }

    public bool PulledTrigger { get; private set; }
}