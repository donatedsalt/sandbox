using Sandbox.Core;
using Sandbox.States;

namespace Sandbox.Entities;

public class Critter : IWeatherObserver, IEntity
{
    public int X { get; set; }
    public int Y { get; set; }

    public char Symbol { get; set; }
    public string Name { get; set; }

    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int MaxEnergy { get; set; }
    public int Energy { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public int Speed { get; set; }
    public int Vision { get; set; }

    public IMovementStrategy MovementStrategy { get; set; }

    public IState CurrentState { get; private set; } = null!;

    public Critter(
        int x,
        int y,
        char symbol,
        string name,
        int maxHealth,
        int maxEnergy,
        int attack,
        int defence,
        int speed,
        int vision,
        IMovementStrategy movementStrategy
    )
    {
        X = x;
        Y = y;
        Symbol = symbol;
        Name = name;
        MaxHealth = maxHealth;
        MaxEnergy = maxEnergy;
        Attack = attack;
        Defence = defence;
        Speed = speed;
        Vision = vision;

        Health = Random.Shared.Next(maxHealth / 2, MaxHealth + 1);
        Energy = Random.Shared.Next(maxEnergy / 2, MaxEnergy + 1);

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
            MaxEnergy -= 1;
        }
    }
}
