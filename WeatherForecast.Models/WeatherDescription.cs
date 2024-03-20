using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class WeatherDescription : BaseEntity
    {
        public double FromTemp { get; set; }
        public double ToTemp { get; set; }
        public string? TempDescriptiveTerm { get; set; }
    }
}
