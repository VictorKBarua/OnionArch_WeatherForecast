using WeatherForecast.Models;

namespace WeatherForecast.UtilitiesService.Service
{
    public interface IForecastServices
    {
        (bool, IEnumerable<WeatherDailyForecast>, string) GetAllWeatherReport();

        (bool, long, string) insertWeatherForecast(WeatherDailyForecast obj);
    }
}
