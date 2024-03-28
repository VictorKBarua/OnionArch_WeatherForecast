using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Models
{
    public class WeatherDailyForecast : BaseEntity
    {
        [Required(ErrorMessage = "Date field is required.")]
        public DateTime Date { get; private set; }

        [Required(ErrorMessage = "Temperature field is required.")]
        public double Temperature { get; private set; }

        public string TemperatureDescription { get; private set; }


        public WeatherDailyForecast(DateTime date, double temperature)
        {
            Date = date;
            Temperature = temperature;
            TemperatureDescription = GetTemperatureDescription(temperature);
        }

        // Logic to convert temperature to a a human readable way (e.g., "Freezing", "Hot", etc)
        public string GetTemperatureDescription(double temperature)
        {
            switch (temperature)
            {
                case double n when n < -10:
                    return DomainConstant.constStrFreezing; ;
                case double n when n <= 0:
                    return DomainConstant.constStrBracing; ;
                case double n when n <= 10:
                    return DomainConstant.constStrChilly;
                case double n when n <= 20:
                    return DomainConstant.constStrCool; ;
                case double n when n <= 25:
                    return DomainConstant.constStrMild;
                case double n when n <= 30:
                    return DomainConstant.constStrWarm;
                case double n when n <= 35:
                    return DomainConstant.constStrBalmy;
                case double n when n <= 40:
                    return DomainConstant.constStrHot;
                case double n when n > 45:
                    return DomainConstant.constStrSweltering;
                default:
                    return DomainConstant.constStrScorching; ;
            }
        }
    }
}
