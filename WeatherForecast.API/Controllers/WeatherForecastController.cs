using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;
using WeatherForecast.UtilitiesService.Service;

namespace WeatherForecast.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IForecastServices _ForecastServices;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IForecastServices ForecastServices)
        {
            _logger = logger;
            _ForecastServices = ForecastServices;
        }

        [HttpGet]
        public IActionResult GetAllWeatherForecast()
        {
            var (isSucess, mdlWeather, strMsg) = _ForecastServices.GetAllWeatherReport();
            if (isSucess)
            {
                return Ok(mdlWeather);
            }
            else return BadRequest(strMsg);

        }

        [HttpPost]
        public IActionResult AddWeatherForecast([FromBody] WeatherDailyForecast mdl)
        {
            var (isSucess, generatedId, strMsg) = _ForecastServices.insertWeatherForecast(mdl);

            if (isSucess)
                return Ok(generatedId);
            else return BadRequest(strMsg);
        }
    }
}