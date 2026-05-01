using Sandbox.Core;
using Sandbox.Entities;

namespace Sandbox.Strategies;

public class WalkStrategy : IMovementStrategy
{
    public void Move(Critter critter)
    {
        Console.WriteLine($"{critter.Name} is walking at {critter.Speed} speed.");
    }
}

public class FlyStrategy : IMovementStrategy
{
    public void Move(Critter critter)
    {
        Console.WriteLine($"{critter.Name} is flying at {critter.Speed} speed.");
    }
}
