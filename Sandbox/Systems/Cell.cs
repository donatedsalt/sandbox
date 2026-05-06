using Sandbox.Core;

namespace Sandbox.Systems;

public class Cell
{
    public List<IEntity> Entities { get; set; } = [];

    public void AddEntity(IEntity entity)
    {
        Entities.Add(entity);
    }

    public void RemoveEntity(IEntity entity)
    {
        Entities.Remove(entity);
    }
}
