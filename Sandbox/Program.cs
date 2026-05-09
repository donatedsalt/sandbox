using Microsoft.Extensions.DependencyInjection;
using Sandbox.Core;
using Sandbox.Factories;
using Sandbox.Strategies;
using Sandbox.Systems;

var services = new ServiceCollection();

services.AddKeyedScoped<IMovementStrategy, WalkStrategy>("walk");
services.AddKeyedScoped<IMovementStrategy, FlyStrategy>("fly");

services.AddSingleton<WeatherSystem>();
services.AddTransient<IEntityFactory, EntityFactory>();


services.AddSingleton<World>(provider => new World(
    entityFactory: provider.GetRequiredService<IEntityFactory>(),
    weatherSystem: provider.GetRequiredService<WeatherSystem>(),
    width: 10,
    height: 10,
    maxEntities: 25,
    tickDelay: 500
));

var serviceProvider = services.BuildServiceProvider();

var world = serviceProvider.GetRequiredService<World>();

world.Initialize();
world.Run(turns: 10, print: true);
Console.WriteLine("World simulation completed.");
