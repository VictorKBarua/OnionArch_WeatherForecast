using WeatherForecast.Dal.Repositories;
using WeatherForecast.Models;

namespace WeatherForecast.UtilitiesService.Service
{
    public class ForecastServices : IForecastServices
    {
        private IForecastRepositories<WeatherDailyForecast> _ForecastRepositories;

        public ForecastServices(IForecastRepositories<WeatherDailyForecast> ForecastRepositories)
        {
            _ForecastRepositories = ForecastRepositories;
        }
        /// <summary>
        /// Service function to get all the weatherforecast data for a week.
        /// </summary>
        /// <returns>Object casted as WeatherDailyForecast</returns>
        public (bool, IEnumerable<WeatherDailyForecast>, string) GetAllWeatherReport()
        {
            try
            {
                return (true, _ForecastRepositories.GetAll().Where(x => x.Date.Date >= DateTime.Now.Date && x.Date.Date <= DateTime.Now.Date.AddDays(ServiceConstant.constTakeValue)), string.Empty);
            }
            catch (Exception ex)
            {
                return (false, Enumerable.Empty<WeatherDailyForecast>(), ex.Message);
            }
        }

        /// <summary>
        /// Service function to insert weather forecast data
        /// </summary>
        /// <param name="obj">Payload object</param>
        /// <returns>Sucess/Falure messages with inserted ID</returns>
        public (bool, long, string) insertWeatherForecast(WeatherDailyForecast obj)
        {
            if (obj == null) return (false, 0, ServiceConstant.ErrMsgNullEntity);
            try
            {
                if (obj.Date < DateTime.Now.Date)// validating date 
                {
                    return (false, 0, ServiceConstant.ErrMsgDateRange);
                }
                if (obj.Temperature < ServiceConstant.constTemperatureMin || obj.Temperature > ServiceConstant.constTemperatureMax)
                {
                    return (false, 0, ServiceConstant.ErrMsgTemperatureRange);
                }

                return (true, _ForecastRepositories.Insert(obj), string.Empty);
            }
            catch (Exception ex)
            {
                return (false, 0, ex.Message);

            }
        }
    }
}
