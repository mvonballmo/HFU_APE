namespace Stuff.Core;

public class Spaceship
{
    private readonly Pilot _pilot;
    private readonly Weapon _weapon;

    public Spaceship(Pilot pilot, Weapon weapon)
    {
        _pilot = pilot;
        _weapon = weapon;
    }

    public void Fight()
    {
        _pilot.Fire(_weapon);
    }
}