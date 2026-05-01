using Sandbox.Core;
using Sandbox.States;

namespace Sandbox.Entities;

public class Critter : IWeatherObserver
{
    public string Name { get; set; }

    public int Health { get; set; }
    public int Energy { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public int Speed { get; set; }
    public int Vision { get; set; }

    public IMovementStrategy MovementStrategy { get; set; }

    public IState CurrentState { get; private set; } = null!;

    public Critter(string name, int health, int energy, int attack, int defence, int speed, int vision, IMovementStrategy movementStrategy)
    {
        Name = name;
        Health = health;
        Energy = energy;
        Attack = attack;
        Defence = defence;
        Speed = speed;
        Vision = vision;

        MovementStrategy = movementStrategy;
        TransitionTo(new IdleState());
    }

    public void Move() => MovementStrategy.Move(this);

    public void Update() => CurrentState.Update(this);

    public void TransitionTo(IState state)
    {
        Console.WriteLine($"{Name} transitioned to {state.GetType().Name}.");
        CurrentState = state;
    }

    public void OnWeatherChange(string weather)
    {
        if (weather == "rain")
        {
            Console.WriteLine($"{Name} is finding shelter from the rain...");
            Energy -= 1;
        }
    }
}
