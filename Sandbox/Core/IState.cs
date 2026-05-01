using Sandbox.Entities;

namespace Sandbox.Core;

public interface IState
{
    void Update(Critter critter);
}
