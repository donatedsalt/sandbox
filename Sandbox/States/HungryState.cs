using Sandbox.Core;
using Sandbox.Entities;

namespace Sandbox.States;

public class HungryState : IState
{
    public void Update(Critter critter)
    {
        Console.WriteLine($"{critter.Name} is searching for food...");

        critter.Energy += 2;

        if (critter.Energy >= critter.MaxEnergy - (critter.MaxEnergy / 4))
        {
            critter.TransitionTo(new IdleState());
        }
    }
}
