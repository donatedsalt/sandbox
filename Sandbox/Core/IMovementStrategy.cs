using Sandbox.Entities;

namespace Sandbox.Core;

public interface IMovementStrategy
{
    void Move(Critter critter);
}
