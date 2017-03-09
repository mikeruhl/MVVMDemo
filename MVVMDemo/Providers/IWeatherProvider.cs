using MVVMDemo.Models;

namespace MVVMDemo.Providers
{
    public interface IWeatherProvider
    {
        WeatherResult GetTemperatureByZip(string zip);
    }
}