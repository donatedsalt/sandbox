using Sandbox.Core;
using Sandbox.Entities;

namespace Sandbox.States;

public class IdleState : IState
{
    public void Update(Critter critter)
    {
        critter.Energy -= 1;

        Console.WriteLine($"{critter.Name} is chilling. Energy: {critter.Energy}");

        if (critter.Energy <= 5)
        {
            critter.TransitionTo(new HungryState());
        }
    }
}
