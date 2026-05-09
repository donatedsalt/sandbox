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
        Cells = new Cell[height, width];
    }

    public void Initialize()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Cells[y, x] = new Cell { };
            }
        }

        for (int i = 0; i < MaxEntities; i++)
        {
            var entity = _entityFactory.CreateRandom(Random.Shared.Next(Width), Random.Shared.Next(Height));
            if (entity is IWeatherObserver observer)
                _weatherSystem.Subscribe(observer);
            Cells[entity.Y, entity.X].AddEntity(entity);
        }
    }

    public void Tick()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                foreach (var entity in Cells[y, x].Entities)
                {
                    entity.Update();
                }
            }
        }
    }

    public void Run(int turns, bool print = false)
    {
        for (int i = 0; i < turns; i++)
        {
            Tick();
            if (print) Print();
            Thread.Sleep(TickDelay);
        }
    }

    public void Print()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Console.Write(Cells[y, x].Entities.Count > 0 ? Cells[y, x].Entities[0].Symbol : ".");
            }
            Console.WriteLine();
        }
    }
}
