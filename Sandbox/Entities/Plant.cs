using Sandbox.Core;

namespace Sandbox.Entities;

public class Plant : IWeatherObserver, IEntity
{
    public int X { get; set; }
    public int Y { get; set; }

    public string Name { get; set; }

    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public double Age { get; set; }
    public double BaseGrowthRate { get; set; }
    public double GrowthRate { get; set; }


    public Plant(int x, int y, string name, int maxHealth, double baseGrowthRate, double age = 0)
    {
        X = x;
        Y = y;
        Name = name;
        MaxHealth = maxHealth;
        Age = age;
        BaseGrowthRate = baseGrowthRate;
        GrowthRate = baseGrowthRate;

        Health = maxHealth;
    }

    public void Update()
    {
        if (Health == MaxHealth)
        {
            Age += GrowthRate;
            MaxHealth = (int)(MaxHealth * (1 + GrowthRate));
        }
        else
        {
            Health += (int)(GrowthRate * MaxHealth);
        }
    }

    public void OnWeatherChange(string weather)
    {
        if (weather == "rain")
        {
            GrowthRate += BaseGrowthRate / 4;
        }
        else
        {
            GrowthRate = BaseGrowthRate;
        }
    }
}
