using Microsoft.Extensions.DependencyInjection;
using Sandbox.Core;
using Sandbox.Entities;

namespace Sandbox.Factories;

public interface IEntityFactory
{
    Critter CreateCritter(string type);
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

    public Critter CreateCritter(string type)
    {
        switch (type)
        {
            case "bunny":
                return new Critter(
                    name: "bunny",
                    health: 10,
                    energy: 10,
                    attack: 1,
                    defence: 1,
                    speed: 1,
                    vision: 1,
                    movementStrategy: _walkStrategy
                );
            case "wolf":
                return new Critter(
                    name: "wolf",
                    health: 10,
                    energy: 10,
                    attack: 2,
                    defence: 1,
                    speed: 1,
                    vision: 1,
                    movementStrategy: _walkStrategy
                );
            case "eagle":
                return new Critter(
                    name: "eagle",
                    health: 10,
                    energy: 10,
                    attack: 2,
                    defence: 1,
                    speed: 2,
                    vision: 1,
                    movementStrategy: _flyStrategy
                );
            default:
                throw new ArgumentException("Invalid critter type", nameof(type));
        }
    }
}
