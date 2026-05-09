using Sandbox.Core;
using Sandbox.Factories;

namespace Sandbox.Systems;

public class World
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int MaxEntities { get; set; }
    public int TickDelay { get; set; }

    private readonly IEntityFactory _entityFactory;
    private readonly WeatherSystem _weatherSystem;

    public Cell[,] Cells { get; set; }

    public World(
        IEntityFactory entityFactory,
        WeatherSystem weatherSystem,
        int width,
        int height,
        int maxEntities,
        int tickDelay
    )
    {
        _entityFactory = entityFactory;
        _weatherSystem = weatherSystem;
        Width = width;
        Height = height;
        MaxEntities = maxEntities;
        TickDelay = tickDelay;
        Cells = new Cell[width, height];
    }

    public void Initialize()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Cells[x, y] = new Cell { };
            }
        }

        for (int i = 0; i < MaxEntities; i++)
        {
            var entity = _entityFactory.CreateRandom(Random.Shared.Next(Width), Random.Shared.Next(Height));
            if (entity is IWeatherObserver observer)
                _weatherSystem.Subscribe(observer);
            Cells[entity.X, entity.Y].AddEntity(entity);
        }
    }

    public void Tick()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                foreach (var entity in Cells[x, y].Entities)
                {
                    entity.Update();
                }
            }
        }
    }

    public void Run(int turns)
    {
        for (int i = 0; i < turns; i++)
        {
            Tick();
            Thread.Sleep(TickDelay);
        }
    }
}
