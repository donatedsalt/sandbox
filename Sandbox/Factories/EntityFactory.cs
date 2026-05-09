using Microsoft.Extensions.DependencyInjection;
using Sandbox.Core;
using Sandbox.Entities;

namespace Sandbox.Factories;

public interface IEntityFactory
{
    IEntity Create(string type, int x, int y);
    IEntity CreateRandom(int x, int y);
}

public class EntityFactory : IEntityFactory
{
    private readonly IMovementStrategy _walkStrategy;
    private readonly IMovementStrategy _flyStrategy;

    public EntityFactory(
        [FromKeyedServices("walk")] IMovementStrategy walkStrategy,
        [FromKeyedServices("fly")] IMovementStrategy flyStrategy)
    {
        _walkStrategy = walkStrategy;
        _flyStrategy = flyStrategy;
    }

    public IEntity Create(string type, int x, int y)
    {
        switch (type)
        {
            case "rabbit":
                return new Critter(
                    x: x,
                    y: y,
                    symbol: 'R',
                    name: "rabbit",
                    maxHealth: 10,
                    maxEnergy: 10,
                    attack: 1,
                    defence: 1,
                    speed: 1,
                    vision: 1,
                    movementStrategy: _walkStrategy
                );
            case "wolf":
                return new Critter(
                    x: x,
                    y: y,
                    symbol: 'W',
                    name: "wolf",
                    maxHealth: 10,
                    maxEnergy: 10,
                    attack: 2,
                    defence: 1,
                    speed: 1,
                    vision: 1,
                    movementStrategy: _walkStrategy
                );
            case "eagle":
                return new Critter(
                    x: x,
                    y: y,
                    symbol: 'E',
                    name: "eagle",
                    maxHealth: 10,
                    maxEnergy: 10,
                    attack: 2,
                    defence: 1,
                    speed: 2,
                    vision: 1,
                    movementStrategy: _flyStrategy
                );
            case "tree":
                return new Plant(
                    x: x,
                    y: y,
                    symbol: 'T',
                    name: "tree",
                    maxHealth: 10,
                    baseGrowthRate: 0.1
                );
            case "bush":
                return new Plant(
                    x: x,
                    y: y,
                    symbol: 'B',
                    name: "bush",
                    maxHealth: 5,
                    baseGrowthRate: 0.2
                );
            case "grass":
                return new Plant(
                    x: x,
                    y: y,
                    symbol: 'G',
                    name: "grass",
                    maxHealth: 1,
                    baseGrowthRate: 0.3
                );
            default:
                throw new ArgumentException("Invalid entity type", nameof(type));
        }
    }

    public IEntity CreateRandom(int x, int y)
    {
        var type = Random.Shared.Next(100);
        switch (type)
        {
            case < 40:
                return Create("grass", x, y);
            case < 60:
                return Create("bush", x, y);
            case < 70:
                return Create("tree", x, y);
            case < 80:
                return Create("bunny", x, y);
            case < 90:
                return Create("wolf", x, y);
            default:
                return Create("grass", x, y);
        }
    }
}
