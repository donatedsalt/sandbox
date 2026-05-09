namespace Sandbox.Core;

public interface IEntity
{
    int X { get; set; }
    int Y { get; set; }

    char Symbol { get; set; }
    string Name { get; set; }
    int MaxHealth { get; set; }
    int Health { get; set; }

    void Update();
}
