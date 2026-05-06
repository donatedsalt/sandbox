using Sandbox.Core;

namespace Sandbox.Systems;

public class WeatherSystem
{
    private readonly List<IWeatherObserver> _observers = [];

    public void Subscribe(IWeatherObserver observer) => _observers.Add(observer);

    public void Unsubscribe(IWeatherObserver observer) => _observers.Remove(observer);

    public void ChangeWeather(string weather)
    {
        foreach (var observer in _observers)
        {
            observer.OnWeatherChange(weather);
        }
    }
}
