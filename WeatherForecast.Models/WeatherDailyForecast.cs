using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Models
{
    public class WeatherDailyForecast : BaseEntity
    {
        [Required(ErrorMessage = "Date field is required.")]
        public DateTime Date { get; private set; }

        [Required(ErrorMessage = "Temperature field is required.")]
        //[Range(-60, 60, ErrorMessage = "Temperature must be between -60 and +60 degrees.")]
        public double Temperature { get; private set; }

        public string TemperatureDescription { get; private set; }


        public WeatherDailyForecast(DateTime date, double temperature)
        {
            //if (date < DateTime.Now)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(date), DomainConstant.ErrMsgDateRange);
            //}

            //if (temperature < -60 || temperature > 60)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(temperature), DomainConstant.ErrMsgTemperatureRange);
            //}

            Date = date;
            Temperature = temperature;
            TemperatureDescription = GetTemperatureDescription(temperature);
        }

        // Logic to convert temperature to a a human readable way (e.g., "Freezing", "Hot", etc)
        public string GetTemperatureDescription(double temperature)
        {
            if (temperature <= -10)
            {
                return DomainConstant.constStrFreezing;
            }
            else if (temperature <= 0)
            {
                return DomainConstant.constStrBracing;
            }
            else if (temperature <= 10)
            {
                return DomainConstant.constStrChilly;
            }
            else if (temperature <= 20)
            {
                return DomainConstant.constStrCool;
            }
            else if (temperature <= 25)
            {
                return DomainConstant.constStrMild;
            }
            else if (temperature <= 30)
            {
                return DomainConstant.constStrWarm;
            }
            else if (temperature <= 35)
            {
                return DomainConstant.constStrBalmy;
            }
            else if (temperature <= 40)
            {
                return DomainConstant.constStrHot;
            }
            else if (temperature <= 45)
            {
                return DomainConstant.constStrSweltering;
            }
            else
            {
                return DomainConstant.constStrScorching;
            }
        }
    }
}
