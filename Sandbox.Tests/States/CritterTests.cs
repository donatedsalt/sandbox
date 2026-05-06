using Sandbox.Entities;
using Sandbox.States;
using Sandbox.Strategies;

namespace Sandbox.Tests.States;

public class CritterTests
{
    [Fact]
    public void Critter_ShouldTransitionToHungryState_WhenEnergyIsBelowThreshold()
    {
        var critter = new Critter(
            x: 0,
            y: 0,
            name: "wolf",
            maxHealth: 10,
            maxEnergy: 10,
            attack: 2,
            defence: 1,
            speed: 1,
            vision: 1,
            movementStrategy: new WalkStrategy()
        );

        critter.Energy = 5;
        critter.Update();
        Assert.IsType<HungryState>(critter.CurrentState);
    }
}
