using Refit;
using WebApp.Integration.Weather.Models;

namespace WebApp.Integration.Weather
{
    public interface IWeatherApi
    {
        [Get("/WeatherForecast")]
        Task<IEnumerable<WeatherForecast>> GetWeatherForecast();
    }
}
