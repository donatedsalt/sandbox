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

var serviceProvider = services.BuildServiceProvider();

var factory = serviceProvider.GetRequiredService<IEntityFactory>();
var weatherSystem = serviceProvider.GetRequiredService<WeatherSystem>();

var critter = factory.CreateCritter("bunny");

weatherSystem.Subscribe(critter);

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"--- Turn {i + 1} ---");
    if (i == 4)
    {
        Console.WriteLine("Its raining!");
        weatherSystem.ChangeWeather("rain");
    }
    if (i == 8)
    {
        Console.WriteLine("It stopped raining!");
        weatherSystem.ChangeWeather("sunny");
    }

    critter.Update();
    Thread.Sleep(500);
}
